namespace XamarinApp1ConsultaCep.Services.Models
{
    public class EnderecoModel
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public int ibge { get; set; }
        public int? gia { get; set; } 
    }
}
