using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiForENGLISH.Models
{
    public class Quetion
    {
        [Key]
        public int QuetId { get; set; }

        [Column(TypeName="text")]
        public string QnInWords { get; set; }
        [Column(TypeName = "text")]
        public string Image { get; set; }
        [Column(TypeName = "text")]
        public string Option1 { get; set; }
        [Column(TypeName = "text")]
        public string Option2 { get; set; }
        [Column(TypeName = "text")]
        public string Option3 { get; set; }
        [Column(TypeName = "text")]
        public string Option4 { get; set; }

        public int Answer { get; set; }
        public string Category { get; set; }
    }
}
