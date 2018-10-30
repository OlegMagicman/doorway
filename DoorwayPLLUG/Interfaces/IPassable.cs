using System;
using System.Collections.Generic;
using System.Text;

namespace DoorwayPLLUG.Interfaces
{
    internal interface IPassable
    {
        bool CanPass(IMeasurable obj);
    }
}
