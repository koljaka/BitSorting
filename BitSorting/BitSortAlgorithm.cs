using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace BitSorting
{
	public class BitSortAlgorithm
	{
		private const int MAX_COLUMN_COUNT = 32;

		private List<bool[]> sortedBitMatrix;

		public BitSortAlgorithm ()
		{
			Some test :) 
		}

		public int[] Sort(int[] array)
		{
			sortedBitMatrix = new List<bool[]>();
			bool[][] bitMatrix = ConvertArrayToBixMatrix(array);
			SortAlgorithm(bitMatrix, 0);
			return ConvertBitMatrixToArray(sortedBitMatrix);
		}

		private void SortAlgorithm(bool[][] bitMatrix, int columnNumber)
		{
			List<bool[]> ones = new List<bool[]> ();
			List<bool[]> zeros = new List<bool[]> ();

			for (int i = 0; i < bitMatrix.Length; i++)
			{
				if (bitMatrix[i][columnNumber])
					ones.Add(bitMatrix[i]);
				else
					zeros.Add(bitMatrix[i]);
			}

			columnNumber++;

			if (columnNumber == MAX_COLUMN_COUNT)
			{
				sortedBitMatrix.AddRange(ones);
				sortedBitMatrix.AddRange(zeros);
				return;
			}

			if (ones.Count != 0)
				SortAlgorithm (ones.ToArray(), columnNumber);
			if (zeros.Count != 0)
				SortAlgorithm (zeros.ToArray(), columnNumber);
		}

		public bool[][] ConvertArrayToBixMatrix(int[] array)
		{
			int arrayLength = array.Length;
			bool[][] bitMatrix = new bool[arrayLength][];
			for (int i = 0; i < array.Length; i++)
			{
				BitArray bitArray = new BitArray (new int[1]{ array [i] });
				bool[] bits = new bool[bitArray.Length];
				bitArray.CopyTo (bits, 0);
				Array.Reverse (bits);
				bitMatrix [i] = bits;
			}
			return bitMatrix;
		}

		private int[] ConvertBitMatrixToArray(List<bool[]> bitMatrix)
		{
			int[] resultArray = new int[bitMatrix.Count];
			int count = 0;
			for (int i = 0; i < bitMatrix.Count; i++)
			{
				bool[] bits = bitMatrix [i];
				Array.Reverse(bits);
				BitArray bitArray = new BitArray(bits);
				int[] tmpArray = new int[1];
				bitArray.CopyTo(tmpArray, 0);
				resultArray [count] = tmpArray [0];
				count++;
			}
			return resultArray;
		}

	}
}

