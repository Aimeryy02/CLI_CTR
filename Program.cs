using System;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenAI_API;

class Program
{
    static async Task Main()
    {
        string choixYN = "y";
        bool boolchoix = true;

        var apiKey = "API_KEY";
        var api = new OpenAIAPI(apiKey);

        while (boolchoix)
        {
            if (choixYN == "y")
            {
                Console.WriteLine("-t -c create");
                Console.Write("Sélectionnez une commande : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "-t":
                        await GetTraduction(api);
                        choixYN = "";
                        break;
                    case "-c":
                        await GetCorrection(api);
                        choixYN = "";
                        break;
                    case "create":
                        CreateReactApp();
                        choixYN = "";
                        break;
                    default:
                        Console.WriteLine("Option non valide. Réessayez.");
                        break;
                }
            }
            else if (choixYN == "n")
            {
                boolchoix = false;
            }
            else
            {
                Console.WriteLine("yes || no");
                choixYN = Console.ReadLine();

            }
        }
    }

    static async Task GetTraduction(OpenAIAPI apiKey)
    {
        Console.WriteLine("Donne moi une phrase en français pour traduire en anglais");
        string strtrad = Console.ReadLine();

        var trad = await apiKey.Completions.GetCompletion("traduire : " + strtrad);
        Console.WriteLine(trad);
    }

    static async Task GetCorrection(OpenAIAPI apiKey)
    {
        Console.WriteLine("Donne moi une phrase en français pour corriger la phrase");
        string strcor = Console.ReadLine();

        var cor = await apiKey.Completions.GetCompletion("corriger : " + strcor);
        Console.WriteLine(cor);
    }

    static void CreateReactApp()
    {
        Console.WriteLine("Création du projet React en cours...");
        string projectName = "mon-projet-react";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "npx",
            Arguments = $"create-react-app {projectName}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        using (Process process = new Process { StartInfo = startInfo })
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine(output);
            Console.WriteLine($"Projet React '{projectName}' créé avec succès.");
        }
    }
}



