using AutoMapper;
using MVC_Core_REST.Dtos;
using MVC_Core_REST.Models;

namespace MVC_Core_REST.Profiles
{
    public class InstructionsProfile : Profile
    {
        public InstructionsProfile()
        {
            CreateMap<Instruction, InstructionReadDto>();
            CreateMap<InstructionCreateDto,Instruction>();
            CreateMap<InstructionUpdateDto,Instruction>();
            CreateMap<Instruction,InstructionUpdateDto>();

        }
    }
}