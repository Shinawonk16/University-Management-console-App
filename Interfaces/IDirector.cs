namespace Admission_portal.Interfaces
{
    public interface IDirector
    {
         public void CreateDirector(string firstName, string lastName, string email, string phoneNumber, string passWord, string dateOfBirth);
         public void UpdateDirector();
         public void DeleteDirector();

         public void GetAllDirector(); 
        public Model.Director GetDirector(string directorId);

         public Model.Director Login(string email,string passWord);
          public void ReadFromFile();
         public void RewriteFile();
    }
}