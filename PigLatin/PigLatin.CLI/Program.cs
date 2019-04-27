namespace PigLatin.CLI
{
    using CommandLine;
    using System.IO;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<PigLatinCliArgs>(args)
            .WithParsed(opts => Run(opts));
        }

        private static void Run(PigLatinCliArgs args)
        {
            using (var outStream = File.OpenWrite(args.OutputFilePath))
            {
                using (var converter = new StreamWordConverter(File.OpenRead(args.InputFilePath), PigLatinWordConverter.Convert, CharExtensions.IsWordSeparator, CharExtensions.IsNotLatinLetter))
                {
                    converter.ConvertTo(outStream, CancellationToken.None).GetAwaiter().GetResult();
                }
            }
        }
    }
}
