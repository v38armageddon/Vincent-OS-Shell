using System.Diagnostics;
using System.IO;

namespace Vincent_OS_Shell
{
    public class Commands
    {
        private static readonly Dictionary<string, string> CommandDictionary = new Dictionary<string, string>()
        {
            { "hello", "Simple commande" },
            { "exit", "Quitte le shell" },
            { "cd", "Se rendre à un dossier" },
            { "conf", "Ouvre le fichier de configuration" },
            { "help", "Commande aide" },
            { "execute", "Exécute un programme ou script PowerShell, CMD" },
            { "clear", "Nettoie le Terminal" },
            { "uname", "Savoir quel système d'exploitation utiliser" },
            { "say", "Dire quelque chose" },
            { "ls", "Montrer tout les fichiers et dossiers" },
            { "mkdir", "Créer un dossier" },
            { "rmdir", "Supprime un dossier" },
            { "rm", "Supprime un fichier" },
            { "mv", "Déplace un fichier" },
            { "cp", "Copie un fichier" },
            { "cat", "Montre le contenu du fichier" },
            { "whatshell", "Montrer quel shell est utilisé" }
        };

        public static void Command()
        {
            var cmd = Console.ReadLine();
            var commands = new Dictionary<string, Action>()
            {
                { "hello", () =>
                    {
                        Console.WriteLine("Bienvenue sur Vincent OS Shell!\n");
                    }
                },
                { "help", () =>
                    {
                        Console.WriteLine("Voici la liste des commandes disponibles sur Vincent OS Shell :");
                        foreach (var commandKey in CommandDictionary.Keys)
                        {
                                Console.WriteLine(commandKey);
                        }
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
                                Process cmd = new Process();
                                cmd.StartInfo.FileName = @"cmd.exe";
                                cmd.StartInfo.UseShellExecute = true;
                                cmd.StartInfo.RedirectStandardOutput = false;
                                cmd.Start();
                                Console.WriteLine("Invite de commande lancé !\n");
                                break;
                            default:
                                return;
                        }
                    }
                },
                { "conf", () =>
                    {
                        // Open the config file to the default text editor
                        string homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        string filePath = Path.Combine(homeFolder, ".VOSshell.conf");
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
                },
                { "exit", () =>
                    {
                        // Exit the shell
                        Environment.Exit(0);
                    }
                },
                { "cd",() =>
                    {
                        // Detect what the user want
                        Console.Write(">> ");
                        string path = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        if (Directory.Exists(path))
                        {
                            Directory.SetCurrentDirectory(path);
                        }
                        else if (File.Exists(path))
                        {
                            Directory.SetCurrentDirectory(Path.GetDirectoryName(path));
                        }
                        else if (!Directory.Exists(path) || !File.Exists(path))
                        {
                            Console.WriteLine(cmd + ": Chemin non valide.");
                        }
                    }
                },
                { "ls",() =>
                    {
                        Console.WriteLine("Liste des fichiers et dossiers dans " + Environment.CurrentDirectory + "\n");
                        string[] files = Directory.GetFiles(Environment.CurrentDirectory);
                        string[] dirs = Directory.GetDirectories(Environment.CurrentDirectory);
                        foreach (string file in files)
                        {
                            Console.WriteLine(file);
                        }
                        foreach (string dir in dirs)
                        {
                            Console.WriteLine(dir);
                        }
                    }
                },
                { "mkdir",() =>
                    {
                        Console.Write(">> ");
                        string dir = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        Directory.CreateDirectory(Environment.CurrentDirectory + dir);
                    }
                },
                { "rm",() =>
                    {
                        Console.Write(">> ");
                        string path = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        else if (!File.Exists(path))
                        {
                            Console.WriteLine(cmd + ": Chemin non valide.");
                        }
                    }
                },
                { "rmdir",() =>
                    {
                        Console.Write(">> ");
                        string path = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        if (Directory.Exists(path))
                        {
                            Directory.Delete(path);
                        }
                        else if (!Directory.Exists(path))
                        {
                            Console.WriteLine(cmd + ": Chemin non valide.");
                        }
                    }
                },
                { "mv",() =>
                    {
                        Console.Write(">> ");
                        string path1 = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        Console.Write(">> ");
                        string path2 = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        if (!File.Exists(path1) || !File.Exists(path2))
                        {
                            Console.WriteLine(cmd + path1, path2 + ": Chemin non valide.");
                        }
                        else if (File.Exists(path1) && File.Exists(path2))
                        {
                            File.Move(path1, path2);
                        }
                    }
                },
                { "cp",() =>
                    {
                        Console.Write(">> ");
                        string path1 = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        Console.Write(">> ");
                        string path2 = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        if (!File.Exists(path1) || !File.Exists(path2))
                        {
                            Console.WriteLine(cmd + path1, path2 + ": Chemin non valide.");
                        }
                        else if (File.Exists(path1) && File.Exists(path2))
                        {
                            File.Copy(path1, path2);
                        }
                    }
                },
                { "cat",() =>
                    {
                        Console.Write(">> ");
                        string path = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        if (File.Exists(path))
                        {
                            Console.WriteLine(File.ReadAllText(path));
                        }
                        else if (!File.Exists(path))
                        {
                            Console.WriteLine(cmd + ": Chemin non valide.");
                        }
                    }
                },
                { "say",() =>
                    {
                        Console.Write(">> ");
                        string message = Console.ReadLine();
                        Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                        {
                            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                            {
                                e.Cancel = true;
                                return;
                            }
                        });
                        Console.WriteLine(message);
                    }
                },
                { "clear",() =>
                    {
                        Console.Clear();
                    }
                },
                { "time",() =>
                    {
                        Console.WriteLine(DateTime.Now);
                    }
                },
                { "whoami",() =>
                    {
                        Console.WriteLine(Environment.UserName);
                    }
                },
                { "whatshell", () => 
                    {
                        Console.WriteLine("Vincent OS Shell");
                    }
                },
                { "hostname",() =>
                    {
                        Console.WriteLine(Environment.MachineName);
                    }
                },
                { "uname",() =>
                    {
                        Console.WriteLine(Environment.OSVersion);
                    }
                },
                { "pwd",() =>
                    {
                        Console.WriteLine(Environment.CurrentDirectory);
                    }
                },
                { "shutdown",() =>
                    {
                        Process.Start("shutdown", "/s /t 0");
                    }
                },
                { "reboot",() =>
                    {
                        Process.Start("shutdown", "/r /t 0");
                    }
                },
            };

#pragma warning disable CS8604
            if (commands.ContainsKey(cmd))
            {
                commands[cmd].Invoke();
            }
            else
            {
                Console.WriteLine("Commande non reconnue.\n");
            }
#pragma warning restore CS8604
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
