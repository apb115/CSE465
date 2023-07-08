using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace TriDiagonalMatrix 
{
	// This enumerator iterates over the whole tridiagonal matrix.
	// This is done in a row major fashion, starting with element at row 0 and column 0,
	// and includes all N x N elements of the matrix (i.e., includes the zeros
	// below and above the band).
	// For example, for the tridiagonal matrix
	//		1  2  0  0  0  0
	//		3  4  5  0  0  0
	//		0  6  7  8  0  0
	//		0  0  9 10 11  0
	//		0  0  0 12 13 14 
	//		0  0  0  0 15 16
	// stored as:
	//		d: 1 4 7 10 13 16
	//		a: 3 6 9 12 15
	//		c: 2 5 8 11 14
	//	the enumerator is supposed to iterate over the matrix as follows:
	//		1 2 0 0 0 0 3 4 5 0 0 0 0 6 7 8 0 0	0 0 9 10 11 0 0 0 0 12 13 14 0 0 0 0 15 16
	public class TriDiagonalMatrixEnumerator : IEnumerator {
		public TriDiagonalMatrix myMatrix;
		public int currC;
		public int currR;
		public TriDiagonalMatrixEnumerator(TriDiagonalMatrix matrix) {
			this.myMatrix = matrix;
            Reset();
		}
		
		public void Reset() {
			currR = -1;
            currC = -1;
		}
		
		public bool MoveNext() {
			int N = myMatrix.N;
			if ((currR == -1) && (currC == -1)) {
				currC = 0;
				currR = 0;
				return true;
			} else if ((currR == N-1) && (currC == N-1)) {   
				return false;
			} else if (currC == N-1) {
				currR++;
				currC = 0;
			} else {
				currC++;
			}
			return true;
		}
		
		object IEnumerator.Current {
			get {
				return Current;
			}
		}
		
		public float Current {
			get {
				try {
					if (currC - 1 == currR) {
						return myMatrix.get(currR, currC);
					} else if (currC + 1 == currR) {
						return myMatrix.get(currR, currC);
					} else if (currC == currR) {
						return myMatrix.get(currR, currC);
					} else {
						return 0;
					}
				} catch (IndexOutOfRangeException) {
					throw new InvalidOperationException();
				}
			}
		}
	}
	
	public class TriDiagonalMatrix : IEnumerable 
	{
		/* 
		Adapted from: http://mathfaculty.fullerton.edu/mathews/n2003/Tri-DiagonalMod.html
		
		A tridiagonal matrix is a sparse matrix, more specifically a band matrix.
		An N x N matrix A is called a tridiagonal matrix if a[i,j] = 0 whenever i + 1 <= j or j + 1 <= i.
		
		Example:
			The following is a 6 x 6 tridiagonal matrix.
			1  2  0  0  0  0
			3  4  5  0  0  0
			0  6  7  8  0  0
			0  0  9 10 11  0
			0  0  0 12 13 14 
			0  0  0  0 15 16
			
		Since tridiagonal matrices are sparse, it is important to devise a compact way to store them.
		The idea is to only store:
			- the elements on the main diagonal in an array d;
			- the elements directly below the main diagonal in an array a; and	
			- the elements directly above the main diagonal in an array c.
		With this representation, assuming array indices start at 0, an N x N tridiagonal matrix would
		have the format:
		
			d[0] 	c[0] 	0 		0		...		0		0		0
			a[0]	d[1]	c[1]	0		...		0		0		0
			0 		a[1]	d[2]	c[2]	...		0		0		0
			...								...		...
			0 		0		0		0		...		a[N-3]	d[N-2]	c[N-2]
			0		0		0		0		...		0		a[N-2]	d[N-1]
			
		Instead of storing N * N elements, we only need to store 3*N - 2 elements. For instance, for a
		31 x 31 matrix, there are 961 elements, 870 of which are zeros. With this approach, we only need 
		to store the 91 elements on the main diagonal and directly above and below it.
				
		Tridiagonal matrices are useful in specifying tridiagonal linear systems of equations,
		which have many applications, especially in physics (e.g., multistage countercurrent extractor).
		*/
		
		
		public float [] d; // main diagonal
		public float [] a; // subdiagonal: directly below the main diagonal
		public float [] c; // superdiagonal: directly above the main diagonal
		// Note: DO NOT add extra data members!

		// Construct an NxN TriDiagonal Matrix, initialized to 0
		// Throws an ArgumentException if N is a negative number.
		// The exception message should include the value of N.
		public TriDiagonalMatrix(int N) {
            if (N < 0) {
				throw new ArgumentException("The value N: " + N.ToString() + " must be a positive number.");
			}

			this.d = new float[N];
			this.a = new float[N-1];
			this.c = new float[N-1];

			int checker = N-1;
			for (int i = 0; i < N; i++) {
				this.d[i] = 0;
				if (i < checker) {
					this.a[i] = 0;
				}
				if (i > 0) {
					this.c[i-1] = 0;
				}
			}
		}
		
		// N represents the size of the N x N matrix.
		// Note that N is a property, not a data member!
		public int N { 
			get {
				return this.d.Length;
			}
		}
		
		// Returns an upper tridiagonal matrix that is the summation of tridiagonal 
		//   matrices x and y.
		// Throws an ArgumentException if x and y are incompatible. The exception
		//   message should include the sizes of x and y.
		public static TriDiagonalMatrix operator + (TriDiagonalMatrix x, TriDiagonalMatrix y) {
			if (x.N != y.N) {
				throw new ArgumentException("Size " + x.N.ToString() + " must be equal to " + y.N.ToString());
			}

			TriDiagonalMatrix final = new TriDiagonalMatrix(x.N);

			for (int i = 0; i < final.N; i++) {
				float place = x.get(i, i) + y.get(i, i);
				final.set(i, i, place);

            	if (i < final.N - 1) {
					float place2 = x.get(i, i+1) + y.get(i, i+1);
					float place3 = x.get(i+1, i) + y.get(i+1, i);
					final.set(i, i+1, place2);
					final.set(i+1, i, place3);
            	}
        	}
        	return final;
		}
		
		// Sets the value at index [row][col] to val.
		// Throws an ArgumentException if [row][col] is an invalid index to alter,
		// 	  i.e., not an element on or directly below/above the main diagonal.
		// Throws an ArgumentException if row or col are out of bound.
		// The exception messages should include the out of bound index (row or col)
		//    or the invalid row and col combination to alter.
		public void set(int row, int col, float val) {
			try {
				if (row == col) {
					this.d[row] = val;
				} else if (row == col + 1) {
					this.a[col] = val;
				} else if (row == col - 1) {
					this.c[row] = val;
				} else {
					if (row >= this.N || row < 0) { 
						throw new ArgumentException("Row index " + row.ToString() + " is out of bounds");
					} else if (col >= this.N || col < 0) {
						throw new ArgumentException("Column index " + col.ToString() + " is out of bounds");
					} else {
						throw new ArgumentException("Position row " + row.ToString() + " and column " + col.ToString() + " is invalid");
					}
				}
			} catch (IndexOutOfRangeException) {
				throw new ArgumentException("Out of bounds exception for dimensions row: " + row.ToString() + " and col: " + col.ToString());
			}
		}
		
		// Returns the value at index [row][col]
		// Throws an ArgumentException if row or col are out of bound.
		// The exception message should include the out of bound parameter.
		public float get(int row, int col) {
            if (row == col) {
        		return this.d[row];
    		} else if (row == col + 1) {
        		return this.a[col];
    		} else if (row == col - 1) {
        		return this.c[row];
    		} else {
				if (row >= this.N || row == 0) { 
					throw new ArgumentException("Row index " + row.ToString() + " is out of bounds");
				} else if (col >= this.N || col == 0) {
					throw new ArgumentException("Column index " + col.ToString() + " is out of bounds");
				} else {
					throw new ArgumentException("Position row " + row.ToString() + " and column " + col.ToString() + " is out of bounds");
				}
    		}
		}
		
		// Returns a string that prints the d, a, c arrays for the current matrix in the format
		// illustrated by the following example:
		//    d: 1 4 7 10 13 16 19 22 25 28
		//    a: 3 6 9 12 15 18 21 24 27
		// 	  c: 2 5 8 11 14 17 20 23 26	
		public string CompactPrint() {
			StringBuilder sb = new StringBuilder();
			sb.Append("d: ");
			for (int i = 0; i < this.d.Length; i++) {
				sb.Append(this.d[i]);
				sb.Append(" ");
			}
			sb.AppendLine();

			sb.Append("a: ");
			for (int i = 0; i < this.a.Length; i++) {
				sb.Append(this.a[i]);
				sb.Append(" ");
			}
			sb.AppendLine();

			sb.Append("c: ");
			for (int i = 0; i < this.c.Length; i++) {
				sb.Append(this.c[i]);
				sb.Append(" ");
			}
			sb.AppendLine();
			
			return sb.ToString();
		}
		
		
		// Returns an enumerator for the tridiagonal matrix
		IEnumerator IEnumerable.GetEnumerator() 
		{
			return GetEnumerator();
		}
		
		public TriDiagonalMatrixEnumerator GetEnumerator() 
		{
			return new TriDiagonalMatrixEnumerator(this);
		}	
	}
}