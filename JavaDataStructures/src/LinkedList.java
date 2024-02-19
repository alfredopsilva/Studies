import java.util.ArrayList;

class Node {
    int value;
    Node next;

    Node(int value) {
        this.value = value;
    }
}

public class LinkedList {
    private Node head;
    private Node tail;
    private int length;

    public LinkedList(int value) {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length = 1;
    }

    public void printList() {
        Node temp = head;
        while (temp != null) {
            System.out.println(temp.value);
            temp = temp.next;
        }
    }

    public void getHead() {
        if (head == null) {
            System.out.println("Head: null");
        } else {
            System.out.println("Head:" + head.value);
        }
    }

    public void getTail() {
        if (tail == null) {
            System.out.println("tail: null");
        } else {
            System.out.println("Tail:" + tail.value);
        }
    }

    public void getLength() {
        System.out.println("Length:" + length);
    }

    public void append(int value) {
        Node newNode = new Node(value);
        if (length == 0) {
            head = newNode;
            tail = newNode;
        } else {
            tail.next = newNode;
            tail = newNode;
        }
        length++;
    }

    public Node removeLast() {
        if (length == 0)
            return null;
        Node temp = head;
        Node pre = head;
        while (temp.next != null) {
            pre = temp;
            temp = temp.next;
        }
        tail = pre;
        tail.next = null;
        length--;
        if (length == 0) {
            head = null;
            tail = null;
        }

        return temp;
    }

    public void prepend(int value) {
        Node newNode = new Node(value);
        if (length == 0) {
            head = newNode;
            tail = newNode;
        } else {
            newNode.next = head;
            head = newNode;
        }
        length++;
    }

    public Node removeFirst() {
        if (length == 0)
            return null;
        Node temp = head;
        head = head.next;
        temp.next = null;
        length--;
        if (length == 0)
            tail = null;

        return temp;
    }

    public Node get(int index) {
        if (index < 0 || index > length)
            return null;
        Node temp = head;
        for (int i = 0; i < index; i++) {
            temp = temp.next;
        }

        return temp;
    }

    public boolean set(int index, int value) {
        Node temp = get(index);
        if (temp != null) {
            temp.value = value;
            return true;
        }

        return false;
    }

    public boolean insert(int index, int value) {
        if (index < 0 || index > length)
            return false;

        if (index == 0) {
            prepend(value);
            return true;
        }

        if (index == length) {
            append(value);
            return true;
        }

        Node newNode = new Node(value);
        Node temp = get(index - 1);
        newNode.next = temp.next;
        temp.next = newNode;
        length++;

        return true;

    }

    public Node remove(int index) {
        if (index < 0 || index >= length)
            return null;
        if (index == 0)
            return removeFirst();
        if (index == length)
            return removeLast();

        Node prev = get(index - 1);
        Node temp = prev.next;

        prev.next = temp.next;
        temp.next = null;
        length--;
        return temp;
    }

    public void reverse() {
        Node temp = head;
        head = tail;
        tail = temp;
        Node after = temp.next;
        Node before = null;

        for (int i = 0; i < length; i++) {
            after = temp.next;
            temp.next = before;
            before = temp;
            temp = after;
        }
    }

    public void partitionList(int x) {
        Node temp = head;
        Node dummySmaller = new Node(0); 
        Node smaller = dummySmaller;
        Node dummyGreater = new Node(0); 
        Node greater = dummyGreater;

        while (temp != null) {
            if (temp.value < x) {
                smaller.next = temp;
                smaller = smaller.next; 
            } 
            else {
                greater.next = temp; 
                greater = greater.next; 
            }
            temp = temp.next; 
        }

        greater.next = null; 
        smaller.next = dummyGreater.next; 
        head = dummySmaller.next;


        printList();
    }

    public void removeDuplicates(){
        Node temp = head;
        Node newHead = new Node(0);  
        ArrayList<Integer> nodes = new ArrayList<>(); 
        
        while(temp != null && !nodes.contains(temp.value)){ 
            nodes.add(temp.value);
            newHead.next = temp.next; 
            newHead = temp; 
            temp = temp.next; 
        }

        printList();
    }
}