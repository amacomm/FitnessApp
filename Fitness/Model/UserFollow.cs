using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Fitness.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class UserFollow {
    /// <summary>
    /// Gets or Sets FollowingUserId
    /// </summary>
    [DataMember(Name="followingUserId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "followingUserId")]
    public string FollowingUserId { get; set; }

    /// <summary>
    /// Gets or Sets FollowedUserId
    /// </summary>
    [DataMember(Name="followedUserId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "followedUserId")]
    public string FollowedUserId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UserFollow {\n");
      sb.Append("  FollowingUserId: ").Append(FollowingUserId).Append("\n");
      sb.Append("  FollowedUserId: ").Append(FollowedUserId).Append("\n");
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
