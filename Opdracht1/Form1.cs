using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Opdracht1 {
    public partial class MainScreen : Form {
        public MainScreen() {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Maximized;

            this.Load += FormLoad;
        }

        Button centerButton = new Button();
        Random mainRandom = new Random();
        Button targetButton = new Button();
        Stopwatch responseTimer = new Stopwatch();
        Point cursorStartLocation;

        int experimentCount = 0;
        const int maxExperiments = 20;

        private void FormLoad(object sender, EventArgs e)
        {
            int x = this.ClientSize.Width / 2 - this.centerButton.Size.Width / 2;
            int y = this.ClientSize.Height / 2 - this.centerButton.Size.Height / 2;
            this.centerButton.Location = new Point(x, y);
            this.Controls.Add(centerButton);
            this.centerButton.Text = "Start";

            this.centerButton.Click += this.OnCenterButtonClick;
            this.Controls.Add(this.targetButton);
            this.targetButton.Visible = false;
            this.targetButton.Click += OnTargetButtonClick; ;
        }

        private void OnTargetButtonClick(object sender, EventArgs e)
        {
            this.targetButton.Visible = false;
            this.centerButton.Visible = true;
            double distance = DistanceCursorToBox(this.cursorStartLocation, this.targetButton.Bounds);
            Console.Write(distance + "\t");
            Console.Write(this.targetButton.Size.Width + "\t");
            Console.Write(IndexOfDifficulty(distance, this.targetButton.Size.Width) + "\t");
            Console.Write(this.responseTimer.ElapsedMilliseconds);

            Console.WriteLine("");

            if(++this.experimentCount >= maxExperiments) {
                this.Close();
            }
        }

        private void OnCenterButtonClick(object sender, EventArgs e)
        {
            this.cursorStartLocation = this.PointToClient(Cursor.Position);

            this.centerButton.Visible = false;

            var newRectangle = RandomRectangleWithinScreen();
            this.targetButton.Location = newRectangle.Location;
            this.targetButton.Size = newRectangle.Size;
            this.targetButton.BackColor = Color.FromArgb(180, 0, 10);
            this.targetButton.Visible = true;
            this.responseTimer.Restart();
        }

        public static double IndexOfDifficulty(double distance, double width)
        {
            return Math.Log(distance / width + 1, 2);
        }

        public static double DistanceCursorToBox(Point cursorLocation, Rectangle box) {
            int dX = cursorLocation.X - box.X - box.Width / 2;
            int dY = cursorLocation.Y - box.Y - box.Height / 2;

            return Pythagoras(dX, dY);
        }

        public static double Pythagoras(double a, double b) {
            return Math.Sqrt(a * a + b * b);
        }

        //randomly generates a rectangle that is withing the bounds of the screen
        public Rectangle RandomRectangleWithinScreen() {
            const int MAX_RECTANGLE_WIDTH = 300;
            const int MAX_RECTANGLE_HEIGHT = 300;
            const int MIN_RECTANGLE_WIDTH = 100;
            const int MIN_RECTANGLE_HEIGHT = 100;

            Random r = this.mainRandom;

            int width = r.Next(MIN_RECTANGLE_WIDTH, MAX_RECTANGLE_WIDTH);
            int height = r.Next(MIN_RECTANGLE_HEIGHT, MAX_RECTANGLE_HEIGHT);

            int x = r.Next(0, this.ClientSize.Width - width);
            int y = r.Next(0, this.ClientSize.Height - height);

            return new Rectangle(x, y, width, height);
        }
    }
}
