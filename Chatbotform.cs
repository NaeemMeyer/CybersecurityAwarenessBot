using System;
using System.Collections.Generic;
using System.Media;
using System.Text.RegularExpressions;
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

        // Part 3 State Control Extensions
        private enum BotState { Normal, WaitingForReminder, QuizActive }
        private BotState currentSessionState = BotState.Normal;
        
        private List<string> activityLog = new List<string>();
        private List<QuizQuestion> quizQuestions;
        private int currentQuizIndex = -1;
        private int quizScore = 0;
        private string pendingTaskTitle = "";

        public ChatBotForm()
        {
            InitializeComponent();
            InitializeChatBot();
            InitializeQuizEngine();
            
            try 
            { 
                DatabaseHelper.InitializeDatabase(); 
            }
            catch (Exception ex) 
            { 
                AppendBotMessage($"[Database Warning] Could not connect to MySQL: {ex.Message}"); 
            }

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

        private void InitializeQuizEngine()
        {
            // Set up more than 10 dynamic quiz questions across distinct cyber spaces to fulfill Task 2 requirements
            quizQuestions = new List<QuizQuestion>
            {
                new QuizQuestion { QuestionText = "What should you do if you receive an email asking for your password?", Options = new List<string>{"A) Reply with password", "B) Delete the email", "C) Report email as phishing", "D) Ignore it"}, CorrectAnswer = "C", Explanation = "Reporting phishing emails helps security teams block malicious infrastructure scams." },
                new QuizQuestion { QuestionText = "A password manager is inherently insecure because it stores all credentials in one space.", Options = new List<string>{"A) True", "B) False"}, CorrectAnswer = "B", Explanation = "Password managers use high-level local vault encryptions and encourage unique credential usage." },
                new QuizQuestion { QuestionText = "Which option represents the strongest credential building pattern?", Options = new List<string>{"A) P@ssword123!", "B) CorrectHorseBatteryStaple7$", "C) admin123", "D) MyBirthYear1995"}, CorrectAnswer = "B", Explanation = "Long, non-obvious random multi-word passphrases maximize overall brute-force security resistance." },
                new QuizQuestion { QuestionText = "What core technique is used when a bad actor calls posing as IT support to get passwords?", Options = new List<string>{"A) Phishing", "B) Social Engineering", "C) Ransomware", "D) Injection"}, CorrectAnswer = "B", Explanation = "Social Engineering relies directly on human psychological manipulation rather than pure code exploits." },
                new QuizQuestion { QuestionText = "You should turn on Two-Factor Authentication (2FA) only for bank accounts.", Options = new List<string>{"A) True", "B) False"}, CorrectAnswer = "B", Explanation = "2FA must be systematically deployed across every digital account profile to shield baseline identities." },
                new QuizQuestion { QuestionText = "What does a green padlock sign symbol inside browser URL paths guarantee?", Options = new List<string>{"A) The site is 100% safe", "B) Connection is encrypted", "C) No malware exists", "D) Certified company owned"}, CorrectAnswer = "B", Explanation = "Padlocks verify encrypted communications via HTTPS, though scam phishing sites can still easily use them." },
                new QuizQuestion { QuestionText = "If your system gets infected with ransomware, you must immediately pay the hackers.", Options = new List<string>{"A) True", "B) False"}, CorrectAnswer = "B", Explanation = "Paying never guarantees file recovery decryption and funds further criminal operational networks." },
                new QuizQuestion { QuestionText = "Which network connectivity type poses the highest operational intercept risk?", Options = new List<string>{"A) Home Wi-Fi", "B) Cellular 5G Data", "C) Public Unencrypted Wi-Fi", "D) Wired Ethernet Connection"}, CorrectAnswer = "C", Explanation = "Public open networks leave transmission packets completely vulnerable to local man-in-the-middle sniffing." },
                new QuizQuestion { QuestionText = "Smishing is a type of phishing attack executed directly through mobile SMS messaging.", Options = new List<string>{"A) True", "B) False"}, CorrectAnswer = "A", Explanation = "Smishing leverages phone text links to route victims into malicious credential-harvesting web panes." },
                new QuizQuestion { QuestionText = "What action is best when an application prompts you to run a critical software update?", Options = new List<string>{"A) Delay for 1 month", "B) Apply patch promptly", "C) Delete application", "D) Ignore indefinitely"}, CorrectAnswer = "B", Explanation = "Applying system security patches closes immediate vulnerabilities being actively targeted by exploits out in the wild." },
                new QuizQuestion { QuestionText = "An unexpected file named 'invoice.exe' arrives from a close client. What do you do?", Options = new List<string>{"A) Double click to open", "B) Forward to friends", "C) Verify sender and inspect file", "D) Rename file extensions"}, CorrectAnswer = "C", Explanation = "Executables masquerading as structural office documents represent primary file-dropper malware patterns." }
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

            ProcessInput(input);
        }

        private void ProcessInput(string rawInput)
        {
            string input = rawInput.ToLower();

            // Intercept & log execution tracking events across runtime changes
            LogActivity($"User entry processed: '{rawInput}'");

            // --- State Guard Architecture ---
            if (currentSessionState == BotState.WaitingForReminder)
            {
                HandleReminderState(rawInput);
                return;
            }
            if (currentSessionState == BotState.QuizActive)
            {
                HandleQuizState(input);
                return;
            }

            // --- Task 3: Regex & Advanced Keyword Matching Engine ---
            if (input.Contains("worried"))
            {
                AppendBotMessage("😟 It’s understandable to feel worried. Scammers can be convincing. Let me share some tips to help you stay safe.");
                AppendBotMessage(GetRandomResponse("scam"));
                return;
            }
            if (input.Contains("curious"))
            {
                AppendBotMessage("🤔 Curiosity is great! Let’s explore this topic together.");
                return;
            }
            if (input.Contains("frustrated"))
            {
                AppendBotMessage("😓 I hear your frustration. Cybersecurity can be overwhelming, but I’ll guide you step by step.");
                return;
            }
            if (input.Contains("exit") || input.Contains("quit"))
            {
                AppendBotMessage("👋 Goodbye! Stay safe online.");
                Application.Exit();
                return;
            }
            if (input.Contains("help"))
            {
                AppendBotMessage("📚 I can answer questions about: Passwords, Phishing, Malware, Scams, Privacy.\n💡 Type 'quiz' to test your skills, 'add task [details]' to plan reminders, or 'show activity log' to view action history.");
                return;
            }

            // Task 4 Trigger Logic
            if (input.Contains("activity log") || input.Contains("what have you done") || input.Contains("show log"))
            {
                DisplayActivityLog();
                return;
            }

            // Task 2 Activation Logic
            if (input.Contains("quiz") || input.Contains("game") || input.Contains("test"))
            {
                StartQuizSession();
                return;
            }

            // Task 1 Task Addition Parser Logic
            var matchTask = Regex.Match(input, @"(?:add task|remind me to)\s+(.+)");
            if (matchTask.Success)
            {
                pendingTaskTitle = rawInput.Substring(matchTask.Groups[1].Index).Trim();
                AppendBotMessage($"Task identified: '{pendingTaskTitle}'. Would you like to set a time reminder for this task? (e.g., 'Yes, in 3 days', 'tomorrow', or 'no')");
                currentSessionState = BotState.WaitingForReminder;
                return;
            }

            if ((input.Contains("more") || input.Contains("another")) && !string.IsNullOrEmpty(lastTopic))
            {
                AppendBotMessage(GetRandomResponse(lastTopic));
                return;
            }

            // Traditional Dictionary Iteration Loops
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    lastTopic = keyword;
                    AppendBotMessage(GetRandomResponse(keyword));
                    return;
                }
            }

            AppendBotMessage("🤔 I'm not sure I quite understood that command. Could you please try rephrasing your question?");
        }

        // --- Task 1 Architecture Core Logic Methods ---
        private void HandleReminderState(string input)
        {
            string cleanInput = input.ToLower();
            DateTime? targetReminderDate = null;
            string descriptionStr = $"Task tracking entry organized regarding: {pendingTaskTitle}.";

            if (cleanInput.Contains("no") || cleanInput.Contains("none"))
            {
                AppendBotMessage($"Understood. Task added: '{pendingTaskTitle}' with no reminder dates attached.");
            }
            else
            {
                int daysToAdd = 0;
                var matchDays = Regex.Match(cleanInput, @"in\s+(\d+)\s+day");
                
                if (matchDays.Success)
                {
                    daysToAdd = int.Parse(matchDays.Groups[1].Value);
                    targetReminderDate = DateTime.Now.AddDays(daysToAdd);
                }
                else if (cleanInput.Contains("tomorrow"))
                {
                    daysToAdd = 1;
                    targetReminderDate = DateTime.Now.AddDays(1);
                }
                else
                {
                    daysToAdd = 7; // Default baseline fallback setting assignment
                    targetReminderDate = DateTime.Now.AddDays(7);
                }

                AppendBotMessage($"Got it! I'll remind you about '{pendingTaskTitle}' on {targetReminderDate.Value.ToShortDateString()}.");
                descriptionStr += $" (Reminder assigned within: {daysToAdd} days).";
            }

            try
            {
                DatabaseHelper.AddTask(pendingTaskTitle, descriptionStr, targetReminderDate);
                LogActivity($"Task Added successfully to Database: '{pendingTaskTitle}'");
            }
            catch (Exception ex)
            {
                AppendBotMessage($"[Database Error] Failed to write task record: {ex.Message}");
            }

            // Reset workflow parameters back to baseline processing state
            pendingTaskTitle = "";
            currentSessionState = BotState.Normal;
        }

        // --- Task 2 Architecture Core Logic Methods ---
        private void StartQuizSession()
        {
            LogActivity("Quiz mode session initialized.");
            quizScore = 0;
            currentQuizIndex = 0;
            currentSessionState = BotState.QuizActive;
            AppendBotMessage("🎮 Cybersecurity Awareness Interactive Quiz Module Activated!");
            PresentQuizQuestion();
        }

        private void PresentQuizQuestion()
        {
            if (currentQuizIndex < quizQuestions.Count)
            {
                var q = quizQuestions[currentQuizIndex];
                AppendBotMessage($"\nQuestion {currentQuizIndex + 1}: {q.QuestionText}");
                foreach (var option in q.Options)
                {
                    AppendBotMessage(option);
                }
            }
        }

        private void HandleQuizState(string input)
        {
            var q = quizQuestions[currentQuizIndex];
            string cleanAnswer = input.Trim().ToUpper();

            // Match exact value choices or full contextual string definitions
            if (cleanAnswer.Contains(q.CorrectAnswer))
            {
                quizScore++;
                AppendBotMessage($"✅ Correct! {q.Explanation}");
            }
            else
            {
                AppendBotMessage($"❌ Incorrect! The correct answer was option ({q.CorrectAnswer}). {q.Explanation}");
            }

            currentQuizIndex++;

            if (currentQuizIndex < quizQuestions.Count)
            {
                PresentQuizQuestion();
            }
            else
            {
                string evalSummary = quizScore >= 8 ? "Great job! You're a cybersecurity pro!" : "Keep learning to stay safe online!";
                AppendBotMessage($"\n🏁 Quiz Complete! Final Score Card: {quizScore}/{quizQuestions.Count}.");
                AppendBotMessage($"🤖 Feedback: {evalSummary}");
                
                LogActivity($"Quiz system completed. Final score card tracked: {quizScore}/{quizQuestions.Count}");
                currentSessionState = BotState.Normal;
            }
        }

        // --- Task 4 Architecture Logging Utility Methods ---
        private void LogActivity(string descriptivePayload)
        {
            string trackingStatement = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {descriptivePayload}";
            activityLog.Add(trackingStatement);
        }

        private void DisplayActivityLog()
        {
            AppendBotMessage("📊 Here is a concise summary of recent chatbot activity:");
            
            int total = activityLog.Count;
            if (total == 0)
            {
                AppendBotMessage("No operational logs recorded within this execution context session branch.");
                return;
            }

            // Enforce constraints to display only the last 5-10 items smoothly
            int boundIndex = Math.Max(0, total - 7);
            int entryId = 1;

            for (int i = boundIndex; i < total; i++)
            {
                AppendBotMessage($"{entryId}. {activityLog[i]}");
                entryId++;
            }
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
            ScrollChatToBottom();
        }

        private void AppendBotMessage(string message)
        {
            conversationHistory.Add($"Bot: {message}");
            lstChat.Items.Add($"🤖 Bot: {message}");
            ScrollChatToBottom();
        }

        private void ScrollChatToBottom()
        {
            lstChat.SelectedIndex = lstChat.Items.Count - 1;
            lstChat.ClearSelected();
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
            
            LogActivity("Main application view initialized and displayed.");
        }
    }
}
