using System;
using System.IO;
using System.Collections.Generic;
using Admission_portal.Interfaces;
using Admission_portal.Model;
namespace Admission_portal.Implementation
{
    public class StudentManager : IStudent
    {
        public static List<Student> listOfStudent = new List<Student>();
        public string FilePath = "C:\\Users\\Toshiba\\Desktop\\Admission portal\\File\\student.txt";


        public void CreateStudent(string firstName, string lastName, string dateOfBirth, string stateOfOrigin, string phoneNumber, string email, string passWord, string falculty)
        {
            Random random = new Random();
            string matricsNum = "UNI/" + lastName + random.Next(500, 60000).ToString() + "/S";
            Student student = new Student(firstName, lastName, email, phoneNumber, passWord, falculty, stateOfOrigin, dateOfBirth,matricsNum);
            listOfStudent.Add(student);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(student.ConvertToFileFormat());
            }
            Console.WriteLine($"thank you mr {student.FirstName}, your  matricsnumber is {student.MatricsNum}");

        }

        public void DeleteStudent()
        {
            System.Console.Write("Enter the student Matric number: ");
             string matricsNum = Console.ReadLine().Trim();
            //  ReadFromFile();
            foreach (var item in listOfStudent)
            {
                if (item.MatricsNum == matricsNum)
                {
                    listOfStudent.Remove(item);
                    RewriteFile();
                    Console.WriteLine($"Successfully deleted.");
                    break;
                }
                else
                {
                    Console.WriteLine("student not found");
                }
            }
        }



        public Student Login(string email, string passWord)
        {
            foreach (var item in listOfStudent)
            {
                if (item.Email == email && item.PassWord == passWord)

                {
                    return item;
                }
            }
            return null;
        }


        public void UpdateStudent()
        {
            Console.WriteLine("Enter Matricnum of student to Update: ");
            string matricsNum = Console.ReadLine().Trim();
            Student studentToUpdate = GetStudent(matricsNum);
            if (studentToUpdate != null)
            {
                System.Console.WriteLine("enter your firstname");
                string firstName = Console.ReadLine().Trim();
                studentToUpdate.FirstName = firstName;
                System.Console.WriteLine("enter yourlastnam");
                string lastName = Console.ReadLine().Trim();
                studentToUpdate.LastName = lastName;
                System.Console.WriteLine("enter your email");
                string email1 = Console.ReadLine().Trim();
                studentToUpdate.Email = email1;
                System.Console.WriteLine("enter your password");
                string passWord = Console.ReadLine().Trim();
                // studentToUpdate.UpdateStudent(firstName, lastName, email, passWord);
                RewriteFile();
                System.Console.WriteLine("student updated successfully");
            }
            else
            {
                System.Console.WriteLine("student not found");
                foreach (var item in listOfStudent)
                {
                    Console.WriteLine(item.MatricsNum);
                }
            }

        }

        public Student GetStudent(string matricsNum)
        {
            foreach (var item in listOfStudent)
            {
                if (item.MatricsNum == matricsNum)
                {
                    return item;
                }
            }
            return null;
        }

        public void GetAllStudent()
        {
            foreach (var item in listOfStudent)
            {
                System.Console.WriteLine($"{item.FirstName} ***** {item.LastName} ***** {item.StateOfOrigin} ***** {item.MatricsNum}");
            }
        }

        public void ReadFromFile()
        {
            Console.WriteLine("Reading");
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string studentInfo = reader.ReadLine();
                    listOfStudent.Add(Student.ConvertToStudent(studentInfo));
                }
            }
        }

        public void RewriteFile()
        {
            File.WriteAllText(FilePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                foreach (var item in listOfStudent)
                {
                    writer.WriteLine(item.ConvertToFileFormat());
                }
            }
        }
    }
}