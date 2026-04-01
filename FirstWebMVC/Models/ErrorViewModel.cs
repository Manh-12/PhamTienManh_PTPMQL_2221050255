namespace FirstWebMVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } = ""; // ✅ fix warning

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}