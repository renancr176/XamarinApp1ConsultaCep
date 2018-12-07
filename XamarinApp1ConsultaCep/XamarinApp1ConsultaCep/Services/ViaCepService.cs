using System;
using System.Net;
using Newtonsoft.Json;
using XamarinApp1ConsultaCep.Services.Models;

namespace XamarinApp1ConsultaCep.Services
{
    public class ViaCepService
    {
        private static string _urlConsultaCep = "https://viacep.com.br/ws/{0}/json/";

        public static EnderecoModel GetEnderecoViaCep(string cep)
        {
            var urlConsultaCep = string.Format(_urlConsultaCep, cep);
            var wc = new WebClient();
            var jsonString = wc.DownloadString(urlConsultaCep);
            var endereco = JsonConvert.DeserializeObject<EnderecoModel>(jsonString);
            if (endereco.cep == null)
            {
                return null;
            }
            return endereco;
        }
    }
}
