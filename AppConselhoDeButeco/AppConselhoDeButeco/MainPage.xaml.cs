using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using AppConselhoDeButeco.Model;
using AppConselhoDeButeco.Services;

namespace AppConselhoDeButeco
{
    public partial class MainPage : ContentPage
    {
        //não consegui fazer :c

        public MainPage()
        {
            InitializeComponent();

            var Image = new Image { Source = "fundo.jpg" };

            this.Title = "Concelho da mesa";

            this.BindingContext = new Mensagem();
        }

        private async void bntMensagem_Clicked(object sender, EventArgs e)
        {

            try
            {
                Mensagem conselho = await DataService.GetMensagem();
                this.BindingContext = conselho;
                bntMensagem.Text = "Novo Conselho";
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "ok");
            }

        }
    }
}
