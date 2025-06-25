using System.Collections;
using System.Collections.Generic;

namespace Lab_5
{
    internal class StudentList
    {
        ArrayList Student = new ArrayList();
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
}