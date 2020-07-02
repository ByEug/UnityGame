using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{

    public class CommandDamage : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandDamage()
        {
            Name = "Damage";
            Command = "damage";
            Description = "Raises bullet's damage to 60";
            Help = "Use it without arguments";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {
            ZombieController.UpBulletDamage_Console();
        }

        public static CommandDamage CreateCommand()
        {
            return new CommandDamage();
        }
    }
}
