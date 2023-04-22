using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();                    
        }

        private int brushSize = 5; // Default brush size

        private void width_Click(object sender, EventArgs e)
        {
            // Create a new context menu for the brush sizes
            ContextMenu brushMenu = new ContextMenu();

            // Create a list of available brush sizes
            List<int> sizes = new List<int> { 1, 5, 10, 15, 20 };

            // Add menu items for each brush size
            foreach (int size in sizes)
            {
                MenuItem menuItem = new MenuItem(size.ToString());
                menuItem.Tag = size;
                menuItem.Click += new EventHandler(widthSize_Click);
                brushMenu.MenuItems.Add(menuItem);
            }

            // Show the brush size menu
            Button button = (Button)sender;
            brushMenu.Show(button, new Point(0, button.Height));
        }

        private void widthSize_Click(object sender, EventArgs e)
        {
            // Get the selected brush size from the menu item tag
            MenuItem menuItem = (MenuItem)sender;
            int size = (int)menuItem.Tag;

            // Update the button text with the selected brush size
            Button button = (Button)menuItem.GetContextMenu().SourceControl;
            button.Text = "width: " + size.ToString();

            // Update the brush size
            brushSize = size;
        }

        private Color previousColor = Color.Black;
        private void colour_Click(object sender, EventArgs e)
        {
            // If the eraser button is selected, do not allow the user to select a color
            if (eraser.BackColor == Color.LightBlue)
            {
                return;
            }

            // Create a new instance of the ColorDialog class
            ColorDialog colorDialog = new ColorDialog();

            // Show the color picker dialog
            DialogResult result = colorDialog.ShowDialog();

            // Check if the user selected a color
            if (result == DialogResult.OK)
            {
                // Set the penColor to the selected color
                penColor = colorDialog.Color;

                // Set the BackColor property of the button to the selected color
                Button button = (Button)sender;
                button.BackColor = penColor;

                // Store the selected color as the previous color
                previousColor = penColor;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private bool isDrawing = false;
        private Point lastPoint;
        private Color penColor = Color.Black;

        private void brush_Click(object sender, EventArgs e)
        {
            // Set the isDrawing flag to true
            isDrawing = true;

            // Set the cursor to crosshair
            pictureBox1.Cursor = Cursors.Cross;

            // If a previous color has been selected, use it as the pen color
            if (previousColor != null)
            {
                penColor = previousColor;
            }
            else
            {
                // Otherwise, set the pen color to black
                penColor = Color.Black;
            }

            // Change the BackColor of the selected button to indicate that it is selected
            brush.BackColor = Color.LightBlue;
            eraser.BackColor = SystemColors.Control;
        }

        private void eraser_Click(object sender, EventArgs e)
        {
            // Set the isDrawing flag to true
            isDrawing = true;

            // Set the cursor to crosshair
            pictureBox1.Cursor = Cursors.Cross;

            // Set the pen color to white (eraser)
            penColor = Color.White;

            // Change the BackColor of the selected button to indicate that it is selected
            eraser.BackColor = Color.LightBlue;
            brush.BackColor = SystemColors.Control;
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                lastPoint = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                Pen pen = new Pen(penColor, brushSize)
                {
                    LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
                    StartCap = System.Drawing.Drawing2D.LineCap.Round,
                    EndCap = System.Drawing.Drawing2D.LineCap.Round
                };
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(pen, lastPoint, e.Location);
                lastPoint = e.Location;
                pen.Dispose();
                g.Dispose();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void select_Click(object sender, EventArgs e)
        {
            // Enable the selection tool.
            // canvas.EnableSelectionTool();
        }

        private Stack<Bitmap> undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();

        private void undo_Click(object sender, EventArgs e)
        {
            // Call the undo function to reverse the previous action.
            //undo();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            // Call the redo function to re-apply the previously undone action.
            // redo();
        }
    }
}
