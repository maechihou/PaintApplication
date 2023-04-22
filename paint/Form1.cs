using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace paint
{
    public partial class Form1 : Form
    {
        private Bitmap canvas; // The drawing canvas
        private int brushSize = 5; // Default brush size
        private bool isDrawing = false;
        private Point lastPoint;
        private Color penColor = Color.Black; // The current pen color
        private Color previousColor = Color.Black;
        private readonly Stack<Bitmap> undoStack = new Stack<Bitmap>(); // Stack to store previous states of the canvas
        private readonly Stack<Bitmap> redoStack = new Stack<Bitmap>(); // Stack to store undone states of the canvas

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // No resizing
            this.MaximizeBox = false; // No maximizing
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height); // Create a new Bitmap to serve as the drawing canvas
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.Paint += PictureBox1_Paint;
            this.KeyPreview = true; // Set KeyPreview property to true
            this.KeyDown += Form1_KeyDown; // Add event handler for key down event on the form
            undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z))); // Undo shortcut
            redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y))); // Redo shortcut
        }

        private void Width_Click(object sender, EventArgs e)
        {
            // Create a context menu for the brush width options
            ContextMenu brushMenu = new ContextMenu();

            // Define a list of brush width sizes
            List<int> sizes = new List<int> { 1, 5, 10, 15, 20 };

            // Loop through the list of sizes and create a menu item for each size
            foreach (int size in sizes)
            {
                MenuItem menuItem = new MenuItem(size.ToString());
                menuItem.Tag = size;
                menuItem.Click += new EventHandler(WidthSize_Click);
                brushMenu.MenuItems.Add(menuItem);
            }

            // Get the button that triggered the event
            Button button = (Button)sender;

            // Show the context menu below the button
            brushMenu.Show(button, new Point(0, button.Height));
        }

        private void WidthSize_Click(object sender, EventArgs e)
        {
            // Get the menu item that triggered the event
            MenuItem menuItem = (MenuItem)sender;

            // Retrieve the brush size from the tag property of the menu item
            int size = (int)menuItem.Tag;

            // Get the button that opened the context menu
            Button button = (Button)menuItem.GetContextMenu().SourceControl;
            brushSize = size;
        }

        private void Colour_Click(object sender, EventArgs e)
        {
            // Check if the eraser is currently selected, if so, return without doing anything
            if (eraser.BackColor == Color.LightBlue)
            {
                return;
            }

            // Create a color dialog to let the user choose a color
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            // If the user clicked OK in the color dialog
            if (result == DialogResult.OK)
            {
                // Update the pen color with the selected color
                penColor = colorDialog.Color;
                Button button = (Button)sender;

                // Set the background color of the button to the selected color
                button.BackColor = penColor;

                // Store the selected color as the previous color if user decides to go back to brush
                previousColor = penColor;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Brush_Click(object sender, EventArgs e)
        {
            isDrawing = true;

            // Set the cursor of the pictureBox1 to a cross cursor
            pictureBox1.Cursor = Cursors.Cross;

            // If a previous color is available, set the pen color to the previous color, otherwise set it to black
            if (previousColor != null)
            {
                penColor = previousColor;
            }
            else
            {
                penColor = Color.Black;
            }

            // Set the background color of the brush button to light blue, indicating it's selected
            brush.BackColor = Color.LightBlue;

            // Set the background color of the eraser button to the default control color to show that it is not selected
            eraser.BackColor = SystemColors.Control;
        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            isDrawing = true;
            pictureBox1.Cursor = Cursors.Cross;

            // Set the pen color to white, indicating it's an eraser
            penColor = Color.White;
            eraser.BackColor = Color.LightBlue;
            brush.BackColor = SystemColors.Control;
        }



        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Store the current mouse location as the last point
                lastPoint = e.Location;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // If drawing is enabled and the left mouse button is pressed
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                // Create a graphics object from the canvas image
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    // Create a pen with the current pen color and brush size, and set line join, start cap, and end cap properties
                    using (Pen pen = new Pen(penColor, brushSize)
                    {
                        LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
                        StartCap = System.Drawing.Drawing2D.LineCap.Round,
                        EndCap = System.Drawing.Drawing2D.LineCap.Round
                    })
                    {
                        // Draw a line from the last point to the current mouse location
                        g.DrawLine(pen, lastPoint, e.Location);

                        // Update the last point to the current mouse location
                        lastPoint = e.Location;
                    }
                }
                // Invalidate the pictureBox1 control to trigger a repaint
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    using (Pen pen = new Pen(penColor, brushSize)
                    {
                        LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
                        StartCap = System.Drawing.Drawing2D.LineCap.Round,
                        EndCap = System.Drawing.Drawing2D.LineCap.Round
                    })
                    {
                        g.DrawLine(pen, lastPoint, e.Location);
                        lastPoint = e.Location;
                    }
                }
                pictureBox1.Invalidate();
                // Push the current canvas image to the undo stack for future undo operations
                undoStack.Push(new Bitmap(canvas));

                // Clear the redo stack as a new action has been performed
                redoStack.Clear();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the canvas image onto the pictureBox1 control using the Graphics object from the PaintEventArgs
            e.Graphics.DrawImage(canvas, 0, 0);
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            // If there are actions in the undo stack
            if (undoStack.Count > 0)
            {
                // Push the current canvas image to the redo stack for future redo operations
                redoStack.Push(new Bitmap(canvas));

                // Set the canvas image to the image popped from the undo stack
                canvas = new Bitmap(undoStack.Pop());

                // Invalidate the pictureBox1 control to trigger a repaint
                pictureBox1.Invalidate();
            }
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(new Bitmap(canvas));
                canvas = new Bitmap(redoStack.Pop());
                pictureBox1.Invalidate();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of SvgExporter class, passing in the pictureBox1 control and canvas bitmap
            SvgExporter svgExporter = new SvgExporter(pictureBox1, canvas);

            // Call the SaveAsSvg method
            svgExporter.SaveAsSvg();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call the undo_Click event handler when the undoToolStripMenuItem is clicked
            Undo_Click(sender, e); 
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo_Click(sender, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                // Call the undo_Click event handler when the Control key and Z key are pressed simultaneously
                Undo_Click(sender, e);
                // Set the Handled property of the KeyEventArgs object to true to indicate that the event has been handled
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                Redo_Click(sender, e);
                e.Handled = true;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Creating a new drawing will discard any unsaved changes. Do you want to continue?", "Confirm New Drawing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Create a new blank bitmap
                canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    // Set the background color of the new bitmap to white
                    g.Clear(Color.White); 
                }

                // Clear the undo and redo stacks
                undoStack.Clear();
                redoStack.Clear();

                // Refresh the PictureBox to display the new blank bitmap
                pictureBox1.Image = canvas;
                pictureBox1.Invalidate();
            }
        }
    }
}
