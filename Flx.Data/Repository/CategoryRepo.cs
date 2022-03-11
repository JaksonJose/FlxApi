using Dapper;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
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
        private static readonly string InsertCategory = "INSERT INTO Category (Name, Description, Duration) VALUES";

        #endregion

        #region Properties
        private readonly IDbConnection _dbConnection;
        private readonly ICategoryBac _categoryBac;
        #endregion

        public CategoryRepo(IDbConnection dbconnection)
        {
            _dbConnection = dbconnection;
        }     

        /// <summary>
        /// Fetch All categories.
        /// </summary>
        /// <returns>InquiryResponse</returns>
        public async Task<CategoryInquiryResponse> FetchAllCategoriesAsync()
        {
            CategoryInquiryResponse response = new();
            
            try
            {             
                response.ResponseData = await this.FindAll();
            } 
            catch (Exception ex)
            {
                response.AddExceptionMessage("Exception in FetchAllCategoriesAsy");             
            }

            return response;
        }

        /// <summary>
        /// Fetch Course By Id with all lesson that belongs to it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>InquiryResponse</returns>
        public async Task<CategoryInquiryResponse> FetchCategoryByIdAsync(long categoryId)
        {
            CategoryInquiryResponse response = new();

            try
            {
                List<Category> categories = await this.FindAll();
              
                var selectedCategory = categories.Where(c => c.Id == categoryId).FirstOrDefault();

                if(selectedCategory != null ) response.ResponseData.Add(selectedCategory);
            }
            catch (Exception ex)
            {
                response.AddExceptionMessage("Exception in FetchCategoryByIdAsync");
            }           

            return response;
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<CategoryInquiryResponse> InsertCategoryAsync(ModelOperationRequest<Category> request, CategoryInquiryResponse response)
        {
            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', InsertCategory, $"('{request.Model.Name}', '{request.Model.Description}', {request.Model.Duration});");
            Template sqlTemplate = builder.AddTemplate(querySql);
            
            try
            {
                await _dbConnection.ExecuteAsync(sqlTemplate.RawSql);
            }
            catch (Exception ex)
            {
                response.AddExceptionMessage("Exception in FetchCategoryByIdAsync");
            }

            return response;
        }

        /// <summary>
        /// Find all categories and match the entities
        /// </summary>
        /// <returns>List<Category></returns>
        private async Task<List<Category>> FindAll()
        {
            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', SelectAllCategories, SelectAllSubcategories, SelectAllImages);
            Template sqlTemplate = builder.AddTemplate(querySql);

            GridReader responseData = await _dbConnection.QueryMultipleAsync(sqlTemplate.RawSql);

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
