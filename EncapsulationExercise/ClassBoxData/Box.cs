using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box( double length,double width,double height)
        {
            Length=length;
            Width=width;
            Height=height;
        }
        public double Length
        {
            get { return this.length;}
            private set
            {

                this.Validate(value, nameof(Length));
                this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                this.Validate(value, nameof(Width));
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                this.Validate(value,nameof(Height));
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double SArea = 2*(Width*Length)+2*(Width*Height)+2*(Height*Length);
            return SArea;
        }

        public double LateralSurfaceArea()
        {
            double LSArea = 2 * (Width * Height) + 2 * (Height * Length);
            return LSArea;
        }

        public double Volume()
        {
            double volume = Width * Length * Height;
            return volume;
        }
        private void Validate(double side, string type)
        {
            if (side <= 0)
            {
                throw new ArgumentException($"{type} cannot be zero or negative.");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}