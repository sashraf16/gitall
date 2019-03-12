namespace webapi.Models
{
    public class Salts
    {
        public int UserId { get; set; }
        public string UserSalt { get; set; }

        public override string ToString()
        {
            string s = "Object as a String - ";
            s += "UserId: " + UserId.ToString();
            s += ", Salt: " + UserSalt;
            return s;
        }
    }
}