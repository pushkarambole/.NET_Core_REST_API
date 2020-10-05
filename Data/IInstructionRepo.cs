using System.Collections.Generic;
using MVC_Core_REST.Models;

namespace MVC_Core_REST.Data
{
    public interface IInstructionRepo
    {
        bool SaveChanges();
        IEnumerable<Instruction> GetAllInstructions();
        Instruction GetInstructionById(int id);
        void CreateInstruction(Instruction inst);
        void UpdateInstruction(Instruction inst);

        void DeleteInstruction(Instruction inst);



    }
}