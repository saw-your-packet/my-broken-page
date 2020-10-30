namespace MyBrokenPage.Models
{
    public class UserSecurityAnswerModel
    {
        public int UserId { get; set; }

        public SecurityQuestionModel SecurtityQuestion { get; set; }

        public string Answer { get; set; }
    }
}
