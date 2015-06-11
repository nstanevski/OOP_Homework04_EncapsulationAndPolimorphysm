using System;

namespace Shapes
{
    public class Circle:IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                this.radius = Math.Abs(value);
            }
        }

        public double CalculatePerimeter()
        {
            return Math.PI * 2.0 * this.Radius;
        }

        public double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

     
    }
}
