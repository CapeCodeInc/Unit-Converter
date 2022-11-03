namespace TestForUnitConverter
{
    using UnitConverterLib;
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitConverter Converter = new UnitConverter();
            Test T = new Test(Converter);

            //example input
            T.Run("1 meters", "feet");
            Console.WriteLine();

            T.Run("3 kiloinches", "meters");
            Console.WriteLine();

            //general input
            T.Run("-2 hectometers", "kilofeet");
            Console.WriteLine();
            
            //temperature conversion
            T.Run("5.3 decacelsius", "fahrenheits");
            Console.WriteLine();

            T.Run("29 fahrenheits", "celsius");
            Console.WriteLine();

            //units of data
            T.Run("24 megabytes", "bits");
            Console.WriteLine();

            //same base unit
            T.Run("0.12 kilometers", "meters");
            Console.WriteLine();

            //missing units
            T.Run("12 kilo", "");
            Console.WriteLine();

            //incorrect input
            T.Run("24 bits", "mikro");
            Console.WriteLine();

            T.Run("", "mikro");
            Console.WriteLine();

            T.Run("24 bits", "");
            Console.WriteLine();

            T.Run("", "");
            Console.WriteLine();

            T.Run("meters", "inches");
            Console.WriteLine();

        }
    }
}