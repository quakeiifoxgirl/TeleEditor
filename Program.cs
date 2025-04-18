using System.Diagnostics;

namespace BadTextEditor
{
    internal class Program
    {
        static string[] Lines;
        static int CurrentLine = 0;
        static int ModifiedLines;

        // Versioning
        static readonly int MajorVersion = 0;
        static readonly int MinorVersion = 1;
        static readonly string Version = $"{MajorVersion}.{MinorVersion}";

        static void Main(string[] args)
        {
            Lines = new string[64000];
            while (true)
            {
                Console.Write("$");
                string input = Console.ReadLine();
                string[] inputsplit = input.ToLower().Split(' ');
                Console.Clear();
                switch(inputsplit[0])
                {
                    default:
                        Console.WriteLine($"Command {inputsplit[0]} is not recognized\nType 'h' and return for command list");
                        break;
                    case "l":
                        if(inputsplit.Length >= 2)
                        {
                            if (File.Exists(inputsplit[1]))
                            {
                                Lines = File.ReadAllLines(inputsplit[1]);
                                Console.WriteLine("File Loaded!");
                            }
                            else
                            {
                                Console.WriteLine("File does not exist!");
                            }
                            
                        }
                        break;
                    case "v":
                        Console.WriteLine($"TeletypEditor Version {Version}\nProgrammed by quakeiifoxgirl");
                        break;
                    case "h":
                        Console.WriteLine("w - Write as String\np - Print all lines in list\ns - Select numbered line\nwt - Write to disk");
                        break;
                    case "w":
                        
                        if (string.IsNullOrWhiteSpace(Lines[CurrentLine]))
                        {
                            ModifiedLines++;
                        }
                        if(input.Length > 2)
                        {
                            Lines[CurrentLine] = input.Substring(2);
                        }
                        else
                        {
                            Lines[CurrentLine] = "";
                        }

                        CurrentLine++;
                        break;
                    case "p":
                        for(int i = 0; i < Lines.Length; i++)
                        {
                            if(i <= ModifiedLines)
                            {
                                Console.WriteLine($"[{i}] {Lines[i]}");
                            }
                            
                        }
                        break;
                    case "s":
                        try
                        {
                            int Selection = int.Parse(inputsplit[1]);
                            CurrentLine = Selection;
                        }
                        catch
                        {

                        }
                        break;
                    case "wt":
                        if(inputsplit.Length >= 2)
                        {
                            List<string> lines = new List<string>();    
                            foreach(string line in Lines)
                            {
                                if (line != null)
                                {
                                    Debug.Print(1.ToString());
                                    lines.Add(line);
                                }
                            }
                            File.WriteAllLines(inputsplit[1], lines.ToArray());
                            Console.WriteLine($"Contents written to {inputsplit[1]}");
                        }
                        
                        
                        break;
                }
            }
        }
    }
}
