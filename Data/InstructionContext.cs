using Microsoft.EntityFrameworkCore;
using MVC_Core_REST.Models;

namespace MVC_Core_REST.Data
{
    public class InstructionContext : DbContext
    {
        public InstructionContext(DbContextOptions<InstructionContext> opt) : base(opt)
        {

        }

        public DbSet<Instruction> Instructions { get; set; }

    }
}