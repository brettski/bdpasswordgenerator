# BD Password Generator

_Moved from [Codeplex](https://bdpasswordgenerator.codeplex.com/) on 9/16/2017_

## Project Description

Fast, flexible and lightweight password and random string generation library.

* The BD Password Generation Library uses System.Security.Cryptography.RNGCryptoServiceProvider() [MSDN](http://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider.aspx), v[4.8.1](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.rngcryptoserviceprovider?view=netframework-4.8.1&redirectedfrom=MSDN) for randomization.  
* Character sets used for randomization may be fully customized with any Unicode values.  
* Generate large random character strings.  Generate a 100,000 character random string in milliseconds.  
* Use for performing random dice rolls.
* Bulk Password Generation
  * Generates 100,000 30 character passwords in < 600ms (i7-2720QM CPU @ 2.2 GHz)
  * Guaranteed no duplicates!

### Download from nuget!

```sh
PM> Install-Package BDPasswordGenerator
```

## Documentation

See [Documentation](https://github.com/brettski/bdpasswordgenerator/wiki) for [class reference](https://github.com/brettski/bdpasswordgenerator/wiki/Class-Reference) and [Examples](https://github.com/brettski/bdpasswordgenerator/wiki/Examples)

## System Requirements

### For Use

* .NET 4.8

### For Development

* .NET 4.8 SDK
* Visual Studio 2017+

### Nuget packaging

```sh
nuget.exe pack -Properties Configuration=Release
```
