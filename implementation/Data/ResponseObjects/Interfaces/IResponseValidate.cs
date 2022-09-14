using implementation.Data.ResponseObjects;

namespace implementation.Data.ResponseObjects.Interfaces
{
    public interface IResponseValidate
    {
        public void Validate(ref ResultResponse response);
    }
}