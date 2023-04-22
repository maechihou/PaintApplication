namespace paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_top = new System.Windows.Forms.Panel();
            this.eraser = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.Button();
            this.undo = new System.Windows.Forms.Button();
            this.size = new System.Windows.Forms.Button();
            this.brush = new System.Windows.Forms.Button();
            this.colour = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_top.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_top.Controls.Add(this.eraser);
            this.panel_top.Controls.Add(this.redo);
            this.panel_top.Controls.Add(this.undo);
            this.panel_top.Controls.Add(this.size);
            this.panel_top.Controls.Add(this.brush);
            this.panel_top.Controls.Add(this.colour);
            this.panel_top.Controls.Add(this.menuStrip1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(2);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1262, 105);
            this.panel_top.TabIndex = 0;
            // 
            // eraser
            // 
            this.eraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.eraser.Image = global::paint.Properties.Resources.eraser;
            this.eraser.Location = new System.Drawing.Point(450, 35);
            this.eraser.Margin = new System.Windows.Forms.Padding(2);
            this.eraser.Name = "eraser";
            this.eraser.Size = new System.Drawing.Size(65, 65);
            this.eraser.TabIndex = 10;
            this.eraser.UseVisualStyleBackColor = true;
            this.eraser.Click += new System.EventHandler(this.Eraser_Click);
            // 
            // redo
            // 
            this.redo.Image = global::paint.Properties.Resources.redo;
            this.redo.Location = new System.Drawing.Point(82, 35);
            this.redo.Margin = new System.Windows.Forms.Padding(2);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(40, 40);
            this.redo.TabIndex = 9;
            this.redo.UseVisualStyleBackColor = true;
            this.redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // undo
            // 
            this.undo.Image = global::paint.Properties.Resources.undo;
            this.undo.Location = new System.Drawing.Point(38, 36);
            this.undo.Margin = new System.Windows.Forms.Padding(2);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(40, 40);
            this.undo.TabIndex = 8;
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // size
            // 
            this.size.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.size.Image = global::paint.Properties.Resources.width;
            this.size.Location = new System.Drawing.Point(243, 36);
            this.size.Margin = new System.Windows.Forms.Padding(2);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(65, 65);
            this.size.TabIndex = 7;
            this.size.UseVisualStyleBackColor = true;
            this.size.Click += new System.EventHandler(this.Width_Click);
            // 
            // brush
            // 
            this.brush.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.brush.Image = global::paint.Properties.Resources.brush;
            this.brush.Location = new System.Drawing.Point(381, 35);
            this.brush.Margin = new System.Windows.Forms.Padding(2);
            this.brush.Name = "brush";
            this.brush.Size = new System.Drawing.Size(65, 65);
            this.brush.TabIndex = 3;
            this.brush.UseVisualStyleBackColor = true;
            this.brush.Click += new System.EventHandler(this.Brush_Click);
            // 
            // colour
            // 
            this.colour.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.colour.Image = global::paint.Properties.Resources.colour;
            this.colour.Location = new System.Drawing.Point(312, 35);
            this.colour.Margin = new System.Windows.Forms.Padding(2);
            this.colour.Name = "colour";
            this.colour.Size = new System.Drawing.Size(65, 65);
            this.colour.TabIndex = 1;
            this.colour.UseVisualStyleBackColor = true;
            this.colour.Click += new System.EventHandler(this.Colour_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1262, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // panel_bottom
            // 
            this.panel_bottom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 654);
            this.panel_bottom.Margin = new System.Windows.Forms.Padding(2);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1262, 20);
            this.panel_bottom.TabIndex = 3;
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 105);
            this.panel_left.Margin = new System.Windows.Forms.Padding(2);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(19, 549);
            this.panel_left.TabIndex = 5;
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(1243, 105);
            this.panel_right.Margin = new System.Windows.Forms.Padding(2);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(19, 549);
            this.panel_right.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 105);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1262, 549);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 674);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_top);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Paint";
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Button eraser;
        private System.Windows.Forms.Button redo;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button size;
        private System.Windows.Forms.Button brush;
        private System.Windows.Forms.Button colour;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

