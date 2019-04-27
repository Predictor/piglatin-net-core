namespace PigLatin
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class StreamWordConverter : IDisposable
    {
        private readonly Memory<char> memory = new Memory<char>(new char[1]);
        private readonly StreamReader streamReader;
        private readonly Func<string, string> convertWord;
        private readonly Func<char, bool> isWordSeparator;

        public StreamWordConverter(Stream stream, Func<string, string> convertWord, Func<char, bool> isWordSeparator)
        {
            this.streamReader = new StreamReader(stream);
            this.convertWord = convertWord;
            this.isWordSeparator = isWordSeparator;
        }

        public async Task ConvertTo(Stream stream, CancellationToken cancellationToken)
        {
            var streamWriter = new StreamWriter(stream);
            var builder = new StringBuilder();
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                
                var count = await this.streamReader.ReadAsync(memory, cancellationToken);
                if (count == 0)
                {
                    if (builder.Length > 0)
                    {
                        var converted = this.convertWord(builder.ToString());
                        await streamWriter.WriteAsync(converted.AsMemory(), cancellationToken);
                    }
                    await streamWriter.FlushAsync();
                    return;
                }
                char c = memory.ToArray()[0];
                if (isWordSeparator(c))
                {
                    if(builder.Length > 0)
                    {
                        var converted = this.convertWord(builder.ToString());
                        await streamWriter.WriteAsync(converted.AsMemory(), cancellationToken);
                        builder.Clear();
                    }
                    await streamWriter.WriteAsync(memory, cancellationToken);
                }
                else
                {
                    builder.Append(c);
                }
            }
        }

        public void Dispose()
        {
            streamReader?.Dispose();
        }
    }
}
