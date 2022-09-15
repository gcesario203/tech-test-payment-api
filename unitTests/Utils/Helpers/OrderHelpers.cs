using implementation.Data;
using implementation.Models;

namespace unitTests.Utils.Helpers
{
    public static class OrderHelpers
    {

        public static OrderDTO MockUser()
        {
            return new OrderDTO
            {
                Seller = new Seller
                {
                    Name = "Evelyn Vera Ester Assunção",
                    Cpf = "71444185055",
                    Email = "evelyn.vera.assuncao@hidrara.com.br",
                    Telphone = "8335501389"
                }
            };
        }
        public static IEnumerable<OrderDTO> GenerateOrders()
        {
            return new List<OrderDTO>
            {
                new OrderDTO(new Seller
                                {
                                    Name = "Levi Enrico Paulo de Paula",
                                    Cpf = "89790224923",
                                    Email = "levi_depaula@lojascentrodamoda.com.br",
                                    Telphone = "2725247589"
                                },
                            new List<Product>
                                {
                                    new Product{ Name = "Seguro veícular Vectra 2000 com cobertura reduzida", Price = 1800.00M}
                                }),
                new OrderDTO(new Seller
                                {
                                    Name = "Milena Isabela Brito",
                                    Cpf = "03405831776",
                                    Email = "milena.isabela.brito@vbrasildigital.net",
                                    Telphone = "8637429180"
                                },
                            new List<Product>
                                {
                                    new Product{ Name = "Seguro residencial", Price = 5000.00M}
                                }),
                new OrderDTO(new Seller
                                {
                                    Name = "Levi Enrico Paulo de Paula",
                                    Cpf = "89790224923",
                                    Email = "levi_depaula@lojascentrodamoda.com.br",
                                    Telphone = "2725247589"
                                },
                            new List<Product>
                                {
                                    new Product{ Name = "Seguro veícular Vectra 2000 com cobertura reduzida", Price = 1800.00M},
                                    new Product{ Name = "Seguro residencial", Price = 3000.00M},
                                    new Product{ Name = "Seguro de responsabilidade civil CRM", Price = 7000.00M}
                                }),
                new OrderDTO(new Seller
                                {
                                    Name = "Milena Isabela Brito",
                                    Cpf = "03405831776",
                                    Email = "milena.isabela.brito@vbrasildigital.net",
                                    Telphone = "8637429180"
                                },
                            new List<Product>
                                {
                                    new Product{ Name = "Seguro veícular Posche Cayenne com cobertura ampliada", Price = 75000.00M},
                                    new Product{ Name = "Seguro de responsabilidade civil CREA", Price = 2500.00M},
                                    new Product{ Name = "SSeguro de responsabilidade civil COREN", Price = 290.00M},
                                    new Product{ Name = "Seguro veícular Posche Cayenne com cobertura ampliada", Price = 75000.00M}
                                }),
            };
        }
    }
}