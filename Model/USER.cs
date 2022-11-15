namespace Admission_portal.Model
{
    public class USER
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string DateOfBirth{get;set;}
        public string Email{get;set;}
        public string PhoneNumber{get;set;}
        public string PassWord{get;set;}
        public USER(string firstName,string lastName,string email,string phoneNumber, string passWord,string dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            PassWord = passWord;
        }
    }
}