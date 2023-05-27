using Flx.Core.Identity.models;
using Flx.Core.Identity.Models;
using Flx.Core.Responses;

namespace Flx.Core.Validators.IValidators
{
    public interface IIdentityValidator
    {
        public UserInquiryResponse RegisterUserValidation(Register userRegister, UserInquiryResponse userResponse);
        public UserInquiryResponse UserAuthenticationValidation(SignIn auth, UserInquiryResponse user);
        public UserInquiryResponse UserExists(UserInquiryResponse userResponse);
        public UserInquiryResponse UserNotExists(UserInquiryResponse userResponse);    
    }
}
