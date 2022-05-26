using Flx.Shared.Models.IModels;

namespace Flx.Shared.Requests
{
    public class ModelOperationRequest<T> : BaseRequest where T : IModel
    {
        public ModelOperationRequest()
        {
        }

        public ModelOperationRequest(T model)
        {
            this.Model = model;
        }

        public T Model { get; set; }
    }
}
