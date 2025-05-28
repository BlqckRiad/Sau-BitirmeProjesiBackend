namespace AdminPanel.Models
{
    public class ChangeRoleRequest
    {
        public int userID { get; set; }
        public int roleID { get; set; }
        public int updatedUserID { get; set; }
    }
}
