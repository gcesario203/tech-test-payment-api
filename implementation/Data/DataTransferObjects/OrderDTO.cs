using implementation.Data.ResponseObjects.Interfaces;
using implementation.Data.ResponseObjects;
using implementation.Models;
using implementation.Models.Enums;
using static implementation.Utils.Helpers.ValidationHelpers;

namespace implementation.Data
{
    public class OrderDTO : IResponseValidate
    {
        public Seller Seller { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public OrderStatus Status { get; set; }

        public void Validate(ref ResultResponse response)
        {
            Seller.ValidateSellerExtension(response.Errors, response.RequiredFields);
            
            if(Products?.Count == 0)
                response.SetErrors("É necessário ter pelo menos um produto na venda");
        }
    }
}