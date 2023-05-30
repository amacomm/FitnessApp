using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Fitness.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class EditUserRequest {
    /// <summary>
    /// Gets or Sets ProfileImage
    /// </summary>
    [DataMember(Name="profileImage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "profileImage")]
    public byte[] ProfileImage { get; set; }

    /// <summary>
    /// Gets or Sets FirstName
    /// </summary>
    [DataMember(Name="firstName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or Sets LastName
    /// </summary>
    [DataMember(Name="lastName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or Sets DateOfBirth
    /// </summary>
    [DataMember(Name="dateOfBirth", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dateOfBirth")]
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Gets or Sets Gender
    /// </summary>
    [DataMember(Name="gender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gender")]
    public Gender Gender { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class EditUserRequest {\n");
      sb.Append("  ProfileImage: ").Append(ProfileImage).Append("\n");
      sb.Append("  FirstName: ").Append(FirstName).Append("\n");
      sb.Append("  LastName: ").Append(LastName).Append("\n");
      sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
      sb.Append("  Gender: ").Append(Gender).Append("\n");
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
