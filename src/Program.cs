namespace Vincent_OS_Shell
{
    public class Shell
    {
        public static void Main()
        {
            Console.Title = "Vincent OS Shell";
            Console.WriteLine("Vincent OS [Version Shell Standalone]");
            Console.WriteLine("Version : 3.0.0.0\n");
            cmdloop();
        }

        public static void cmdloop()
        {
            while (true)
            {
                Console.Write("vincentOS:\\> ");
                Commands.Command();
            }
        }
    }
}