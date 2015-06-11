using System;

namespace Shapes
{
    public class Rectangle:BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
            
        }

        public override double CalculatePerimeter()
        {
            return 2.0*(this.Height + this.Width);
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }


    }
}
