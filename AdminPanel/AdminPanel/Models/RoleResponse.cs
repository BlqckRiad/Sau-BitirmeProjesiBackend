namespace AdminPanel.Models
{
    public class RoleResponse
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public DateTime createdDate { get; set; }
        public int createdUserID { get; set; }
        public DateTime updatedDate { get; set; }
        public int updatedUserID { get; set; }
        public DateTime deletedDate { get; set; }
        public int deletedUserID { get; set; }
        public bool isDeleted { get; set; }
    }

}
