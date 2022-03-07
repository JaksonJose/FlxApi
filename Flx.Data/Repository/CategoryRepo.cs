using Dapper;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using System.Data;
using static Dapper.SqlBuilder;
using static Dapper.SqlMapper;

namespace Flx.Data.Repository
{
    public class CategoryRepo: ICategoryRepo
    {
        #region SQL

        private static readonly string SelectAllCategories = "SELECT * FROM Category;";
        private static readonly string SelectAllSubcategories = "SELECT * FROM Subcategory;";
        private static readonly string SelectAllImages = "SELECT * FROM Image;";

        #endregion

        private readonly IDbConnection _dbConnection;
        private readonly ICategoryBac _categoryBac;

        public CategoryRepo(IDbConnection dbconnection)
        {
            _dbConnection = dbconnection;
        }

        /// <summary>
        /// Fetch All categories.
        /// </summary>
        /// <returns>List<Course></returns>
        public async Task<InquiryResponse<Category>> FetchAllCategoriesAsync()
        {
            InquiryResponse<Category> response = new();
            response.ResponseData = await this.FindAll();

            return response;
        }

        /// <summary>
        /// Fetch Course By Id with all lesson that belongs to it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<Course></returns>
        public async Task<InquiryResponse<Category>> FetchCategoryByIdAsync(long categoryId)
        {
            InquiryResponse<Category> response = new();

            List<Category> categories = await this.FindAll();

            Category selectedCategory = categories.Where(c => c.Id == categoryId).FirstOrDefault();

            response.ResponseData.Add(selectedCategory);

            return response;
        }

        /// <summary>
        /// Find all categories and match the entities
        /// </summary>
        /// <returns></returns>
        private async Task<List<Category>> FindAll()
        {
            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', SelectAllCategories, SelectAllSubcategories, SelectAllImages);
            Template sqlTemplate = builder.AddTemplate(querySql);

            var responseData = await _dbConnection.QueryMultipleAsync(sqlTemplate.RawSql);

            List<Category> categories = responseData.Read<Category>().ToList();
            List<SubCategory> subCategories = responseData.Read<SubCategory>().ToList();
            List<Image> images = responseData.Read<Image>().ToList();

            categories.ForEach(c =>
            {
                c.SubCategories = subCategories.Where(sb => sb.CategoryId == c.Id).ToList();
                c.Images = images.Where(im => im.CategoryId == c.Id).ToList();
            });

            return categories;
        }
    }
}
