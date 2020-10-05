
using System.Collections.Generic;
using MVC_Core_REST.Models;

namespace MVC_Core_REST.Data
{
    public class MockInstructionRepo : IInstructionRepo
    {
        public void CreateInstruction(Instruction inst)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteInstruction(Instruction inst)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Instruction> GetAllInstructions()
        {
            var instructions = new List<Instruction>
            {
                new Instruction{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
                new Instruction{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="knife & chopping board"},
                new Instruction{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"}
            };

            return instructions;
        }

        public Instruction GetInstructionById(int id)
        {
            return new Instruction { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateInstruction(Instruction inst)
        {
            throw new System.NotImplementedException();
        }
    }
}