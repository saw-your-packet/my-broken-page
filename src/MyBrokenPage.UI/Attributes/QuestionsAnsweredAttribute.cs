using MyBrokenPage.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBrokenPage.UI.Attributes
{
    public class QuestionsAnsweredAttribute : ValidationAttribute
    {
        private new const string ErrorMessage = "All the security questions have to be answered.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<UserSecurityAnswerViewModel> userSecurityAnswers;
            try
            {
                userSecurityAnswers = (ICollection<UserSecurityAnswerViewModel>)value;
            }
            catch (InvalidCastException)
            {
                return new ValidationResult(ErrorMessage);
            }

            if (userSecurityAnswers == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            foreach (var userSecurityAnswer in userSecurityAnswers)
            {
                if (string.IsNullOrWhiteSpace(userSecurityAnswer.Answer))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
