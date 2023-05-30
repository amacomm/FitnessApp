using Fitness.Client;
using Fitness.Model;
using RestSharp;

namespace Fitness.Services
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFollowsService
    {
        /// <summary>
        /// Remove a user follow 
        /// </summary>
        /// <param name="followedUserId"></param>
        /// <returns></returns>
        Task ApiFollowsFollowedUserIdDelete(string followedUserId);
        /// <summary>
        /// Add a new user follow 
        /// </summary>
        /// <param name="followedUserId"></param>
        /// <returns></returns>
        Task ApiFollowsFollowedUserIdPost(string followedUserId);
        /// <summary>
        /// Get user followers by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List&lt;UserFollow&gt;</returns>
        Task<List<UserFollow>> ApiFollowsIdFollowersGet(string id);
        /// <summary>
        /// Get user follows by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List&lt;UserFollow&gt;</returns>
        Task<List<UserFollow>> ApiFollowsIdGet(string id);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class FollowsService : IFollowsService
    {
        private readonly ISettingsService _settingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FollowsService"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        //public FollowsService(ApiClient apiClient = null)
        //{
        //    if (apiClient == null) // use the default one in Configuration
        //        this.ApiClient = Configuration.DefaultApiClient; 
        //    else
        //        this.ApiClient = apiClient;
        //}
    
        /// <summary>
        /// Initializes a new instance of the <see cref="FollowsService"/> class.
        /// </summary>
        /// <returns></returns>
        public FollowsService(ISettingsService settingsService)
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
        public String GetBasePath()
        {
            return this.ApiClient.BasePath;
        }

        public void SetAccessToken(string accessToken)
        {
            this.ApiClient.AccessToken = accessToken;
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
        /// Remove a user follow 
        /// </summary>
        /// <param name="followedUserId"></param>
        /// <returns></returns>
        public async Task ApiFollowsFollowedUserIdDelete(string followedUserId)
        {
            // verify the required parameter 'followedUserId' is set
            if (followedUserId == null) throw new ApiException(400, "Missing required parameter 'followedUserId' when calling ApiFollowsFollowedUserIdDelete");

            var path = "/api/Follows/{followedUserId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "followedUserId" + "}", ApiClient.ParameterToString(followedUserId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { $"Bearer {GetAccessToken()}" };

            // make the HTTP request
            var response = await ApiClient.CallApi(path, Method.Delete, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsFollowedUserIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsFollowedUserIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Add a new user follow 
        /// </summary>
        /// <param name="followedUserId"></param>
        /// <returns></returns>
        public async Task ApiFollowsFollowedUserIdPost(string followedUserId)
        {
            // verify the required parameter 'followedUserId' is set
            if (followedUserId == null) throw new ApiException(400, "Missing required parameter 'followedUserId' when calling ApiFollowsFollowedUserIdPost");

            var path = "/api/Follows/{followedUserId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "followedUserId" + "}", ApiClient.ParameterToString(followedUserId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { $"Bearer {GetAccessToken()}" };

            // make the HTTP request
            var response = await ApiClient.CallApi(path, Method.Post, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsFollowedUserIdPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsFollowedUserIdPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Get user followers by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List&lt;UserFollow&gt;</returns>
        public async Task<List<UserFollow>> ApiFollowsIdFollowersGet(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiFollowsIdFollowersGet");

            var path = "/api/Follows/{id}/followers";
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
            var response = await ApiClient.CallApi<List<UserFollow>>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, null);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsIdFollowersGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsIdFollowersGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        /// <summary>
        /// Get user follows by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List&lt;UserFollow&gt;</returns>
        public async Task<List<UserFollow>> ApiFollowsIdGet(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiFollowsIdGet");

            var path = "/api/Follows/{id}";
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
            var response = await ApiClient.CallApi<List<UserFollow>>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, null);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiFollowsIdGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

    }
}
