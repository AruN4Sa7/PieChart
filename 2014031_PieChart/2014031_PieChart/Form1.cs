using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Shikka_sFirstClassLibrary;

namespace _2014031_PieChart
{
    public partial class Form1 : Form
    {
        float AnimationSweepAngle = 0;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.Yellow;
            //this.Visible = false;
            //lblJanuary.ForeColor = Color.DarkRed;
            //Random rand = new Random();
            //Bitmap bmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Graphics g = Graphics.FromImage(bmap);
            //SolidBrush mybrush = new SolidBrush(panelJanuary.BackColor);
            //int RandomParameter = rand.Next(250);
            //g.FillRectangle(mybrush, RandomParameter, RandomParameter, RandomParameter, RandomParameter);
            //pictureBox1.Image = bmap;
            //MessageBox.Show("message text", "message caption", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;


        }

        private void btnDrawPieChart_Click(object sender, EventArgs e)
        {
            DrawPieChart();
        }

        public void DrawPieChart()
        {
            if (GetTotalSales() > 0)
            {
                Bitmap bmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics graph = Graphics.FromImage(bmap);
                Color[] color = { 
                                panelJanuary.BackColor,
                                panelFebruary.BackColor,
                                panelMarch.BackColor,
                                panelApril.BackColor,
                                panelMay.BackColor,
                                panelJune.BackColor,
                                panelJuly.BackColor,
                                panelAugust.BackColor,
                                panelSeptember.BackColor,
                                panelOctober.BackColor,
                                panelNovember.BackColor,
                                panelDecember.BackColor 
                            };

                Rectangle rect = new Rectangle(19, 19, pictureBox1.Width - 20, pictureBox1.Height - 40);
                float StartAngle = 0;

                for (int i = 0; i < Sales().Length; i++)
                {
                    SolidBrush SliceBrush = new SolidBrush(color[i]);
                    //graph.FillPie(SliceBrush, rect, SweepAngle(i - 1), SweepAngle(i));
                    graph.FillPie(SliceBrush, rect, StartAngle, SweepAngle(i));
                    StartAngle += SweepAngle(i);

                    

                }
                pictureBox1.Image = bmap;

                
                lblTotalSales.ForeColor = Color.Black;
                lblTotalSales.BackColor = Color.White;
                panelTotalSales.BackColor = Color.White;
                txtTotalSales.BackColor = Color.White;
                txtTotalSales.Text = GetTotalSales().ToString("c");
            }

            else
            {
                //MessageBox.Show("There are no values! You cannot have a pie chart whos values sum to zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                //Code to draw empty circle if no values are specified
                Bitmap bmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Rectangle rect = new Rectangle(19, 19, pictureBox1.Width - 20, pictureBox1.Height - 40);
                Graphics graph = Graphics.FromImage(bmap);
                Pen pen = new Pen(Color.White,1);
                graph.DrawEllipse(pen, rect);
                pictureBox1.Image = bmap;
            }
        }

        public decimal[] Sales()
        {
            decimal[] sales = new decimal[12];
            
                //January 
                if (!decimal.TryParse(textBox01.Text, out sales[0]))
                { ShowParseError("January"); textBox01.Text = "0"; }
    
                //February 
                if (!decimal.TryParse(textBox02.Text, out sales[1]))
                { ShowParseError("February"); textBox02.Text = "0"; }
                
                //March
                if (!decimal.TryParse(textBox03.Text, out sales[2]))
                { ShowParseError("March"); textBox03.Text = "0"; }

                //April
                if (!decimal.TryParse(textBox04.Text, out sales[3]))
                { ShowParseError("April"); textBox04.Text = "0";}

                //May
                if (!decimal.TryParse(textBox05.Text, out sales[4]))
                { ShowParseError("May"); textBox05.Text = "0";}

                //June
                if (!decimal.TryParse(textBox06.Text, out sales[5]))
                {ShowParseError("June"); textBox06.Text = "0";}

                //July
                if (!decimal.TryParse(textBox07.Text, out sales[6]))
                { ShowParseError("July"); textBox07.Text = "0"; }

                //August
                if (!decimal.TryParse(textBox08.Text, out sales[7]))
                { ShowParseError("August"); textBox08.Text = "0"; }

                //September
                if (!decimal.TryParse(textBox09.Text, out sales[8]))
                { ShowParseError("September"); textBox09.Text = "0"; }

                //October
                if (!decimal.TryParse(textBox10.Text, out sales[9]))
                { ShowParseError("October"); textBox10.Text = "0"; }

                //November
                if (!decimal.TryParse(textBox11.Text, out sales[10]))
                { ShowParseError("November"); textBox11.Text = "0"; }

                //December
                if (!decimal.TryParse(textBox12.Text, out sales[11]))
                { ShowParseError("December"); textBox12.Text = "0"; }

            return sales;
        }

