using System.Collections.Generic;
using MVC_Core_REST.Models;
using System.Linq;
using System;

namespace MVC_Core_REST.Data
{
    public class SqlInstructionRepo : IInstructionRepo
    {
        private readonly InstructionContext _context;

        public SqlInstructionRepo(InstructionContext context)
        {
            _context=context;
        }

        public void CreateInstruction(Instruction inst)
        {
            if(inst==null)
            {
                throw new ArgumentNullException(nameof(inst));
            }
             _context.Instructions.Add(inst);
        }

        public void DeleteInstruction(Instruction inst)
        {
            if(inst==null)
            {
                throw new ArgumentNullException(nameof(inst));
            }
            _context.Instructions.Remove(inst);
        }

        public IEnumerable<Instruction> GetAllInstructions()
        {
            return _context.Instructions.ToList();
        }

        public Instruction GetInstructionById(int id)
        {
            return _context.Instructions.FirstOrDefault(p=>p.Id==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateInstruction(Instruction inst)
        {
            //Nothing
        }
    }
}