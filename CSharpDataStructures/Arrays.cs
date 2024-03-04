namespace CSharpDataStructures;

public class ArrayImplementation
{

  public int Length;
  private Object[] data;

  // Creating Array Constructor. 
  public Array(int length, int data)
  {
    this.Length = length;
    this.Data = data;
  }


  //Methods
  public Object getElement(int index)
  {
    return data[index];
  }

  public Object[] pushElement(Object item)
  {

    if (this.data.Length == this.Length)
    {

      Object[] temp = new Object[this.length];
      Array.Copy(this.data, temp, Length);
      this.data = new Object[Length + 1];
      Array.Copy(temp, this.data, Length);

    }

    this.data(this.Length) = item;
    this.Length++;
    return this.data;
  }

  public Object pop()
  {
    Object poped = data[this.Length - 1];
    this.data[this.Length - 1] = null;
    this.Length--;
    return poped;
  }

  public Object delete(int index)
  {
    Object itemToDelete = data[index];
    shiftItems(index);
    return itemToDelete;
  }

  private void shiftItems(int index)
  {
    for (var i = index; i < Length - 1; i++)
    {
      data[i] = data[i + 1];
    }
    data[Length - 1] = null;
    Length--;
  }
}
