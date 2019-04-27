using CommandLine;
using CommandLine.Text;
using System.Collections.Generic;

namespace PigLatin.CLI
{
    public class PigLatinCliArgs
    {
        [Option('i', "input", Required = true, HelpText = "Input file path.")]
        public string InputFilePath { get; set; }
        [Option('o', "output", Required = true, HelpText = "Output file path.")]
        public string OutputFilePath { get; set; }

        [Usage(ApplicationAlias = "PigLatin.CLI")]
        public static IEnumerable<Example> Examples =>
            new[] { new Example(
                "Convert file to a trendy format", 
                new PigLatinCliArgs { InputFilePath = "english.txt", OutputFilePath = "piglatin.txt" }) };

    }
}
