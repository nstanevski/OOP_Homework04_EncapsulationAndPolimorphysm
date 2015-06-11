using System;
using System.Collections.Generic;

using Shapes;

/*
 * Define an interface IShape with two abstract methods: CalculateArea() and CalculatePerimeter().
 * Define an abstract class BasicShape implementing IShape and holding width and height. 
 * Leave the methods CalculateArea() and CalculatePerimeter() abstract.
 * Define two new BasicShape subclasses: Triangle and Rectangle that implement the abstract 
 * methods CalculateArea() and CalculatePerimeter().
 * Define a class Circle implementing IShape with a suitable constructor.
 * Create an array of different shapes (Circle, Rectangle, Triangle) and test the behavior 
 * of the CalculateSurface() and CalculatePerimeter() methods.
 */

class ShapesMain
{
    static void Main()
    {
        List<IShape> shapes = new List<IShape>();
        shapes.Add(new Circle(2.0));
        shapes.Add(new Rectangle(2.6, 4.5));
        shapes.Add(new Triangle(3, 4));
        shapes.Add(new Triangle(6, 8));
        shapes.Add(new Circle(6));

        foreach (IShape shp in shapes)
        {
            Console.WriteLine("Shape type: {0}, area: {1:f2}, perimeter: {2:f2}",
                shp.GetType().Name, shp.CalculateArea(), shp.CalculatePerimeter());
        }
    }
}
