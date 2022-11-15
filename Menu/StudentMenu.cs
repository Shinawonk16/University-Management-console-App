using Admission_portal.Implementation;
using Admission_portal.Interfaces;
using Admission_portal.Model;

namespace Admission_portal.Menu
{
    public class StudentMenu
    {
        // StudentMenu studentMenu = new StudentMenu();
        MainMenu mainMenu1 = new MainMenu();

        IStudent studentManager = new StudentManager();
            public void Login()

            {
                System.Console.WriteLine("enter your email");
                string email = Console.ReadLine();
                System.Console.WriteLine("enter your password");
                string passWord = Console.ReadLine();
                // System.Console.WriteLine("enter your matric num");
                // string matricsNum = Console.ReadLine();
                Student student = studentManager.Login(email, passWord);
                if (student != null)
                {
                    System.Console.WriteLine("login successful");
                    StudentMiniMenu();

                }
                else
                {
                    System.Console.WriteLine("unable to login");
                }
            }
            public void Register()
            {
                System.Console.WriteLine("enter first name");

                string firstName = Console.ReadLine();
                System.Console.WriteLine("enter second name");
                string lastName = Console.ReadLine();
                Console.WriteLine("enter your dateofbirth\nyyyy/mm/dd ");
                string dateOfBirth = Console.ReadLine();
                System.Console.WriteLine("enter state of origin");
                string stateOfOrigin = Console.ReadLine();
                System.Console.WriteLine("enter your Falculty");
                string falculty = Console.ReadLine();
                System.Console.WriteLine("enter your email");
                string email = Console.ReadLine();
                Console.WriteLine("enter your phone number");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("enter your password");
                string passWord = Console.ReadLine();
                studentManager.CreateStudent(firstName, lastName, dateOfBirth, stateOfOrigin, phoneNumber, email, passWord, falculty);
                // StudentSubMenu();
            }
        

        
        public void StudentSubMenu()
        {
            // studentManager.ReadFromFile();
            bool isPrev = false;
            while (!isPrev)
            {
                System.Console.WriteLine("enter 1 to register \n enter 2 to login\n enter 0 to go back to main menu");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Register();
                }
                else if (choice == "2")
                {
                    Login();
                }
                else if (choice == "0")
                {
                    isPrev = true;
                }
                else
                {
                   System.Console.WriteLine("invalid input");
                }
            }

           
        }

        public void StudentMiniMenu()
        {
            bool isPrev = false;
            while (!isPrev)
            {
                System.Console.WriteLine("enter 1 to update student\n enter 2 to go back to menu");
                string opt = Console.ReadLine();
                if (opt == "1")
                {
                    studentManager.UpdateStudent();
                }
                else if (opt == "2")
                {
                    isPrev = true;
                }
                else
                {
                    System.Console.WriteLine("invalid input");
                }

            }


        }
    }
}