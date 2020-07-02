using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{

    public class CommandHealth : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandHealth()
        {
            Name = "Health";
            Command = "health";
            Description = "Raises current player's health to 100";
            Help = "Use it without arguments";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {
            PlayerController.UpHealth_Console();
        }

        public static CommandHealth CreateCommand()
        {
            return new CommandHealth();
        }
    }
}