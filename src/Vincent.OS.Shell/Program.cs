using System.Text;

namespace Vincent_OS_Shell
{
    public class Shell
    {
        public static void Main()
        {
            string homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filePath = Path.Combine(homeFolder, "VOSshell.conf");

            if (File.Exists(filePath))
            {
                // Apply the current config
                string[] lines = File.ReadAllLines(filePath);
                // Read the SHOW_TIME and SIMPLY_PATH config
                switch (lines[4])
                {
                    case "SHOW_TIME = True":
                        Console.WriteLine(DateTime.Now);
                        initConsole();
                        break;
                    case "SHOW_TIME = False":
                        initConsole();
                        break;
                    default:
                        Console.WriteLine("[FATAL]: The config file is corrupted.");
                        Console.WriteLine("Please delete the config file and restart the shell.");
                        break;
                }
            }
            else
            {
                // Create the config file
                string defaultContent = "# This is the default config file for Vincent OS Shell\n" +
                    "# You can change the config file by using the command \"config\"\n" +
                    "# It open the config file in your default text editor\n" +
                    "SHOW_TIME = False\n" +
                    "SIMPLY_PATH = True\n";
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(defaultContent);
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        public static void initConsole()
        {
            Console.Title = "Vincent OS Shell";
            Console.WriteLine("Vincent OS Shell [Version Standalone]");
            Console.WriteLine("Version : 4.0.0.0\n");
            cmdLoop();
        }

        public static void cmdLoop()
        {
            string homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filePath = Path.Combine(homeFolder, "VOSshell.conf");

            while (true)
            {
                string[] lines = File.ReadAllLines(filePath);
                switch (lines[5])
                {
                    case "SIMPLY_PATH = True":
                        Console.Write(
                            Environment.MachineName + "\\" +
                            Environment.UserName + "\\" +
                            "vincentOS:\\> ");
                        Commands.Command();
                        break;
                    case "SIMPLY_PATH = False":
                        Console.Write(
                            Environment.MachineName + "\\" +
                            Environment.UserName + "\\" +
                            Environment.CurrentDirectory + "\\" +
                            "vincentOS:\\> ");
                        Commands.Command();
                        break;
                    default:
                        Console.WriteLine("[FATAL]: The config file is corrupted.");
                        Console.WriteLine("Please delete the config file and restart the shell.");
                        break;
                }
            }
        }
    }
}