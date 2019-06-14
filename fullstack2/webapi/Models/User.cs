namespace webapi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            string s = "Object as a String - ";
            s += "UserId: " + UserId.ToString();
            s += ", FirstName: " + FirstName.ToString();
            s += ", LastName: " + LastName.ToString();
            s += ", Username: " + Username.ToString();
            s += ", Password: " + Password.ToString();
            return s;
        }

    }
}