
namespace UnitConverterLib
{
    internal class StringParser
    {
        //unit strings - will be entered in plural in small letters
        PrefixCollection Prefixes;
        UnitCollection Units;

        public StringParser(PrefixCollection prefixes, UnitCollection units)
        {
            Prefixes = prefixes;
            Units = units;
         
        }

        public double ReadValue(string spec, ref int pos)
        {
            double result = double.NaN;

            if (pos >= spec.Length)
                return result;
            if (pos < 0)
                return result;

            pos = spec.IndexOf(' '); //assumption: value is separated from text

            if (pos == -1)
                return result;
            
                    result = Convert.ToDouble(spec.Substring(0, pos));

            pos++;  //for following reads from the string

            return result;
        }
        public double ReadPrefix(string spec, ref int pos)
        {
            double result = 1; //value of no prefix
            
            if (pos >= spec.Length)
                return result;
            if (pos < 0)
                return result;

            string subspec2 = spec.Substring(pos, spec.Length - pos); //spec without the number part

            foreach (KeyValuePair<string, double> kvp in Prefixes)
            {
                string s = kvp.Key;
                if (s.Length + pos > spec.Length)
                    continue;

                if (subspec2.StartsWith(kvp.Key))
                {
                    result = kvp.Value;
                    pos = kvp.Key.Length + pos; //for following reads from the string
                }
            }
            
            return result;
        }
        public Unit ReadUnit(string spec, ref int pos)
        {
            if (pos >= spec.Length)
                return Unit._missing;
            if (pos < 0)
                return Unit._notFound;

            string p = spec.Substring(pos,spec.Length - pos); //to the end of the string
            if (Units.ContainsKey(p))
                return Units[p];
            
            return Unit._notFound;
        }
        public ParseResult ParseInput(string spec)
        {
            int pos = 0;
            ParseResult result = new ParseResult();
            result.value = ReadValue(spec, ref pos);
            result.prefix = ReadPrefix(spec, ref pos);
            result.unit = ReadUnit(spec, ref pos);

            return result;
            //would help to handle exceptions here
        }
        public ParseResult ParseOutput(string spec)
        {
            int pos = 0;
            ParseResult result = new ParseResult();
            result.prefix = ReadPrefix(spec, ref pos);
            result.unit = ReadUnit(spec, ref pos);

            return result;
         
        }
        //Exception ParsingException
        //{
        //    string message
        //}
    }
}
