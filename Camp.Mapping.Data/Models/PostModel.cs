using System;
using System.ComponentModel.DataAnnotations;

namespace Camp.Mapping.Data.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required] public string Subject { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public UserModel Author { get; set; }
        public DateTime Created { get; set; }
    }
}