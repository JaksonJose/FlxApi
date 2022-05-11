namespace Flx.Shared.Responses.IResponses
{
    public interface IInquiryResponse<T>
    {
        public List<T> ResponseData { get; set; }
    }
}
