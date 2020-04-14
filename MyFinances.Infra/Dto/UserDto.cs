using MyFinances.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFinances.Infra.Dto
{
    [Table("User")]
    public class UserDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