        private byte ShowParseError(string month) //to be used only in Sales() method
        {
            MessageBox.Show(String.Format("Invalid input for {0} sales!", month), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            byte error = 1;
            return error; 
        }

        public decimal GetTotalSales() 
        {
            decimal SalesTotal = 0;

            for (int i = 0; i < Sales().Length; i++)
            {
                SalesTotal += Sales()[i];
            }

            return SalesTotal;
        }

        private float SweepAngle(int MonthIndex) //uses data from method Sales() and method GetTotalSales(sales)
        {
            float sweepAngle;
            decimal calc;
            decimal[] sales = Sales();
            //try
            //{
                if (MonthIndex == -1)
                {
                    sweepAngle = 0;
                   
                }

                else
                {

                    //Formula: sweepAngle = 360*sale/totalSales 
                        calc = 360 * sales[MonthIndex] / GetTotalSales();
                        sweepAngle = (float)calc;
                        
                }
                return sweepAngle;

            //}

            //catch (DivideByZeroException)
            //{
                //MessageBox.Show("There are no values! You cannot have a pie chart whos values sum to zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return sweepAngle = -1;
                
            //}

            
            
        }

        private void btnDrawRandomPieChart_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            //decimal RandomSale  = rand.Next(1000000000);
            textBox01.Text = rand.Next(1000000000).ToString();
            textBox02.Text = rand.Next(1000000000).ToString();
            textBox03.Text = rand.Next(1000000000).ToString();
            textBox04.Text = rand.Next(1000000000).ToString();
            textBox05.Text = rand.Next(1000000000).ToString();
            textBox06.Text = rand.Next(1000000000).ToString();
            textBox07.Text = rand.Next(1000000000).ToString();
            textBox08.Text = rand.Next(1000000000).ToString();
            textBox09.Text = rand.Next(1000000000).ToString();
            textBox10.Text = rand.Next(1000000000).ToString();
            textBox11.Text = rand.Next(1000000000).ToString();
            textBox12.Text = rand.Next(1000000000).ToString();

            DrawPieChart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form1.ActiveForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel1.Visible = false;
            
            pictureBox1.BackColor = Color.Transparent;
            //this.Visible = false;

            timerPieAnimation.Start();
        }
        

        private void timerPieAnimation_Tick(object sender, EventArgs e)
        {
            if (AnimationSweepAngle < 361)
            {
                Bitmap bmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Rectangle rect = new Rectangle(19, 19, pictureBox1.Width - 20, pictureBox1.Height - 40);
                Graphics graph = Graphics.FromImage(bmap);
                graph.FillPie(Brushes.DimGray, rect, 0, AnimationSweepAngle);
                pictureBox1.Image = bmap;
                AnimationSweepAngle+=10;
            }

            else
            {
                Form1.ActiveForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                GradientMonth gM = new GradientMonth();
                gM.FillControlBackground(this, 50);
                panel1.Visible = true;
                pictureBox1.BackColor = Color.DimGray;
                timerPieAnimation.Stop();
            }
        }




    }
}
///Lab Assignment
///1. Read all the sales values from the textboxes and save them to an array or list. Do that in a method.
///2. Write a method "GetTotalSales" that takes an array or list of sales and returns the total sales
///2. Write a method that the amount of sales and returns its corresponding sweep angle
///     
///   In the button click use a for loop to sequence thru all the sales, compute its sweepAngle, thru the method and fill its corresponding pie then advance the start angle.
///   add color coded labels, color code the months


///Version 1 (initial release) completed on 2014034
///
///Plans for version 2:
///     * Fixed error messages
///     * Code optimization
///     * application icon
///     * "Splash" startup animations
///     * "Spin" rotational pie animation on pie render
///     * Animated gradient "pulse" effect for slice corresponding to entity(month) on mouse hover
///     * Main menu
///     * Sample pies ex: ratio of vitamins for recomended daily value, etc...
///     * New chart creation with nameable fields and selectable colors
///     * Save function
///     * Screen autosize
///     * Animated progressive pie charts
///     * Autoarrange slices according to specified criteria