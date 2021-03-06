# BD Password Generator
_Moved from [Codeplex](https://bdpasswordgenerator.codeplex.com/) on 9/16/2017_

## Project Description
Fast, flexible and lightweight password and random string generation library.

* The BD Password Generation Library uses System.Security.Cryptography.RNGCryptoServiceProvider() [MSDN](http://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider.aspx) for randomization.  
* Character sets used for randomization may be fully customized with any Unicode values.  
* Generate large random character strings.  Generate a 100,000 character random string in a few milliseconds.  
* Use for performing random dice rolls.
* Bulk Password Generation
	* Generates 100,000 12 character passwords in < 600ms (i7-2720QM CPU @ 2.2 GHz)
	* Guaranteed no duplicates!

Download from nuget!
`PM> Install-Package BDPasswordGenerator`

See [Documentation](https://github.com/brettski/bdpasswordgenerator/wiki) for details and [Examples](https://github.com/brettski/bdpasswordgenerator/wiki/Examples)

-----

## System Requirements
### For Use
* .NET 4.5
### For Development
* .NET 4.5
* .NET 4.5 SDK
* Visual Studio 2012+
