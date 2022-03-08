using Flx.Shared.Enums;
using Flx.Shared.Models;
using Flx.Shared.Responses.IResponses;

namespace Flx.Shared.Responses
{
    public abstract class Response : IResponse
    {
        #region Properties

        public List<Message> Messages { get; set; } = new();

        /// <summary>
        /// Reflect if the message list has any messages
        /// </summary>
        public bool HasAnyMessages { get { return Messages.Count > 0; } }

        /// <summary>
        /// Reflect if there are any error message
        /// </summary>
        public bool HasErrorMessages { get { return HasMessageType(MessageTypeEnum.Error); } }

        #endregion

        #region Public Method
        public Response AddErrorMessage(string text)
        {
            Messages.Add(new Message(MessageTypeEnum.Error, text));
            return this;
        }

        public Response AddExceptionMessage(string text)
        {
            Messages.Add(new Message(MessageTypeEnum.Exception, text));
            return this;
        }

        #endregion

        #region Private Method

        private bool HasMessageType(MessageTypeEnum messageType)
        {
            return Messages.Any(item => item.MessageType == messageType);
        }

        #endregion
    }
}
