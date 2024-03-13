public class Node
{
  public int Value { get; set; }
  public Node? Next { get; set; }

  public Node(int value)
  {
    this.Value = value;
    this.Next = null;
  }
}

public class MyLinkedList
{
  private Node head;
  private Node tail;
  private int length;

  public MyLinkedList(int value)
  {
    this.head = new Node(value);
    this.tail = this.head;
    this.length = 1;
  }

  public void append(int value)
  {
    Node newNode = new Node(value);
    this.tail.Next = newNode;
    this.tail = newNode;
    this.length++;
  }

  public void prepend(int value)
  {
    Node newNode = new Node(value);
    newNode.Next = this.head;
    this.head = newNode;
    this.length++;
  }
}
