using System.Collections;

namespace CSharpDataStructures;


public class MergeSortedArrays
{
  public static ArrayList? returnSortedArray(ArrayList a, ArrayList b)
  {

    if (a == null || b == null) return null;

    a.AddRange(b);
    a.Sort();
    return a;

  }
}

