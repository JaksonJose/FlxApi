using Flx.Domain.Domains;
using Flx.Domain.Responses;

namespace Flx.Domain.BAC.IBAC
{
    public interface ICategoryBac
    {
        public InquiryResponse<Category> CategoryList(IEnumerable<Category> category);
    }
}
