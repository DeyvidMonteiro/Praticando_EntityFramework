namespace eCommerce.Models
{
    public class EnderecoEntrega
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NomeEndereco { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public Usuario? usuario { get; set; }

    }
}
