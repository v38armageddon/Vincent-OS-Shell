using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Vincent_OS_Shell
{
    public class Commands
    {
        private static readonly Dictionary<string, string> CommandDictionary = new Dictionary<string, string>()
        {
            { "hello", "" },
            { "exit", "" },
            { "cd", "" },
            { "conf", "" },
            { "help", "" },
            { "execute", "" },
            { "clear", "" },
            { "uname", "" },
            { "say", "" },
            { "ls", "" },
            { "mkdir", "" },
            { "rmdir", "" },
            { "rm", "" },
            { "mv", "" },
            { "cp", "" },
            { "cat", "" },
            { "whatshell", "" },
            { "whoami", "" }
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
                { "", () =>
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = cmd;
                        process.Start();
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
                        string[] files = new string[Directory.GetFileSystemEntries(Environment.CurrentDirectory).Length];
                        string[] dirs = Directory.GetDirectories(Environment.CurrentDirectory);
                        Array.Copy(dirs, files, dirs.Length);
                        Array.Copy(Directory.GetFiles(Environment.CurrentDirectory), 0, files, dirs.Length, files.Length - dirs.Length);
                        foreach (string entry in files)
                        {
                            Console.WriteLine(Path.GetFileName(entry));
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
            else if (!string.IsNullOrEmpty(cmd))
            {
                if (IsValidProgram(cmd))
                {
                    commands[""].Invoke();
                }
                else
                {
                    Console.WriteLine(cmd + " : Programme non reconnue.\n");
                }
            }
            else
            {
                Console.WriteLine(cmd + " : Commande non reconnue.\n");
            }
#pragma warning restore CS8604
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private static bool IsValidProgram(string cmd)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = cmd;
                    return true;
                }
            }
            catch (Win32Exception)
            {
                return false;
            }
        }
    }
}
