using Microsoft.Data.SqlClient;

namespace TradeScope.Infrastructure
{
    public sealed class SqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<SqlConnection> CreateOpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellationToken).ConfigureAwait(false);
            return conn;
        }
    }
}
