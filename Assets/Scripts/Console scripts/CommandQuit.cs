using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{

    public class CommandQuit : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandQuit()
        {
            Name = "Quit";
            Command = "quit";
            Description = "Exits the app";
            Help = "Use it to quit";

            AddCommandToConsole();
        }
        public override void RunCommand()
        {
            Application.Quit();

        }

        public static CommandQuit CreateCommand()
        {
            return new CommandQuit();
        }
    }
}
