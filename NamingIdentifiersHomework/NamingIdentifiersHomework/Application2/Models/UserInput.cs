namespace Application2.Models
{
    public class UserInput
    {
        public UserInput()
        {
            this.Row = -1;
            this.Column = -1;
        }
        
        public string Username { get; set; }
        
        public string Command { get; set; }
        
        public int Row { get; set; }
        
        public int Column { get; set; }
    }
}
