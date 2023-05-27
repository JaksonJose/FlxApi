using Flx.Shared.Enums;
using Flx.Shared.Models.IModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Flx.Shared.Models
{
    public class BaseModel: IModel
    {
        [NotMapped]
        [JsonIgnore]
        public ModelActionEnum Action { get; set; }
    }
}