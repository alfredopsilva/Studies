using System.Collections;

namespace CSharpDataStructures;

class Program
{
  static void Main(string[] args)
  {
    ArrayList? test;
    test = MergeSortedArrays.returnSortedArray(new ArrayList { 12, 2, 4, 5, 50, 100, 1000 }, new ArrayList { 3, 10, 20, 50 });
    for (var i = 0; i < test?.Count; i++)
    {
      System.Console.WriteLine(test[i]);
    }
  }
}
