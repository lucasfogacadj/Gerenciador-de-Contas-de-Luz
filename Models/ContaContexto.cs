using Microsoft.EntityFrameworkCore;  
using MvcDemo.Models;  


namespace MvcDemo.Models
{
    public class ContaContexto :DbContext
    {
          public ContaContexto (DbContextOptions<ContaContexto> options)  
            : base(options)  
        {  
        }  
  
        public DbSet<MvcDemo.Models.ContaDeLuz> Conta { get; set; }  
    }
}