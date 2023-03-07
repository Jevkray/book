using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
 
namespace knigaWEB.Models
{
    public class Comment
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
 
        [Required]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }
 
        public int CommentId { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
    }
 
    public class EditCommentView
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
 
        public int CommentId { get; set; }
    }
 
    public class CreateCommentView
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}