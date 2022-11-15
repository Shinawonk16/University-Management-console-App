namespace Admission_portal.Model
{
    public class Director:USER
    {

     public string DirectorId{get;set;}  
      
      
        public Director(string firstName, string lastName, string email, string phoneNumber, string passWord, string dateOfBirth,string directorId) : base(firstName, lastName, email, phoneNumber, passWord, dateOfBirth)
        {
          DirectorId = directorId;
        }
         public string ConvertToFileFormat()
        {
          return $"{FirstName}@@@@{LastName}@@@@{Email}@@@@{PhoneNumber}@@@@{PassWord}@@@@{DateOfBirth}@@@@{DirectorId}";
        }
        public static Director ConvertToDirector(string directorInfo)
        {
          string[]info = directorInfo.Split("@@@@");
          return new Director(info[0],info[1],info[2],info[3],info[4],info[5],info[6]);
        }
    }
}