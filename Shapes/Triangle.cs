using System;

namespace Shapes
{
    public class Triangle:BasicShape
    {
        public Triangle(int width, int height)
            :base(width, height)
        {

        }
        public override double CalculatePerimeter()
        {
            //suppose it is a right triangle:
            double hypotenuse = Math.Sqrt(this.Width * this.Width + this.Height * this.Height);
            return this.Width + this.Height + hypotenuse;
        }

        public override double CalculateArea()
        {
            return this.Width*this.Height / 2.0;
        }
    }
}
