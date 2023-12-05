namespace ResumeCraft.Web.Models
{
    public enum ResponseTypes
    {
        Success,
        Danger,
        Info,
        Warning
    }

    public class ResponseModel
    {
        public string Title { get; set; }
        public string? Message { get; set; }
        public ResponseTypes Type { get; set; }
    }
}
