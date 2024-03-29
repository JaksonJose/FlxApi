﻿using Flx.Core.IValidators;
using Flx.Core.Models;
using Flx.Shared.Responses;
using Microsoft.AspNetCore.Http;

namespace Flx.Core.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        public ModelOperationResponse ValidateCategory(Category category)
        {
            ModelOperationResponse response = new();
            
            if (category == null)
            {
                response.AddErrorMessage("Category can't be null");
                return response;
            }

            if (string.IsNullOrEmpty(category.Name))
            {
                response.AddErrorMessage("Category Name is required", StatusCodes.Status400BadRequest);
            }
            
            if (string.IsNullOrEmpty(category.Description))
            {
                response.AddWarningMessage("Category Description is empty");
            }

            return response;
        }   
    }
}
