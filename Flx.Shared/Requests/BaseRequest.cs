namespace Flx.Shared.Requests
{
    public class BaseRequest : IBaseRquest
    {
        /// <summary>
        /// The user that makes the request
        /// </summary>
        public string User { get; set; } = "System Default";
    }
}
