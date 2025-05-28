namespace AdminPanel.Models
{
    public class ChangeUserDataRequest
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? UserName { get; set; }
        public DateTime UserDate { get; set; } = DateTime.MinValue;
        public int UserSexsID { get; set; }
        public int UpdatedUserID { get; set; }
    }
}
