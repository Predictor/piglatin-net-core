# Pig Latin Text Converter
## Pig Latin definition
- Words that start with a consonant have their first letter moved to the end of the word and the letters “ay” added to the end.
  - Hello becomes Ellohay
- Words that start with a vowel have the letters “way” added to the end.
  - apple becomes appleway
- Words that end in “way” are not modified.
  - stairway stays as stairway
- Punctuation must remain in the same relative place from the end of the word.
  - can’t becomes antca’y
  - end. becomes endway.
- Hyphens are treated as two words
  - this-thing becomes histay-hingtay
- Capitalization must remain in the same place.
  - Beach becomes Eachbay
  - McCloud becomes CcLoudmay
## Prerequisites 
- [__.NET Core 2.2__](https://dotnet.microsoft.com/download/dotnet-core/2.2) SDK to build the project. Runtime to be able to run CLI.
- [__Visual Studio__](https://visualstudio.microsoft.com/) (to build and run tests, as there is no build script provided)
## Input file format
Any text file. To get a sensible result it should be an English text.
## Command line arguments
_**dotnet** PigLatin.CLI.dll --input <english.txt> --output <piglatin.txt>_

  __-i, --input__     Required. Input file path.

  __-o, --output__    Required. Output file path.

## Project structure
- __PigLatin__ - contains classes for Pig Latin conversion of words and classes to apply conversion to a Stream
- __PigLatin.CLI__ - command line interface (see above)
- __PigLatinTests__ - unit tests for PigLatin library

## Main classes
- [__PigLatinWordConverter__](https://github.com/Predictor/piglatin-net-core/blob/master/PigLatin/PigLatin/PigLatinWordConverter.cs) – converts a word to Pig Latin
- [__StreamWordConverter__](https://github.com/Predictor/piglatin-net-core/blob/master/PigLatin/PigLatin/StreamWordConverter.cs) – applies a given string transformation to a stream. _isWordSeparator_ ctor parameter defindes possible word separators (spaces, line breaks, dashes). _isIgnoredOutsideWord_ defines a set of symbols are not converted when not inside the word (quotation marks, brakets, etc)