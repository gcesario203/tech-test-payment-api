using implementation.Models.Abstractions;

namespace implementation.Models
{
    public class Seller : BaseEntity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Telphone { get; set; }
        public Seller(int id, string name, string cpf, string email, string telphone) : base(id)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Telphone = telphone;
        }
    }
}