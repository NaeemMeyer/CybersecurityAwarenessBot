namespace ST10468609_Mogamat_Naeem_Meyer_PROG6221
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not play greeting.wav structural initialization audio: " + ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatBotForm());
        }
    }
}


