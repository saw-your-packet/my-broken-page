using System.ComponentModel.DataAnnotations;

namespace MyBrokenPage.Dal.Models
{
    public class UserSecurityAnswer
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key]
        public int SecurityQuestionId { get; set; }
        public SecurityQuestion SecurityQuestion { get; set; }

        public string Answer { get; set; }
    }
}
