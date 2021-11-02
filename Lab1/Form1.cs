using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        List<double> Xdots;
        List<double> Ydots;
        //Строим кривую
        private void button1_Click(object sender, EventArgs e) {
            chart1.Series[0].Points.Clear();
            string sa = textBox1.Text.Replace('.', ',');
            string sB = textBox2.Text.Replace('.', ',');
            double a = Convert.ToDouble(sa);
            double B = Convert.ToDouble(sB);
            double step = 0.01;
            Xdots = new List<double>();
            Ydots = new List<double>();
            for (double x = 0; x <= B; x += step) {
                double y = a * Math.Pow(x, 1.5);
                Xdots.Add(x);
                Ydots.Add(y);
            }
            for (int i = 0; i < Xdots.Count; i++) {
                chart1.Series[0].Points.AddXY(Xdots[i], Ydots[i]);
            }
        }
        //Обеспечиваем автоматическое масштабирование при изменении размеров окна
        private void Form1_ResizeEnd(object sender, EventArgs e) {
            chart1.Series[0].Points.Clear();
            chart1.Size = new Size(ClientSize.Width - 24, ClientSize.Height - 89);
            label1.Location = new Point(103, chart1.Size.Height + 27);
            textBox1.Location = new Point(131, chart1.Size.Height + 24);
            label2.Location = new Point(103 + chart1.Size.Width / 2, chart1.Size.Height + 27);
            textBox2.Location = new Point(131 + chart1.Size.Width / 2, chart1.Size.Height + 24);
            button1.Location = new Point(chart1.Size.Width / 2 - 152, chart1.Size.Height + 55);
            if (Xdots != null) {
                for (int i = 0; i < Xdots.Count; i++) {
                    chart1.Series[0].Points.AddXY(Xdots[i], Ydots[i]);
                }
            }
        }
    }
}
