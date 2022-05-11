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
        private static readonly string SelectAllUsers = "SELECT Id, UserName, Email, EmailConfirmed, PasswordHash, PasswordSalt, FirstName, LastName FROM FlxUser;";
        private static readonly string InsertUser = "INSERT INTO dbo.FlxUser(UserName, Email, EmailConfirmed, PasswordHash, PasswordSalt, FirstName, LastName) VALUES";

        private readonly IDbConnection _dbConnection;
        public UserRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Fetch user comparing by email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserInquiryResponse> FetchUserByEmail(ModelOperationRequest<SignIn> request)
        {
            UserInquiryResponse response = new();
            List<User> users = new();            

            try
            {
                users = await this.FindAllUsers();

                List<User> selectedUser = users.FindAll(u => u.Email == request.Model.Email);

                response.ResponseData.AddRange(selectedUser);

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
                string querySql = string.Join(' ', InsertUser, $"('{request.Model.UserName}', '{request.Model.Email}', {Convert.ToInt32(request.Model.EmailConfirmed)}, '{request.Model.PasswordHash}', '{request.Model.PasswordSalt}', '{request.Model.FirstName}', '{request.Model.LastName}')");
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
            //Build the SQL
            SqlBuilder builder = new();
            string querySql = string.Join(' ', SelectAllUsers);
            Template sqlTemplate = builder.AddTemplate(querySql);

            IEnumerable<User> responseData = await _dbConnection.QueryAsync<User>(sqlTemplate.RawSql);

            List<User> users = responseData.ToList();

            return users;         
        }
    }
}
