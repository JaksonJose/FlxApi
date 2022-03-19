using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
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
            UserInquiryResponse response =  _identity.AuthValidation(auth);

            if (response.HasErrorMessages)
            {
                return response;
            }

            string token = TokenService.GenerateToken(auth);

            response.Token = token;

            return response;
        }

        public UserInquiryResponse UserBac(UserInquiryResponse response)
        {
            //string token = TokenService.GenerateToken();


            return response;
        }
    }
}
