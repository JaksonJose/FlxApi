using Dapper;
using Flx.Data.Repository.IRepository;
using Flx.Domain.Domains;
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

        public CategoryRepo(IDbConnection dbconnection)
        {
            _dbConnection = dbconnection;
        }

        /// <summary>
        /// Fetch All courses.
        /// </summary>
        /// <returns>List<Course></returns>
        public List<Category> FetchAllCategories()
        {         
            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', "SELECT", SelectAllColumns, "FROM", SelectFromTableName);
            Template sqlTemplate = builder.AddTemplate(querySql);

            IEnumerable<Category> response = _dbConnection.Query<Category>(sqlTemplate.RawSql);

            return response.ToList();
        }

        /// <summary>
        /// Fetch Course By Id with all lesson that belongs to it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<Course></returns>
        public async Task<Category> FetchCategoryByIdAsync(long categoryId)
        {
            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', "SELECT", SelectAllColumns, "FROM", SelectFromTableName, LockedJoin, WhereCaluse);
            string sql = querySql.Replace("@CategoryId", $"{categoryId}");
            Template template = builder.AddTemplate(sql);

            var categoryDic = new Dictionary<int, Category>();

            IEnumerable<Category> response = await _dbConnection.QueryAsync<Category, SubCategory, Category>(template.RawSql, (category, subcategory) =>
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

            return response.FirstOrDefault();
        }
    }
}
