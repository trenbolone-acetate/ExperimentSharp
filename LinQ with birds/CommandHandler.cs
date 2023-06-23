namespace Testing
{
    using static ExtensionsAndUtils;

    public static class CommandHandler
    {
        public static void HandleCommand()
        {
            bool isQuitting = true;
            while (isQuitting)
            {
                Console.WriteLine("Enter your command:\ntype -help to get the list of all commands");
                string userString = Console.ReadLine()?.ToLower();

                switch (userString)
                {
                    case "-help":
                        PrintCommands();
                        break;
                    case "-search":
                        Search.SearchForBird(Program.Birds);
                        break;
                    case "-add bird":
                        Program.Birds.Add();
                        break;
                    case "-quit":
                        isQuitting = false;
                        break;
                    default:
                        Console.WriteLine("No such command!\n");
                        break;
                }
            }
        }

        private static void PrintCommands()
        {
            Console.WriteLine("Commands:");
            foreach (var command in Collections.commands)
            {
                Console.WriteLine($"\t{command}");
            }
            Console.WriteLine();
        }
    }
}