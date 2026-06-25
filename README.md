CybersecurityAwarenessBot
A C# chatbot project for cybersecurity awareness

A C# console chatbot project designed to teach cybersecurity concepts in a fun and interactive way.  
It features ASCII art, colorful console UI, friendly responses, and even a voice greeting.

---

FEATURES:
- Creative ASCII art logo with borders
-  Personalized greeting with emoji and colors
-  Keyword-based responses for natural conversation
-  Expanded topics: passwords, phishing, malware, ransomware, VPNs, 2FA, social engineering
-  Exception handling for stability
-  Color-coded UI (cyan for input, yellow for welcome, magenta for help, red for errors)
-  Plays a custom voice greeting (`greeting.wav`)

---

HOW TO RUN
1. Clone the repository:
   ```bash
   git clone https://github.com/NaeemMeyer/CybersecurityAwarenessBot.git

PROJECT STRUCTURE
CybersecurityAwarenessBot/
 └── ST10468609-Mogamat-Naeem-Meyer-PROG6221/
      ├── Program.cs
      ├── ST10468609-Mogamat-Naeem-Meyer-PROG6221.csproj
      ├── greeting.wav
      ├── bin/   
      └── obj/   

📝 COMMIT HISTORY
Commit 1
README added with comments

Commit 2
Keyword matching: Bot now looks for keywords (e.g., “password”, “vpn”) instead of exact phrases

Expanded topics: Added answers for malware, ransomware, social engineering, VPNs, and 2FA

Friendlier responses: Conversational tone (“That’s a good question!”)

Flexible exit: Recognizes both “exit” and “quit”

Commit 3
ASCII art logo with borders and green color

Greeting with emoji and colors

Basic responses for common cybersecurity topics

Help command to list available topics

Exception handling added

Color-coded UI (cyan, yellow, magenta, red)

Commit 4
Added greeting.wav folder

Final Commit
Finalized code structure and logic


Fixed greeting audio: converted from .m4a to proper .wav format


<img width="639" height="306" alt="Snipping of C# success" src="https://github.com/user-attachments/assets/1d3cabc9-69ea-429b-a47f-6d0cf652f64d" />

Part 2 – Work Done
Enhancements Implemented
Integrated Windows Forms interface for a more interactive experience.

Added audio playback using SoundPlayer to play greeting.wav at startup.

Updated .csproj to automatically copy the audio file into the build output.

Improved error handling for missing or inaccessible audio files.

Ensured multi-topic keyword detection for smoother chatbot responses.

Refined UI layout for better readability and user engagement.

Verified compatibility with .NET 6.0 Windows Desktop SDK.

Cleaned up duplicate build artifacts (bin and obj) to prevent compilation errors.

Testing and Validation
Confirmed successful build and execution via dotnet run.

Verified that greeting.wav plays correctly on startup.

Tested all keyword responses for accuracy and tone.

Ensured color-coded console output matches design intent.

Validated exception handling for empty input and invalid commands.

Outcome
The chatbot now runs smoothly with both visual and auditory feedback, providing an engaging way to learn cybersecurity concepts interactively.

Part 1 amendments:
Added CI Workflow 


Part 3 :
## 🚀 Core Features

### 💻 Visual & Auditory Interface
*   **Dual-Interface Heritage:** Combines a beautifully color-coded Console UI (Cyan for inputs, Yellow for welcomes, Magenta for help guides, and Red for runtime errors) with a modern, responsive **Windows Forms** desktop interface.
*   **Immersive Media:** Leverages the native Windows `SoundPlayer` API to trigger an automated voice greeting (`greeting.wav`) right at application startup, complete with strict fallback exception handling to prevent application crashes if audio hardware or files are missing.
*   **Creative Presentation:** Eye-catching ASCII art branding, responsive borders, and emoji integration designed to lower the barrier of entry for security students.

### 🧠 Advanced Text Processing & NLP
*   **Intent-Based Keyword Matching:** Replaces rigid phrase matching with an intelligent, normalized NLP text parsing layer. The bot strips punctuation, normalizes casing, and maps user queries directly to cybersecurity topic domains.
*   **Comprehensive Knowledge Base:** Out-of-the-box conversational training covering:
    *   *Password Hygiene & Two-Factor Authentication (2FA)*
    *   *Phishing Detection & Social Engineering Vectors*
    *   *Malware, Ransomware, and Virtual Private Networks (VPNs)*

### 🎮 Gamified Evaluation & Persistence
*   **Multi-Format Quiz Structures:** An interactive quiz subsystem supporting Multiple Choice Questions (MCQs), True/False scenarios, and practical Phishing Email Simulations.
*   **MySQL Database Integration:** A secure local database backend managed via a parameterized `DatabaseHelper` class.
*   **Local Activity Tracking:** Automatically audits and captures user session telemetry, logging timestamps, unique session IDs, action tracking metrics (`CHAT_QUERY`, `QUIZ_SCORE`), and learning task progression data.

---

## 📁 Project Structure

```text
CybersecurityAwarenessBot/
├── .github/workflows/                 # Continuous Integration (CI) Workflow schemas
├── ST10468609-Mogamat-Naeem-Meyer-PROG6221/
│   ├── Program.cs                     # Main application entry point & thread orchestrator
│   ├── ST10468609-Mogamat-Naeem-Meyer-PROG6221.csproj  # Target framework & asset copying build rules
│   ├── greeting.wav                   # Startup auditory asset (PCM-encoded WAV)
│   ├── DatabaseHelper.cs              # Parameterized MySQL data access layer
│   ├── QuizEngine.cs                  # Polymorphic quiz handler and evaluation logic
│   ├── bin/                           # Compiled binaries (excluded from version control)
│   └── obj/                           # Build artifacts (cleanly managed to prevent conflicts)
└── README.md


