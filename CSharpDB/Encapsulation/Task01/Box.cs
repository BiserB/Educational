using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Box
    {   //length, width and height.
        private double length;
        private double width;
        private double height;

        private double Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        private double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        private double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double CalcSurface()
        {
            double result = (2 * this.Length * this.Width)
                        + (2 * this.Width * this.Height)
                        + (2 * this.Length * this.Height);
            return result;
        }
        public double CalcLateralSurface()
        {
            double result = (2 * this.Width * this.Height)
                          + (2 * this.Length * this.Height);
            return result;
        }
        public double CalcVolume()
        {
            double result = this.Width * this.Height * this.Length;
            return result;
        }
    }

