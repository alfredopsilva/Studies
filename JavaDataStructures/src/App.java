public class App {
  public static void main(String[] args) throws Exception {

    DoublyLinkedList myDLL = new DoublyLinkedList(19);
   myDLL.append(120);
    myDLL.printList();
    System.out.println("Removing");
    myDLL.removeLast(); 
    myDLL.printList();
  }
}
