using System;
using System.Runtime.CompilerServices;

namespace Rectangle
{
    public class Rectangle
    {
        private Decimal length;

        private Decimal width;

        private const Decimal UpperLimit = 20;

        private const Decimal LowerLimit = 0;

        private String outOfBoundsErrorMessage = $"The value must be greater than {LowerLimit} and less than {UpperLimit}";
        
        public Rectangle()
        {
            Length = 1;
            
            Width = 1;
        }

        public Rectangle(Decimal length, Decimal width)
        {
            Length = length;
            
            Width = width;
        }

        public Decimal Length
        {
            get => length;
            
            set
            {
                if ((value < 0) || (value > 20))
                {
                    throw new ArgumentOutOfRangeException(outOfBoundsErrorMessage);
                }
                
                length = value;
            }
        }

        public Decimal Width
        {
            get => width;

            set
            {
                if ((value < 0) || (value > 20))
                {
                    throw new ArgumentOutOfRangeException(outOfBoundsErrorMessage);
                }

                width = value;
            }
        }

        public Decimal Perimeter()
        {
            return 2 * (Length + Width);
        }

        public Decimal Area()
        {
            return Length * Width;
        }
    }
}