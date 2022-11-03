namespace UnitConverterLib
{
    public delegate double conversionFunction(double input);
    public class Conversion
    {
        public double Factor { get; set; }
        public conversionFunction ConversionThere;
        public conversionFunction ConversionBack;
        double defaultConversionThere(double input)
        {
            return input * Factor;
        }
        double defaultConversionBack(double input)
        {
            return input / Factor;
        }
        public Conversion(double factor)
        {
            Factor = factor;
            ConversionThere = defaultConversionThere;
            ConversionBack = defaultConversionBack;
        }
        public Conversion(conversionFunction cf1, conversionFunction cf2)
        { 
            ConversionThere = cf1;
            ConversionBack = cf2;
        }

    }
}
