using System.ComponentModel.DataAnnotations;

namespace Camp.Mapping.Web.ViewModels
{
    public class PostViewModel
    {
        [Required] public string Subject { get; set; }
        public string Body { get; set; }
        public string CreationTimestamp { get; set; }
    }
}