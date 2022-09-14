using implementation.Data.ResponseObjects.Interfaces;

namespace implementation.Data.ResponseObjects
{
    public class ResultResponse : IResponse
    {
        public object Data { get; private set; }

        public List<string> RequiredFields { get; private set; } = new List<string>();
        public List<string> Errors { get; private set; } = new List<string>();
        
        public bool IsOk() => !RequiredFields.Any() && !Errors.Any();

        public void SetData(object data) => Data = data;

        public void SetErrors(params string[] errors) => Errors.AddRange(errors);

        public void SetRequiredFields(params string[] requiredFields) => RequiredFields.AddRange(requiredFields);
    }
}