using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Common
{
    class DataOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string DateFormat = "yyyy-dd-MM"; // Define the date format

        // Read (Deserialize) DateOnly from JSON
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException("Expected a string for DateOnly.");
            }

            var dateString = reader.GetString();
            if (DateOnly.TryParseExact(dateString, DateFormat, null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }

            throw new JsonException($"Invalid date format. Expected format: {DateFormat}");
        }

       
        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }


    }
}
