using System.Collections;

namespace CSharpDataStructures;

class Program
{
  static void Main(string[] args)
  {
    List<int> A = new List<int> { 2, 5, 1, 2, 3, 5, 1, 2, 4 };
    List<int> B = new List<int> { 2, 1, 1, 2, 3, 5, 1, 2, 4 };
    List<int> C = new List<int> { 2, 3, 4, 6 };
    System.Console.WriteLine(FirstRecurringNumber.FirstRecurringNumberSolution(A));
    System.Console.WriteLine(FirstRecurringNumber.FirstRecurringNumberSolution(B));
    System.Console.WriteLine(FirstRecurringNumber.FirstRecurringNumberSolution(C));


    // MERGE SORTED ARRAYS EXERCISE
    /* ArrayList? test; */
    /* test = MergeSortedArrays.returnSortedArray(new ArrayList { 12, 2, 4, 5, 50, 100, 1000 }, new ArrayList { 3, 10, 20, 50 }); */
    /* for (var i = 0; i < test?.Count; i++) */
    /* { */
    /*   System.Console.WriteLine(test[i]); */
    /* } */
  }
}
