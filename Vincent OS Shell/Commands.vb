Module Commands
    Sub Commands()
        Dim cmd As String = Console.ReadLine
        If cmd = "hello" Then
            Console.Write("Welcome to Vincent OS Shell!")
            Console.WriteLine()
        ElseIf cmd = "Bing Chrome" Then
            System.Diagnostics.Process.Start("https://www.bing.com")
            Console.Write("Bing Chrome lancé !")
            Console.WriteLine()
        ElseIf cmd = "clear" Then
            Console.Clear()
        ElseIf cmd = "ls" Then
            Console.Write("vincentOS/Apps")
            Console.WriteLine()
            Console.Write("vincentOS/Users")
            Console.WriteLine()
            Console.Write("vincentOS/Sys")
            Console.WriteLine()
        ElseIf cmd = "ls vincentOS/Apps" Then
            Console.Write("Apps/Bing Chrome.ShortVOS")
            Console.WriteLine()
            Console.Write("Apps/clear.ShVOS")
            Console.WriteLine()
            Console.Write("Apps/hello.ShVOS")
            Console.WriteLine()
            Console.Write("Apps/PS.CompVOS")
            Console.WriteLine()
        ElseIf cmd = "ls vincentOS/Users" Then
            Console.Write("Aucun dossiers ou fichiers n'existent dans ce répertoire.")
            Console.WriteLine()
        ElseIf cmd = "ls vincentOS/Sys" Then
            lssys()
            Console.WriteLine()
        ElseIf cmd = "PS" Then
            Console.Write("ATTENTION : Vous n'avez pas précisé le paramètre suivant : --WINCOMP. Commande annulé pour cause de sécurité")
            Console.WriteLine()
        ElseIf cmd = "PS --WINCOMP" Then
            System.Diagnostics.Process.Start("C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe")
            Console.Write("PowerShell ouvert en compatibilité Windows !")
            Console.WriteLine()
        ElseIf cmd = "cd" Then
            Console.Write("vincentOS:\")
            Console.WriteLine()
        ElseIf cmd = "cd Apps" Then
            Console.Write("vincentOS/Apps:\>")
        ElseIf cmd = "cd Users" Then
            Console.Write("vincentOS/Users:\>")
        ElseIf cmd = "cd Sys" Then
            Console.Write("vincentOS/Sys:\>")
        ElseIf cmd = "ver" Then
            Console.Write("Nom du Shell : Vincent OS Shell")
            Console.WriteLine()
            Console.Write("Version du Shell : 1.0")
            Console.WriteLine()
            Console.Write("Type : Open Source")
            Console.WriteLine()
            Console.Write("Créateur : v38armageddon")
            Console.WriteLine()
        Else
            Console.Write("Commande non reconnu.")
            Console.WriteLine()
        End If
        cmdloop()
    End Sub
End Module
