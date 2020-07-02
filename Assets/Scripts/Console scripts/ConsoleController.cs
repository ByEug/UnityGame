using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public abstract class ConsoleCommand
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }

        public void AddCommandToConsole()
        {
            string addMessage = "\nCommand added.";

            ConsoleController.AddCommandsToConsole(Command, this);
            bool check = true;
            ConsoleController.AddMessageToConsole(Name + addMessage, check);
        }

        public abstract void RunCommand();
    }

    public class ConsoleController : MonoBehaviour
    {
        public static ConsoleController Instance { get; private set; } = null;
        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

        public bool isActiveConsole = false;

        public Canvas consoleCanvas;
        public ScrollRect scrollRect;
        public Text consoleText;
        public Text inputText;
        public InputField consoleInput;

        public GameObject player;
        private void Awake()
        {
            
            if (Instance != null && Instance != this)
            {
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);
            Commands = new Dictionary<string, ConsoleCommand>();
            
        }

        private void Start()
        {
            consoleCanvas.gameObject.SetActive(false);
            isActiveConsole = false;
            CreateCommands();
        }

        private void CreateCommands()
        {
            CommandQuit commandQuit = CommandQuit.CreateCommand();
            CommandHealth commandHealth = CommandHealth.CreateCommand();
            CommandDamage commandDamage = CommandDamage.CreateCommand();
        }

        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
        {
            if(!Commands.ContainsKey(_name))
            {
                Commands.Add(_name, _command);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.BackQuote))
            {
                if (isActiveConsole)
                {
                    consoleCanvas.gameObject.SetActive(false);
                    isActiveConsole = false;
                    Time.timeScale = 1f;
                }
                else
                {
                    consoleCanvas.gameObject.SetActive(true);
                    isActiveConsole = true;
                    Time.timeScale = 0f;
                }
            }

            if (consoleCanvas.gameObject.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (inputText.text != "")
                    {
                        AddMessageToConsole(inputText.text);
                        ParseInput(inputText.text);
                    }
                }
            }
        }

        private void AddMessageToConsole(string msg)
        {
            consoleText.text += msg + "\n";
            scrollRect.verticalNormalizedPosition = 0f;
        }

        public static void AddMessageToConsole(string msg, bool control)
        {
            if (control)
            {
                ConsoleController.Instance.consoleText.text += msg + "\n";
                ConsoleController.Instance.scrollRect.verticalNormalizedPosition = 0f;
            }
        }

        private void ParseInput(string input)
        {
            string[] _input = input.Split(null);

            if (_input.Length == 0 || _input == null)
            {
                AddMessageToConsole("Command not found.");
                return;
            }

            if (!Commands.ContainsKey(_input[0]))
            {
                AddMessageToConsole("Command not found.");
            }
            else
            {
                Commands[_input[0]].RunCommand();
            }
        }
    }
}
