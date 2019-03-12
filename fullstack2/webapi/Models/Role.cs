namespace webapi.Models
{
    public class Roles
    {
        public int UserId { get; set; }
        public int Role { get; set; }

        public override string ToString()
        {
            string s = "Object as a String - ";
            s += "UserId: " + UserId.ToString();
            s += ", Role: " + Role.ToString();
            return s;
        }
    }
}