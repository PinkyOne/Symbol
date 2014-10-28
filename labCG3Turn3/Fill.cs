using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labCG3Turn3
{
    using System.Drawing;

    public class Fill
    {
        private static int imgN = 0;

        public static void Filling(Graphics g, Bitmap image, int x, int y)
        {
            var rigthX = x + 1;
            var leftX = x - 1;
            {
                var bitmap = new Bitmap(@"E:\123.bmp");
                bitmap.SetPixel(x, y, Color.Black);
                if (leftX < 20) leftX = 20;
                var color = bitmap.GetPixel(leftX, y);
                while (leftX > 1 && color == bitmap.GetPixel(10, 10))
                {
                    bitmap.SetPixel(leftX, y, Color.Black);
                    leftX--;
                    if (leftX < 20) break;
                    color = bitmap.GetPixel(leftX, y);
                }
                while (rigthX < 700 && bitmap.GetPixel(rigthX, y) == bitmap.GetPixel(10, 10))
                {
                    bitmap.SetPixel(rigthX, y, Color.Black);
                    rigthX++;
                }
                bitmap.Save(@"E:\12355.bmp");
                bitmap.Dispose();
            }
            var i = leftX;
            var j = leftX;
            var drawUp = false;
            var drawDown = false;
            {
                var bittmp = new Bitmap(@"E:\12355.bmp");
                bittmp.Save(@"E:\123.bmp");
                g.DrawImage(bittmp, 0, 0, bittmp.Width, bittmp.Height);
                for (; i <= rigthX; i++)
                {
                    if (y > 10 && y < 400 && bittmp.GetPixel(i, y + 1) == bittmp.GetPixel(10, 10))
                    {
                        drawUp = true;
                        break;
                    }
                }
                for (; j <= rigthX; j++)
                {
                    if (y > 10 && y < 400 && bittmp.GetPixel(j, y - 1) == bittmp.GetPixel(10, 10))
                    {
                        drawDown = true;
                        break;
                    }
                }
                bittmp.Dispose();
            }
            if (drawUp) Filling(g, null, i, y + 1);
            if (drawDown) Filling(g, null, j, y - 1);
        }
    }
}