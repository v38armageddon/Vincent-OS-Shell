using System.Diagnostics;

namespace Vincent_OS_Shell
{
    class Shell
    {
        public static void Main()
        {
            Console.Title = "Vincent OS Shell";
            Console.WriteLine("Vincent OS [Version Shell Standalone]\n");
            Console.WriteLine("Projet : Open Source\n\n");
            cmdloop();
        }

        public static void cmdloop()
        {
            while (true)
            {
                Console.Write("vincentOS:\\>");
                string cmd = Console.ReadLine(); // Lol, l'avertissement inutile
                if (cmd == "hello")
                {
                    Console.WriteLine("Welcome to Vincent OS Shell!\n All rewriten in C#!\n");
                }
                else if (cmd == "Bing Chrome")
                {
                    System.Diagnostics.Process bingchrome = new System.Diagnostics.Process();
                    bingchrome.StartInfo.FileName = @"https://www.bing.com";
                    bingchrome.StartInfo.UseShellExecute = true;
                    bingchrome.StartInfo.RedirectStandardOutput = false;
                    bingchrome.Start();
                    Console.WriteLine("Bing Chrome lancé !\n");
                }
                else if (cmd == "clear")
                {
                    Console.Clear();
                }
                else if (cmd == "help")
                {
                    Console.WriteLine("Voici la liste des commandes disponibles sur Vincent OS Shell :\n");
                    Console.Write("Bing Chrome\n");
                    Console.Write("clear\n");
                    Console.Write("help\n");
                    Console.Write("ls\n");
                    Console.Write("PS\n");
                    Console.WriteLine("ver\n");
                }
                else if (cmd == "ls")
                {
                    Console.Write("vincentOS/Apps\n");
                    Console.Write("vincentOS/Users\n");
                    Console.WriteLine("vincentOS/Sys\n");
                }
                else if (cmd == "ls vincentOS/Apps")
                {
                    lsapps();
                }
                else if (cmd == "ls vincentOS/Users")
                {
                    Console.WriteLine("Aucun dossiers ou fichiers n'existent dans ce répertoire.\n");
                }
                else if (cmd == "ls vincentOS/Sys")
                {
                    lssys();
                }
                else if (cmd == "PS")
                {
                    Console.WriteLine("ATTENTION : Vous n'avez pas précisé le paramètre suivant : --WINCOMP.\nCommande annulé pour cause de sécurité.\n");
                }
                else if (cmd == "PS --WINCOMP")
                {
                    System.Diagnostics.Process ps = new System.Diagnostics.Process();
                    ps.StartInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
                    ps.StartInfo.UseShellExecute = true;
                    ps.StartInfo.RedirectStandardOutput = false;
                    ps.Start();
                    Console.WriteLine("PowerShell ouvert en compatibilité Windows !\n");
                }
                else if (cmd == "ver")
                {
                    Console.Write("Nom du Shell : Vincent OS Shell\n");
                    Console.Write("Version du Shell : 2\n");
                    Console.Write("Type : Open Source\n");
                    Console.Write("Licence : GPL-v3.0\n");
                    Console.WriteLine("Créateur : v38armageddon\n");
                }
                else
                {
                    Console.WriteLine("Commande non reconnu.\n");
                }
            }
        }

        public static void lsapps()
        {
            Console.Write("Apps/Bing Chrome.ShortVOS\n");
            Console.Write("Apps/clear.ShVOS\n");
            Console.Write("Apps/help.ShVOS\n");
            Console.Write("Apps/ls.ShVOS\n");
            Console.Write("Apps/hello.ShVOS\n");
            Console.Write("Apps/PS.CompVOS\n");
            Console.WriteLine("Apps/ver.ShVOS\n");
        }

        public static void lssys()
        {
            Console.Write("Sys/.vs\n");
            Console.Write("Sys/bin\n");
            Console.Write("Sys/obj\n");
            Console.Write("Sys/Commands.cs\n");
            Console.Write("Sys/logo.ico\n");
            Console.Write("Sys/Vincent OS Shell.cs\n");
            Console.Write("Sys/Vincent OS Shell.csproj\n");
            Console.WriteLine("Sys/Vincent OS Shell.sln\n");
        }
    }
}