using System.Collections.Generic;
// using AutoMapper;
using MVC_Core_REST.Data;
// using Instruction.Dtos;
using MVC_Core_REST.Models;
// using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_REST.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace MVC_Core_REST.Controllers
{
    [Route("api/instructions")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IInstructionRepo _repo;
        private IMapper _mapper;

        public InstructionsController(IInstructionRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InstructionReadDto>> GetAllInstructions()
        {
            var instructionItems = _repo.GetAllInstructions();
            return Ok(_mapper.Map<IEnumerable<InstructionReadDto>>(instructionItems));
        }

        [HttpGet("{id}", Name="GetInstructionById")]
        public ActionResult<InstructionReadDto> GetInstructionById(int id)
        {
            var instructionItem = _repo.GetInstructionById(id);
            if (instructionItem != null)
                return Ok(_mapper.Map<InstructionReadDto>(instructionItem));

            return NotFound();
        }

        [HttpPost]
        public ActionResult<InstructionReadDto> CreateInstruction(InstructionCreateDto instructionCreateDto)
        {
            var instructionModel = _mapper.Map<Instruction>(instructionCreateDto);
            _repo.CreateInstruction(instructionModel);
            _repo.SaveChanges();

            var instructionReadDto=_mapper.Map<InstructionReadDto>(instructionModel);
            //return Ok(instructionReadDto);

            return CreatedAtRoute(nameof(GetInstructionById),new {Id= instructionReadDto.Id},instructionReadDto);

            //return Ok(instructionModel);
        }

        
        [HttpPut("{id}")]
        public ActionResult UpdateInstruction(int id, InstructionUpdateDto instructionUpdateDto)
        {
            var instructionUpdateModel=_repo.GetInstructionById(id);
            if(instructionUpdateModel==null)
            {
                return NotFound();
            }
            
            _mapper.Map(instructionUpdateDto, instructionUpdateModel);
            _repo.UpdateInstruction(instructionUpdateModel);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateInstructionPartially(int id, JsonPatchDocument<InstructionUpdateDto> patchDoc)
        {
            var instructionModelFromRepo=_repo.GetInstructionById(id);
            if(instructionModelFromRepo==null)
            {
                NotFound();
            }

            var instructionPatch=_mapper.Map<InstructionUpdateDto>(instructionModelFromRepo);
            patchDoc.ApplyTo(instructionPatch,ModelState);
            if(! TryValidateModel(instructionPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(instructionPatch,instructionModelFromRepo);
            _repo.UpdateInstruction(instructionModelFromRepo);
            _repo.SaveChanges();

            return NoContent();


        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInstruction(int id)
        {
            var instructionModelFromRepo=_repo.GetInstructionById(id);
            if(instructionModelFromRepo==null)
            {
                NotFound();
            }

            _repo.DeleteInstruction(instructionModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

    }
}