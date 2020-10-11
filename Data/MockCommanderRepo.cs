using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Conseguir novia", Line="Se amable", Plataform="Casa"},
                new Command{Id=1, HowTo="Cocinar posole", Line="Con una olla", Plataform="Cocina"},
                new Command{Id=2, HowTo="Aprender a manejar", Line="Cursos de manejo", Plataform="Servicio"},
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Conseguir novia", Line="Se amable", Plataform="Casa"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}