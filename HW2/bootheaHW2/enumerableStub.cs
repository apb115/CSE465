using System;
using System.Collections;
using System.Collections.Generic;

namespace CSEnumerable {

	public class CatalogEnumerator : IEnumerator {
		private Catalog catalog;
		private bool inUGclasses; // currently in the first list
		private int currIndex; // index in the UG or Grad list
		
		public CatalogEnumerator(Catalog cat)
		{
			this.catalog = cat;
			Reset();
		}
		public void Reset()
		{
			inUGclasses = true;
			currIndex = -1; // just before the first element
		}
		public bool MoveNext()
		{
			currIndex++;
			if (inUGclasses) {
				if (currIndex >= catalog.ugClasses.Count) {
					inUGclasses = false;
					currIndex = 0;

					if (catalog.gradClasses.Count == 0) {
						return false;
					}
				}
			} else {
				if (currIndex >= catalog.gradClasses.Count) {
					return false;
				}
			}
			return true;
		}
		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}
		public string Current
		{
			get
			{
				try {
					// TODO
				}
				catch (IndexOutOfRangeException) {
					throw new InvalidOperationException();
				}
			}
		}
	}

	public class Catalog : IEnumerable {
		public List<string> ugClasses = new List<string>();
		public List<string> gradClasses = new List<string>();
		public Catalog()
		{
			ugClasses.Add("CSE 174");
			ugClasses.Add("CSE 271");
			ugClasses.Add("CSE 274");
			ugClasses.Add("CSE 465");
			ugClasses.Add("CSE 486");

			gradClasses.Add("CSE 620");
			gradClasses.Add("CSE 627");
			gradClasses.Add("CSE 667");
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		public CatalogEnumerator GetEnumerator()
		{
			return new CatalogEnumerator(this);
		}
	}
	public class enumerable {
		static void Main(string[] args)
		{
			Catalog a1 = new Catalog();

			foreach (string x in a1) {
				Console.Write(x + " ");
			}
			Console.WriteLine();

			IEnumerator e1 = a1.GetEnumerator();
			while (e1.MoveNext()) {
				Console.Write(e1.Current + " ");
			}
			Console.WriteLine();
		}
	}
}
