using System;

namespace DoorwayPLLUG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter width and height of doorway in cm. " +
                "\nNumbers must be a positive integers and greater than zero");
            Console.Write("Width = ");
            var dWidth = Input();
            Console.Write("Height = ");
            var dHeight = Input();

            Console.WriteLine("\nEnter width, height and depth of object in cm. " +
                "\nNumbers must be a positive integers and greater than zero.");
            Console.Write("Width = ");
            var oWidth = Input();
            Console.Write("Height = ");
            var oHeight = Input();
            Console.Write("Depth = ");
            var oDepth = Input();

            var doorway = new Doorway(dWidth, dHeight);
            var obj = new Wardrobe(oWidth, oHeight, oDepth);

            if (doorway.IsPassed(obj))
                Console.WriteLine("\nPassed!");
            else
                Console.WriteLine("\nFail! Object must be smaller than doorway.");

            Console.WriteLine("Doorway: {0}x{1}", dWidth, dHeight);
            Console.WriteLine("Object: {0}x{1}x{2}", oWidth, oHeight, oDepth);
            Console.ReadLine();
        }

        private static int Input()
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out int number))
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
                Console.WriteLine("Dimension must be an integer positive number. Set to 0");
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
