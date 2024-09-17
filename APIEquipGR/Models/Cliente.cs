using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIEquipGR.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string? RazaoSocial { get; set; }

        [StringLength(2)]
        public string? UF { get; set; }

        public string? Secretaria { get; set; }

        public int QuantidadeEquipamento { get; set; }
        [ForeignKey("Equipamento")]
        public int IMEIEquipamento { get; set; }

    }
}
