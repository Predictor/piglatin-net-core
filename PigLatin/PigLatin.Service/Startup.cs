using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace PigLatin.Service
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                if(context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                {
                    using (var writer = new StreamWriter(context.Response.Body))
                    {
                        await writer.WriteAsync("Welcome to Pig Latin text converter. Send the text to convert in a POST request.".AsMemory(), context.RequestAborted);
                    }
                }

                if (context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.ContentType = "text/plain";
                    using (var outStream = context.Response.Body)
                    {
                        using (var converter = new StreamWordConverter(context.Request.Body, PigLatinWordConverter.Convert, CharExtensions.IsWordSeparator, CharExtensions.IsNotLatinLetter))
                        {
                            await converter.ConvertTo(outStream, context.RequestAborted);
                        }
                    }
                }
            });
        }
    }
}
