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
            //string appId = "2";

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

        public static async Task<dynamic> getDataFromServiceByMensage(string id)
        {
            //string appId = "27f3dbe7780d6027b8150a6fd63dd8c1";

            string url = string.Format("https://api.adviceslip.com/advice");
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);
            dynamic data = null;

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }

    }
}
