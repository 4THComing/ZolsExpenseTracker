namespace ZolsExpenseTracker.Api.DTOs.Integrations
{
    public class CreateVendorDTO
    {
        public string VendorName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Location { get; set;}
    }
}