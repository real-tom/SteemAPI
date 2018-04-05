using System;

namespace SteemAPI
{
    class Program
    {
        private static SimpleSteemRPC ssr;

        private static void ShowHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("ESC:  Programm beenden/Exit application");
            Console.WriteLine("F1:   Diese Hilfe anzeigen/Show this help");
            Console.WriteLine("F2:   Befehle anzeigen/Show commands");
            Console.WriteLine("0-68: Befehl anhand ID ausführen/Execute command by ID");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Steem API Befehlszeilen/Commandline Browser");
            try
            {
                ssr = new SimpleSteemRPC();
                ShowHelp();
                int id = -1;
                while (true)
                {
                    if (Console.KeyAvailable)//Non blocking
                    {
                        ConsoleKeyInfo cki = Console.ReadKey(true);
                        if (cki.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Verlasse Programm/Leaving program");
                            break;
                        }
                        else if (cki.Key == ConsoleKey.F1) ShowHelp();
                        else if (cki.Key == ConsoleKey.F2) ShowCommands();
                        else if (cki.Key == ConsoleKey.D0 || cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.D3 || cki.Key == ConsoleKey.D4 || cki.Key == ConsoleKey.D5 || cki.Key == ConsoleKey.D6 || cki.Key == ConsoleKey.D7 || cki.Key == ConsoleKey.D8 || cki.Key == ConsoleKey.D9)
                        {
                            if (id == -1)
                            {
                                id = cki.KeyChar - 0x30;
                                Console.WriteLine("");
                            }
                            else
                            {
                                id = id * 10 + cki.KeyChar - 0x30;
                            }
                            Console.Write(cki.KeyChar);
                        }
                        else if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Write(Environment.NewLine);
                            if (id > 0 && id <= 68) ExecuteCommand(id);
                            id = -1;
                        }
                        else id = -1;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine(e.Message);
                Console.WriteLine("Beende mit Taste/Exit with key");
                Console.ReadKey();
            }
        }

        private static void ShowCommands()
        {
            Console.WriteLine("");
            Console.WriteLine("{0,2} {1,-38} {2}","ID","Name", "Description");
            foreach (SteemdCommand c in SteemdCommandList.steemdCommandList)
            {
                Console.WriteLine("{0,2} {1,-38} {2}", c.ID,c.Name,c.Description);
            }
        }

        private static void ExecuteCommand(int id)
        {
            Console.WriteLine("");
            SteemdCommand sc = SteemdCommandList.GetSteemdCommandByID(id);
            Console.WriteLine("Befehl/Command {0}: {1}", sc.ID, sc.Name);
            Console.WriteLine(sc.Description);
            Console.WriteLine(ssr.FormatJSON(ssr.Transaction(sc.Name,sc.Parameter)));
        }
    }
}
