using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_2Sm_
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        double angle1 = 0;
        double angle2 = 0;
        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 700;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            angle1 += 0.05;
            angle2 -= 0.05;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawA(g);
            DrawB(g);
            DrawV(g);
        }
        void DrawA(Graphics g)
        {
            //Шестикутник
            Point[] hexagon =
            {
                new Point(80,80),
                new Point(120,60),
                new Point(160,80),
                new Point(160,120),
                new Point(120,140),
                new Point(80,120),
            };
            g.FillPolygon(Brushes.Black, hexagon);
            //Коло
            g.DrawEllipse(Pens.Black, 250, 70, 80, 80);
            //Еліпс
            g.FillEllipse(Brushes.Black, 380, 60, 120, 80);
            //Прямокутник
            g.DrawRectangle(Pens.Black, 560, 70, 120, 80);
        }
        void DrawB(Graphics g)
        {
            int x = 100;
            int y = 220;
            g.FillRectangle(Brushes.Red, x, y, 220, 50);
            // Верх машини
            Point[] top =
            {
                new Point(x + 40, y),
                new Point(x + 80, y - 35),
                new Point(x + 160, y - 35),
                new Point(x + 190, y),
            };
            g.FillPolygon(Brushes.Red, top);
            //Контури
            g.DrawRectangle(Pens.Black, x, y, 220, 50);
            g.DrawPolygon(Pens.Black, top);
            // Вікна
            g.FillRectangle(Brushes.LightBlue, x + 90, y - 30, 55, 25);
            g.DrawRectangle(Pens.Black, x + 90, y - 30, 55, 25);
            // Колеса
            g.FillEllipse(Brushes.Black, x + 25, y + 30, 50, 50);
            g.FillEllipse(Brushes.Black, x + 145, y + 30, 50, 50);
            // Диски
            g.FillEllipse(Brushes.Gray, x + 38, y + 43, 24, 24);
            g.FillEllipse(Brushes.Gray, x + 158, y + 43, 24, 24);
            // Фари
            g.FillEllipse(Brushes.Yellow, x + 205, y + 15, 10, 10);

        }
        void DrawV(Graphics g)
        {
            int centerX = 700;
            int centerY = 300;
            int radius1 = 100;
            int radius2 = 60;
            g.DrawEllipse(Pens.Aqua, centerX - radius1, centerY - radius1, radius1 * 2, radius1 * 2);
            g.DrawEllipse(Pens.Aqua, centerX - radius2, centerY - radius2, radius2 * 2, radius2 * 2);
            int x1 = centerX + (int)(radius1 * Math.Cos(angle1));
            int y1 = centerY + (int)(radius1 * Math.Sin(angle1));
            int x2 = centerX + (int)(radius2 * Math.Cos(angle2));
            int y2 = centerY + (int)(radius2 * Math.Sin(angle2));
            // Еліпси
            g.FillEllipse(Brushes.Green, x1 - 20, y1 - 10, 40, 20);
            g.FillEllipse(Brushes.Blue, x2 - 15, y2 - 15, 50, 20);
        }
    }
}
