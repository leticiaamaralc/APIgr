using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIEquipGR.Models
{
    public class Lote
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Cliente")]
        public int IDCliente { get; set; }

        [ForeignKey("Equipamento")]
        public int IMEIEquipamento { get; set; }


        //public ICollection<Equipamento> Equipamentos { get; set; }

    }
}
