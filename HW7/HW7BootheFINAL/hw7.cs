using System.IO;
using System;
using System.Collections.Generic;

public class HW7
{
    public static void Main(string[] args)
    {
        // Begin by opening up the first arg file with StreamReader
        StreamReader f = new StreamReader(args[0]);

        // Next open the second arg file with StreamReader
        StreamReader g = new StreamReader(args[1]);

        // List for g lines (this holds the .tmp file lines)
        var gPos = new List<String>();

        string line;
        // while loops loop through each line and adds the .tmp lines
        while ((line = g.ReadLine()) != null) {
            gPos.Add(line);
        }

        int index = -1;
        // Holds positions of result data
        List<String> elements = new List<String>();

        // loops through .tsv file lines
        while ((line = f.ReadLine()) != null) {

            var lines = line.Trim().Split("\t");
            // Finds line with Headers in it
            if (line.Contains("ID") && !(line.Contains("<<"))) {
                index = Array.IndexOf(lines, "ID");
                elements.AddRange(lines);
                continue;
            } else if (index != -1) {
                string name = lines[index] + ".txt";
                // Final resultant file created with StreamWriter
                StreamWriter h = new StreamWriter(name);
                // copy all args from g into this file
                foreach (string lines2 in gPos)
                {
                    if (lines2.Contains("ID") && lines2.Contains("NAME")) continue;
                    string copy = lines2;
                    foreach (string x in elements)
                    {
                        string replacer = "<<" + x + ">>";
                        if (lines2.Contains(replacer))
                        {
                            copy = copy.Replace(replacer, lines[Array.IndexOf(elements.ToArray(), x)]);
                        }
                    }
                    h.WriteLine(copy);
                }
                h.Close();
            }
        }
        f.Close();
    }
}