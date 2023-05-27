using Dapper;
using Flx.Core.Interfaces.IRepository;
using Flx.Core.Models;
using Flx.Core.Responses;
using Flx.Shared.Requests;
using Microsoft.AspNetCore.Http;
using System.Data;
using static Dapper.SqlBuilder;
using static Dapper.SqlMapper;

namespace Flx.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private static readonly string SelectAllUsers = "SELECT Id," +
            " UserName," +
            " Email," +
            " PasswordHash," +
            " PasswordSalt," +
            " FirstName," +
            " LastName" +
            " FROM FlxUser";

        private static readonly string InsertUser = "INSERT INTO dbo.FlxUser(UserName, Email, EmailConfirmed, PasswordHash, PasswordSalt, FirstName, LastName) VALUES";

        private readonly IDbConnection _dbConnection;
        public UserRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Fetches user comparing by email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserInquiryResponse> FetchUserByEmailAsync(ModelOperationRequest<User> request)
        {
            UserInquiryResponse response = new();        

            try
            {
                //Build the SQL
                SqlBuilder builder = new();
                string querySql = string.Join(' ', SelectAllUsers, $"WHERE Email = '{request.Model.Email}'");
                Template sqlTemplate = builder.AddTemplate(querySql);

                IEnumerable<User> userResponse = await _dbConnection.QueryAsync<User>(sqlTemplate.RawSql);
                User? user = userResponse.FirstOrDefault();

                if (user != null)
                {
                    response.ResponseData.Add(user);

                    return response;
                }

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

        /// <summary>
        /// Fetch all Users
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> FetchAllUsersAsync()
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
