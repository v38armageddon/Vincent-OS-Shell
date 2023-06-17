using System.Text;

namespace Vincent_OS_Shell
{
    public class Shell
    {
        public static void Main()
        {
            string homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filePath = Path.Combine(homeFolder, ".VOSshell.conf");

            bool showTimeValue = false;
            bool simplyPathValue = false;

            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                byte[] info = new UTF8Encoding(true).GetBytes(
                    "# This is the default config file for Vincent OS Shell\n" +
                    "# You can change the config file by using the command \"config\"\n" +
                    "# It open the config file in your default text editor\n" +
                    "SHOW_TIME=False\n" +
                    "SIMPLY_PATH=True\n");
                fs.Write(info, 0, info.Length);
                fs.Close();
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.StartsWith("SHOW_TIME"))
                {
                    showTimeValue = line.Split('=')[1].Trim() == "True";
                }
                else if (line.StartsWith("SIMPLY_PATH"))
                {
                    simplyPathValue = line.Split('=')[1].Trim() == "True";
                }
            }

            if (showTimeValue)
            {
                Console.WriteLine(DateTime.Now);
            }

            initConsole(showTimeValue, simplyPathValue);
        }

        public static void initConsole(bool showTimeValue, bool simplyPathValue)
        {
            Console.Title = "Vincent OS Shell";
            Console.WriteLine("Vincent OS Shell [Version Standalone]");
            Console.WriteLine("Version : 4.0.0.0\n");
            cmdLoop();
        }

        public static void cmdLoop()
        {
            string homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filePath = Path.Combine(homeFolder, ".VOSshell.conf");
            string[] lines = File.ReadAllLines(filePath);
            bool simplyPathValue = false;

            while (true)
            {
                foreach (string line in lines)
                {
                    if (line.StartsWith("SIMPLY_PATH"))
                    {
                        bool boolResult;
                        bool.TryParse(line.Split('=')[1].Trim(), out boolResult);
                        simplyPathValue = boolResult;
                        switch (boolResult)
                        {
                            case true:
                                Console.Write(
                                    Environment.MachineName + "\\" +
                                    Environment.UserName + "\\" +
                                    "vincentOS:\\> ");
                                Commands.Command();
                                break;
                            case false:
                                Console.Write(
                                    Environment.MachineName + "\\" +
                                    Environment.UserName + "\\" +
                                    Environment.CurrentDirectory + "\\" +
                                    "vincentOS:\\> ");
                                Commands.Command();
                                break;
                            default:
                        }
                    }
                }
            }
        }
    }
}