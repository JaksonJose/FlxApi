
using Flx.Shared.Models;

namespace Flx.Shared.Responses.IResponses
{
    public interface IResponse
    {
        /// <summary>
        /// Does it have any messages
        /// </summary>
        public bool HasAnyMessages { get; }
        public bool HasErrorMessages { get; }

        public List<Message> Messages { get; set; }
    }
}
