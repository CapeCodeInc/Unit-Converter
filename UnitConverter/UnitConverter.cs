
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
            
            ParseResult input = Parser.ParseInput(convertFrom);
            ParseResult output = Parser.ParseOutput(convertTo);

            if (input.unit == Unit._missing && output.unit != Unit._missing)
                return double.NaN;  //One of the units is not present. Units are not compatible

            if (input.unit != Unit._missing && output.unit == Unit._missing)
                return double.NaN;  //One of the units is not present. Units are not compatible

            if (input.unit == Unit._notFound || output.unit == Unit._notFound)
                return double.NaN;  //At least one of the units is incorrect

            if (input.unit == output.unit)  //Unit from and unit to are the same. Converting only prefixes
                return input.value * input.prefix / output.prefix;  //this will also run if no units are entered

            input.value *= input.prefix;
            double result = Conversions.Convert(input.value, input.unit, output.unit);

            return result/output.prefix;
        }


    }
}
