using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Fitness.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Gpx {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or Sets Points
    /// </summary>
    [DataMember(Name="points", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "points")]
    public List<Point> Points { get; set; }

    /// <summary>
    /// Gets or Sets Creator
    /// </summary>
    [DataMember(Name="creator", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creator")]
    public string Creator { get; set; }

    /// <summary>
    /// Gets or Sets Version
    /// </summary>
    [DataMember(Name="version", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "version")]
    public string Version { get; set; }

    /// <summary>
    /// Gets or Sets MinLon
    /// </summary>
    [DataMember(Name="minLon", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minLon")]
    public float? MinLon { get; set; }

    /// <summary>
    /// Gets or Sets MinLat
    /// </summary>
    [DataMember(Name="minLat", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minLat")]
    public float? MinLat { get; set; }

    /// <summary>
    /// Gets or Sets MaxLon
    /// </summary>
    [DataMember(Name="maxLon", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxLon")]
    public float? MaxLon { get; set; }

    /// <summary>
    /// Gets or Sets MaxLat
    /// </summary>
    [DataMember(Name="maxLat", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxLat")]
    public float? MaxLat { get; set; }

    /// <summary>
    /// Gets or Sets AllTime
    /// </summary>
    [DataMember(Name="allTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "allTime")]
    public TimeSpan AllTime { get; set; }

    /// <summary>
    /// Gets or Sets Distance2D
    /// </summary>
    [DataMember(Name="distance2D", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "distance2D")]
    public float? Distance2D { get; set; }

    /// <summary>
    /// Gets or Sets Distance3D
    /// </summary>
    [DataMember(Name="distance3D", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "distance3D")]
    public float? Distance3D { get; set; }

    /// <summary>
    /// Gets or Sets MaxSpeed
    /// </summary>
    [DataMember(Name="maxSpeed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxSpeed")]
    public float? MaxSpeed { get; set; }

    /// <summary>
    /// Gets or Sets AvgSpeed
    /// </summary>
    [DataMember(Name="avgSpeed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "avgSpeed")]
    public float? AvgSpeed { get; set; }

    /// <summary>
    /// Gets or Sets Limb
    /// </summary>
    [DataMember(Name="сlimb", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "сlimb")]
    public float? Limb { get; set; }

    /// <summary>
    /// Gets or Sets MaxAlt
    /// </summary>
    [DataMember(Name="maxAlt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxAlt")]
    public float? MaxAlt { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Gpx {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Points: ").Append(Points).Append("\n");
      sb.Append("  Creator: ").Append(Creator).Append("\n");
      sb.Append("  Version: ").Append(Version).Append("\n");
      sb.Append("  MinLon: ").Append(MinLon).Append("\n");
      sb.Append("  MinLat: ").Append(MinLat).Append("\n");
      sb.Append("  MaxLon: ").Append(MaxLon).Append("\n");
      sb.Append("  MaxLat: ").Append(MaxLat).Append("\n");
      sb.Append("  AllTime: ").Append(AllTime).Append("\n");
      sb.Append("  Distance2D: ").Append(Distance2D).Append("\n");
      sb.Append("  Distance3D: ").Append(Distance3D).Append("\n");
      sb.Append("  MaxSpeed: ").Append(MaxSpeed).Append("\n");
      sb.Append("  AvgSpeed: ").Append(AvgSpeed).Append("\n");
      sb.Append("  Limb: ").Append(Limb).Append("\n");
      sb.Append("  MaxAlt: ").Append(MaxAlt).Append("\n");
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
