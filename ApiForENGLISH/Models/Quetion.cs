using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiForENGLISH.Models
{
    public class Quetion
    {
        [Key]
        public int QuetId { get; set; }

        [Column(TypeName="nvarchar(50)")]
        public string QnInWords { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Image { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Option1 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Option2 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Option3 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Option4 { get; set; }

        public int Answer { get; set; }
        public string Category { get; set; }
    }
}
