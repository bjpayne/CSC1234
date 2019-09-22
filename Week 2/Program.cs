using System;

namespace Rectangle
{
    class Program
    {
        private const String ErrorMessage = "Please provide a valid decimal value";

        static void Main(String[] args)
        {
            try
            {
                Rectangle rectangle = new Rectangle();
                
                SetLength(rectangle);

                SetWidth(rectangle);

                Console.WriteLine($"Rectangle 1 is a {rectangle.Length} x {rectangle.Width} rectangle");
                
                Decimal perimeter = rectangle.Perimeter();

                Decimal area = rectangle.Area();
                
                Console.WriteLine($"The perimeter of the rectangle is {perimeter}");

                Console.WriteLine($"The area of the rectangle is {area}\n\n");

                Main(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void SetLength(Rectangle rectangle)
        {
            try
            {
                Console.Write("Length: ");

                Decimal length = Decimal.Parse(Console.ReadLine() ?? throw new Exception(ErrorMessage));

                rectangle.Length = length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                SetLength(rectangle);
            }
        }

        private static void SetWidth(Rectangle rectangle)
        {
            try
            {
                Console.Write("Width: ");

                Decimal width = Decimal.Parse(Console.ReadLine() ?? throw new Exception(ErrorMessage));

                rectangle.Width = width;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                SetWidth(rectangle);
            }
        }
    }
}