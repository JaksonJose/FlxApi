using Dapper;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.IValidators;
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
        private readonly string LockedJoin = "INNER JOIN [dbo].[SubCategory] sc on sc.CourseId = @CategoryId";
        private readonly string WhereCaluse = "WHERE Category.Id = @CategoryId";

        #endregion

        private readonly IDbConnection _dbConnection;
        private readonly ICategoryValidator _categoryValidator;

        public CategoryRepo(IDbConnection dbconnection, ICategoryValidator categoryValidator)
        {
            _dbConnection = dbconnection;
            _categoryValidator = categoryValidator;
        }

        /// <summary>
        /// Fetch All courses.
        /// </summary>
        /// <returns>List<Course></returns>
        public async Task<InquiryResponse<Category>> FetchAllCategoriesAsync()
        {
            InquiryResponse<Category> response = new();

            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', "SELECT", SelectAllColumns, "FROM", SelectFromTableName);
            Template sqlTemplate = builder.AddTemplate(querySql);

            IEnumerable<Category> responseData = await _dbConnection.QueryAsync<Category>(sqlTemplate.RawSql);      

            response = _categoryValidator.ValidateCategoryList(responseData.ToList());

            response.ResponseData = responseData.ToList();

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

            response.ResponseData.Add(responseData.FirstOrDefault());

            return response;
        }
    }
}
