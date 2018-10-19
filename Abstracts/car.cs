namespace Abstracts
{
    class car : vehicle
    {
        private string carname;
        
        public car () {}

        public bool cartype (string s)
        {
            carname = s;
            return true;
        }

        public void printcar ()
        {
            System.Console.WriteLine("car name is {0}", carname);
        }
        
        
    }
}