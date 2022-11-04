using System.Collections.Generic;

namespace UnitConverterLib
{   
    public class ConversionCollection : Dictionary<UnitPair, Conversion>
    {
        public void Add(Unit unit1, Unit unit2, Conversion conversion) //adding a new conversion
        {
            UnitPair up = new UnitPair(unit1, unit2);
            Add(up, conversion);
        }
        public void Add(Unit unit1, Unit unit2, double factor) //adding a generic one factor conversion
        {
            UnitPair u = new UnitPair(unit1, unit2);
            Conversion c = new Conversion(factor);
            Add(u, c);
        }
        public void Add(Unit unit1, Unit unit2, conversionFunction cf1, conversionFunction cf2)
        {   
            UnitPair u = new UnitPair(unit1, unit2);
            Conversion c = new Conversion(cf1, cf2);
            Add(u, c);
        }
        public double Convert(double value, Unit unit1, Unit unit2)
        {
            foreach (KeyValuePair<UnitPair, Conversion> kvp in this)
            {
                if (kvp.Key.Contains(unit1, unit2) == searchresult.foundAsForward)
                {
                    if (kvp.Value.ConversionThere == null)
                        return double.NaN;  //The conversion function is not present
                    else
                        return kvp.Value.ConversionThere(value);
                }

                if (kvp.Key.Contains(unit1, unit2) == searchresult.foundAsReverse)
                {
                    if (kvp.Value.ConversionBack == null)
                        return double.NaN;  //The conversion function is not present
                    else
                        return kvp.Value.ConversionBack(value);
                }                
            }
            return double.NaN;  //there is no conversion for the given unit pair
        }

    }
}
