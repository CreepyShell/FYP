using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetForum.DAL.DomainModels
{
    public class Topic : BaseModel
    {
        public string Name { get; set; }
        [Required]
        public string PostId { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public string CommentId { get; set; }
        public virtual ICollection<PostTopic> Posts { get; set; }
    }
}
