using System;
using System.Collections.Generic;
using System.Collections;

namespace UTMatrix {
	// This iterator iterates over the upper triangular matrix.
	// This is done in a row major fashion, starting with [0][0],
	// and includes all N*N elements of the matrix.
	public class UTMatrixEnumerator : IEnumerator {
        public UTMatrix myMatrix;
        public int currR;
        public int currC;
       
		public UTMatrixEnumerator(UTMatrix matrix) {
            this.myMatrix = matrix;
            Reset();
		}
		public void Reset() {
            currR = 0;
            currC = -1;
		}
		public bool MoveNext() {
            int N = myMatrix.getSize();
            if (currC < N-1) {   
                currC++;
                return true;
            } else {
                currC = 0;
                if (currR < N-1) {
                    currR++;
                    return true;
                }
            }
			return false;
		}
		object IEnumerator.Current {
			get {
				return Current;
			}
		}
		public int Current {
			get {
				try {
					if (currC < currR)
						return 0;
					else
						return myMatrix.get(currR, currC);
				}
				catch (IndexOutOfRangeException) {
					throw new InvalidOperationException();
				}
			}
		}
	}
	public class UTMatrix : IEnumerable {
		// Must use a one dimensional array, having minimum size.
		public int [] data;

		// Construct an NxN Upper Triangular Matrix, initialized to 0
		// Throws an error if N is non-sensical.
		public UTMatrix(int N) {
			data = new int[N*(N+1)/2];
		}
		// Returns the size of the matrix
		public int getSize() {
			int m = data.Length;
			return (int)Math.Floor(Math.Sqrt(2*m));
		}
		// Returns an upper triangular matrix that is the summation of a & b.
		// Throws an error if a and b are incompatible.
		public static UTMatrix operator + (UTMatrix a, UTMatrix b) {
			// TODO
			return null;
		}
		// Set the value at index [r][c] to val.
		// Throws an error if [r][c] is an invalid index to alter. Use:
		// 		throw new System.ArgumentException(msg);
		public void set(int r, int c, int val) {
			// TODO
		}
		// Returns the value at index [r][c]
		// Throws an error if [r][c] is an invalid index. Use:
		// 		throw new System.ArgumentException(msg);
		public int get(int r, int c) {
			return 0;
		}
		// Returns the position in the 1D array for [r][c].
		// Throws an error if [r][c] is an invalid index. Use:
		// 		throw new System.ArgumentException(msg);
		public int accessFunc(int r, int c) {
            int N = getSize();
            if (r > c) {
                throw new System.ArgumentException("Below the diagonal");
            }
            if ((r >= N) || (c >= N)) {
                throw new System.ArgumentException("Out of bound arguments");
            }
			return (N*(N-1))/ 2 - ((N-r)*(N-r-1))/ 2 + c;
		}
		// Returns an enumerator for an upper triangular matrix
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
		public UTMatrixEnumerator GetEnumerator() {
			return new UTMatrixEnumerator(this);
		}

		public static void Main(String [] args) {
			const int N = 5;
			UTMatrix ut1 = new UTMatrix(N);
			UTMatrix ut2 = new UTMatrix(N);
			
			// Write your own tests
			
			/* Uncomment the code below once you implement set
			for (int r = 0; r < N; r++) {
				ut1.set(r, r, 1);
				for (int c = r; c < N; c++) {
					ut2.set(r, c, 1);
				}
			}
			*/
			
			/* Uncomment the code below once you implement +
			UTMatrix ut3 = ut1 + ut2;
			UTMatrixEnumerator ie = ut3.GetEnumerator();
			while (ie.MoveNext()) {
				Console.Write(ie.Current + " ");
			}
			Console.WriteLine();
			foreach (int v in ut3) {
				Console.Write(v + " ");
			}
			Console.WriteLine();
			*/
		}
	}
}
