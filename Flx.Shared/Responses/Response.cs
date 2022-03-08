using Flx.Shared.Enums;
using Flx.Shared.Models;
using Flx.Shared.Responses.IResponses;

namespace Flx.Shared.Responses
{
    public abstract class Response : IResponse
    {
        public List<Message> Messages { get; set; } = new();

        /// <summary>
        /// Reflect if the message list has any messages
        /// </summary>
        public bool HasAnyMessages { get { return Messages.Count > 0; } }

        /// <summary>
        /// Reflect if there are any error message
        /// </summary>
        public bool HasErrorMessages { get { return HasMessageType(MessageTypeEnum.Error); } }

        public Response AddExceptionMessage()
        {
            Messages.Add(new Message(MessageTypeEnum.Exception));
            return this;
        }
        private bool HasMessageType(MessageTypeEnum messageType)
        {
            return Messages.Any(item => item.MessageType == messageType);
        }
    }
}
