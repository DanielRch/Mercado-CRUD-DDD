using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Entities
{
    public class Produto
    {
        public int IdProduto { get; set; }

        public string Setor { get; set; }

        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }

        public string Marca { get; set; }
                
        public double Valor { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

    }
}
