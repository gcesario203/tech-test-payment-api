
using AutoMapper;
using implementation.Data;
using implementation.Data.ResponseObjects;
using implementation.Data.ResponseObjects.Interfaces;
using implementation.Models;
using implementation.Models.Enums;
using implementation.Repositories.Interfaces;
using implementation.Services.Interfaces;
using static implementation.Utils.Helpers.RepositoryHelpers;

namespace implementation.Services
{
    public class OrderService : IService<OrderDTO, ResultResponse>
    {
        private readonly IRepository<Order> _repository;

        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public ResultResponse Create(OrderDTO item)
        {
            var result = new ResultResponse();

            item.Validate(ref result);

            if (!result.IsOk())
                return result;

            var mappedItem = _mapper.Map<Order>(item);

            _repository.Create(mappedItem);

            result.SetData(mappedItem);

            return result;
        }

        public ResultResponse Delete(int id)
        {
            var result = new ResultResponse();

            var deleteResult = _repository.Delete(id);

            if (!deleteResult)
                result.SetErrors("Houve um erro ao deletar a venda");

            result.SetData(deleteResult);

            return result;
        }

        public ResultResponse GetAll()
        {
            var result = new ResultResponse();

            result.SetData(_repository.GetAll());

            return result;
        }

        public ResultResponse GetById(int id)
        {
            var result = new ResultResponse();

            var order = _repository.GetById(id);

            if (order == null)
                result.SetErrors("Venda não encontrada");

            if (result.IsOk())
                result.SetData(order);

            return result;
        }

        public ResultResponse Update(int id, OrderDTO item)
        {
            var result = new ResultResponse();

            var orderToChange = _repository.GetById(id);

            if (orderToChange == null)
                result.SetErrors("Venda não encontrada");

            item.Validate(ref result);

            if (!result.IsOk())
                return result;

            if (!CanChangeOrderStatus(orderToChange.Status, item.Status))
            {
                result.SetErrors($"Não é possivel alterar o status da venda {orderToChange.Id} de {orderToChange.Status.ToString()} para {item.Status.ToString()}");

                return result;
            }

            var mappedItem = _mapper.Map<Order>(item);

            var updateResult = _repository.Update(id, mappedItem);

            if (!updateResult)
                result.SetErrors("Houve um erro ao efetivar a mudança");

            result.SetData(mappedItem);

            return result;
        }

        public ResultResponse UpdateStatus(int id, OrderStatus status)
        {
            var result = new ResultResponse();

            var orderToChange = _repository.GetById(id);

            if (orderToChange == null)
                result.SetErrors("Venda não encontrada");
            
            if (!CanChangeOrderStatus(orderToChange.Status, status))
            {
                result.SetErrors($"Não é possivel alterar o status da venda {orderToChange.Id} de {orderToChange.Status.ToString()} para {status.ToString()}");

                return result;
            }

            var updateResult = _repository.UpdateField<OrderStatus>(id, status);

            if (!updateResult)
                result.SetErrors("Houve um erro ao efetivar a mudança");

            return result;
        }
    }
}