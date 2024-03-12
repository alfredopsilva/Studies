using System.Collections;

public class FirstRecurringNumber
{


  public static int FirstRecurringNumberSolution(List<int> A)
  {

    Hashtable myTable = new Hashtable();
    int result = 0;

    for (var i = 0; i < A.Count; i++)
    {
      if (!myTable.Contains(A[i]))
      {
        myTable.Add(A[i], A[i]);
      }
      else
      {
        result = A[i];
        break;
      }
    }
    return result;
  }
}

