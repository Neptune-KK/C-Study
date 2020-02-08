namespace ScreenCapture
{
    partial class Frmpaste
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销毁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem75 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem100 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存toolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.销毁ToolStripMenuItem,
            this.不透明度ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 保存toolStripMenuItem
            // 
            this.保存toolStripMenuItem.Name = "保存toolStripMenuItem";
            this.保存toolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存toolStripMenuItem.Text = "保存";
            this.保存toolStripMenuItem.Click += new System.EventHandler(this.保存toolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 销毁ToolStripMenuItem
            // 
            this.销毁ToolStripMenuItem.Name = "销毁ToolStripMenuItem";
            this.销毁ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.销毁ToolStripMenuItem.Text = "销毁";
            this.销毁ToolStripMenuItem.Click += new System.EventHandler(this.销毁ToolStripMenuItem_Click);
            // 
            // 不透明度ToolStripMenuItem
            // 
            this.不透明度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem25,
            this.toolStripMenuItem50,
            this.toolStripMenuItem75,
            this.toolStripMenuItem100});
            this.不透明度ToolStripMenuItem.Name = "不透明度ToolStripMenuItem";
            this.不透明度ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.不透明度ToolStripMenuItem.Text = "不透明度";
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem25.Text = "25%";
            this.toolStripMenuItem25.Click += new System.EventHandler(this.toolStripMenuItem25_Click);
            // 
            // toolStripMenuItem50
            // 
            this.toolStripMenuItem50.Name = "toolStripMenuItem50";
            this.toolStripMenuItem50.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem50.Text = "50%";
            this.toolStripMenuItem50.Click += new System.EventHandler(this.toolStripMenuItem50_Click);
            // 
            // toolStripMenuItem75
            // 
            this.toolStripMenuItem75.Name = "toolStripMenuItem75";
            this.toolStripMenuItem75.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem75.Text = "75%";
            this.toolStripMenuItem75.Click += new System.EventHandler(this.toolStripMenuItem75_Click);
            // 
            // toolStripMenuItem100
            // 
            this.toolStripMenuItem100.Name = "toolStripMenuItem100";
            this.toolStripMenuItem100.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem100.Text = "100%";
            this.toolStripMenuItem100.Click += new System.EventHandler(this.toolStripMenuItem100_Click);
            // 
            // Frmpaste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frmpaste";
            this.Text = "Frmpaste";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frmpaste_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frmpaste_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Frmpaste_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 销毁ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 不透明度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem25;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem75;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem100;
    }
}