using System.Net.Mail;
using implementation.Models;

namespace implementation.Utils.Helpers
{
    public static class ValidationHelpers
    {

        public static void ValidateSellerExtension(this Seller seller, List<string> errors, List<string> requiredFields)
        {
            if (seller == null)
            {
                errors.Add("É necessário que a venda tenha um vendedor");

                return;
            }

            CheckRequiredFields(requiredFields, "Campo obrigatório", seller.Cpf, seller.Email, seller.Name, seller.Telphone);

            if(!isValidEmail(seller.Email))
                errors.Add("Email inválido");

            if(!IsValidCpf(seller.Cpf))
                errors.Add("Cpf inválido");
        }

        private static void CheckRequiredFields(List<string> requiredFields, string message, params string[] fieldNames)
        {
            foreach (var fieldName in fieldNames)
                if (string.IsNullOrEmpty(fieldName))
                    requiredFields.Add($"{message} '{fieldName}'");
        }

        public static bool isValidEmail(string email)
        {
            var validEmail = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                validEmail = false;
            }

            return validEmail;
        }

        /// <summary>
        /// Furtei o Macoratti
        /// </summary>
        /// <seealso cref="https://www.macoratti.net/11/09/c_val1.htm"/>
        public static bool IsValidCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}