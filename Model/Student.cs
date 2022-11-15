using System;
namespace Admission_portal.Model
{
    public class Student : USER
    {
        public string StateOfOrigin{get;set;}
        public string MatricsNum{get;set;}
        public string Falculty{get;set;}
       

        

        public Student(string firstName, string lastName, string email, string phoneNumber, string passWord,string falculty ,string stateOfOrigin, string dateOfBirth,string matricsNum) : base(firstName, lastName, email, phoneNumber, passWord, dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            StateOfOrigin = stateOfOrigin;
            Email = email;
            PhoneNumber = PhoneNumber;
            PassWord = passWord;
            MatricsNum = matricsNum;
            Falculty = falculty;
        }
         public string ConvertToFileFormat()
        {
            return $"{FirstName}@@@@{LastName}@@@@{Email}@@@@{PhoneNumber}@@@@{PassWord}@@@@{Falculty}@@@@{StateOfOrigin}@@@@{DateOfBirth}@@@@{MatricsNum}";
        }
        public static Student ConvertToStudent(string studentInfo)
        {
            string[]info = studentInfo.Split("@@@@");
            return new Student(info[0],info[1],info[2],info[3],info[4],info[5],info[6],info[7],info[8]);
        }
    }
}    
