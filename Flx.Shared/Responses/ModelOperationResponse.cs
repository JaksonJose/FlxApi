
namespace Flx.Shared.Responses
{
    public class ModelOperationResponse : BaseResponse
    {
        public ModelOperationResponse() : base()
        {
        }

        /// <summary>
        /// How mwany row this affected
        /// </summary>
        /// <param name="operationCount"></param>
        public ModelOperationResponse(int operationCount) : base()
        {
            OperationCount = operationCount;
        }

        public int OperationCount { get; set; } = 0;

        public void Merge(ModelOperationResponse response)
        {
            base.Merge(response);
            OperationCount += response.OperationCount;
        }
    }
}