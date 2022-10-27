using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn
{
    class ExtraMethods
    {
        public static int EnforceLimits(int value, int min, int max, bool loopAround = false)
        {
            if (!loopAround)
            {
                if (value < min)
                    value = min;
                if (value > max)
                    value = max;
            }
            else
            {
                if (value < min)
                    value = max;
                if (value > max)
                    value = min;
            }
            return value;
        }
    }
}
