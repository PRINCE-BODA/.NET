
//namespace Lab_5
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //StudentList studentList = new StudentList();
//            StudentList_2nd studentList = new StudentList_2nd();
//            studentList.Addstudent("ZAla");
//            studentList.Addstudent("Harsh");
//            studentList.Addstudent("");
//            studentList.PrintStudentList();

//            studentList.RemoveStudent(1);

//            studentList.RemoveRange(0, 1);

//            studentList.ClearStudent();
//            studentList.PrintStudentList();
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

//class Program
//{
//    static void Main(string[] args)
//    {
//        //        Create a Stack which takes integer values and perform following
//        //operations:
//        //        a.Push() - To Add new item in stack
//        //b.Pop() - To Remove item from the stack
//        //c.Peek() – To Return the top item from the stack. 
//        //d.Contains() - To Checks whether an item exists in the stack or not. 
//        //e.Clear() - To clear items from stack
//        Stack<int> ints = new Stack<int>();
//        ints.Push(10);
//        ints.Push(20);
//        ints.Push(30);
//        ints.Push(40);
//        foreach (var item in ints)
//        {
//            Console.WriteLine(item);
//        }
//        Console.WriteLine("pop element is" + ints.Pop());
//        foreach (var item in ints)
//        {
//            Console.WriteLine(item);
//        }



//    }
//}


//class program
//{
////    . Create a Queue which takes integer values and perform following
////operations:  
////a.Enqueue() - Adds an item into the queue.
////b.Dequeue() - Returns an item from the beginning of the queue and
////                          removes it from the queue.
////c.Peek() - Returns an first item from the queue without removing it.
////d.Contains() - Checks whether an item is in the queue or not
////e.Clear() - Removes all the items from the queue

//    static void Main(string[] args)
//    {
//        Queue<int> ints = new Queue<int>();
//        ints.Enqueue(10);
//        ints.Enqueue(20);
//        ints.Enqueue(30);
//        ints.Enqueue(40);
        
//        foreach (var item in ints)
//        {
//            Console.WriteLine(item);
//        }
        
//        Console.WriteLine("Dequeue element is: " + ints.Dequeue());
        
//        foreach (var item in ints)
//        {
//            Console.WriteLine(item);
//        }
        
//        Console.WriteLine("Peek element is: " + ints.Peek());
        
//        Console.WriteLine("Contains 20: " + ints.Contains(20));
        
//        ints.Clear();
        
//        Console.WriteLine("Queue cleared. Count: " + ints.Count);
//    }
//}


//class program
//{
////    . Create a Dictionary collection class object and preform following
////operations: 
////a.Add: Adds a key-value pair.
////b.Remove: Removes a key-value pair by key. 
////c.ContainsKey: Checks if a key exists in the hashtable. 
////d.ContainsValue: Checks if a value exists in the hashtable. 
////e.Clear: Removes all key-value pairs. 
//    static void Main(string[] args)
//    {
//        Dictionary<int, string> studentDict = new Dictionary<int, string>();
        
//        studentDict.Add(1, "ZAla");
//        studentDict.Add(2, "harsh");
//        studentDict.Add(3, "zala");
        
//        foreach (var item in studentDict)
//        {
//            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
//        }
        
//        studentDict.Remove(2);
        
//        Console.WriteLine("Contains key 2: " + studentDict.ContainsKey(2));
        
//        Console.WriteLine("Contains value 'Alice': " + studentDict.ContainsValue("Alice"));
        
//        studentDict.Clear();
        
//        Console.WriteLine("Dictionary cleared. Count: " + studentDict.Count);
//    }
//}

class program
{
//    . Create a Hashtable collection class object and preform following
//operations: 
//a.Add: Adds a key-value pair.
//b.Remove: Removes a key-value pair by key. 
//c.ContainsKey: Checks if a key exists in the hashtable. 
//d.ContainsValue: Checks if a value exists in the hashtable. 
//e.Clear: Removes all key-value pairs.
    static void Main(string[] args)
    {
        Hashtable studentTable = new Hashtable();
        
        studentTable.Add(1, "ZAla");
        studentTable.Add(2, "Harsh");
        studentTable.Add(3, "Zala");
        
        foreach (DictionaryEntry item in studentTable)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
        
        studentTable.Remove(2);
        
        Console.WriteLine("Contains key 2: " + studentTable.ContainsKey(2));
        
        Console.WriteLine("Contains value ': " + studentTable.ContainsValue("Alice"));
        
        studentTable.Clear();
        
        Console.WriteLine("Hashtable cleared. Count: " + studentTable.Count);
    }
}