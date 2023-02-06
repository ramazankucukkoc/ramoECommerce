using Core.Application.Constants;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Core.Application.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 8)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage(ValidationExtensionMessages.PasswordEmpty)
                .MinimumLength(minimumLength).WithMessage(ValidationExtensionMessages.PasswordLength)
                 .Matches("[A-Z]").WithMessage(ValidationExtensionMessages.PasswordUppercaseLetter)
                 .Matches("[a-z]").WithMessage(ValidationExtensionMessages.PasswordLowercaseLetter)
                 .Matches("[0-9]").WithMessage(ValidationExtensionMessages.PasswordDigit)
                  .Matches("[^a-zA-Z0-9]").WithMessage(ValidationExtensionMessages.PasswordSpecialCharacter);

            return options;
        }
        public static IRuleBuilderOptions<T, string> FirstLetterMustBeUpperCase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(strToCheck => Char.IsUpper(strToCheck[0])).WithMessage("The first letter is not uppercase");
        }
        public static IRuleBuilder<T, string> IsPhoneValid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage(ValidationExtensionMessages.PhoneEmpty)
                .MinimumLength(ValidationExtensionMessages.MinumumPhoneLenght).WithMessage(ValidationExtensionMessages.PhoneLength)
                .Must(IsPhoneValid).WithMessage(ValidationExtensionMessages.PhoneSpecialCharacter);
            return options;
        }
        public static bool IsPhoneValid(string mobilePhone)
        {
            if (string.IsNullOrWhiteSpace(mobilePhone))
                return false;

            mobilePhone = Regex.Replace(mobilePhone, "[^0-9]", "");
            return mobilePhone.StartsWith("5") && mobilePhone.Length == 10;
        }

    }
}
