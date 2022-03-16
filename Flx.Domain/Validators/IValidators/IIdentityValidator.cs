using Flx.Domain.Identity.Models;
using Flx.Domain.Responses;

namespace Flx.Domain.Validators.IValidators
{
    public interface IIdentityValidator
    {
        public UserInquiryResponse AuthValidation(Auth auth);
    }
}
