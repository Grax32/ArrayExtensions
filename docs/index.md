# Array Extensions

## Fast Array Fill Function

## Install package
`Install-Package Grax.ArrayExtensions`

## Add the using statement
`using Grax;`

## .Fill Extension

Fill with a single value
`var myArray = new int[12000];
myArray.Fill(255);`

Fill with a repeating array
`var myArray = new int[12000];
var filler = new int[] { 1, 2, 3, 4, 5 };

myArray.Fill(filler);`
