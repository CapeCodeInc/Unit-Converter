
namespace UnitConverterLib
{
    //BASIC ENUMS
    public enum Unit    //allows to add additional unit names here
    {                   //additional units may be added in 
        _notFound,
        _missing,
        meters,
        feet,
        inches,
        celsius,
        fahrenheits,
        bits,
        bytes,
        L100Km,
        MPG
    };
    public enum Prefix  //allows to add additional prefix names and values
    {                   //based on the power of 10
                        //additional prefixes may be added in Resources.InitializePrefixes()
                        //using general values
        yotta = 24,
        zetta = 21,
        exa = 18,
        peta = 15,
        tera = 12,
        giga = 9,
        mega = 6,
        kilo = 3,
        hecto = 2,
        deca = 1,
        deci = -1,
        centi = -2,
        milli = -3,
        micro = -6,
        nano = -9,
        pico = -12,
        femto = -15,
        atto = -18,
        zepto = -21,
        yocto = -24,
    }
    
    
    class Resources     //Edit InitializePrefixes(), InitializeConversions() to 
    {                   //expand the capabilities of the library
        UnitConverter Converter;
        ConversionCollection Conversions;
        PrefixCollection Prefixes;
        UnitCollection Units;
        
        public Resources(UnitConverter u)
        {
            Converter = u;
            Conversions = u.Conversions;
            Prefixes = u.Prefixes;
            Units = u.Units;
            InitializeConversions();
            InitializePrefixes();
            InitializeUnits();

        }
        public void InitializeConversions()     //Simple factor conversions can be added providing the unit pair
                                                //and the corresponding factor.
        {                                       //More complex conversions can be added as pairs of units and 
                                                //conversion functions. The functions have to conform to: 
                                                //public delegate double conversionFunction(double input);
                                                //They can either become member functions of the Resources class
                                                //or they can be directly added as lambda expressions into the
                                                //ConversionColection.public void Add(Unit unit1, Unit unit2,
                                                //conversionFunction cf1, conversionFunction cf2)
                                                //
                                                //It is possible to enter "null" in place of either one of the  
                                                //functions. This will result in a compiler warning, but it will
                                                //work. The converter will return double.NaN for the
                                                //missing conversion.
            Conversions.Clear();

            //Length
            Conversions.Add(Unit.feet, Unit.inches, 12);    //12 inches to a foot
            Conversions.Add(Unit.meters, Unit.feet, 3.280839895d);
            Conversions.Add(Unit.meters, Unit.inches, 39.37008d);            

            //Temperatures:
            Conversions.Add(Unit.fahrenheits, Unit.celsius, (x=>(x-32)*5/9), (x => x * 9 / 5 + 32));

            //Data
            Conversions.Add(Unit.bytes, Unit.bits, 8d);

            //more complex case
            Conversions.Add(Unit.L100Km, Unit.MPG, (x => 100*3.785411784/(1.609344*x)), (x => 100 * 3.785411784 / (1.609344 * x)));


        }
        public void InitializePrefixes()    //Add new prefixes as a pair of string and value
        {
            Prefixes.Clear();
            string[] names = (string[])Enum.GetNames(typeof(Prefix));
            int[] values = (int[])Enum.GetValues(typeof(Prefix));

            for (int i = 0; i < names.Length; i++)
            {
                Prefixes.Add(names[i], (double)Math.Pow(10d, values[i]));

            }

            //adding dozen
            Prefixes.Add("dozen", 12);
        }
        public void InitializeUnits()
        {
            Units.Clear();
            string[] names = (string[])Enum.GetNames(typeof(Unit));
            Unit[] values = (Unit[])Enum.GetValues(typeof(Unit));

            for (int i = 0; i < names.Length; i++)
            {
                Units.Add(names[i], values[i]);

            }
        }
        
    }
}
