using Flx.Domain.Responses.IResponses;

namespace Flx.Domain.Responses
{
    public abstract class Response : IResponse
    {
        public List<string> Messages { get; set; } = new();

        /// <summary>
        /// Reflect if the message list has any messages
        /// </summary>
        public bool HasAnyMessages { get { return Messages.Count > 0; } }

        /// <summary>
        /// Reflect if there are any error message
        /// </summary>
        public bool HasErrorMessages { get; }
    }
}
