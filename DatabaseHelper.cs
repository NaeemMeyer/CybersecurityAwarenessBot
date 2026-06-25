using System;
using MySql.Data.MySqlClient;

namespace ST10468609_Mogamat_Naeem_Meyer_PROG6221
{
    public static class DatabaseHelper
    {
        // Connection string configured with your specified credentials
        private static readonly string connString = "Server=localhost;Database=cyber_bot_db;Uid=root;Pwd=YourPassword;";

        /// <summary>
        /// Initializes the database by creating the required tasks table if it does not already exist.
        /// </summary>
        public static void InitializeDatabase()
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string tableQuery = @"
                    CREATE TABLE IF NOT EXISTS user_tasks (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        title VARCHAR(255) NOT NULL,
                        description TEXT NULL,
                        reminder_date DATETIME NULL,
                        is_completed TINYINT(1) DEFAULT 0
                    );";
                using (var cmd = new MySqlCommand(tableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Inserts a new cybersecurity task along with its description and optional reminder date into the database.
        /// </summary>
        /// <param name="title">The headline or summary of the task.</param>
        /// <param name="description">The contextual details or action items.</param>
        /// <param name="reminderDate">The calculated future date and time for the reminder, or null if no reminder is set.</param>
        public static void AddTask(string title, string description, DateTime? reminderDate)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO user_tasks (title, description, reminder_date) VALUES (@title, @desc, @reminder);";
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@reminder", (object)reminderDate ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
