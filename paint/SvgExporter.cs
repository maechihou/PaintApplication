using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

public class SvgExporter
{
    private PictureBox pictureBox1;
    private Bitmap canvas;

    public SvgExporter(PictureBox pictureBox, Bitmap canvas)
    {
        this.pictureBox1 = pictureBox;
        this.canvas = canvas;
    }

    public void SaveAsSvg()
    {
        // Create a SaveFileDialog to prompt the user for a file location to save the canvas as SVG
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "SVG Files|*.svg";
        saveFileDialog.Title = "Save As SVG";

        // Show the SaveFileDialog and store the DialogResult
        DialogResult result = saveFileDialog.ShowDialog();

        // If the user clicked OK in the SaveFileDialog
        if (result == DialogResult.OK)
        {
            // Get the file path from the SaveFileDialog
            string filePath = saveFileDialog.FileName;

            // Create a StreamWriter to write the SVG content to the file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Create an XmlWriter to write the SVG content as XML
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    // Write the SVG document start element
                    writer.WriteStartDocument();

                    // Write the SVG root element with the appropriate namespace
                    writer.WriteStartElement("svg", "http://www.w3.org/2000/svg");

                    // Write the width and height attributes of the SVG element based on the size of the pictureBox1 control
                    writer.WriteAttributeString("width", pictureBox1.Width.ToString());
                    writer.WriteAttributeString("height", pictureBox1.Height.ToString());

                    // Loop through each pixel in the canvas image
                    for (int x = 0; x < pictureBox1.Width; x++)
                    {
                        for (int y = 0; y < pictureBox1.Height; y++)
                        {
                            // Get the color of the pixel
                            Color pixelColor = canvas.GetPixel(x, y);

                            // If the pixel is not transparent
                            if (pixelColor.A != 0)
                            {
                                // Write a rect element for the pixel with appropriate attributes and fill color
                                writer.WriteStartElement("rect", "http://www.w3.org/2000/svg");
                                writer.WriteAttributeString("x", x.ToString());
                                writer.WriteAttributeString("y", y.ToString());
                                writer.WriteAttributeString("width", "1");
                                writer.WriteAttributeString("height", "1");
                                writer.WriteAttributeString("fill", "#" + pixelColor.R.ToString("X2") + pixelColor.G.ToString("X2") + pixelColor.B.ToString("X2"));
                                writer.WriteEndElement();
                            }
                        }
                    }

                    // Write the SVG document end element
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    // Flush the XmlWriter to write any remaining content to the StreamWriter
                    writer.Flush();
                }
            }

            // Show a success message box indicating that the canvas was saved as SVG successfully
            MessageBox.Show("Canvas saved as SVG successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
