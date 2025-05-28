namespace AdminPanel.Models
{
    public class ChangeEmailRequest
    {
        public string NewEmail { get; set; }
        public int updatedUserID { get; set; }
        public int userID { get; set; }
    }
}
