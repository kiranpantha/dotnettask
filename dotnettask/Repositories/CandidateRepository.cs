using CandidateHubAPI.Models;
using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace CandidateHubAPI.Repositories
{
    public class CandidateRepository:ICandidateRepository
    {
        private readonly string _connectionString;

        public CandidateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<string> AddOrUpdateCandidateAsync(Candidate candidate)
        {
            using DbConnection connection = new SqliteConnection(_connectionString); // Generic DbConnection
            await connection.OpenAsync();

            // Check if the candidate exists
            using DbCommand checkCommand = connection.CreateCommand();
            checkCommand.CommandText = "SELECT COUNT(*) FROM Candidates WHERE Email = @Email";
            AddParameter(checkCommand, "@Email", System.Data.DbType.String, candidate.Email);

            var exists = Convert.ToInt32(await checkCommand.ExecuteScalarAsync()) > 0;

            if (exists)
            {
                // Update the existing candidate
                using DbCommand updateCommand = connection.CreateCommand();
                updateCommand.CommandText = @"
                    UPDATE Candidates
                    SET FirstName = @FirstName,
                        LastName = @LastName,
                        PhoneNumber = @PhoneNumber,
                        PreferredCallTime = @PreferredCallTime,
                        LinkedInURL = @LinkedInURL,
                        GitHubURL = @GitHubURL,
                        Comment = @Comment
                    WHERE Email = @Email";

                AddCandidateParameters(updateCommand, candidate);
                await updateCommand.ExecuteNonQueryAsync();

                return "updated";
            }
            else
            {
                // Insert a new candidate
                using DbCommand insertCommand = connection.CreateCommand();
                insertCommand.CommandText = @"
                    INSERT INTO Candidates (FirstName, LastName, Email, PhoneNumber, PreferredCallTime, LinkedInURL, GitHubURL, Comment)
                    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @PreferredCallTime, @LinkedInURL, @GitHubURL, @Comment)";

                AddCandidateParameters(insertCommand, candidate);
                await insertCommand.ExecuteNonQueryAsync();

                return "created";
            }
        }

        private void AddParameter(DbCommand command, string name, System.Data.DbType type, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        private void AddCandidateParameters(DbCommand command, Candidate candidate)
        {
            AddParameter(command, "@FirstName", System.Data.DbType.String, candidate.FirstName);
            AddParameter(command, "@LastName", System.Data.DbType.String, candidate.LastName);
            AddParameter(command, "@Email", System.Data.DbType.String, candidate.Email);
            AddParameter(command, "@PhoneNumber", System.Data.DbType.String, candidate.PhoneNumber!);
            AddParameter(command, "@PreferredCallTime", System.Data.DbType.String, candidate.PreferredCallTime!);
            AddParameter(command, "@LinkedInURL", System.Data.DbType.String, candidate.LinkedInURL!);
            AddParameter(command, "@GitHubURL", System.Data.DbType.String, candidate.GitHubURL!);
            AddParameter(command, "@Comment", System.Data.DbType.String, candidate.Comment);
        }
    }
}
