namespace AdminPanel.Models
{
    public class LoginResponse
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userTelNo { get; set; }
        public string userToken { get; set; }
        public int userRoleID { get; set; }
        public int userSexsID { get; set; }
        public int userImageID { get; set; }
        public string userImageUrl { get; set; }
    }
} 