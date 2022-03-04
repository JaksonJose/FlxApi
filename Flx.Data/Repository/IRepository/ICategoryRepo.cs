using Flx.Domain.Domains;


namespace Flx.Data.Repository.IRepository
{
    public interface ICategoryRepo
    {
        public List<Category> FetchAllCategories();

        public Task<Category> FetchCategoryByIdAsync(long categoryId);
    }
}
