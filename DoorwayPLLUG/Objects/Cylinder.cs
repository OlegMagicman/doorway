using DoorwayPLLUG.Interfaces;

namespace DoorwayPLLUG.Objects
{
    internal class Cylinder : IMeasurable
    {
        /// <summary>
        /// Height of Cylinder
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Diameter of the base of Cylinder
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Cylinder - cylinder
        /// </summary>
        public Cylinder(double height, double diameter)
        {
            Height = height;
            Diameter = diameter;
        }

        /// <summary>
        /// Get the smallest surface of Cylinder
        /// </summary>
        /// <returns>Radius of circle surface of cylinder, or rectangular (diameter as width)</returns>
        public double[] GetSmallestSurfaceDimensions()
        {
            return Height >= Diameter ? new[] { Diameter } : new[] { Height, Diameter };
        }
    }
}
