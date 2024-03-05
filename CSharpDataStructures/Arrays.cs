namespace CSharpDataStructures;

public class ArrayImplementation
{
  public int length;
  private Object[] data;

  // Creating Array Constructor. 
  public ArrayImplementation()
  {
    this.length = 0;
    this.data = new Object[1];
  }

  //Methods
  public Object getElement(int index)
  {
    return data[index];
  }

  public Object[] pushElement(Object item)
  {
    if (this.data.Length == this.length)
    {
      Object[] temp = new Object[this.length];
      Array.Copy(this.data, temp, length);
      this.data = new Object[length + 1];
      Array.Copy(temp, this.data, length);

    }

    this.data[this.length] = item;
    this.length++;
    return this.data;
  }

  public Object pop()
  {
    Object poped = data[this.length - 1];
    this.data[this.length - 1] = null;
    this.length--;
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
    for (var i = index; i < length - 1; i++)
    {
      data[i] = data[i + 1];
    }
    data[length - 1] = null;
    length--;
  }
}
