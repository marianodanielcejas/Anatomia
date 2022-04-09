using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anatomia.Comunes.Data.Entidades
{ 
    [Index(nameof(CodMusculo), Name = "UQ_Musculo_CodMusculo", IsUnique = true)]
    public class Musculo
    {
        public int Id { get; set; }
    
        [Required(ErrorMessage = "El Código del musculo es Obligatorio")]
        [MaxLength(2, ErrorMessage =" El campo tiene como maximo {1} caracteres")]

        public string CodMusculo { get; set; }

        [Required(ErrorMessage = "El Nombre del musculo es Obligatorio")]
        [MaxLength(120, ErrorMessage = " El campo tiene como maximo {1} caracteres")]
        public string NombreMusculo { get; set; }

        public List <Insercion> Inserciones  { get; set; }
    }
}
