﻿using Flx.Domain.Identity.Models;
using Flx.Domain.Responses;


namespace Flx.Domain.BAC.IBAC
{
    public interface IIdentityBac
    {
        public UserInquiryResponse AuthBac(Auth auth);
        public UserInquiryResponse UserBac(UserInquiryResponse response);
    }
}