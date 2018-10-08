using System;
using System.Collections.Generic;
using System.Text;

namespace DoorwayPLLUG
{
    class Wardrobe: IObject
    {
        /// <summary>
        /// Width of Wardrobe
        /// </summary>
        //
        private readonly int width = 0;

        /// <summary>
        /// Height of Wardrobe
        /// </summary>
        private readonly int height = 0;

        /// <summary>
        /// Depth of Wardrobe
        /// </summary>
        private readonly int depth = 0;

        /// <summary>
        /// Wardrobe - rectangular parallelepiped
        /// </summary>
        public Wardrobe(int width, int height, int depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        /// <summary>
        /// Get the smallest surface of Wardrobe
        /// </summary>
        /// <returns>Pair of width and height of the smallest surface</returns>
        public (int, int) GetSurface()
        {
            if (depth > width && depth > height)
                // Return if depth is higher than width and height
                return (width, height);
            else
                if (width >= height)
                // Return if width is higher than height and depth
                    return (height, depth);
                else
                // Return if height is higher than width and depth
                    return (width, depth);
        }
    }
}
