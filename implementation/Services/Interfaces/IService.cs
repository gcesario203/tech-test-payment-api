using implementation.Data.ResponseObjects.Interfaces;
using implementation.Models.Enums;

namespace implementation.Services.Interfaces
{
    public interface IService<TDto, TResponse> where TResponse : IResponse
    {
        TResponse GetAll();

        TResponse GetById(int id);

        TResponse Create(TDto item);

        TResponse Update(int id, TDto item);

        TResponse Delete(int id);

        TResponse UpdateStatus(int id, OrderStatus status);
    }
}