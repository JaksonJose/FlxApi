
namespace Flx.Shared.Responses.IResponses
{
    public interface IResponse
    {
        /// <summary>
        /// Does it have any messages
        /// </summary>
        bool HasAnyMessages { get; }
        public bool HasErrorMessages { get; }
    }
}
