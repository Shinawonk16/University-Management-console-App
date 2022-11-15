using Admission_portal.Implementation;
using Admission_portal.Interfaces;

using Admission_portal.Model;

namespace Admission_portal.Menu
{
    public class DirectorMenu
    {
        IDirector directorManager = new DirectorManager();
        public void DirectorSubMenu()
        {
            bool isPrev = false;
            while (!isPrev)
            {
                System.Console.WriteLine("enter 1 to register\nenter 2 to login \n enter 0 to go back to menu");
                string dev = Console.ReadLine();
                if (dev == "1")
                {
                    Register();
                }
                else if (dev == "2")
                {
                    Login();
                }
                else if (dev == "0")
                {
                    MainMenu mainMenu1 = new MainMenu();
                    mainMenu1.MiniMenu();
                    // DirectorSubMenu();//
                }
                else
                {
                    System.Console.WriteLine("invalid input");
                }
            }

            void Register()
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
                directorManager.CreateDirector(firstName, lastName, email, phoneNumber, passWord, dateOfBirth);
                DirectorSubMenu();
            }


            void Login()
            {
                System.Console.WriteLine("enter your email");
                string email = Console.ReadLine();
                System.Console.WriteLine("enter your password");
                string passWord = Console.ReadLine();
                Director director = directorManager.Login(email, passWord);
                if (director != null)
                {
                    System.Console.WriteLine("login successful");
                    DirectorMiniMenu();
                }
                else
                {
                    System.Console.WriteLine("unable to login try again!!");
                }
            }
            void DirectorMiniMenu()
            {
                bool isPrev = false;
                while (!isPrev)
                {
                    System.Console.WriteLine("enter 1 to update lecturer\n enter 2 to go back to menu");
                    string opt = Console.ReadLine();
                    if (opt == "1")
                    {
                        directorManager.UpdateDirector();
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
}