using DoorwayPLLUG.Interfaces;
using System;

namespace DoorwayPLLUG.Doorways
{
    internal class TriangularDoorway : IPassable
    {
        /// <summary>
        /// Left side of TriangleDoorway
        /// </summary>
        public double LeftSide { get; set; }

        /// <summary>
        /// Right side of TriangleDoorway
        /// </summary>
        public double RightSide { get; set; }

        /// <summary>
        /// Base of TriangleDoorway
        /// </summary>
        public double BaseSide { get; set; }

        /// <summary>
        /// TriangleDoorway – triangle 
        /// </summary>
        public TriangularDoorway(double leftSide, double rightSide, double baseSide)
        {
            LeftSide = leftSide;
            RightSide = rightSide;
            BaseSide = baseSide;
        }

        /// <summary>
        /// Check if object smallest surface has smaller dimensions than the doorway.
        /// 
        /// If smallest surface has only 1 dimension ( diameter ) consider that it is a 
        /// diameter of circle. For this case need to find the biggest circle can be 
        /// inscribed into TriangleDoorway and compare its diameter with the surface 
        /// one. The biggest circle can be find by next formula: r = S/p, where r - radius
        /// of the circle, S - square, p - half of the perimeter of the TriangleDoorway.
        /// 
        /// If smallest surface has 2 dimensions consider that it is a width and height 
        /// of rectangle. For this case need to create triangle around rectangle,
        /// by put the highest sides of the triangle and rectangle one at the other and save
        /// one of the angles which adjoins the highest triangle side. If another angle, which
        /// adjoins to the highest triangle side is smaller than the TriangleDoorway one return true.
        /// Angles of TriangleDoorway find by cosine theorem.
        /// 
        /// </summary>
        /// <param name="obj">Object, implementing IMeasurable interface</param>
        /// <returns>True or false</returns>
        public bool CanPass(IMeasurable obj)
        {
            var surface = obj.GetSmallestSurfaceDimensions();
            switch (surface.Length)
            {
                case 1:
                {
                    var halfOfPerimeter = (LeftSide + RightSide + BaseSide) / 2;
                    var biggestRadius = System.Math.Sqrt(
                        (halfOfPerimeter - LeftSide) *
                        (halfOfPerimeter - RightSide) *
                        (halfOfPerimeter - BaseSide) / halfOfPerimeter);
                    return biggestRadius >= surface[0] / 2;
                }
                case 2:
                {
                    // Create array of ABC triangle sides dimensions.
                    // Highest side is AB, lower - BC, lowest - AC.
                    // 
                    var dimensions = new double[] {LeftSide, RightSide, BaseSide};
                    Array.Sort(dimensions);

                    // Let names of rectangle angles will be K,L,M,N
                    // Sorting rectangle sides. Higher sides KL or MN will be put on highest side of triangle
                    Array.Sort(surface);

                    if (dimensions[2] < surface[1]) return false;

                    // Find angles of triangle by cosine theorem
                    var angleCAB = Math.Acos((Math.Pow(dimensions[0], 2) + Math.Pow(dimensions[2], 2) 
                                            - Math.Pow(dimensions[1], 2)) 
                                            / (2 * dimensions[0] * dimensions[1]));
                    var angleABC = Math.Acos((Math.Pow(dimensions[1], 2) + Math.Pow(dimensions[2], 2)
                                            - Math.Pow(dimensions[0], 2)) 
                                            / (2 * dimensions[1] * dimensions[2]));
 
                    // offcutAN - is a distance between angle CAB and rectangle KLMN
                    var offcutAN = surface[0] / Math.Atan(angleCAB);

                    // offcutBM - is a distance between angle CBA and rectangle KLMN
                    var offcutBM = dimensions[2] - offcutAN - surface[1];

                    // Imagine new triangle LBM. To check if rectangle can be inscribed into triangle need to calculate angle LBM
                    var angleLBM = Math.Atan(surface[0] / offcutBM);

                    return angleABC >= angleLBM;
                }
                default:
                {
                    return false;
                }
            }
        }
    }
}
