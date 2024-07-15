
//PASO 3 =>  CREAR EL DBContext PARA LA CONEXION A LA BASE DE DATOS (SE PUEDE CREAR UNA CARPETA Y EN ESTA LA CLASE):

using Anecdotes.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Anecdotes.Server.Data
{
    public class AppAnecdotasDbContext: DbContext
    {
        public AppAnecdotasDbContext(DbContextOptions<AppAnecdotasDbContext> options) : base(options) { }

        public DbSet<UserOfReg> UsuarioRegistrado {  get; set; }
    }
}
