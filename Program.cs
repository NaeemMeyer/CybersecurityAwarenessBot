using System;
using System.Media;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            try
            {
                VoiceGreeting.PlayGreeting();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Greeting audio not found, continuing without sound...");
                Console.ResetColor();
            }

            UI.DisplayLogo();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nPlease enter your name: ");
            string userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName)) userName = "User";
            Console.ResetColor();

            UI.DisplayWelcome(userName);
            ChatBot.StartConversation(userName);
        }
    }

    static class VoiceGreeting
    {
        public static void PlayGreeting()
        {
            SoundPlayer player = new SoundPlayer("greeting.wav");
            player.Load();
            player.PlaySync();
        }
    }

    static class UI
    {
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==================================================");
            Console.WriteLine("   ██████╗ ██╗   ██╗██████╗ ███████╗██████╗       ");
            Console.WriteLine("  ██╔═══██╗██║   ██║██╔══██╗██╔════╝██╔══██╗      ");
            Console.WriteLine("  ██║   ██║██║   ██║██████╔╝█████╗  ██████╔╝      ");
            Console.WriteLine("  ██║   ██║██║   ██║██╔═══╝ ██╔══╝  ██╔═══╝       ");
            Console.WriteLine("  ╚██████╔╝╚██████╔╝██║     ███████╗██║           ");
            Console.WriteLine("   ╚═════╝  ╚═════╝ ╚═╝     ╚══════╝╚═╝           ");
            Console.WriteLine("                                                  ");
            Console.WriteLine("        Cybersecurity Awareness Bot               ");
            Console.WriteLine("==================================================");
            Console.ResetColor();
        }

        public static void DisplayWelcome(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n👋 Hello {userName}! Welcome to the Cybersecurity Awareness Bot.");
            Console.WriteLine("💡 Ask me about passwords, phishing, malware, VPNs, and more!");
            Console.ResetColor();
        }

        public static void TypingEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }
            Console.WriteLine();
        }
    }

    static class ChatBot
    {
        public static void StartConversation(string userName)
        {
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n❓ Ask me something (or type 'help' / 'exit'): ");
                string input = Console.ReadLine();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    UI.TypingEffect("⚠️ I didn’t catch that — could you rephrase?");
                    continue;
                }

                input = input.ToLower();

                try
                {
                    if (input.Contains("exit") || input.Contains("quit"))
                    {
                        UI.TypingEffect("👋 Goodbye! Stay safe online.");
                        running = false;
                    }
                    else if (input.Contains("help"))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n📚 I can answer questions about:");
                        Console.WriteLine(" - Password safety");
                        Console.WriteLine(" - Phishing");
                        Console.WriteLine(" - Malware");
                        Console.WriteLine(" - Ransomware");
                        Console.WriteLine(" - VPNs");
                        Console.WriteLine(" - Two-factor authentication (2FA)");
                        Console.WriteLine(" - Social engineering");
                        Console.ResetColor();
                    }
                    else if (input.Contains("password"))
                    {
                        UI.TypingEffect("🔑 Strong passwords should be long, unique, and include letters, numbers, and symbols.");
                    }
                    else if (input.Contains("phishing"))
                    {
                        UI.TypingEffect("📧 Phishing emails pretend to be trusted sources. Watch for suspicious links and urgent language.");
                    }
                    else if (input.Contains("malware"))
                    {
                        UI.TypingEffect("🦠 Malware is harmful software. Avoid downloads from untrusted sites and keep antivirus updated.");
                    }
                    else if (input.Contains("ransomware"))
                    {
                        UI.TypingEffect("💻 Ransomware locks your files until you pay. Protect yourself with backups and caution.");
                    }
                    else if (input.Contains("vpn"))
                    {
                        UI.TypingEffect("🌐 A VPN encrypts your traffic and hides your IP, improving privacy and security.");
                    }
                    else if (input.Contains("two factor") || input.Contains("2fa"))
                    {
                        UI.TypingEffect("🔒 Two-factor authentication adds an extra step to login, making accounts much harder to hack.");
                    }
                    else if (input.Contains("social engineering"))
                    {
                        UI.TypingEffect("🎭 Social engineering tricks people into giving info. Always verify requests, even if they seem friendly.");
                    }
                    else
                    {
                        UI.TypingEffect("🤔 That’s a good question! Try asking me about passwords, phishing, malware, VPNs, or 2FA.");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[!] An error occurred: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}


