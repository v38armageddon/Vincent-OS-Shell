namespace Vincent_OS_Shell
{
    public class Shell
    {
        public static void Main()
        {
            Console.Title = "Vincent OS Shell";
            Console.WriteLine("Vincent OS Shell [Version Standalone]");
            Console.WriteLine("Version : 4.0.0.0\n");
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