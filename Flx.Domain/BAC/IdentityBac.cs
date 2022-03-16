using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity.Models;
using Flx.Domain.Responses;
using Flx.Domain.Validators.IValidators;

namespace Flx.Domain.BAC
{
    public class IdentityBac : IIdentityBac
    {
        private readonly IIdentityValidator _identity;
        public IdentityBac(IIdentityValidator identity)
        {
            _identity = identity;
        }

        public UserInquiryResponse AuthBac(Auth auth)
        {
            UserInquiryResponse response = new();

            response =  _identity.AuthValidation(auth);

            return response;
        }
    }
}
