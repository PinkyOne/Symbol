using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labCG3Turn3
{
    using System.Drawing;

    class Brezenham
    {
        public static void BresenhamCircle(Graphics g, Color clr, int _x, int _y, int radius)
        {
            int x = 0, y = radius, gap = 0, delta = (2 - 2 * radius);
            while (y >= 0)
            {
                PutPixel(g, clr, _x + x, _y + y, 255);
                PutPixel(g, clr, _x + x, _y - y, 255);
                PutPixel(g, clr, _x - x, _y - y, 255);
                PutPixel(g, clr, _x - x, _y + y, 255);

                gap = 2 * (delta + y) - 1;

                if (delta < 0 && gap <= 0)
                {
                    x++;

                    delta += 2 * x + 1;

                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;

                    delta -= 2 * y + 1;

                    continue;
                }
                x++;
                delta += 2 * (x - y);
                y--;
            }
        }

        // Метод, устанавливающий пиксел на форме с заданными цветом и прозрачностью
        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }

        private static int IPart(float x)
        {
            return (int)x;
        }

        private static float FPart(float x)
        {
            while (x >= 0)
                x--;
            x++;
            return x;
        }
    }
}
