using Admission_portal.Implementation;
using Admission_portal.Interfaces;
using Admission_portal.Model;

namespace Admission_portal.Menu
{
    public class CouncelorMenu
    {
        // CouncelorMenu councelorMenu = new CouncelorMenu();
        ICouncellor councellorManager = new CouncellorManager();
        IDirector directorManager = new DirectorManager();
        IStudent studentManager = new StudentManager();

        public void CouncelorSubMenu()
        {
            // councellorManager.ReadFromFile();
            bool isPrev = false;
            while (!isPrev)
            {
                Console.WriteLine("enter 1 to register\n enter 2 login\n enter 3 to view lectures\n enter 4 to view student\nenter 5 Get a student\nenter 6 to get a lecturer\n enter 0 to go back to mainmenu");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Register();
                }
                else if (choice == "2")
                {
                    Login();
                }
                else if (choice == "3")
                {
                    directorManager.GetAllDirector();
                    // councelorMenu.CouncelorSubMenu();
                }
                else if (choice == "4")
                {
                    studentManager.GetAllStudent();
                    // councelorMenu.CouncelorSubMenu();
                }
                else if (choice == "5")
                {
                    GetStudentMenu();
                }
                else if (choice == "6")
                {
                    GetDirectorMenu();
                }
                else if (choice == "0")
                {
                    isPrev = true;
                }
            }
        }
   
        public void Register()
        {
            System.Console.WriteLine("enter first name");
            string firstName = Console.ReadLine();
            System.Console.WriteLine("enter second name");
            string lastName = Console.ReadLine();
            System.Console.WriteLine("enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("enter your phone number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("enter your password");
            string passWord = Console.ReadLine();
            Console.WriteLine("enter your dateofbirth\n yyyy/mm/dd");
            string dateOfBirth = Console.ReadLine();

            councellorManager.CreateCouncellor(firstName, lastName, email, phoneNumber, passWord, dateOfBirth);
            CouncelorSubMenu();
        }

        public void Login()
        {
            System.Console.WriteLine("enter your email");
            string email = Console.ReadLine();
            System.Console.WriteLine("enter your password");
            string passWord = Console.ReadLine();
            Councelor councelor = councellorManager.Login(email, passWord);
            if (councelor != null)
            {
                System.Console.WriteLine("login successful");
                // CouncelorMiniMenu();
                CouncelorMiniMenu();
            }
            else
            {
                System.Console.WriteLine("unable to login");
            }

        }

        public void CouncelorMiniMenu()
        {
            bool isPrev = false;
            while (!isPrev)
            {
                System.Console.WriteLine("enter 1 to delete councellor\nenter 2 to delete director\nenter 3 to delete student\nenter 4 to update councelor\n enter 0 to go back to main menu ");
                string opt = Console.ReadLine();
                if (opt == "1")
                {
                    councellorManager.DeleteCouncellor();
                }
                else if (opt == "2")
                {
                    directorManager.DeleteDirector();
                }
                else if (opt == "3")
                {
                    studentManager.DeleteStudent();
                }
                else if (opt == "4")
                {
                    councellorManager.UpdateCouncellor();
                }
                else if (opt == "0")
                {
                    // councelorMenu.CouncelorSubMenu();
                    isPrev = true;
                }
                else
                {
                    System.Console.WriteLine("invalid input");
                }
            }

        }

        public void GetDirectorMenu()
        {
            System.Console.WriteLine("enter directorId");
            string directorId = Console.ReadLine();
            directorManager.GetDirector(directorId);
            if (directorManager.GetDirector(directorId) != null)
            {
                System.Console.WriteLine($"{directorManager.GetDirector(directorId).FirstName}  {directorManager.GetDirector(directorId).LastName}   {directorManager.GetDirector(directorId).DirectorId}");
            }
            else
            {
                System.Console.WriteLine("lecturer not found.");
            }
        }

        public void GetStudentMenu()
        {
            System.Console.WriteLine("enter  student matricNum");
            string matricsNum = Console.ReadLine();
            studentManager.GetStudent(matricsNum);
            if (studentManager.GetStudent(matricsNum) != null)
            {
                Console.WriteLine($"{studentManager.GetStudent(matricsNum).FirstName}   {studentManager.GetStudent(matricsNum).LastName}   {studentManager.GetStudent(matricsNum).MatricsNum}");
            }
            else
            {
                System.Console.WriteLine("Student not found.");
            }
        }

    }
}