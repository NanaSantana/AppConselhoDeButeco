using System;
using System.Collections.Generic;
using System.Text;

namespace AppConselhoDeButeco.Model
{
    class Mensagem
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Conselho { get; set; }

        public Mensagem()
        {
            this.Title = " "; 
            this.Id = " ";
            this.Conselho = " ";
        }
    }
}
