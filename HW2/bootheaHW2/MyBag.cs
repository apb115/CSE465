using System;
using System.Collections.Generic;

namespace Bags {

	public class MyBag {
		List<int> items;
		
		public MyBag()
		{
			items = new List<int>();
		}
		
		public void Add(int x)
		{
			items.Add(x);
		}
		
		public bool Remove(int x)
		{
			return items.Remove(x);
		}
		
		public int Count(int item)
		{
			int counter = 0;
			foreach (int i in items)
			{ 
				if (i == item)	
				{
					counter++;
				}
			}
			return counter;
		}
		
		public int Size()
		{
			return items.Count;
		}

		public void Clear()
		{
			items = new List<int>();
		}
		
		public override string ToString() 
		{
			string s = "";
			foreach (int i in items)
			{
				s += i.ToString() + " ";
			}
			return s;
		}
	}
		
	public class MyBag2 {
		Dictionary<int, int> items;
		
		public MyBag2()
		{
			items = new Dictionary<int, int>();
		}
		
		public void Add(int x)
		{
			if (items.ContainsKey(x)) {
				items[x]++;
			} else {
				items.Add(x, 1);
			}
		}
		
		public bool Remove(int x)
		{
			if ((items.ContainsKey(x)) && (items[x] > 1)) {
				items[x]--;
				return true;
			} else {
				return items.Remove(x);
			}
		}
		
		public int Count(int item)
		{
			if (items.ContainsKey(item)) {
				return items[item];
			} else {
				return 0;
			}
		}
		
		public int Size()
		{
			int size = 0;
			foreach (var x in items) {
				size += X.Value;
			}
			return size;
		}

		public void Clear()
		{
			items = new Dictionary<int, int>();
		}
		
		public override string ToString() 
		{
			string s = "";
			foreach (var x in items) {
				for (int i=0; i< x.Value; i++) {
					s += x.Key.ToString() + " ";
				}
 			}
			return s.Trim();
		}
	}
	
	public class Tester {
		static void Main(string[] args)
		{
			MyBag m = new MyBag();
			//MyBag2 m = new MyBag2();
			m.Add(1);
			Console.WriteLine(m);
			m.Add(2);
			Console.WriteLine(m);
			m.Add(2);
			Console.WriteLine(m);
			Console.WriteLine("Count 2: {0}", m.Count(2));
			Console.WriteLine("Size: {0}", m.Size());
			m.Remove(1);
			Console.WriteLine(m);
			m.Remove(3);
			Console.WriteLine(m);
			m.Remove(2);
			Console.WriteLine(m);
		}
	}
}

// Read .TSV file
