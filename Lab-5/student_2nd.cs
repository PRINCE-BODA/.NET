//. Create a List for StudentName and perform following operations: 
//a.Add() - To Add new student in list
//b.Remove() - To Remove Student with specified index 
//c. RemoveRange() - To Remove student with specified range. 
//d. Clear() - To clear all the student from the list

class StudentList_2nd
{
    public List<string> Student = new List<string>();
    public void Addstudent(string Name)
    {
        Student.Add(Name);
    }
    public void RemoveStudent(int index)
    {
        Student.RemoveAt(index);
    }
    public void RemoveRange(int startindex, int endindex)
    {
        int SI = startindex;
        int En = endindex - startindex + 1;
        Student.RemoveRange(SI, endindex);
    }
    public void ClearStudent()
    {
        Student.Clear();
    }
    public void PrintStudentList()
    {
        foreach (var item in Student)
        {
            Console.WriteLine(item);
        }
    }
}