using DoorwayPLLUG.Interfaces;

namespace DoorwayPLLUG.Doorways
{
    internal class RectangularDoorway : IPassable
    {
        /// <summary>
        /// Height of Doorway
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Width of Doorway
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Doorway – rectangle 
        /// </summary>
        public RectangularDoorway(double height, double width)
        {
            Height = height;
            Width = width;
        }

        /// <summary>
        /// Check if object smallest surface has smaller dimensions than the doorway 
        /// 
        /// If smallest surface has only 1 dimension ( diameter ) consider that it is a 
        /// diameter of circle
        /// 
        /// If smallest surface has 2 dimensions consider that it is a width and height 
        /// of rectangle
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
                        var surfaceDiameter = s[0];
                        return Height >= surfaceDiameter && Width >= surfaceDiameter;
                    }
                case 2:
                    {
                        var surfaceHeight = s[0];
                        var surfaceWidth = s[1];
                        return (Height >= surfaceHeight && Width >= surfaceWidth) ||
                               (Height >= surfaceWidth && Width >= surfaceHeight);
                    }
                default:
                    return false;
            }
        }
    }
}
