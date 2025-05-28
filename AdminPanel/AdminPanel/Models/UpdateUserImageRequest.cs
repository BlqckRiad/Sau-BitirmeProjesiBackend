namespace AdminPanel.Models
{
    public class UpdateUserImageRequest
    {
        public int userID { get; set; }
        public int newImageID { get; set; }
        public string newImageUrl { get; set; }
        public int updatedUserID { get; set; }
    }
} 