using Flx.Shared.Models;
using System.Text.Json.Serialization;

namespace Flx.Core.Models
{
    public class BaseSAModel : BaseModel
    {
        /// <summary>
        /// The date the instace was created.
        /// </summary>
        [JsonIgnore]
        public DateTime CreateDateTimeUTC { get; set; }

        /// <summary>
        /// Set when user modify the instance
        /// </summary>
        [JsonIgnore]
        public DateTime ModifyDateTimeUTC { get; set; }
    }
}
