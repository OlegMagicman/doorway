using System;
using DoorwayPLLUG.Doorways;
using DoorwayPLLUG.Objects;
using DoorwayPLLUG.Interfaces;

namespace DoorwayPLLUG
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var obj = CreateObject();

            var doorway = CreateDoorway();

            Console.WriteLine(doorway.CanPass(obj) ? 
                "\nPassed!" : 
                "\nFail! Object must be smaller than doorway.");
            Console.ReadLine();
        }

        /// <summary>
        /// Create an IPassable object with set dimensions
        /// </summary>
        /// <returns>IPassable object</returns>
        private static IPassable CreateDoorway()
        {
            Console.WriteLine("\nChoose type of doorway: 1 - Rectangular, 2 - Circle, 3 - Triangle");
            var doorwayType = Input();
            switch (doorwayType)
            {
                case 1:
                {
                    Console.WriteLine("Enter width and height of doorway in cm. " +
                        "\nNumbers must be greater than zero");
                    Console.Write("Width = ");
                    var width = Input();
                    Console.Write("Height = ");
                    var height = Input();
                    return new RectangularDoorway(width, height);
                }
                case 2:
                {
                    Console.WriteLine("Enter diameter of doorway in cm. " +
                        "\nNumbers must be a greater than zero");
                    Console.Write("Diameter = ");
                    var diameter = Input();
                    return new CircularDoorway(diameter);
                }
                case 3:
                {
                    Console.WriteLine("Enter 3 sides of triangle (last one will be base)" +
                        "in cm. \nNumbers must be greater than zero");
                    Console.Write("Left side = ");
                    var leftSide = Input();
                    Console.Write("Right side = ");
                    var rightSide = Input();
                    Console.Write("Base side = ");
                    var baseSide = Input();
                    if ((leftSide < rightSide + baseSide) &&
                        (rightSide < leftSide + baseSide) &&
                        (baseSide < rightSide + leftSide))
                    {
                        return new TriangularDoorway(leftSide, rightSide, baseSide);
                    }
                    return new TriangularDoorway(1,1,1);
                }
                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Create an IMeasurable object with set dimensions
        /// </summary>
        /// <returns>IMeasurable object</returns>
        private static IMeasurable CreateObject()
        {
            Console.WriteLine("Choose type of object: 1 - Parallelepiped, 2 - Cylinder, 3 - Sphere");
            var objectType = Input();
            switch (objectType)
            {
                case 1:
                {
                    Console.WriteLine("\nEnter width, height and depth of parallelepiped in " +
                        "cm. \nNumbers must be a positive integers and greater than zero.");
                    Console.Write("Width = ");
                    var width = Input();
                    Console.Write("Height = ");
                    var height = Input();
                    Console.Write("Depth = ");
                    var depth = Input();
                    return new Wardrobe(width, height, depth);
                }
                case 2:
                {
                    Console.WriteLine("Enter height of the cylinder and diameter of its base " +
                        "in cm. \nNumbers must be greater than zero");
                    Console.Write("Height = ");
                    var height = Input();
                    Console.Write("Diameter = ");
                    var diameter = Input();
                    return new Cylinder(height, diameter);
                }
                case 3:
                {
                    Console.WriteLine("Enter diameter of sphere in cm. " +
                        "\nNumbers must be a greater than zero");
                    Console.Write("Diameter = ");
                    var diameter = Input();
                    return new Sphere(diameter);
                }
                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Cleaning up an input with correct checks
        /// </summary>
        /// <returns>Correct input</returns>
        private static double Input()
        {
            try
            {
                if (!double.TryParse(Console.ReadLine(), out var number))
                {
                    Console.WriteLine("Number must be an integer. Set to 1");
                    number = 1;
                }
                if (number <= 0)
                {
                    Console.WriteLine("Number must have positive sign. Set to 1");
                    number = 1;
                }
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Number must be an positive number. Set to 1");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Set to 1");
                return 1;
            }
        }
    }
}
