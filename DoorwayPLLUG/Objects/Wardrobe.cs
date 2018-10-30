using DoorwayPLLUG.Interfaces;

namespace DoorwayPLLUG.Objects
{
    internal class Wardrobe: IMeasurable
    {
        /// <summary>
        /// Width of Wardrobe
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Height of Wardrobe
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Depth of Wardrobe
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Wardrobe - rectangular parallelepiped
        /// </summary>
        public Wardrobe(double width, double height, double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        /// <summary>
        /// Get the smallest surface of Wardrobe
        /// </summary>
        /// <returns>Pair of width and height of the smallest surface</returns>
        public double[] GetSmallestSurfaceDimensions()
        {
            if ( Depth > Width && Depth > Height )
            {
                // Return if depth is higher than width and height
                return new [] { Width, Height };
            }
            else
            {
                if ( Width >= Height )
                {
                    // Return if width is higher than height and depth
                    return new [] { Height, Depth };
                }
                else
                {
                    // Return if height is higher than width and depth
                    return new [] { Width, Depth };
                }
            }
        }
    }
}
