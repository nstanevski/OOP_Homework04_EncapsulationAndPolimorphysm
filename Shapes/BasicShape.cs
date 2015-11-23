using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class BasicShape:IShape
    {
        private double width;
        private double height;

        protected BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
       

        public double  Width 
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Can't assign non-positive width");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set{
                if (value <= 0)
                {
                    throw new InvalidOperationException("Can't assign non-positive height");
                }
                this.height = value;
            }
           
        }
    }
}
