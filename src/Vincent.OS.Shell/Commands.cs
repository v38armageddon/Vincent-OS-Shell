using System.Diagnostics;

namespace Vincent_OS_Shell
{
    public class Commands
    {
        public static void Command()
        {
            var cmd = Console.ReadLine();

            var commands = new Dictionary<string, Action>()
            {
                { "hello", () =>
                    {
                        Debug.WriteLine("[INFO]: Commande 'hello' exécuté.");
                        Console.WriteLine("Bienvenue sur Vincent OS Shell!\n");
                    }
                },
                { "help", () =>
                    {
                        Debug.WriteLine("[INFO]: Commande 'help' exécuté.");
                        Console.WriteLine("Voici la liste des commandes disponibles sur Vincent OS Shell :\n" +
                            "hello\n" +
                            "conf\n" +
                            "help\n" +
                            "execute\n");
                    }
                },
                { "execute", () =>
                    {
                        Console.Write(">> ");
                        var param = Console.ReadLine();
                        switch (param)
                        {
                            case "ps_script":
                                Debug.WriteLine("[INFO]: Commande 'Execute' exécuté avec le paramètre 'ps_script'.");
                                
                                break;
                            case "cmd_script":
                                Debug.WriteLine("[INFO]: Commande 'Execute' exécuté avec le paramètre 'cmd_script'.");
                                
                                break;
                            case "ps":
                                Debug.WriteLine("[INFO]: Commande 'Execute' exécuté avec le paramètre 'ps'.");
                                if (param == "ps")
                                {
                                    Process ps = new Process();
                                    ps.StartInfo.FileName = @"powershell.exe";
                                    ps.StartInfo.UseShellExecute = true;
                                    ps.StartInfo.RedirectStandardOutput = false;
                                    ps.Start();
                                    Console.WriteLine("PowerShell lancé !\n");
                                }
                                break;
                            case "cmd":
                                Debug.WriteLine("[INFO]: Commande 'Execute' exécuté avec le paramètre 'cmd'.");
                                
                                break;
                            default:
                                Debug.WriteLine("[INFO]: Commande 'Execute' exécuté avec un paramètre non reconnu.");
                                return;
                        }
                    }
                },
                { "conf", () =>
                    {
                        Debug.WriteLine("[INFO]: Commande 'conf' exécuté.");
                        // Open the config file to the default text editor
                        string homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        string filePath = Path.Combine(homeFolder, "VOSshell.conf");
                        if (Environment.OSVersion.Platform == PlatformID.Unix)
                        {
                            Process.Start("nano", filePath);
                        }
                        else if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        {
                            Process.Start("notepad.exe", filePath);
                        }
                        Console.WriteLine("Fichier de configuration ouvert !\n");
                    }
                }
            };

            if (commands.ContainsKey(cmd))
            {
                commands[cmd].Invoke();
            }
            else
            {
                Debug.WriteLine("[INFO]: Commande non reconnue.");
                Console.WriteLine("Commande non reconnue.\n");
            }
        }
    }
}
