using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Models;
using Commander.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers
{
    // api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
          _repository = repository;  
        }

        //Get api/commands
        [HttpGet]
        public ActionResult <Command> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        //Get api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(commandItem);
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <Command> CreateCommand(Command command)
        {
            _repository.CreateCommand(command);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetCommandById), new {Id = command.Id}, command);
        }

        //PUT api/commands/{Id}
        [HttpPut("{Id}")]
        public ActionResult UpdateCommand(int id, Command command){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }
            commandModelFromRepo.HowTo = command.HowTo;
            commandModelFromRepo.Line = command.Line;
            commandModelFromRepo.Plataform = command.Plataform;
            
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult ParcialCommandUpdate(int id, JsonPatchDocument<Command> patchDoc){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }

            patchDoc.ApplyTo(commandModelFromRepo, ModelState);

            if(!TryValidateModel(commandModelFromRepo))
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}