using System;
using System.Media;
using System.Threading;
using System.Text;

class Program
{
    private static string userName = ""; 
    private static readonly Random random = new Random();

    static void Main(string[] args)
    {
        Console.Title = "Cybersecurity Awareness Chatbot";
        Console.Clear();
        DisplayAsciiArt();
        PlayWelcomeGreeting();
        GetUserName();
        RunChatLoop(); 
    }

    static void PlayWelcomeGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("welcome.wav");
            player.Play();
        }
        catch
        {
            TypeWriteEffect("Audio greeting unavailable. Welcome to the Cybersecurity Awareness Bot!", ConsoleColor.Yellow);
        }
    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
   _____      _                _____ _                      
  / ____|    | |              / ____| |                     
 | (___   ___| |__   ___ _ __| (___ | |__   __ _ _ __ _ __  
  \___ \ / __| '_ \ / _ \ '__\___ \| '_ \ / _` | '__| '_ \ 
  ____) | (__| | | |  __/ |  ____) | | | | (_| | |  | |_) |
 |_____/ \___|_| |_|\___|_| |_____/|_| |_|\__,_|_|  | .__/    
                                                    | |    
                                                    |_|    
        ___         _   _   _           _   _              
       / __| __ _ _| |_| |_| |___ _ _  | |_| |_  ___ _ __  
       \__ \/ _` |_   _| '_ / -_) '_| |  _| ' \/ -_) '  \ 
       |___/\__,_| |_| |_,_\___|_|    \__|_||_\___|_|_|_|
");
        Console.ResetColor();

        DrawSectionHeader("CYBERSECURITY AWARENESS CHATBOT", ConsoleColor.DarkYellow);
        Thread.Sleep(800);
    }

    static void GetUserName()
    {
        TypeWriteEffect("\nBefore we begin, what should I call you? ", ConsoleColor.White);
        userName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userName))
        {
            TypeWriteEffect("I didn't catch your name. Could you please tell me again? ", ConsoleColor.Red);
            userName = Console.ReadLine();
        }

        DrawSectionHeader($"WELCOME, {userName.ToUpper()}!", ConsoleColor.Green);
        TypeWriteEffect("I'm your Cybersecurity Awareness Assistant.\n", ConsoleColor.Cyan);
        TypeWriteEffect("I can help you with topics like:\n", ConsoleColor.White);
        TypeWriteEffect("• Password safety\n• Phishing detection\n• Safe browsing\n• General cybersecurity", ConsoleColor.Magenta);
        Console.WriteLine();
    }

    static void RunChatLoop()
    {
        string[] helpOptions = {
            "» How to create strong passwords",
            "» How to recognize phishing emails",
            "» Safe browsing practices",
            "» What's your purpose?",
            "» How are you?",
            "» Type 'exit' to end our chat"
        };

        DrawSectionHeader("HOW CAN I HELP YOU?", ConsoleColor.Blue);
        Console.ForegroundColor = ConsoleColor.Yellow;
        TypeWriteEffect("Here are some things you can ask me about:\n", 20);
        foreach (var option in helpOptions)
        {
            TypeWriteEffect(option + "\n", 30);
            Thread.Sleep(100);
        }
        Console.ResetColor();
        DrawDivider('═', ConsoleColor.DarkCyan);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n[{userName}] ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("» ");
            Console.ResetColor();

            string input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeWriteEffect("I didn't hear anything. Could you repeat that?\n", 20);
                Console.ResetColor();
                continue;
            }

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                DrawSectionHeader($"GOODBYE, {userName.ToUpper()}!", ConsoleColor.Blue);
                TypeWriteEffect("Remember to stay safe online!\n", ConsoleColor.Green);
                Thread.Sleep(1000);
                Environment.Exit(0);
            }

            string response = GetResponse(input);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Bot] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("» ");
            TypeWriteEffect(response + "\n", 10);
            Console.ResetColor();
        }
    }

    static string GetResponse(string input)
    {
        input = input.ToLower();

        if (input.Contains("how are you"))
        {
            return "I'm functioning optimally, thank you for asking! How about you?";
        }
        else if (input.Contains("purpose") || input.Contains("what do you do"))
        {
            return "My purpose is to help you stay safe online by providing cybersecurity awareness information.";
        }
        else if (input.Contains("password") || input.Contains("strong password"))
        {
            return "🔒 Strong passwords should:\n- Be at least 12 characters long\n- Include uppercase, lowercase, numbers and symbols\n- Not contain personal information\n- Be unique for each account\n- Consider using a password manager!";
        }
        else if (input.Contains("phishing") || input.Contains("fake email"))
        {
            return "🚩 Watch for these phishing signs:\n1. Urgent or threatening language\n2. Requests for personal information\n3. Suspicious sender addresses\n4. Poor spelling/grammar\n5. Unexpected attachments\n6. Links that don't match the displayed text";
        }
        else if (input.Contains("browsing") || input.Contains("safe internet"))
        {
            return "🌐 Safe browsing tips:\n- Look for 🔐 HTTPS in URLs\n- Don't download from untrusted sites\n- Keep browser/plugins updated\n- Use ad-blockers\n- Avoid public WiFi for sensitive tasks\n- Enable two-factor authentication";
        }
        else if (input.Contains("help") || input.Contains("what can i ask"))
        {
            return "You can ask me about:\n- 🔒 Password security\n- 🚩 Phishing scams\n- 🌐 Safe browsing\n- 🛡️ General cybersecurity tips\n- ℹ️ My purpose";
        }
        else
        {
            return "I didn't quite understand that. Try asking about:\n- 'password safety'\n- 'phishing emails'\n- 'safe browsing'\nOr type 'help' for options.";
        }
    }

    #region UI Enhancement Methods
    static void TypeWriteEffect(string text, int delay = 30)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(random.Next(delay / 2, delay + 10));
        }
    }

    static void TypeWriteEffect(string text, ConsoleColor color, int delay = 30)
    {
        Console.ForegroundColor = color;
        TypeWriteEffect(text, delay);
        Console.ResetColor();
    }

    static void DrawSectionHeader(string text, ConsoleColor color)
    {
        Console.WriteLine();
        Console.ForegroundColor = color;
        Console.WriteLine($"╔{new string('═', text.Length + 2)}╗");
        Console.WriteLine($"║ {text} ║");
        Console.WriteLine($"╚{new string('═', text.Length + 2)}╝");
        Console.ResetColor();
        Thread.Sleep(300);
    }

    static void DrawDivider(char symbol, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(new string(symbol, Console.WindowWidth - 1));
        Console.ResetColor();
    }
    #endregion
}