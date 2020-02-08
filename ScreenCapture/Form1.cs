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
    public partial class Form1 : Form
    {
        Bitmap resourceimg;
        Point startPoint = new Point(0, 0);
        Point endPoint = new Point(0, 0);
        bool isShooting = false;
        Size imgSize = new Size(0, 0);

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            /*参数说明:
            UserPaint 
            如果为 true，控件将自行绘制，而不是通过操作系统来绘制。此样式仅适用于派生自 Control 的类。

            AllPaintingInWmPaint 
            如果为 true，控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁。仅当 UserPaint 位设置为 true 时，才应当应用该样式。  

            DoubleBuffer 
            如果为 true，则绘制在缓冲区中进行，完成后将结果输出到屏幕上。双重缓冲区可防止由控件重绘引起的闪烁。要完全启用双重缓冲，还必须将 UserPaint 和 AllPaintingInWmPaint 样式位设置为 true。
             */
             
            HotKey.RegisterHotKey(this.Handle, 4123, HotkeyModifiers.Control, Keys.F10);//注册快捷键
            this.notifyIcon.Icon = icon.植物_粉色;
            lblsize.BackColor = Color.FromArgb(200, 100, 100, 100);
            lblinfo.BackColor = Color.FromArgb(200, 100, 100, 100);
            lblcolor.BackColor = Color.FromArgb(200, 100, 100, 100);
            pictureBox.BackColor=Color.FromArgb(50, 200, 200, 200);
            this.lblcolor.Text = "█ 按R复制RGB颜色值\r\n█ 按H复制HEX颜色值\r\n█ 按C复制图像\r\n█ 按T贴图";
            lblsize.Visible = false;
            pictureBox.Visible = false;
            notifyIcon.ShowBalloonTip(3000, "ScreenCapture", "ScreenCapture is running \r\nPress the ctrl+F10 to shoot screen.", ToolTipIcon.Info);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Hide();
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x0312:
                    switch (m.WParam.ToInt32())
                    {
                        case 4123:
                            StartShoot();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void SetInfo(Point point)
        {
            Color color = resourceimg.GetPixel(point.X, point.Y);
            lblcolor.ForeColor = color;
            lblinfo.Text = $"({point.X},{point.Y})\r\nrgb({color.R}, {color.G}, {color.B})\r\nHEX: #{color.R.ToString("X")}{color.G.ToString("X")}{color.B.ToString("X")}";
            Bitmap bitmap = new Bitmap(ptboxMax.Width / 2, ptboxMax.Height / 2);//放大镜
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(j, i, resourceimg.GetPixel(point.X + j - bitmap.Width / 2, point.Y + i - bitmap.Height / 2));
                }
            }
            ptboxMax.Image = bitmap;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    EndShoot();
                    break;
                case Keys.C:
                    if (imgSize.Width > 0 && imgSize.Height > 0)
                        CopyImg();
                    break;
                case Keys.T:
                    if (imgSize.Width > 0 && imgSize.Height > 0)
                    {
                        Frmpaste frmpaste = new Frmpaste(GetBitmap(), startPoint);
                        frmpaste.Show();
                        EndShoot();
                    }
                    break;
                case Keys.R:
                    Clipboard.SetText($"{lblcolor.ForeColor.R}, {lblcolor.ForeColor.G}, {lblcolor.ForeColor.B}");
                    break;
                case Keys.H:
                    Clipboard.SetText($"#{lblcolor.ForeColor.R.ToString("X")}{lblcolor.ForeColor.G.ToString("X")}{lblcolor.ForeColor.B.ToString("X")}");
                    break;
                default:
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = new Point(e.X, e.Y);
            isShooting = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ptboxMax.Left = e.X + 10;
            ptboxMax.Top = e.Y - 10 - ptboxMax.Height;
            lblinfo.Left= e.X + 10;
            lblinfo.Top= e.Y + 10;
            lblcolor.Left= e.X - 10 - lblcolor.Width;
            lblcolor.Top= e.Y + 10;
            SetInfo(e.Location);
            if (isShooting)
            {
                pictureBox.Visible = true;
                lblsize.Visible = true;
                endPoint = e.Location;
                imgSize.Width = Math.Abs(startPoint.X - e.X);
                imgSize.Height = Math.Abs(startPoint.Y - e.Y);
                pictureBox.Size = imgSize;
                pictureBox.Left = startPoint.X < e.X ? startPoint.X : e.X;
                pictureBox.Top = startPoint.Y < e.Y ? startPoint.Y : e.Y;
                lblsize.Location = pictureBox.Location;
                lblsize.Text = $"Size:{imgSize.Width}x{imgSize.Height}";
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Hide();
            }
            isShooting = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HotKey.UnregisterHotKey(this.Handle, 4123);
        }

        private void StartShoot()
        {
            this.BackgroundImage = GetScreen();
            this.Show();
        }

        private void EndShoot()
        {
            this.Hide();
            pictureBox.Visible = false;
            lblsize.Visible = false;
        }

        private Bitmap GetScreen()
        {
            Bitmap bitmap = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            graphics.Dispose();
            resourceimg = (Bitmap)bitmap.Clone();
            return bitmap;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Bitmap GetBitmap()
        {
            Bitmap img = new Bitmap(imgSize.Width, imgSize.Height);
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    img.SetPixel(j, i, resourceimg.GetPixel(j + startPoint.X, i + startPoint.Y));
                }
            }
            return img;
        }

        /// <summary>
        /// 保存img的一系列操作
        /// </summary>
        private void SaveImg()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();//组件
            //属性
            saveFileDialog.Title = "Save Picture!";
            saveFileDialog.Filter = "图片文件(*.jpg)|*.jpg";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = $"{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                EndShoot();
                GetBitmap().Save(saveFileDialog.FileName);
            }
        }

        private void CopyImg()
        {
            Clipboard.SetImage(GetBitmap());
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyImg();
            EndShoot();
        }

        private void 贴图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmpaste frmpaste = new Frmpaste(GetBitmap(), startPoint);
            frmpaste.Show();
            EndShoot();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImg();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EndShoot();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            SaveImg();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X + pictureBox.Left, e.Y + pictureBox.Top);
            ptboxMax.Left = point.X + 10;
            ptboxMax.Top = point.Y - 10 - ptboxMax.Height;
            lblinfo.Left = point.X + 10;
            lblinfo.Top = point.Y + 10;
            lblcolor.Left = point.X - 10 - lblcolor.Width;
            lblcolor.Top = point.Y + 10;
            SetInfo(point);
        }
    }
}
