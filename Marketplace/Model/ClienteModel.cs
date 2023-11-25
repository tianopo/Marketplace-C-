namespace Marketplace.Models.Model
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnderecoModel Endereco { get; set; }
    }

}
