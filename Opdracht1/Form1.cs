using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdracht1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent(); ;
        }

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
            //else, cursor is overlapping with the box, so distance = 0

            if(cursorLocation.Y < box.Top) {
                //cursor is above the box
                verticalDistance = box.Top - cursorLocation.Y;
            }
            else if(cursorLocation.Y > box.Bottom) {
                //cursos is underneath the box
                verticalDistance = cursorLocation.Y - box.Bottom;
            }

            return Pythagoras(horizontalDistance, verticalDistance);
        }

        public static double Pythagoras(double a, double b) {
            return Math.Sqrt(a * a + b * b);
        }
    }
}
