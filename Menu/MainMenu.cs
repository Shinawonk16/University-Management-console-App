using Admission_portal.Implementation;
using Admission_portal.Interfaces;

namespace Admission_portal.Menu
{
    
    public class MainMenu
    {
        public void MiniMenu()
        {
            ICouncellor councellorManager = new CouncellorManager();
         //   System.Console.WriteLine("reading");
            councellorManager.ReadFromFile();
            IDirector directorManager = new DirectorManager();
         //   System.Console.WriteLine("reading");
            directorManager.ReadFromFile();
            IStudent studentManager = new StudentManager();
         //   System.Console.WriteLine("reading");
            studentManager.ReadFromFile();

            
            System.Console.WriteLine("{{{{{{{{{{{{{{{{{{{WELCOME TO UNIWAR}}}}}}}}}}}}}}}");
            bool isExit = false;
            while (!isExit)
            {
                System.Console.WriteLine("enter 1 as co+uncelor\nenter 2 for Director\nenter 3 for Student");
                string run = Console.ReadLine();
                if (run == "1")
                {
                    CouncelorMenu councelorMenu = new CouncelorMenu();
                    councelorMenu.CouncelorSubMenu();
                }
                else if (run == "2")
                {
                    DirectorMenu directorMenu = new DirectorMenu();
                    directorMenu.DirectorSubMenu();
                }
                else if (run == "3")
                {
                    StudentMenu studentMenu = new StudentMenu();
                    studentMenu.StudentSubMenu();
                }
                else if (run == "0")
                {
                    System.Console.WriteLine("Exiting Application");
                    isExit = true;
                }
            }


        }

    }
}