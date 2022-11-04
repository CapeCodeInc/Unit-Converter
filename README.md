# Unit Converter Class Library

Converts quantities between different units of measure, using text input to specify the quantity, unit prefix and the unit. The resulting quantity is of type "double". The converter must be instantiated as an object. Conversion function is 
public double UnitConverter.Convert((string convertFrom, string convertTo)

Language:&emsp;&emsp;&emsp;&emsp;&ensp;	C#<br />
Version:&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;	.NET Version 6.0<br />
Supported Units:&emsp;&ensp;			meters, feet, inches, <br />
			&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; bits, bytes, <br />
			&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; Fahrenheits and Celsius degrees<br />
			&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; liters/100km(L100Km), MPG<br />


## Input specification
The input must consist of two strings:
First string specifies the quantity to convert, and unit prefix and unit to convert from. The quantity is separated from the text by a space. Unit prefix and unit are input as one word, i.e. "kilometers". The library handles common SI Unit Prefixes. 
All prefix names are input as a word in lower case letters, i.e. "megabyte". 
All units names are input as a word in English, plural only, i.e. "fahrenheits", "celsius".
Similarly the second string specifies the unit prefix and unit to convert to.

## Result
is of the type "double". In case of incorret input, the library returns "double.NaN" - not a number. Incorrect input may be missing quanitity, unrecognizable units, mismatched units, missing conversion.

## Usage without units of measure
The library can be used just to evaluate the value of prefixes of a given quantity without units. For example "20 kilo" converted to "" yields 20 000. This could be considered an inconsistent input, but it is also a useful function.

## Expansibility
The library can be easily expanded by editing the file Resources.cs. 
To add additional units of measure, add the unit name into public enum Unit{ ... }. 
To add conversion between units, edit the class Resources, function <br />
public void InitializeConversions()

Each conversion is identified by the unit1 and unit2, input as elements of enum. The conversion itself may be defined by
- factor which will be used to multiply the given quantity to convert it from unit 1 to unit 2. The reverse conversion uses the same factor by division.
- a pair of functions to convert the quantity to and from units unit1 and unit2. The functions may be entered as lambda expressions or they may be defined    sepparately as members of the Resources class.

The following functions facilitate the addition: <br />
public void Add(Unit unit1, Unit unit2, Conversion conversion) //adding a new conversion<br />
public void Add(Unit unit1, Unit unit2, double factor) //adding a generic one factor conversion<br />
public void Add(Unit unit1, Unit unit2, conversionFunction cf1, conversionFunction cf2)<br />

To add a unit prefix based on the power of 10, add its name into the Prefix enum together with the value of the exponent. Alternatively prefixes such as "dozen = 12" can be added as a string and value in the <br />
public void InitializePrefixes() <br />
function of the Resources class.

## Testing
Testing is done under the console application project TestForUnitConverter, within the solution. Additional tests can be included by editing the Program.Main[] function. The function call is <br />
public void Run(string inputSpec, string outputSpec)<br />
in the class Test. If the conversion yields a number, the same conversion is run back to verify the result. In cases of incorrect input the library yielded the "double.NaN" result. In all other cases the conversion has been reversible. 

## Future Development
Part of the intention was to demonstrate handling of text input. Converting text input into scientific language for further software development would make for a good class library project on its own. Here it brings limitations to the intended use for converting between pairs of units. For example some units and their prefixes have Greek symbols. The use of enums to represent resource data was intended to simplify the expansibility of the library, but in the present it complicates matters while there is little performance enhancement. Further, in other projects the data to convert will typically exist as numbers and unit information. In the future I will atttempt to separate text input and provide text output. This will also make the business part run faster, and simplify use. It is not inconceivable that the library could provide a static environment that does not need to be instantiated when used in other prograns.
