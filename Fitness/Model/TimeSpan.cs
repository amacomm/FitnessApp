using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Fitness.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TimeSpan {
    /// <summary>
    /// Gets or Sets Ticks
    /// </summary>
    [DataMember(Name="ticks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ticks")]
    public long? Ticks { get; set; }

    /// <summary>
    /// Gets or Sets Days
    /// </summary>
    [DataMember(Name="days", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "days")]
    public int? Days { get; set; }

    /// <summary>
    /// Gets or Sets Hours
    /// </summary>
    [DataMember(Name="hours", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hours")]
    public int? Hours { get; set; }

    /// <summary>
    /// Gets or Sets Milliseconds
    /// </summary>
    [DataMember(Name="milliseconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "milliseconds")]
    public int? Milliseconds { get; set; }

    /// <summary>
    /// Gets or Sets Microseconds
    /// </summary>
    [DataMember(Name="microseconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "microseconds")]
    public int? Microseconds { get; set; }

    /// <summary>
    /// Gets or Sets Nanoseconds
    /// </summary>
    [DataMember(Name="nanoseconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nanoseconds")]
    public int? Nanoseconds { get; set; }

    /// <summary>
    /// Gets or Sets Minutes
    /// </summary>
    [DataMember(Name="minutes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minutes")]
    public int? Minutes { get; set; }

    /// <summary>
    /// Gets or Sets Seconds
    /// </summary>
    [DataMember(Name="seconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "seconds")]
    public int? Seconds { get; set; }

    /// <summary>
    /// Gets or Sets TotalDays
    /// </summary>
    [DataMember(Name="totalDays", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalDays")]
    public double? TotalDays { get; set; }

    /// <summary>
    /// Gets or Sets TotalHours
    /// </summary>
    [DataMember(Name="totalHours", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalHours")]
    public double? TotalHours { get; set; }

    /// <summary>
    /// Gets or Sets TotalMilliseconds
    /// </summary>
    [DataMember(Name="totalMilliseconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalMilliseconds")]
    public double? TotalMilliseconds { get; set; }

    /// <summary>
    /// Gets or Sets TotalMicroseconds
    /// </summary>
    [DataMember(Name="totalMicroseconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalMicroseconds")]
    public double? TotalMicroseconds { get; set; }

    /// <summary>
    /// Gets or Sets TotalNanoseconds
    /// </summary>
    [DataMember(Name="totalNanoseconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalNanoseconds")]
    public double? TotalNanoseconds { get; set; }

    /// <summary>
    /// Gets or Sets TotalMinutes
    /// </summary>
    [DataMember(Name="totalMinutes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalMinutes")]
    public double? TotalMinutes { get; set; }

    /// <summary>
    /// Gets or Sets TotalSeconds
    /// </summary>
    [DataMember(Name="totalSeconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalSeconds")]
    public double? TotalSeconds { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TimeSpan {\n");
      sb.Append("  Ticks: ").Append(Ticks).Append("\n");
      sb.Append("  Days: ").Append(Days).Append("\n");
      sb.Append("  Hours: ").Append(Hours).Append("\n");
      sb.Append("  Milliseconds: ").Append(Milliseconds).Append("\n");
      sb.Append("  Microseconds: ").Append(Microseconds).Append("\n");
      sb.Append("  Nanoseconds: ").Append(Nanoseconds).Append("\n");
      sb.Append("  Minutes: ").Append(Minutes).Append("\n");
      sb.Append("  Seconds: ").Append(Seconds).Append("\n");
      sb.Append("  TotalDays: ").Append(TotalDays).Append("\n");
      sb.Append("  TotalHours: ").Append(TotalHours).Append("\n");
      sb.Append("  TotalMilliseconds: ").Append(TotalMilliseconds).Append("\n");
      sb.Append("  TotalMicroseconds: ").Append(TotalMicroseconds).Append("\n");
      sb.Append("  TotalNanoseconds: ").Append(TotalNanoseconds).Append("\n");
      sb.Append("  TotalMinutes: ").Append(TotalMinutes).Append("\n");
      sb.Append("  TotalSeconds: ").Append(TotalSeconds).Append("\n");
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
