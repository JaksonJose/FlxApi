using Flx.Domain.Identity.models;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;

namespace Flx.Domain.Validators.IValidators
{
    public interface IIdentityValidator
    {
        public UserInquiryResponse UserAuthenticationValidation(SignIn auth, UserInquiryResponse user);
        public UserInquiryResponse RegisterUserValidation(List<User> userList, Register userRegister);
    }
}
