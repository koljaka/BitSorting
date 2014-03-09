using System;

namespace BitSorting
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] arrayToSort = GenerateArray(1000000);

			BitSortAlgorithm bitSort = new BitSortAlgorithm();
			int[] sortedArray =  bitSort.Sort(arrayToSort);

			bool isSortCorrect = CheckSort(sortedArray);
			Console.WriteLine("Is Sort Correct: {0}", isSortCorrect);
			Console.ReadKey();
		}

		private static int[] GenerateArray(int count)
		{
			int[] resultArray = new int[count];
			Random random = new Random();
			for (int i = 0; i < count; i++)
			{
				resultArray[i] = random.Next(50);
			}

			return resultArray;
		}

		private static bool CheckSort(int[] arrayToCheck)
		{
			int count = 0;
			for (int i = 0; i < arrayToCheck.Length-2; i++)
			{
				if (arrayToCheck[i] >= arrayToCheck[i + 1])
					count++;
			}

			if (count == arrayToCheck.Length - 2)
				return true;
			return false;
		}
	}
}
