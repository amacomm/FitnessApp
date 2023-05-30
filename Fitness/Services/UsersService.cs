using Fitness.Client;
using Fitness.Model;
using Newtonsoft.Json;
using RestSharp;

namespace Fitness.Services
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUsersService
    {
        ///// <summary>
        ///// Edit user data 
        ///// </summary>
        ///// <param name="body"></param>
        ///// <returns></returns>
        Task ApiUsersEditUserPut (EditUserRequest body);
        /// <summary>
        /// Retrieve all users 
        /// </summary>
        /// <returns>List&lt;UserDto&gt;</returns>
        Task<List<UserDto>> ApiUsersGet ();
        /// <summary>
        /// Retrieve a specific user by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserDto</returns>
        Task<UserDto> ApiUsersIdGet(string id);
        /// <summary>
        /// Retrieve the profile image of a user 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>byte[]</returns>
        Task<byte[]> ApiUsersIdImageGet(string id);
        /// <summary>
        /// Attempt to login with provided credentials and get tokens if successful 
        /// </summary>
        /// <param name="body"></param>
        /// <returns>AuthResponse</returns>
        Task<AuthResponse> ApiUsersLoginPost(AuthRequest body);
        /// <summary>
        /// Retrieve currently logged in user 
        /// </summary>
        /// <returns>UserDto</returns>
        Task<UserDto> ApiUsersMeGet();
        /// <summary>
        /// Get new access and refresh tokens by active refresh token 
        /// </summary>
        /// <returns>AuthResponse</returns>
        Task<AuthResponse> ApiUsersRegenerateAccessTokenPost();
        /// <summary>
        /// Register new user 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task ApiUsersRegisterPost(RegisterRequest body);
        /// <summary>
        /// Revoke refresh token (revoke refresh token stored in cookie if no specific token provided) 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task ApiUsersRevokeTokenPost(RevokeTokenRequest body);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly ISettingsService _settingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        //public UsersService(ApiClient apiClient = null)
        //{
        //    if (apiClient == null) // use the default one in Configuration
        //        this.ApiClient = Configuration.DefaultApiClient; 
        //    else
        //        this.ApiClient = apiClient;
        //}
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            this.ApiClient = new ApiClient(_settingsService);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        public void SetAccessToken(string accessToken)
        {
            this.ApiClient.AccessToken = accessToken;
            _settingsService.AccessToken = accessToken;
        }

        public string GetAccessToken()
        {
            return this.ApiClient.AccessToken;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}

        /// <summary>
        /// Edit user data 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task ApiUsersEditUserPut(EditUserRequest body)
        {

            var path = "/api/Users/editUser";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { $"Bearer {GetAccessToken()}" };

            // make the HTTP request
            var response = await ApiClient.CallApi(path, Method.Put, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersEditUserPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersEditUserPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Retrieve all users 
        /// </summary>
        /// <returns>List&lt;UserDto&gt;</returns>
        public async Task<List<UserDto>> ApiUsersGet ()
        {
            var path = "/api/Users";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            //String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            var response = await ApiClient.CallApi<List<UserDto>>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, null);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiUsersGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiUsersGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        /// <summary>
        /// Retrieve a specific user by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserDto</returns>
        public async Task<UserDto> ApiUsersIdGet(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiUsersIdGet");

            var path = "/api/Users/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            //String[] authSettings = new String[] { "Bearer" };

            // make the HTTP request
            var response = await ApiClient.CallApi<UserDto>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, null);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersIdGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        /// <summary>
        /// Retrieve the profile image of a user 
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns > byte[] </ returns >
        public async Task<byte[]> ApiUsersIdImageGet(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiUsersIdImageGet");

            var path = "/api/Users/{id}/image";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            //String[] authSettings = new String[] { "Bearer" };

            // make the HTTP request
            var response = await ApiClient.CallApi<byte[]>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, null);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersIdImageGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersIdImageGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        /// <summary>
        /// Attempt to login with provided credentials and get tokens if successful 
        /// </summary>
        /// <param name = "body" ></ param >
        /// < returns > AuthResponse </ returns >
        public async Task<AuthResponse> ApiUsersLoginPost(AuthRequest body)
        {

            var path = "/api/Users/login";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { $"Bearer {GetAccessToken()}" };

            // make the HTTP request
            var response = await ApiClient.CallApi<AuthResponse>(path, Method.Post, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersLoginPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersLoginPost: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        /// <summary>
        /// Retrieve currently logged in user 
        /// </summary>
        /// <returns>UserDto</returns>
        public async Task<UserDto> ApiUsersMeGet()
        {

            var path = "/api/Users/me";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { $"Bearer {GetAccessToken()}" };

            // make the HTTP request
            var response = await ApiClient.CallApi<UserDto>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersMeGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersMeGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        /// <summary>
        /// Get new access and refresh tokens by active refresh token 
        /// </summary>
        /// <returns>AuthResponse</returns>
        public async Task<AuthResponse> ApiUsersRegenerateAccessTokenPost()
        {

            var path = "/api/Users/regenerateAccessToken";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };

            // make the HTTP request
            var response = await ApiClient.CallApi<AuthResponse>(path, Method.Post, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersRegenerateAccessTokenPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersRegenerateAccessTokenPost: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        ///// <summary>
        ///// Register new user 
        ///// </summary>
        ///// <param name = "body" ></ param >
        ///// < returns ></ returns >
        public async Task ApiUsersRegisterPost(RegisterRequest body)
        {

            var path = "/api/Users/register";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { $"Bearer {GetAccessToken()}" };

            // make the HTTP request
            var response = await ApiClient.CallApi(path, Method.Post, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersRegisterPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersRegisterPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        ///// <summary>
        ///// Revoke refresh token(revoke refresh token stored in cookie if no specific token provided)
        ///// </summary>
        ///// <param name = "body" ></ param >
        ///// < returns ></ returns >
        public async Task ApiUsersRevokeTokenPost(RevokeTokenRequest body)
        {

            var path = "/api/Users/revokeToken";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { $"Bearer {GetAccessToken()}" };

            // make the HTTP request
            var response = await ApiClient.CallApi(path, Method.Post, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersRevokeTokenPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiUsersRevokeTokenPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

    }
}
