public class App {
    public static void main(String[] args) throws Exception {
        LinkedList LL = new LinkedList(3); 
        LL.append(8);
        LL.append(5);
        LL.append(10);
        LL.append(2);
        LL.append(1);

        LL.removeDuplicates(); 
    }
}
