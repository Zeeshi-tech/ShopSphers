namespace ShopSphere.Models
{
    public class SellerRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
            = string.Empty;

        public string Email { get; set; }
            = string.Empty;

        public string StoreName { get; set; }
            = string.Empty;

        public string Status { get; set; }
            = "Pending";
    }
}