using System;
using System.Collections.Generic;
using System.Text;

namespace DoorwayPLLUG
{
    class Doorway
    {
        /// <summary>
        /// Height of the doorway
        /// </summary>
        private readonly int height;

        /// <summary>
        /// Width of the doorway
        /// </summary>
        private readonly int width;

        /// <summary>
        /// Doorway – rectangle 
        /// </summary>
        public Doorway(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// Check if object smallest surface has smaller dimensions than the doorway 
        /// </summary>
        /// <param name="obj">Object, implementing IObject interface</param>
        /// <returns>True or false</returns>
        public bool IsPassed(IObject obj)
        {
            var s = obj.GetSurface();
            int sHeight = s.Item1;
            int sWidth = s.Item2;
            if ((height > sHeight && width > sWidth) || (height > sWidth && width > sHeight))
                return true;
            return false;
        }
    }
}
