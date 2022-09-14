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

            var fieldNames = typeof(Seller).GetProperties().Select(x => x.Name);

            foreach (var fieldName in fieldNames)
                CheckRequiredFields(requiredFields, "Campo obrigatório", fieldName, seller.GetType().GetProperty(fieldName)?.GetValue(seller)?.ToString());

            if (!isValidEmail(seller.Email))
                errors.Add("Email inválido");

            if (!IsValidCpf(seller.Cpf))
                errors.Add("Cpf inválido");
        }

        private static void CheckRequiredFields(List<string> requiredFields, string message, string fieldName, string fieldValue)
        {
            if (string.IsNullOrEmpty(fieldValue))
                requiredFields.Add($"{message} '{fieldName}'");
        }
    }
}