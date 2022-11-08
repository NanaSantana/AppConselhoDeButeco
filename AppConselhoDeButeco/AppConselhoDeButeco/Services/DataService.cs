using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppConselhoDeButeco.Model;

namespace AppConselhoDeButeco.Services
{
    public class DataService
    {
        public static async Task<Mensagem> GetMensagem()
        {
            //string appId = "2";

            string queryString = "https://api.adviceslip.com/advice";
            dynamic resultado = await getDataFromService(queryString).ConfigureAwait(false);

            if (resultado["slip"] != null)
            {
                Mensagem mensagem = new Mensagem();

               // mensagem.Title = (string)resultado["slip"];
                mensagem.Id = (string)resultado["slip"]["id"];
                mensagem.Conselho = (string)resultado["slip"]["advice"];
                return mensagem;
            }
            else
            {
                return null;
            }
        }

        public static async Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            dynamic data = null;

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<dynamic>(json);
            }
            return data;
        }

    }
}
