namespace MiniORMLive
{
    using System.Data.SqlClient;
    class ConnectionStringBuilder
    {
        private SqlConnectionStringBuilder connectionString;

        public ConnectionStringBuilder(string databaseName)
        {
            this.connectionString = new SqlConnectionStringBuilder();
            this.connectionString["Server"] = ".";
            this.connectionString["Integrated Security"] = true;
            this.connectionString["Trusted_Connection"] = true;
            this.connectionString["Connect Timeout"] = 1000;
            this.connectionString["Database"] = databaseName;
        }

        public string ConnectionString => this.connectionString.ToString();
    }
}
