namespace AdminPanel.Models
{
    
    public class ChangePhoneRequest
    {
        public string NewTelNo { get; set; }
        public int updatedUserID { get; set; }
        public int userID { get; set; }
    }
}
