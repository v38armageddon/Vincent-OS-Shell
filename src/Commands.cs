using System.Diagnostics;

namespace Vincent_OS_Shell
{
    public class Commands
    {
        public static void Command()
        {
            var cmd = Console.ReadLine();
            
            if (cmd == "hello")
            {
                Debug.WriteLine("[INFO]: Commande 'hello' exécuté.");
                Console.WriteLine("Bienvenue sur Vincent OS Shell!\nTout réécrit en C# !\n");
            }
            
            else if (cmd == "Bing Chrome")
            {
                Debug.WriteLine("[INFO]: Exécution de Bing Chrome.");
                System.Diagnostics.Process bingchrome = new System.Diagnostics.Process();
                bingchrome.StartInfo.FileName = @"https://www.bing.com";
                bingchrome.StartInfo.UseShellExecute = true;
                bingchrome.StartInfo.RedirectStandardOutput = false;
                bingchrome.Start();
                Console.WriteLine("Bing Chrome lancé !\n");
            }
            
            else if (cmd == "clear")
            {
                Debug.WriteLine("[INFO]: Commande 'clear' exécuté.");
                Console.Clear();
            }
            
            else if (cmd == "exit")
            {
                Debug.WriteLine("[INFO]: Arrêt du logiciel.");
                Environment.Exit(0);
            }

            else if (cmd == "help")
            {
                Debug.WriteLine("[INFO]: Commande 'help' exécuté.");
                Console.WriteLine("Voici la liste des commandes disponibles sur Vincent OS Shell :\n");
                Console.WriteLine("Bing Chrome");
                Console.WriteLine("clear");
                Console.WriteLine("exit");
                Console.WriteLine("hello");
                Console.WriteLine("help");
                Console.WriteLine("ls");
                Console.WriteLine("PowerShell");
                Console.WriteLine("ver\n");
            }
            
            else if (cmd == "ls")
            {
                Debug.WriteLine("[INFO]: Affichage des dossiers.");
                Console.WriteLine("vincentOS/Apps");
                Console.WriteLine("vincentOS/Users");
                Console.WriteLine("vincentOS/Sys\n");
            }
            
            else if (cmd == "ls vincentOS/Apps")
            {
                Debug.WriteLine("[INFO]: Affichage des dossiers.");
                lsapps();
            }
            
            else if (cmd == "ls vincentOS/Users")
            {
                Debug.WriteLine("[INFO]: Il n'y a pas d'utilisateur, retour à la normal.");
                Console.WriteLine("Aucun dossiers ou fichiers n'existent dans ce répertoire.\n");
            }
            
            else if (cmd == "ls vincentOS/Sys")
            {
                Debug.WriteLine("[INFO]: Affichage des dossiers.");
                lssys();
            }
            
            else if (cmd == "PowerShell")
            {
                Debug.WriteLine("[ALERT]: Empêchement de l'exécution de la commande 'PowerShell'.");
                Console.WriteLine("ATTENTION : Vous n'avez pas précisé le paramètre suivant : --WINCOMP.\nCommande annulé pour cause de sécurité.\n");
            }
            
            else if (cmd == "PowerShell --WINCOMP")
            {
                Debug.WriteLine("[ALERT]: Exécution de la commande 'PowerShell' en mode de compatibilité Windows.");
                System.Diagnostics.Process ps = new System.Diagnostics.Process();
                ps.StartInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
                ps.StartInfo.UseShellExecute = true;
                ps.StartInfo.RedirectStandardOutput = false;
                ps.Start();
                Console.WriteLine("PowerShell ouvert en compatibilité Windows !\n");
            }
            
            else if (cmd == "ver")
            {
                Debug.WriteLine("[INFO]: Affichage de la version de Vincent OS Shell.");
                Console.WriteLine("Nom du Shell : Vincent OS Shell");
                Console.WriteLine("Version du Shell : 3.0.0.0");
                Console.WriteLine("Licence : GPL-v3.0");
                Console.WriteLine("Créateur : v38armageddon\n");
            }
            
            else
            {
                Debug.WriteLine("[INFO]: Commande non reconnue.");
                Console.WriteLine("Commande non reconnu.\n");
            }
        }

        public static void lsapps()
        {
            Console.WriteLine("Apps/Bing Chrome.ShortVOS");
            Console.WriteLine("Apps/clear.ShVOS");
            Console.WriteLine("Apps/exit.ShVOS");
            Console.WriteLine("Apps/help.ShVOS");
            Console.WriteLine("Apps/ls.ShVOS");
            Console.WriteLine("Apps/hello.ShVOS");
            Console.WriteLine("Apps/PowerShell.CompVOS");
            Console.WriteLine("Apps/ver.ShVOS\n");
        }

        public static void lssys()
        {
            Console.WriteLine("Sys/bin");
            Console.WriteLine("Sys/obj");
            Console.WriteLine("Sys/Commands.cs");
            Console.WriteLine("Sys/Program.cs");
            Console.WriteLine("Sys/logo.ico");
            Console.WriteLine("Sys/Vincent OS Shell.cs");
            Console.WriteLine("Sys/Vincent OS Shell.sln\n");
        }
    }
}
