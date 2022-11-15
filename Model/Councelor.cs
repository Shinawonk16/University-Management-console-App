namespace Admission_portal.Model
{
    public class Councelor : USER
    {
        public string CouncelorId{get;set;}
       

        public Councelor(string firstName, string lastName, string email, string phoneNumber, string passWord, string dateOfBirth,string councelorId) : base(firstName, lastName, email, phoneNumber, passWord, dateOfBirth)
        {
            
            CouncelorId = councelorId;
        }

        public string ConvertToFileFormat()
        {
            return $"{CouncelorId}@@@@{FirstName}@@@@{LastName}@@@@{Email}@@@@{PhoneNumber}@@@@{PassWord}@@@@{DateOfBirth}";
        }

        public static Councelor ConvertToCouncelor(string councelorInfo)
        {
            string[] info = councelorInfo.Split("@@@@");
            return new Councelor(info[1],info[2],info[3],info[4],info[5],info[0],info[6]);
        }
    }
}