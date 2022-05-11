using Flx.Shared.Models;

namespace Flx.Shared.Responses.IResponses
{
    public interface IBaseResponse
    {
        /// <summary>
        /// Does it have any messages?
        /// </summary>
        public bool HasAnyMessages { get; }

        /// <summary>
        /// Does it have Error messages?
        /// </summary>
        public bool HasErrorMessages { get; }

        /// <summary>
        /// Does it have Information messages?
        /// </summary>
        public bool HasInformationMessages { get; }

        /// <summary>
        /// Does it have Validation messages?
        /// </summary>
        public bool HasValidationMessages { get; }

        public List<Message> Messages { get; set; }

        /// <summary>
        /// Method to add error messages
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public BaseResponse AddErrorMessage(string text, int? status = null);

        /// <summary>
        /// Method to add Exception Messages
        /// </summary>
        /// <param name="text"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public BaseResponse AddExceptionMessage(string text, int? status = null);

        /// <summary>
        /// Method to add Infomation Messages
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public BaseResponse AddInfoMessage(string text, int? status = null);

        /// <summary>
        /// Method to add Validation messages
        /// </summary>
        /// <param name="status"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public BaseResponse AddValidationMessage(string text, int? status = null);

        /// <summary>
        /// Method to add Warning Messages
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public BaseResponse AddWarningMessage(string text, int? status = null);
    }
}
