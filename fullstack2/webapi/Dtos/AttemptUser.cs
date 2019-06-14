namespace webapi.Models
{
    public class AttemptUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            string s = "Object as a String - ";
            s += "Username: " + Username.ToString();
            s += ", Password: " + Password.ToString();
            return s;
        }
    }
}