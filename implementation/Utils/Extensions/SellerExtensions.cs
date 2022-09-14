using implementation.Models;
using static implementation.Utils.Helpers.ValidationHelpers;

namespace implementation.Utils.Extensions
{
    public static class SellerExtensions
    {
        public static void ValidateSeller(this Seller seller, List<string> errors, List<string> requiredFields)
        {
            if (seller == null)
            {
                errors.Add("É necessário que a venda tenha um vendedor");

                return;
            }

            CheckRequiredFields(requiredFields, "Campo obrigatório", seller.Cpf, seller.Email, seller.Name, seller.Telphone);

            if (!isValidEmail(seller.Email))
                errors.Add("Email inválido");

            if (!IsValidCpf(seller.Cpf))
                errors.Add("Cpf inválido");
        }

        private static void CheckRequiredFields(List<string> requiredFields, string message, params string[] fieldNames)
        {
            foreach (var fieldName in fieldNames)
                if (string.IsNullOrEmpty(fieldName))
                    requiredFields.Add($"{message} '{fieldName}'");
        }
    }
}