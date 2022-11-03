using UnitConverterLib;

namespace TestForUnitConverter
{
    internal class Test
    {
        UnitConverter Converter;
        
        public Test(UnitConverter unitConverter)
        {
            Converter = unitConverter;
            
        }
        public void Run(string inputSpec, string outputSpec)
        {
            //if the conversion yields a number, the same conversion is run back to verify the result
            PrintInput(inputSpec, outputSpec);
            double result = Converter.Convert(inputSpec, outputSpec);
            PrintResult(result, outputSpec);

            if (double.IsNaN(result))
                return;

            string revInputSpec = result.ToString()+" "+outputSpec;
            int pos = inputSpec.IndexOf(" ");
            if (pos == -1)
                return;
            string revOutputSpec = inputSpec.Substring(pos+1, inputSpec.Length - pos-1);
            PrintRevInput(revInputSpec, revOutputSpec);
            double revResult = Converter.Convert(revInputSpec, revOutputSpec);
            PrintRevResult(revResult, revOutputSpec);

            pos = inputSpec.IndexOf(" ");
            if (pos == -1)
                return;
            string origValue = inputSpec.Substring(0, pos);

            if (origValue == revResult.ToString())
                Console.WriteLine("PASSED");
            else Console.WriteLine("FAILED");

        }
        public void PrintInput(string inputSpec, string outputSpec)
        {
            Console.WriteLine("Convert {0} to {1}:",inputSpec, outputSpec);
        }
        public void PrintResult(double result, string outputSpec)
        {
            Console.WriteLine("The result is: {0} {1}", result, outputSpec);
        }
        public void PrintRevInput(string inputSpec, string outputSpec)
        {
            Console.WriteLine("Convert {0} to {1}:", inputSpec, outputSpec);
        }
        public void PrintRevResult(double result, string outputSpec)
        {
            Console.WriteLine("The reverse result is: {0} {1}", result, outputSpec);
        }
    }
}
