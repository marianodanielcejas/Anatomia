using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anatomia.Comunes.Data.Entidades
{
    [Index(nameof(CodInsercion), Name = "UQ_Insercion_CodInsercion", IsUnique = true)]
    public class Insercion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Código de la Insercion es Obligatorio")]
        [MaxLength(1, ErrorMessage = "$ El campo tiene como maximo {1} caracteres")]

        public string CodInsercion { get; set; }

        [Required(ErrorMessage = "El Nombre de la Insercion es Obligatorio")]
        [MaxLength(120, ErrorMessage = " El campo tiene como maximo {1} caracteres")]
        public string NombreInsercion { get; set; }

        [Required(ErrorMessage = "El musculo es Obligatorio")]

        public int MusculoId { get; set; }

        public Musculo Musculo { get; set; }
    }
}
