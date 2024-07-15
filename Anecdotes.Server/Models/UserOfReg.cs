using System.ComponentModel.DataAnnotations;

/* PASO 1 => INSTALAR DEPENDENCIAS NECESARIAS:
            *MANAGE NUGET PACKAGE: + Microsoft.EntityFrameworkCore
                                   + Microsoft.EntityFrameworkCore.SqlServer
                                   + Microsoft.EntityFrameworkCore.Tools */

// PASO 2 => CREAR CARPETA MODELS CON EL MODELO (CLASE) QUE TENDRA NUESTRA BASE DE DATOS CON LOS CAMPOS AHI (JDCN) 

namespace Anecdotes.Server.Models
{
    public class UserOfReg
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string userName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