Detailed Commit Breakdowns
Commit 1:
feat: added local MySQL database initialization scripts and helper classes
The Technical Focus: Establishing the data persistence layer and data access object (DAO) patterns.
This commit lays the foundational backend infrastructure for the application by integrating a local MySQL database. It includes raw .sql initialization scripts that automatically generate the database schema, required tables (such as users, activity_logs, and quiz_records), and seed data for initial testing. Alongside the database, a dedicated DatabaseHelper or MySqlConnector class was introduced. This helper class manages connection pooling, safely opens and closes connections, and exposes parameterized methods to execute queries and non-queries, strictly preventing SQL injection vulnerabilities right from the start.

Commit 2:
feat: integrated local activity logging tracker mechanism
The Technical Focus: User session tracking, auditing, and state persistence.
Building on the database layer, this feature implements an automated, real-time logging engine that captures user telemetry during runtime. Whenever a user interacts with the chatbot, initiates a query, or finishes an assignment task, the backend automatically serializes this event. The tracker captures a timestamp, the session ID, the type of action (e.g., CHAT_QUERY, TASK_COMPLETE), and a payload description. This data is piped directly into the local MySQL database, creating a clean audit trail that allows the application to dynamically reconstruct the user's progress dashboard upon subsequent logins.

Commit 3:
feat: introduced multi-format cybersecurity quiz structures
The Technical Focus: Gamification, polymorphic data models, and educational logic.
This commit introduces the interactive mini-game component via a robust, extensible quiz engine. Rather than relying on rigid, single-format questions, the backend was refactored to support polymorphic quiz structures—specifically Multiple Choice Questions (MCQs), True/False scenarios, and interactive Phishing Email Simulation analysis. A core QuizEngine class handles the random selection of questions from the database, evaluates user inputs against encryption-checked answer keys, calculates real-time scoring metrics, and prepares the final score payload to be handed off to the activity logger.

Commit 4:
feat: enhanced NLP text processing parsing layers
The Technical Focus: Natural Language Processing (NLP), intent recognition, and regex matching.
To make the chatbot feel conversational rather than rule-bound, this update replaces basic keyword-matching with an upgraded text-processing pipeline. The input string parsing layer was enhanced to handle text normalization (lowercasing, punctuation stripping, and whitespace trimming), tokenization, and stop-word removal. It introduces a structured intent-recognition map that scores user queries against known cybersecurity domains (e.g., password security, social engineering, malware protection). This drastically reduces false-negative responses when users phrase questions naturally or introduce minor typos.

Commit 5:
fix: corrected UI thread state transitions between chat and quiz blocks
The Technical Focus: Multithreading, asynchronous UI programming, and state management.
A critical bug fix addressing an issue where switching between the resource-heavy NLP chat interface and the interactive quiz module would occasionally freeze the application or throw a Cross-thread operation not valid exception. This fix ensures that heavy database fetches and text processing tasks run entirely on background threads using asynchronous patterns (async/await / Task). Upon completion, UI updates are marshaled back to the main UI thread using the framework's dispatcher. It also introduces a clean state machine to cleanly dispose of the chat view's memory and resource handles before initializing the quiz view.

Commit 6:
docs: populated README instructions with setup and execution schemas
The Technical Focus: Project documentation, deployment guidelines, and developer onboarding.
The final component of the development cycle, wrapping the entire repository in consumer-ready documentation. The README.md file was fully populated with comprehensive project onboarding requirements. It details prerequisite environment software (Visual Studio workloads, local MySQL server versions), step-by-step repository cloning and NuGet package restoration instructions, a visual directory schema map, explicit connection-string modification guides, and the terminal commands required to run the local database initialization scripts.




👨‍💻 AUTHOR
Developed by Naeem Meyer as part of a cybersecurity awareness project.
