using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppConselhoDeButeco.Model;

namespace AppConselhoDeButeco.Services
{
    class DataService
    {
        public static async Task<Mensagem> GetMensagem()
        {
            string appId = "2";

            string queryString = "https://api.adviceslip.com/advice";
            dynamic resultado = await getDataFromService(queryString).ConfigureAwait(false);

            if (resultado[""] != null)
            {
                Mensagem mensagem = new Mensagem();

                mensagem.Title = (string)resultado["slip"];
                mensagem.Id = (string)resultado["id"];
                mensagem.Conselho = (string)resultado["advice"];
                return mensagem;
            }
        }
    }
}
