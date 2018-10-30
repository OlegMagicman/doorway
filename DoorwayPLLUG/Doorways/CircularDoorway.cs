using System;
using DoorwayPLLUG.Interfaces;

namespace DoorwayPLLUG.Doorways
{
    internal class CircularDoorway : IPassable
    {
        /// <summary>
        /// Diameter of circle doorway
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// CircleDoorway – circle 
        /// </summary>
        public CircularDoorway(double diameter)
        {
            Diameter = diameter;
        }

        /// <summary>
        /// Check if object smallest surface has smaller dimensions than the doorway 
        /// 
        /// If smallest surface has only 1 dimension ( diameter ) consider that it is a 
        /// diameter of circle
        /// 
        /// If smallest surface has 2 dimensions consider that it is a width and height 
        /// of rectangle
        ///
        /// </summary>
        /// <param name="obj">Object, implementing IMeasurable interface</param>
        /// <returns>True or false</returns>
        public bool CanPass(IMeasurable obj)
        {
            var s = obj.GetSmallestSurfaceDimensions();
            switch (s.Length)
            {
                case 1:
                {
                    return Diameter >= s[0];
                }
                case 2:
                {
                    var surfaceDiagonal = Math.Sqrt(Math.Pow(s[0], 2) + Math.Pow(s[1], 2));
                    return Diameter >= surfaceDiagonal;
                }
                default:
                    return false;
            }
        }
    }
}
