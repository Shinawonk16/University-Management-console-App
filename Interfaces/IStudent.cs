namespace Admission_portal.Interfaces
{
    public interface IStudent
    {
         public void CreateStudent(string firstName, string lastName,string dateOfBirth, string stateOfOrigin,string phoneNumber, string email, string passWord,string falculty);
         public void UpdateStudent();
         public void DeleteStudent();
         public void GetAllStudent();

         public Model.Student Login(string email, string passWord);
         public Model.Student GetStudent(string matricsNum);
        public void ReadFromFile();
         public void RewriteFile();
    }
}