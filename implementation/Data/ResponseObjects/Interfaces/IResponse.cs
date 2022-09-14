namespace implementation.Data.ResponseObjects.Interfaces
{
    public interface IResponse
    {
        public bool IsOk();

        public void SetErrors(params string[] errors);

        public void SetRequiredFields(params string[] requiredFields);

        public void SetData(object data);
    }
}