# PasswordGenerator Class


### Hiearchy
System.Object
 Brettski.PasswordGenerator.PasswordGenerator

**Namespace:** Brettski.PasswordGenerator

### Syntax
public class PasswordGenerator

### Constructors
|| Name || Description ||
| PasswordGenerator() | Initializes a new instance of PasswordGenerator class |

### Properties
|| Name || Description ||
| UpperAlpha | Gets or sets the upper case character set |
| LowerAlpha | Gets or sets the lower case character set |
| Numbers | Gets or sets the number character set |
| Punctuation | Gets or sets the punctuation character set |
| Special | Gets or sets the special character set |
| PasswordLength | Gets or sets the generated password length |
| UseUpperAlpha | Gets or sets to use the upper case character set when generating a random string |
| UseLowerAlpha | Gets or sets to use the lower case character set when generating a random string |
| UseNumbers | Gets or sets to use the numbers character set when generating a random string |
| UsePunctuation | Gets or sets to use the punctuation character set when generating a random string |
| UseSpecial | Gets or sets to use the special character set when generating a random string |

### Methods
|| Name || Description ||
| GeneratePassword() | Generates a random string |
| GeneratePassword(int) | Generates a random string |
| GeneratePasswordList(int, int) | Generates a list of random strings |

### Default Character Values
|| Name || Values || Enabled By Default ||
| UPPER_ALPHA |  ABCDEFGHIJKLMNOPRSTUVWXYZ | True |
| LOWER_ALPHA | abcdefghijklmnopqrstuvwxyz | True |
| NUMBERS  | 0123456789 | True |
| PUNCTUATION  | !.?:;(){}[]() | False |
| SPECIAL | ~@#$%^&*_-+={"|"}\/';:<>," | False |
| {"DEFAULT_PASSWORD_LENGTH"} | 12 | Not Applicable |


