using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace ST10468609_Mogamat_Naeem_Meyer_PROG6221
{
    public partial class ChatBotForm : Form
    {
        private string userName = "User";
        private Dictionary<string, List<string>> keywordResponses;
        private List<string> conversationHistory;
        private string lastTopic = "";
        private Random random;

        public ChatBotForm()
        {
            InitializeComponent();
            InitializeChatBot();
            PlayGreeting();
        }

        private void InitializeChatBot()
        {
            random = new Random();
            conversationHistory = new List<string>();

            keywordResponses = new Dictionary<string, List<string>>()
            {
                { "password", new List<string> {
                    "🔑 Strong passwords should be long, unique, and include letters, numbers, and symbols.",
                    "Make sure to use strong, unique passwords for each account. Avoid using personal details.",
                    "Passwords should be at least 12 characters long and never reused across accounts."
                }},
                { "phishing", new List<string> {
                    "📧 Phishing emails pretend to be trusted sources. Watch for suspicious links and urgent language.",
                    "Be cautious of emails asking for personal info. Always verify the sender.",
                    "Phishing attempts often use fear or urgency. Slow down and double-check before clicking."
                }},
                { "malware", new List<string> {
                    "🦠 Malware is harmful software. Avoid downloads from untrusted sites and keep antivirus updated.",
                    "Malware can steal data or damage systems. Keep your OS and apps patched.",
                    "Use antivirus and avoid suspicious attachments to reduce malware risks."
                }},
                { "scam", new List<string> {
                    "⚠️ Online scams trick people into giving money or info. Always verify before acting.",
                    "Scammers often pose as trusted companies. Double-check URLs and requests.",
                    "Never share sensitive info unless you’re 100% sure of the source."
                }},
                { "privacy", new List<string> {
                    "🔒 Protect your privacy by limiting what you share online.",
                    "Use privacy settings on social media to control who sees your info.",
                    "A VPN can help protect your privacy by hiding your IP address."
                }}
            };
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Load();
                player.Play();
            }
            catch
            {
                AppendBotMessage("[!] Greeting audio not found, continuing without sound...");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtUserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            AppendUserMessage(input);
            txtUserInput.Clear();

            ProcessInput(input.ToLower());
        }

        private void ProcessInput(string input)
        {
            if (input.Contains("worried"))
            {
                AppendBotMessage("😟 It’s understandable to feel worried. Scammers can be convincing. Let me share some tips to help you stay safe.");
                AppendBotMessage(GetRandomResponse("scam"));
                return;
            }
            else if (input.Contains("curious"))
            {
                AppendBotMessage("🤔 Curiosity is great! Let’s explore this topic together.");
            }
            else if (input.Contains("frustrated"))
            {
                AppendBotMessage("😓 I hear your frustration. Cybersecurity can be overwhelming, but I’ll guide you step by step.");
            }

            if (input.Contains("exit") || input.Contains("quit"))
            {
                AppendBotMessage("👋 Goodbye! Stay safe online.");
                Application.Exit();
                return;
            }

            if (input.Contains("help"))
            {
                AppendBotMessage("📚 I can answer questions about: Passwords, Phishing, Malware, Ransomware, VPNs, 2FA, Social Engineering, Scams, Privacy.");
                return;
            }

            if ((input.Contains("more") || input.Contains("another")) && !string.IsNullOrEmpty(lastTopic))
            {
                AppendBotMessage(GetRandomResponse(lastTopic));
                return;
            }

            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    lastTopic = keyword;
                    AppendBotMessage(GetRandomResponse(keyword));
                    return;
                }
            }

            AppendBotMessage("🤔 I’m not sure I understand. Can you try rephrasing?");
        }

        private string GetRandomResponse(string keyword)
        {
            var responses = keywordResponses[keyword];
            return responses[random.Next(responses.Count)];
        }

        private void AppendUserMessage(string message)
        {
            conversationHistory.Add($"User: {message}");
            lstChat.Items.Add($"👤 {userName}: {message}");
        }

        private void AppendBotMessage(string message)
        {
            conversationHistory.Add($"Bot: {message}");
            lstChat.Items.Add($"🤖 Bot: {message}");
        }

        private void ChatBotForm_Load(object sender, EventArgs e)
        {
            lblLogo.Text =
                "   ██████╗ ██╗   ██╗██████╗ ███████╗██████╗       \n" +
                "  ██╔═══██╗██║   ██║██╔══██╗██╔════╝██╔══██╗      \n" +
                "  ██║   ██║██║   ██║██████╔╝█████╗  ██████╔╝      \n" +
                "  ██║   ██║██║   ██║██╔═══╝ ██╔══╝  ██╔═══╝       \n" +
                "  ╚██████╔╝╚██████╔╝██║     ███████╗██║           \n" +
                "   ╚═════╝  ╚═════╝ ╚═╝     ╚══════╝╚═╝           \n" +
                "        Cybersecurity Awareness Bot               ";
        }
    }
}
