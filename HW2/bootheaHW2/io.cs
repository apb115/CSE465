using System;
using System.IO;

namespace basic {

	public class IO {
		public static void Main(string[] args) {
			var lines = File.ReadAllLines(args[0]);
			/* 
			for (int i = 0; i < lines.Length; i++)
			{
				Console.WriteLine(lines[i]);
			} 
			*/
			foreach (var line in lines)
			{
				String[] arr = line.Split("\t");
				Array.Sort(arr);
				String res = String.Join(",", arr);
				Console.WriteLine(res);
			}
		}
	}
}
