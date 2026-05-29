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


👨‍💻 AUTHOR

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
Developed by Naeem Meyer as part of a cybersecurity awareness project.
