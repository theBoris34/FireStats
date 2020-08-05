using MySql.Data.MySqlClient;

namespace FireStats.BL.Model
{
    public class DataBase
    {
        static string serverHost = "localhost";
        static string serverPort = "3306";
        static string serverUserName = "root";
        static string serverUserPassword = "root";
        static string serverNameDataBase = "firestats";

        MySqlConnection connection = new MySqlConnection($"server={serverHost};port={serverPort};username={serverUserName};password={serverUserPassword};database={serverNameDataBase}");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

    }
}
