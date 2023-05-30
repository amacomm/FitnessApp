using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Fitness.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AuthResponse {
    /// <summary>
    /// Gets or Sets AccessToken
    /// </summary>
    [DataMember(Name="accessToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessToken")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Gets or Sets RefreshToken
    /// </summary>
    [DataMember(Name="refreshToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "refreshToken")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// Gets or Sets RefreshTokenExpiration
    /// </summary>
    [DataMember(Name="refreshTokenExpiration", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "refreshTokenExpiration")]
    public DateTime? RefreshTokenExpiration { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AuthResponse {\n");
      sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
      sb.Append("  RefreshToken: ").Append(RefreshToken).Append("\n");
      sb.Append("  RefreshTokenExpiration: ").Append(RefreshTokenExpiration).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
