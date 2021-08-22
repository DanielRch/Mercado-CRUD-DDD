using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        [Display (Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

    }
}
