using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[] X = {70, 140, 210, 280, 350, 420 };
        int[] Y = { 70, 140, 210, 280, 350, 420 };
        string direction = "right";
        public Form1()
        {
            InitializeComponent();

        }

        private void mainForm_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            List<int> logs = new List<int> {};
            int score = 0;
            label1.Text = "Score: " + score;
            direction = "right";
            Timer timer = new Timer();
            int time = 1000;
            timer.Interval = time;
            int count = 0;
            int maxX = 490;
            int maxY = 490;
            int minX = 50;
            int minY = 50;
            int fX = -210;
            int fY = -280;
            Graphics g = this.CreateGraphics();
            Graphics fruit = this.CreateGraphics();
            Graphics p = this.CreateGraphics();
            g.Clear(Color.White);
            fruit.Clear(Color.White);
            p.Clear(Color.White);
            double x = 70;
            double y = 70;
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(490.0F, 50.0F);
            PointF point3 = new PointF(490.0F, 490.0F);
            PointF point4 = new PointF(50.0F, 490.0F);
            
            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 
             };
            Random r1 = new Random();
            Random r2 = new Random();
            g.DrawEllipse(Pens.Black, (int)x, (int)y, 50, 50);
            g.FillEllipse(Brushes.Green, (int)x, (int)y, 50, 50);
            p.DrawPolygon(Pens.Black, curvePoints);
            fruit.DrawEllipse(Pens.Black, fX, fY, 50, 50);
            fruit.FillEllipse(Brushes.Red, fX, fY, 50, 50);
            int fTimer = 6;
            timer.Tick += new EventHandler((o, ev) =>
            {
                

                if (score > 2) {
                    fTimer = 8;
                    time = 900;
                    timer.Interval = time;
                }
                if (score > 4)
                {
                    fTimer = 10;
                    time = 800;
                    timer.Interval = time;
                }
                if (score > 6)
                {
                    fTimer = 11;
                    time = 700;
                    timer.Interval = time;
                }
                if (score > 8)
                {
                    fTimer = 12;
                    time = 600;
                    timer.Interval = time;
                }

                switch (direction) {
                    case "up":
                        y -= 70;
                        break;
                    case "left":
                        x -= 70;
                        break;
                    case "right":
                        x += 70;
                        break;
                    case "down":
                        y += 70;
                        break;
                    default:
                        break;
                }
                logs.Add((int)x);
                logs.Add((int)y);
                g.Clear(Color.White);
                int j = 0;
                List<int> steps = new List<int> {};
                for (int i = 0; i < score + 1; i++) {
                    steps.Add(logs[logs.Count - j - 2]);
                    steps.Add(logs[logs.Count - j - 1]);
                    Console.WriteLine(i + " "+ logs[logs.Count - j - 2] +" "+ logs[logs.Count - j - 1]);
                    g.DrawEllipse(Pens.Black, logs[logs.Count-j-2], logs[logs.Count - j-1], 50, 50);
                    g.FillEllipse(Brushes.Green, logs[logs.Count - j - 2], logs[logs.Count - j-1], 50, 50);
                    j += 2;
                    p.DrawPolygon(Pens.Black, curvePoints);
                }

                if (count % fTimer == 0)
                {
                    fX = X[r1.Next(0, 5)];
                    fY = Y[r2.Next(0, 5)];
                    int k = 0;
                    for (int i = 0; i < steps.Count / 2; i++)
                    {
                        if (fX == steps[steps.Count - k - 2] && fY == steps[steps.Count - k - 1])
                        {
                            fX = X[r1.Next(0, 5)];
                            fY = Y[r2.Next(0, 5)];
                            return;
                        }
                        if (fX == steps[steps.Count - k - 2] && fY == steps[steps.Count - k - 1])
                        {
                            fX = X[r1.Next(0, 5)];
                            fY = Y[r2.Next(0, 5)];
                            return;
                        }
                        if (fX == steps[steps.Count - k - 2] && fY == steps[steps.Count - k - 1])
                        {
                            fX = X[r1.Next(0, 5)];
                            fY = Y[r2.Next(0, 5)];
                            return;
                        }
                        if (fX == steps[steps.Count - k - 2] && fY == steps[steps.Count - k - 1])
                        {
                            fX = X[r1.Next(0, 5)];
                            fY = Y[r2.Next(0, 5)];
                            return;
                        }
                        if (fX == steps[steps.Count - k - 2] && fY == steps[steps.Count - k - 1])
                        {
                            fX = X[r1.Next(0, 5)];
                            fY = Y[r2.Next(0, 5)];
                            return;
                        }
                        k++;
                    }
                    p.DrawPolygon(Pens.Black, curvePoints);
                }

                p.DrawPolygon(Pens.Black, curvePoints);
                fruit.DrawEllipse(Pens.Black, fX, fY, 50, 50);
                fruit.FillEllipse(Brushes.Red, fX, fY, 50, 50);
                count++;

                if (x == fX && y == fY ) {
                    fruit.Clear(Color.White);
                    j = 0;
                    for (int i = 0; i < score + 1; i++)
                    {
                        Console.WriteLine(i + " " + logs[logs.Count - j - 2] + " " + logs[logs.Count - j - 1]);
                        g.DrawEllipse(Pens.Black, logs[logs.Count - j - 2], logs[logs.Count - j - 1], 50, 50);
                        g.FillEllipse(Brushes.Green, logs[logs.Count - j - 2], logs[logs.Count - j - 1], 50, 50);
                        j += 2;
                    }
                    p.DrawPolygon(Pens.Black, curvePoints);
                    fX = -200;
                    fY = -200;
                    score++;
                    label1.Text = "Score: " + score;

                }
                if (steps.Count > 2) {
                    int v = 0;
                    for (int i = 0; i < steps.Count / 2-1; i++)
                    {
                        Console.WriteLine(i + "st: " + steps[steps.Count - v - 2] + " " + steps[steps.Count - v - 1]);
                        if (x == steps[steps.Count - v - 2] && y == steps[steps.Count - v - 1])
                        {
                            Timer t = o as Timer;

                            t.Stop();
                            MessageBox.Show("О неет, вы проиграли(((((", "Как жаль.", MessageBoxButtons.OK);
                            button5.Enabled = true;
                        }
                        v+=2;
                    }
                }
                

                if (x == maxX || y == maxY || x < minX || y < minY)
                {
                    Timer t = o as Timer;
                    
                    t.Stop();
                    MessageBox.Show("О неет, вы проиграли(((((", "Как жаль.", MessageBoxButtons.OK);
                    button5.Enabled = true;
                }

            });
            
            timer.Start();                                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            direction = "up";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            direction = "left";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            direction = "right";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            direction = "down";
        }


    }
}
