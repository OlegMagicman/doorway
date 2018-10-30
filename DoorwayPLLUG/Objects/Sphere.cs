using DoorwayPLLUG.Interfaces;

namespace DoorwayPLLUG.Objects
{
    internal class Sphere : IMeasurable
    {
        /// <summary>
        /// Diameter of sphere object
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Sphere - rectangular parallelepiped
        /// </summary>
        public Sphere(double diameter)
        {
            Diameter = diameter;
        }

        /// <summary>
        /// Get the smallest surface dimensions of Sphere
        /// </summary>
        /// <returns>Diameter of the sphere</returns>
        public double[] GetSmallestSurfaceDimensions()
        {
            return new[] { Diameter };
        }
    }
}
