using System.Text.Json.Serialization;

namespace Beis.RegisterYourInterest.Data.Entities
{
    public class RegisteredOfficeAddress: Beis.Common.Services.CompanyHouseApi.RegisteredOfficeAddress
    {
        [Key]
        public int id { get; set; }

        [JsonPropertyName("registered_office_address")]
        public RegisteredOfficeAddress registered_office_address { get; set; }
    }
}
