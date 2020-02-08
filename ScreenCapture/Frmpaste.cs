using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class Frmpaste : Form
    {
        /// <summary>
        /// 在构造方法中添加坐标和图片参数。（窗体之间的传递）
        /// </summary>
        public Frmpaste(Bitmap bitmap,Point point)
        {
            InitializeComponent();
            this.BackgroundImage = (Bitmap)bitmap.Clone();
            this.Size = bitmap.Size;
            this.Location = point;
        }

        private void 保存toolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Picture!";
            saveFileDialog.Filter = "图片文件(*.jpg)|*.jpg";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = $"{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage.Save(saveFileDialog.FileName);
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(this.BackgroundImage);
        }

        private void 销毁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.25;
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void toolStripMenuItem75_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.75;
        }

        private void toolStripMenuItem100_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private Point mouseOff;
        private bool leftFlag;

        private void Frmpaste_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void Frmpaste_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                this.Location = mouseSet;
            }
        }

        private void Frmpaste_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }

        }
    }
}
