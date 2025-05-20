using System;
using System.IO;
using AnimKit.Core;

namespace AnimKit.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: AnimKit.CLI <input_file> <output_file>");
                Console.WriteLine("Converts between raw and open animation formats.");
                return;
            }

            try
            {
                string inputFile = args[0];
                string outputFile = args[1];

                if (!File.Exists(inputFile))
                {
                    Console.WriteLine($"Error: Input file {inputFile} does not exist.");
                    return;
                }

                var asset = new Asset();
                asset.ImportFromFile(inputFile, AssetImportStage.Animations);
                asset.ExportToFile(outputFile);

                Console.WriteLine($"Successfully converted {inputFile} to {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }
    }
}
