using Marketplace.Models.Model;

namespace Marketplace.Model
{
    public class VendedorModel
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cnpj { get; set; }
        public decimal Comissao { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}

