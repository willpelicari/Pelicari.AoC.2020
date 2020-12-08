using System.Collections.Generic;

namespace Pelicari.AoC._2020.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private IInputsRepository _inputsRepository;

        public CommandRepository(IInputsRepository inputsRepository)
        {
            _inputsRepository = inputsRepository;
        }
        public IEnumerable<(string command, int value)> Compile()
        {
            List<(string command, int value)> commands = new List<(string command, int value)>();
            var inputs = _inputsRepository.GetInputs(8, 1);
            foreach (var input in inputs)
            {
                var parts = input.Split(" ");
                commands.Add((parts[0].Trim(), int.Parse(parts[1].Trim())));
            }
            return commands;
        }
    }
}
