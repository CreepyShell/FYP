using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetForum.DAL.DomainModels
{
    public class Interest : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Weight { get; set; }
        public virtual ICollection<UserInterest> Users { get; set; }
    }
}
