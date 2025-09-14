using LinkDev.IKEA.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Common.JsonConverter
{
    class EmployeeTypeJsonCoverter : JsonConverter<EmployeeType>
    {
        public override EmployeeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var employeetypeAsString = reader.GetString();
            return employeetypeAsString?.ToLower() switch
            {
                "fulltime" => EmployeeType.FullTime,
                "parttime" => EmployeeType.PartTime,
                "intern" => EmployeeType.Intern,
                _ => EmployeeType.FullTime

            };
        }

        public override void Write(Utf8JsonWriter writer, EmployeeType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
