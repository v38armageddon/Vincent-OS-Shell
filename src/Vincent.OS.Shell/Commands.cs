using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

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
            { "time", "" },
            { "whatshell", "" },
            { "whoami", "" },
            { "hostname", "" },
            { "pwd", "" },
            { "shutdown", "" },
            { "reboot", "" }
        };

        public static void Command()
        {
            var cmd = Console.ReadLine();
            var commands = new Dictionary<string, Action>()
            {
                { "hello", () =>
                    {
                        Console.WriteLine("Welcome to Vincent OS Shell!\n");
                    }
                },
                { "help", () =>
                    {
                        Console.WriteLine("Here is the list of available commands on Vincent OS Shell :");
                        foreach (var commandKey in CommandDictionary.Keys)
                        {
                            Console.WriteLine(commandKey);
                        }
                        Console.WriteLine("For more information about commands, visit: https://docs.v38armageddon.net/software/vincent-os/shell/list-of-commands\n");
                    }
                },
                { "execute", () =>
                    {
                        Console.Write(">> ");
                        var param = Console.ReadLine();
                        switch (param)
                        {
                            case "ps_script":
                                Console.Write(">> ");
                                var param2 = Console.ReadLine();
                                if (Path.GetExtension(param2) == ".ps1" || Path.GetExtension(param2) == ".psm1" ||
                                Path.GetExtension(param2) == ".psd1")
                                {
                                    Process process = new Process();
                                    process.StartInfo.FileName = "powershell.exe";
                                    process.StartInfo.Arguments = "./" + cmd;
                                    process.Start();
                                    Console.WriteLine("PowerShell script executed!\n");
                                }
                                else
                                {
                                    Console.WriteLine(cmd + ": Invalid file type.");
                                }
                                break;
                            case "cmd_script":
                                Console.Write(">> ");
                                var param3 = Console.ReadLine();
                                if (Path.GetExtension(param3) == ".bat" || Path.GetExtension(param3) == ".cmd" ||
                                Path.GetExtension(param3) == ".btm" || Path.GetExtension(param3) == ".vbs")
                                {
                                    Process process = new Process();
                                    process.StartInfo.FileName = "cmd.exe";
                                    process.StartInfo.Arguments = cmd;
                                    process.Start();
                                    Console.WriteLine("CMD script executed!\n");
                                }
                                else
                                {
                                    Console.WriteLine(cmd + ": Invalid file type.");
                                }
                                break;
                        }
                    }
                },
                { "", () =>
                    {
                        if (File.Exists(cmd))
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = cmd;
                            process.Start();
                        }
                        else
                        {
                            Console.WriteLine(cmd + ": Command or Program not found.\n");
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
                        Console.WriteLine("Configuration file opened!\n");
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
                            Console.WriteLine(cmd + ": Invalid path.");
                        }
                    }
                },
                { "ls",() =>
                    {
                        Console.WriteLine("List of all files and directory in " + Environment.CurrentDirectory + "\n");
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
                            Console.WriteLine(cmd + ": Invalid path.");
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
                            Console.WriteLine(cmd + ": Invalid path.");
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
                        if (!File.Exists(path1) || !Directory.Exists(path2))
                        {
                            Console.WriteLine(cmd + path1, path2 + ": Invalid path.");
                        }
                        else if (File.Exists(path1) && !Directory.Exists(path2))
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
                        if (!File.Exists(path1) || !Directory.Exists(path2))
                        {
                            Console.WriteLine(cmd + path1, path2 + ": Invalid path.");
                        }
                        else if (File.Exists(path1) && Directory.Exists(path2))
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
                            Console.WriteLine(cmd + ": Invalid path.");
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
                        OSPlatform OS = new OSPlatform();
                        if (OS == OSPlatform.Windows)
                        {
                            Process.Start("shutdown", "/s /t 0");
                        }
                        else if (OS == OSPlatform.Linux)
                        {
                            Process.Start("sudo poweroff");
                        }
                    }
                },
                { "reboot",() =>
                    {
                        OSPlatform OS = new OSPlatform();
                        if (OS == OSPlatform.Windows)
                        {
                            Process.Start("shutdown", "/r /t 0");
                        }
                        else if (OS == OSPlatform.Linux)
                        {
                            Process.Start("sudo reboot");
                        }
                    }
                },
            };

            if (commands.ContainsKey(cmd))
            {
                commands[cmd].Invoke();
            }
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
