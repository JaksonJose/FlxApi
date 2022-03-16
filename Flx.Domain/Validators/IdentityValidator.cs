using Flx.Domain.Identity.Models;
using Flx.Domain.Responses;
using Flx.Domain.Validators.IValidators;
using System.Text.RegularExpressions;

namespace Flx.Domain.Validators
{
    public class IdentityValidator : IIdentityValidator
    {
        /// <summary>
        /// Validadate the credentials (email and password)
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public UserInquiryResponse AuthValidation(Auth auth)
        {
            UserInquiryResponse response = new();

            // Improve this later
            Regex emailForm = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if(string.IsNullOrEmpty(auth.Email) || string.IsNullOrWhiteSpace(auth.Email) || !emailForm.Match(auth.Email).Success)
            {
                response.AddErrorMessage("Invalid Email");
            }

            // Improve this later
            if(string.IsNullOrEmpty(auth.Password) || string.IsNullOrWhiteSpace(auth.Password) || auth.Password.Length < 4 && 
                Regex.IsMatch(auth.Password, "[a-ZA-Z0-9]+", RegexOptions.IgnoreCase))
            {
               response.AddErrorMessage("Invalid Password");
            }

            return response;
        }
    }
}
