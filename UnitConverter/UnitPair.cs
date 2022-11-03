
namespace UnitConverterLib
{
    
    public struct UnitPair
    {
        public Unit Unit1;
        public Unit Unit2;

        public UnitPair(Unit unit1, Unit unit2)
        {
            Unit1 = unit1;
            Unit2 = unit2;

        }
        public searchresult Contains(Unit U)    //searchresult defined in UnitConverter.cs
        {
            if (Unit1 == U) return searchresult.foundAsForward;
            if (Unit2 == U) return searchresult.foundAsReverse;
            return searchresult.notFound;
        }
        public searchresult Contains(Unit u1, Unit u2)
        {
            if (Unit1 == u1 && Unit2 == u2) return searchresult.foundAsForward;
            if (Unit2 == u1 && Unit1 == u2) return searchresult.foundAsReverse;
            return searchresult.notFound;
        }
    }
}
