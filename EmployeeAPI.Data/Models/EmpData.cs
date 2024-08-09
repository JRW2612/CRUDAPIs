using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmployeeAPI.Data.Models
{

    public enum Gender
    {
        Male=0, Female=1,Others=2
    }

    public class EmpData
    {
        [Key]
        public int RowId { get; set; }

        [JsonIgnore]
        public string? EmployeeCode { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required int CountryId { get; set; }

        public required int StateId { get;set; }

        public required int CityId { get; set; }

        public required string Email { get; set; }

        public required long Phone { get; set; }

        public required string PAN { get; set; }

        public required string Passport { get; set; }

        public string Image { get; set; }
        public required Gender gender { get; set; }

        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DoB { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Doj { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime UpdatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

       

    }


    public static class JsonConverters
    {
        public static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            Converters =
        {
            new JsonStringEnumConverter(),
            new DateOnlyJsonConverter(),
            new DateTimeJsonConverter()
        }
        };
    }

    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.ParseExact(value, Format);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }

    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-ddTHH:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateTime.ParseExact(value, Format, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }

}
