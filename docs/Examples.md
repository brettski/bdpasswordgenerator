* [Basic ](-#BasicExample)
* [Numeric Only ](-#NumericOnly-)
* [Custom Character Set ](-#CustomCharSet-)
* [Custom Character Set 2 ](-#CustomCharSet2-)
* [6 sided Dice Roll ](-#DiceRoll6-)
* [12 sided Dice Roll ](-#DiceRoll12-)
* [Generate Password List ](-#GenPwList) ^^New^^


{anchor:BasicExample}
### Basic  
{code:c#}
using System;
using Brettski.PasswordGenerator

public string GeneratePassword()
{
    // Generates a password with library defaults
    IPasswordGenerator pwgen = new PasswordGenerator();
    return pwgen.GeneratePassword():
}
{code:c#}

{anchor:NumericOnly}
### Numeric Only 
{code:c#}
using System;
using Brettski.PasswordGenerator

public string GeneratePassword()
{
    IPasswordGenerator pwgen = new PasswordGenerator():
    pwgen.UseUpperAlpha = false;
    pwgen.UseLowerAlpha = false;
    pwgen.UseNumeric = true;    // true is default, included for example
    return pwgen.GeneratePassword();
}
{code:c#}

{anchor:CustomCharSet}
### Custom Character Set 
{code:c#}
using System;
using Brettski.PasswordGenerator

public string GeneratePassword()
{
    IPasswordGenerator pwgen = new PasswordGenerator():
    pwgen.UpperAlpha = @"XYZPDQ";  // Can be set to any Unicode value 256 characters max length
    pwgen.LowerAlpaha = @"xyzpdq";  // This is the same for all character value sets
    pwgen.Numbers = @"23456789";    // UpperAlpha, LowerAlpha, Numbers, Punctuation, and Special
    return pwgen.GeneratePassword();
}
{code:c#}

{anchor:CustomCharSet2}
### Custom Character Set 2 
{code:c#}
using System;
using Brettski.PasswordGenerator

public string GeneratePassword()
{
    IPasswordGenerator pwgen = new PasswordGenerator():
    // Put your whole custom character set into one character value set up to 256 characters
    // Make sure you only use the character value set you updated
    pwgen.Special = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    pwgen.UseUpperAlpha = false;
    pwgen.UseLowerAlpha = false;
    pwgen.UseNumbers = false;
    pwgen.UseSpecial = true;
    return pwgen.GeneratePassword();
}
{code:c#}

{anchor:DiceRoll6}
### 6 Sided Dice Roll 
{code:c#}
using System;
using Brettski.PasswordGenerator

public int RollSixSidedDie()
{
    IPasswordGenerator pwgen = new PasswordGenerator():
    pwgen.Numbers = "123456";
    pwgen.UseUpperAlpha = false;
    pwgen.UseLowerAlpha = false;
    pwgen.PasswordLength = 1;
    return (int)pwgen.GeneratePassword();
}
{code:c#}

{anchor:DiceRoll12}
### 12 Sided Dice Roll 
{code:c#}
using System;
using Brettski.PasswordGenerator

public int RollTwelveSidedDie()
{
    IPasswordGenerator pwgen = new PasswordGenerator():
    pwgen.Numbers = "123456789abc"
    pwgen.UseUpperAlpha = false;
    pwgen.UseLowerAlpha = false;
    pwgen.PasswordLength = 1;
    string roll = pwgen.GeneratePassword();
    switch (roll)
    {
        case "a":
            roll = "10";
            break;

        case "b":
            roll = "11";
            break;

        case "c":
            roll = "12";
            break;
    }
    return (int)roll;
}
{code:c#}

{anchor:GenPwList}
### Generate Password List
{code:c#}
using System;
using System.Collections.Generic;
using Brettski.PasswordGenerator

public List<string> GeneratePWList(int PasswordLength, int PasswordCount)
{
    IPasswordGenerator pwgen = new PasswordGenerator():
    return pwgen.GeneratePasswordList(PasswordLength, PasswordCount);
}
{code:c#}



----
{anchor:template}
### Template 
{code:c#}
using System;
using Brettski.PasswordGenerator

public string GeneratePassword()
{
    IPasswordGenerator pwgen = new PasswordGenerator():

}
{code:c#}