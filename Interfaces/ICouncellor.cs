namespace Admission_portal.Interfaces
{
    public interface ICouncellor
    {
        public void CreateCouncellor(string firstName, string lastName, string email, string phoneNumber, string passWord, string dateOfBirth);
         public void UpdateCouncellor();
         public void DeleteCouncellor();
         public Model.Councelor GetCouncelor(string councelorId);
         public Model.Councelor Login(string email,string passWord);
         public void ReadFromFile();
         public void RewriteFile();
    }
}



