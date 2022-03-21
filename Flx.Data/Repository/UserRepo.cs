using Dapper;
using Flx.Data.Repository.IRepository;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Microsoft.AspNetCore.Http;
using System.Data;
using static Dapper.SqlBuilder;
using static Dapper.SqlMapper;

namespace Flx.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private static readonly string SelectAllUsers = "SELECT Id, UseName, Email, FirstName, LastName FROM FlxUser;";
        private static readonly string InsertUser = "INSERT INTO dbo.FlxUser(UserName, Email, EmailConfirmed, PasswordHash, FirstName, LastName) VALUES";

        private readonly IDbConnection _dbConnection;
        public UserRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Fetch user comparing by email
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task<UserInquiryResponse> FetchUserByEmail(ModelOperationRequest<Auth> request, UserInquiryResponse response)
        {
            List<User> users = new();

            try
            {
                users = await this.FindAllUsers();

                User selectedUser = response.ResponseData.Where(c => c.Email == request.Model.Email).FirstOrDefault();

                if (selectedUser != null) response.ResponseData.Add(selectedUser);

                return response;
            }
            catch
            {
                response.AddExceptionMessage("Error while trying to fetch the users: FindAllUsers method", StatusCodes.Status500InternalServerError);
                return response;
            }         
        }

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserInquiryResponse> InsertUserAsync(ModelOperationRequest<User> request)
        {
            UserInquiryResponse response = new();

            try
            {
                //Build the SQL
                SqlBuilder builder = new();
                string querySql = string.Join(' ', InsertUser, $"('{request.Model.UserName}', '{request.Model.Email}', {request.Model.EmailConfirmed}, '{request.Model.PasswordHash}', '{request.Model.FirstName}', '{request.Model.LastName}');");
                Template sqlTemplate = builder.AddTemplate(querySql);

                await _dbConnection.ExecuteAsync(sqlTemplate.RawSql);

                return response;
            }
            catch
            {
                response.AddExceptionMessage("Error while trying to Insert a user: FindAllUsers method", StatusCodes.Status500InternalServerError);
                return response;
            }    
        }

        private async Task<List<User>> FindAllUsers()
        {
            List<User> users = new();

            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', "SELECT Id, Email, FirstName, LastName FROM FlxUser");
            Template sqlTemplate = builder.AddTemplate(querySql);

            IEnumerable<User> responseData = await _dbConnection.QueryAsync<User>(sqlTemplate.RawSql);
            
            users = responseData.ToList();

            return users;         
        }
    }
}
