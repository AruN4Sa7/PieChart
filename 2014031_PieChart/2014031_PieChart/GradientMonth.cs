using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace _2014031_PieChart
{
    public class GradientMonth
    {
        //Created 2014066
        //Last Modified: 2014067

        //sets accent colors (gradient) to the popular birthstone colors based on the current month

        private byte m_month;
        private Color m_monthColor1;
        private Color m_monthColor2;

        public Color MonthColor1 { get { return m_monthColor1; } }
        public Color MonthColor2 { get { return m_monthColor2; } }

        public GradientMonth()
        {
            m_month = (byte)DateTime.Now.Month;
            SetMonthColors();
        }

        public GradientMonth(byte MonthNumber)
        {
            Exception InvalidMonthNumberException = new Exception("Invalid Month Number");

            if (MonthNumber >= 1 && MonthNumber <= 12) m_month = MonthNumber;
            else throw InvalidMonthNumberException;

            SetMonthColors();
        }

        private void SetMonthColors()
        {
            switch (m_month)
            {
                case 1:
                    m_monthColor1 = Color.Firebrick;
                    m_monthColor2 = Color.Maroon;
                    break;
                case 2:
                    m_monthColor1 = Color.Violet;
                    m_monthColor2 = Color.Purple;
                    break;
                case 3:
                    m_monthColor1 = Color.Aquamarine;
                    m_monthColor2 = Color.LightBlue;
                    break;
                case 4:
                    m_monthColor1 = Color.Azure;
                    m_monthColor2 = Color.Silver;
                    break;
                case 5:
                    m_monthColor1 = Color.SpringGreen;
                    m_monthColor2 = Color.SeaGreen;
                    break;
                case 6:
                    m_monthColor1 = Color.SeaShell;
                    m_monthColor2 = Color.LightPink;
                    break;
                case 7:
                    m_monthColor1 = Color.Red;
                    m_monthColor2 = Color.Crimson;
                    break;
                case 8:
                    m_monthColor1 = Color.YellowGreen;
                    m_monthColor2 = Color.LightGreen;
                    break;
                case 9:
                    m_monthColor1 = Color.DeepSkyBlue;
                    m_monthColor2 = Color.DodgerBlue;
                    break;
                case 10:
                    m_monthColor1 = Color.Pink;
                    m_monthColor2 = Color.HotPink;
                    break;
                case 11:
                    m_monthColor1 = Color.Yellow;
                    m_monthColor2 = Color.Orange;
                    break;
                case 12:
                    m_monthColor1 = Color.LightSkyBlue;
                    m_monthColor2 = Color.LightSteelBlue;
                    break;
            }
        }

        public void FillControlBackground(Control control, int GradientAngle)
        {
            Bitmap bmap = new Bitmap(control.Size.Width, control.Size.Height);
            Rectangle rect = new Rectangle(0, 0, bmap.Width, bmap.Height);
            Graphics g = Graphics.FromImage(bmap);
            LinearGradientBrush MonthBrush = new LinearGradientBrush(rect, m_monthColor1, m_monthColor2, GradientAngle);
            g.FillRectangle(MonthBrush, rect);
            control.BackgroundImage = bmap; //writing to control
        }
    }
}
