
namespace UnitConverterLib
{
    public enum searchresult
    {
        notFound,
        foundAsForward,
        foundAsReverse
    };

    public class UnitConverter
    {
        public ConversionCollection Conversions = new ConversionCollection();
        public PrefixCollection Prefixes = new PrefixCollection();
        public UnitCollection Units = new UnitCollection();
        
        Resources InitialData;
        StringParser Parser;
        public UnitConverter()
        {
            InitialData = new Resources(this);            
            Parser = new StringParser(Prefixes, Units);

        }

        public double Convert(string convertFrom, string convertTo)
        {
            //double result = double.NaN;
            
            ParseResult inputSpec = Parser.ParseInput(convertFrom);
            ParseResult outputSpec = Parser.ParseOutput(convertTo);

            if (double.IsNaN(inputSpec.value))
                return double.NaN;  //The quantity is not present. Conversion cannot yield a number.

            if (inputSpec.unit == Unit._missing && outputSpec.unit != Unit._missing)
                return double.NaN;  //One of the units is not present. Units are not compatible

            if (inputSpec.unit != Unit._missing && outputSpec.unit == Unit._missing)
                return double.NaN;  //One of the units is not present. Units are not compatible

            if (inputSpec.unit == Unit._notFound || outputSpec.unit == Unit._notFound)
                return double.NaN;  //At least one of the units is incorrect

            if (inputSpec.unit == outputSpec.unit)  //Unit from and unit to are the same. Converting only prefixes
                return inputSpec.value * inputSpec.prefix / outputSpec.prefix;  //this will also run if no units are entered

            inputSpec.value *= inputSpec.prefix;
            double result = Conversions.Convert(inputSpec.value, inputSpec.unit, outputSpec.unit);

            return result/outputSpec.prefix;
        }


    }
}
