using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LabCG3Turn3
{
    using System.Threading;

    using labCG3Turn3;

    public partial class Form1 : Form
    {
        private readonly BezierCurve bezier;
        private readonly Marker[] markers = new Marker[4];

        public Form1()
        {
            InitializeComponent();
            markers[0] = new Marker(150, 200);
            markers[1] = new Marker(300, 350);
            markers[2] = new Marker(300, 50);
            markers[3] = new Marker(450, 200);
            for (int index = 0; index < markers.Length; index++)
            {
                Marker marker = markers[index];
                int i = index;
                marker.OnDrag += f =>
                {
                    bezier[i] = f;
                    pictureBox1.Invalidate();
                };
                marker.OnMouseDown += f => { Cursor = Cursors.Hand; };
            }
            bezier = new BezierCurve(markers.Select(m => m.Location).ToArray());
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Pen pen = new Pen(Color.Gray, 1f);
            e.Graphics.DrawLines(pen, markers.Select(m => m.Location).ToArray());
            foreach (Marker marker in markers)
            {
                marker.Draw(e.Graphics);
            }
            bezier.Draw(e.Graphics);

            Brezenham.BresenhamCircle(e.Graphics, Color.Black, 300, 200, 150);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Marker marker in markers)
                {
                    marker.MouseMove(e);
                    Thread.Sleep(0);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Marker marker in markers)
            {
                marker.MouseDown(e);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Marker marker in markers)
            {
                marker.MouseUp();
            }
            Cursor = Cursors.Arrow;
        }
    }
}
