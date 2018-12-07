using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp1ConsultaCep.Services;

namespace XamarinApp1ConsultaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnConsultar.Clicked += BtnConsultaClickedEvent;
            inputCep.TextChanged += InputCepChangedEvent;
        }

        private bool ValidaCep()
        {
            int outCep;
            if (inputCep.Text != ""
                && inputCep.Text.Length == 8
                && Int32.TryParse(inputCep.Text, out outCep))
            {
                return true;
            }

            return false;
        }

        private void InputCepChangedEvent(object sender, EventArgs args)
        {
            if (!this.ValidaCep())
            {
                labelResultado.Text = "";
            }
        }

        private void BtnConsultaClickedEvent(object sender, EventArgs args)
        {
            if (this.ValidaCep())
            {
                var endereco = ViaCepService.GetEnderecoViaCep(inputCep.Text);
                var textoEndereco = string.Format("Logradouro: {0}\nBairro: {1}\nCidade: {2}\nUF: {3}", endereco.logradouro, endereco.bairro, endereco.localidade, endereco.uf);
                labelResultado.Text = textoEndereco;
            }
            else
            {
                DisplayAlert("Erro CEP inválido","Informe um CEP válido", "OK");
                inputCep.Text = "";
                inputCep.Focus();
            }
        }
    }
}
