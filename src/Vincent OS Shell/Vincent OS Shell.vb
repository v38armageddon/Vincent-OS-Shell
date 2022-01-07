Module Shell

    Sub Main()
        Console.Title = "Vincent OS Shell"
        Console.Write("Vincent OS [Version Shell Standalone]")
        Console.WriteLine()
        Console.WriteLine("Projet : Open Source")
        Console.WriteLine()
        cmdloop()
    End Sub

    Sub cmdloop()
        Console.WriteLine()
        Console.Write("vincentOS:\>")
        Commands.Commands()
    End Sub

    Sub lssys()
        Console.Write("Sys/bin")
        Console.WriteLine()
        Console.Write("Sys/My Project")
        Console.WriteLine()
        Console.Write("Sys/obj")
        Console.WriteLine()
        Console.Write("Sys/Commands.vb")
        Console.WriteLine()
        Console.Write("Sys/Logo Vincent OS 2.ico")
        Console.WriteLine()
        Console.Write("Sys/Vincent OS Shell.vb")
        Console.WriteLine()
        Console.Write("Sys/Vincent OS Shell.vbproj")
        Console.WriteLine()
        Console.Write("Sys/Vincent OS Shell.vbproj.user")
        Console.WriteLine()
    End Sub
End Module
