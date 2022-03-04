using Dapper;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using System.Data;
using static Dapper.SqlBuilder;

namespace Flx.Data.Repository
{
    public class CategoryRepo: ICategoryRepo
    {
        #region SQL

        private static readonly string SelectAllColumns = "*";

        private readonly string SelectFromTableName = "Category";
        private readonly string LockedJoin = "LEFT OUTER JOIN [dbo].[SubCategory] sb on sb.CategoryId = Category.Id";
        private readonly string WhereCaluse = "WHERE Category.Id = @CategoryId";

        #endregion

        private readonly IDbConnection _dbConnection;
        private readonly ICategoryBac _categoryBac;

        public CategoryRepo(IDbConnection dbconnection, ICategoryBac categoryBac)
        {
            _dbConnection = dbconnection;
            _categoryBac = categoryBac;
        }

        /// <summary>
        /// Fetch All courses.
        /// </summary>
        /// <returns>List<Course></returns>
        public async Task<InquiryResponse<Category>> FetchAllCategoriesAsync()
        {
            InquiryResponse<Category> response = new();
            List<Category> categoryList = new();

            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', "SELECT", SelectAllColumns, "FROM", SelectFromTableName, LockedJoin);
            Template sqlTemplate = builder.AddTemplate(querySql);

            var categoryDic = new Dictionary<int, Category>();

            IEnumerable<Category> responseData = await _dbConnection.QueryAsync<Category, SubCategory, Category>(sqlTemplate.RawSql, (category, subcategory) =>
            {
                Category currentCategory = new();

                if (!categoryDic.TryGetValue(category.Id, out currentCategory!))
                {
                    categoryDic.Add(category.Id, currentCategory = category);
                }

                if (currentCategory.SubCategories == null)
                {
                    currentCategory.SubCategories = new List<SubCategory>();
                }

                currentCategory.SubCategories.Add(subcategory);

                return currentCategory;
            }, splitOn: "Id");
       
            response.ResponseData.AddRange(responseData.Distinct());           

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

            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', "SELECT", SelectAllColumns, "FROM", SelectFromTableName, LockedJoin, WhereCaluse);
            string sql = querySql.Replace("@CategoryId", $"{categoryId}");
            Template template = builder.AddTemplate(sql);

            var categoryDic = new Dictionary<int, Category>();

            IEnumerable<Category> responseData = await _dbConnection.QueryAsync<Category, SubCategory, Category>(template.RawSql, (category, subcategory) =>
            {
                Category currentCategory = new();

                if (!categoryDic.TryGetValue(category.Id, out currentCategory!))
                {
                    categoryDic.Add(category.Id, currentCategory = category);
                }

                if (currentCategory.SubCategories == null)
                {
                    currentCategory.SubCategories = new List<SubCategory>();
                }

                currentCategory.SubCategories.Add(subcategory);

                return currentCategory;
            }, splitOn: "Id");

            IEnumerable<Image> responseImage = await _dbConnection.QueryAsync<Image>("Select * from Image where CategoryId = 1");

            foreach(var category in responseData.Distinct())
            {
                category.Images = responseImage.ToList();
                response.ResponseData.Add(category);
            }

            return response;
        }
    }
}
