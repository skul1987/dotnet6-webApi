using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EmployeeType
    {
        Permanant =1,

        Contract=2,

        Temparary=3


    }
}