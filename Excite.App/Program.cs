using System;
using CommandLine;
using Excite.Utilities.Extensions;

namespace Excite.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var prog = new Program();
            var typedArgs = prog.GetOptions(args);

            try
            {
                var result = typedArgs.Text.IndicesOf(typedArgs.SubText);
                if(result.Count > 0)
                    Console.WriteLine(string.Join(",", result));
                else
                    Console.WriteLine("<no matches>");
            }
            catch (ArgumentNullException arex)
            {
                Console.WriteLine($"Error: {arex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private InputArgs GetOptions(string[] args)
        {
            var options = new InputArgs();
            var migrationArgs = CommandLine.Parser.Default.ParseArguments(args, options);

            return options;
        }
    }

    public class InputArgs
    {
        [Option('t', "Text", DefaultValue = null,
            HelpText = "input text",
            Required = true)]
        public string Text { get; set; }

        [Option('s', "SubText", HelpText = "input subtext to match", DefaultValue = null, Required = true)]
        public string SubText { get; set; }
    }
}
