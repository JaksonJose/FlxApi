using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;

namespace Flx.Domain.BAC
{
    public class CategoryBac : ICategoryBac
    {   
        public CategoryBac(ICategoryValidator categoryValidator)
        {
        } 
    }
}
