using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiForENGLISH.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }

        [Column(TypeName = "text")]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Name { get; set; }

        public int Score { get; set; }

        public int TimeTaken { get; set; }
    }
}
