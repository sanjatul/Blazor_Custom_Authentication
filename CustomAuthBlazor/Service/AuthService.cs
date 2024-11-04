
using CustomAuthBlazor.Models;
using CustomAuthBlazor.Service.Interface;
using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CustomAuthBlazor.Service
{
    public class AuthService:IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            _httpContextAccessor = httpContextAccessor;
        }
        //public async Task<UserDetails?> GetUserDetails(LoginModel loginModel)
        //{
        //    // Define parameters to pass to the stored procedure
        //    var parameters = new
        //    {
        //        Username = loginModel.Email,
        //        Password = loginModel.Password
        //    };



        //    // Call the stored procedure with parameters
        //    var user= await _connection.QueryFirstOrDefaultAsync<UserDetails>(
        //        "GetEmployeeDetails",
        //        parameters,
        //        commandType: System.Data.CommandType.StoredProcedure
        //    );
        //    if (user != null) {


        //        var claims = ToClaims(user);

        //        // Create an identity and principal
        //        var identity = new ClaimsIdentity(claims, Constants.AuthScheme);
        //        var principal = new ClaimsPrincipal(identity);

        //        // Set up authentication properties
        //        var authProperties = new AuthenticationProperties
        //        {
        //            IsPersistent = loginModel.RememberMe
        //        };

        //        // Sign in the user
        //        await _httpContextAccessor.HttpContext.SignInAsync(Constants.AuthScheme, principal, authProperties);
        //    }
        //    return user;
        //}
        public async Task<UserDetails?> GetUserDetails(LoginModel loginModel)
        {
            // Define parameters to pass to the stored procedure
            var parameters = new
            {
                Username = loginModel.Email,
                Password = loginModel.Password
            };

            // Call the stored procedure with parameters
            var user = await _connection.QueryFirstOrDefaultAsync<UserDetails>(
                "GetEmployeeDetails",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
            return user; // This return statement is correct as is
        }


    

    }
}
