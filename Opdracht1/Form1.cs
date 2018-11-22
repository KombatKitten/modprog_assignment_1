﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdracht1 {
    public partial class MainScreen : Form {
        public MainScreen() {
            InitializeComponent();
        }

        Random mainRandom = new Random();

        public static double DistanceCursorToBox(Point cursorLocation, Rectangle box) {
            int horizontalDistance = 0;
            int verticalDistance = 0;

            if(cursorLocation.X < box.Left) {
                //cursor is left from the box
                horizontalDistance = box.Left - cursorLocation.X;
            }
            else if(cursorLocation.X > box.Right) {
                //cursor is right from the box
                horizontalDistance = cursorLocation.X - box.Right;
            }
            //else, the cursor is horizontally overlapping with the box, so the distance is 0

            if(cursorLocation.Y < box.Top) {
                //cursor is above the box
                verticalDistance = box.Top - cursorLocation.Y;
            }
            else if(cursorLocation.Y > box.Bottom) {
                //cursor is underneath the box
                verticalDistance = cursorLocation.Y - box.Bottom;
            }

            if(horizontalDistance == 0) 
                return verticalDistance;
            else if(verticalDistance == 0)
                return horizontalDistance;
            else
                return Pythagoras(horizontalDistance, verticalDistance);
        }

        public static double Pythagoras(double a, double b) {
            return Math.Sqrt(a * a + b * b);
        }

        //randomly generates a rectangle that is withing the bounds of the screen
        public Rectangle RandomRectangleWithinScreen(Random r) {
            const int MAX_RECTANGLE_WIDTH = 300;
            const int MAX_RECTANGLE_HEIGHT = 300;
            const int MIN_RECTANGLE_WIDTH = 100;
            const int MIN_RECTANGLE_HEIGHT = 100;

            int width = r.Next(MIN_RECTANGLE_WIDTH, MAX_RECTANGLE_WIDTH);
            int height = r.Next(MIN_RECTANGLE_HEIGHT, MAX_RECTANGLE_HEIGHT);

            int x = r.Next(0, this.ClientSize.Width - width);
            int y = r.Next(0, this.ClientSize.Height - height);

            return new Rectangle(x, y, width, height);
        }
    }
}
