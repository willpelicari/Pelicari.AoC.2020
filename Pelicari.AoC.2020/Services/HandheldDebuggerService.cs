using Pelicari.AoC._2020.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Services
{
    public class HandheldDebuggerService : IHandheldDebuggerService
    {
        private ICommandRepository _commandRepository;

        public HandheldDebuggerService(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public int GetLastValueFromAccumulator(bool autoSolveInfiniteLoop)
        {
            int accumulator = 0;
            var commands = _commandRepository.Compile().ToArray();

            var indexesWithJmpOrNopCommand = 
                commands.Select((c, i) => (c.command, index: i))
                .Where(ci => ci.command == "jmp" || ci.command == "nop").ToArray();

            bool fullyExecuted = false;
            (string command, int index) currentChange = default;
            var currentChangeIndex = -1;
            do
            {
                if (!TryRunCommands(commands, out accumulator))
                {
                    if (!autoSolveInfiniteLoop)
                        return accumulator;

                    if (currentChange != default)
                        commands[indexesWithJmpOrNopCommand[currentChangeIndex].index] = InvertCommand(currentChange);

                    currentChangeIndex++;
                    currentChange = InvertCommand(commands[indexesWithJmpOrNopCommand[currentChangeIndex].index]);
                    commands[indexesWithJmpOrNopCommand[currentChangeIndex].index] = currentChange;
                } else
                    fullyExecuted = true;                
            } while (!fullyExecuted);
            return accumulator;
        }

        public bool TryRunCommands((string command, int value)[] commandList, out int finalAccValue)
        {
            int accumulator = 0;
            var listOfExecutedCommands = new List<(int index, (string command, int value))>();

            for (int i = 0; i < commandList.Length; i++)
            {
                var command = commandList[i];
                if (listOfExecutedCommands.Select(c => c.index).Contains(i))
                {
                    finalAccValue = accumulator;
                    return false;
                }
                else
                    listOfExecutedCommands.Add((i, command));

                switch (command.command)
                {
                    case "acc":
                        accumulator += command.value;
                        break;
                    case "jmp":
                        i += (command.value - 1); //+1 will be added at the next loop
                        break;
                    case "nop":
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            finalAccValue = accumulator;
            return true;
        }

        public (string command, int index) InvertCommand((string command, int index) command)
        {
            if (command.command == "jmp")
                command.command = "nop";
            else
                command.command = "jmp";
            return command;
        }
    }
}
