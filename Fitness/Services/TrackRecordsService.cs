using Fitness.Client;
using Fitness.Model;
using RestSharp;

namespace Fitness.Services
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITrackRecordsService
    {
        /// <summary>
        /// Remove a track record 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //void ApiTrackRecordsIdDelete (int? id);
        /// <summary>
        /// Get a track record by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TrackRecordDto</returns>
        Task<TrackRecordDto> ApiTrackRecordsIdGet(int? id);
        /// <summary>
        /// Add a new track record to current user 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task ApiTrackRecordsPost(AddTrackRecordRequest body);
        /// <summary>
        /// Edit an existing track record 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task ApiTrackRecordsPut(EditTrackRecordRequest body);
        /// <summary>
        /// Get track records for a user 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List&lt;TrackRecordDto&gt;</returns>
        Task<List<TrackRecordDto>> ApiTrackRecordsUserUserIdGet(string userId);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TrackRecordsService : ITrackRecordsService
    {
        private readonly ISettingsService _settingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackRecordsService"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        //public TrackRecordsService(ApiClient apiClient = null)
        //{
        //    if (apiClient == null) // use the default one in Configuration
        //        this.ApiClient = Configuration.DefaultApiClient; 
        //    else
        //        this.ApiClient = apiClient;
        //}
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackRecordsService"/> class.
        /// </summary>
        /// <returns></returns>
        public TrackRecordsService(ISettingsService settingsService)
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
        /// Remove a track record 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ApiTrackRecordsIdDelete(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiTrackRecordsIdDelete");

            var path = "/api/TrackRecords/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

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
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsIdDelete: " + response.Content, response.Content);

        }

        /// <summary>
        /// Get a track record by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TrackRecordDto</returns>
        public async Task<TrackRecordDto> ApiTrackRecordsIdGet(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiTrackRecordsIdGet");

            var path = "/api/TrackRecords/{id}";
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
            var response = await ApiClient.CallApi<TrackRecordDto>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, null);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsIdGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

        /// <summary>
        /// Add a new track record to current user 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task ApiTrackRecordsPost(AddTrackRecordRequest body)
        {

            var path = "/api/TrackRecords";
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
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsPost: " + response.ErrorMessage, response.ErrorMessage);
        }

        /// <summary>
        /// Edit an existing track record 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task ApiTrackRecordsPut(EditTrackRecordRequest body)
        {

            var path = "/api/TrackRecords";
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
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsPut: " + response.ErrorMessage, response.ErrorMessage);
        }

        /// <summary>
        /// Get track records for a user 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List&lt;TrackRecordDto&gt;</returns>
        public async Task<List<TrackRecordDto>> ApiTrackRecordsUserUserIdGet(string userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling ApiTrackRecordsUserUserIdGet");

            var path = "/api/TrackRecords/user/{userId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "userId" + "}", ApiClient.ParameterToString(userId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            //String[] authSettings = new String[] { "Bearer" };

            // make the HTTP request
            var response = await ApiClient.CallApi<List<TrackRecordDto>>(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, null);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsUserUserIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiTrackRecordsUserUserIdGet: " + response.ErrorMessage, response.ErrorMessage);

            return response.Data;
        }

    }
}
