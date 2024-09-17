using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIEquipGR.Models
{
    public class Equipamento
    {
        [Key]
        public int IMEI { get; set; }

        public string? MarcaModelo { get; set; }

        public string? Cor { get; set; }

        [ForeignKey("Cliente")]
        public int? IDCliente { get; set; }

        // public Cliente Cliente { get; set; } // Propriedade de navegação


    }
}
