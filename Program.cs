using System;
using System.Windows.Forms;
using System.Media;

namespace ST10468609_Mogamat_Naeem_Meyer_PROG6221
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Play greeting.wav when the app starts
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not play greeting.wav: " + ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatBotForm());
        }
    }
}


