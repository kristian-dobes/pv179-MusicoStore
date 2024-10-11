using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class LogMessageRepository : IRepository<LogMessage>
    {
        private readonly string _logFilePath;
        private readonly List<LogMessage> _buffer = new List<LogMessage>();

        public LogMessageRepository(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void Add(LogMessage logMessage)
        {
            _buffer.Add(logMessage);
        }

        public void Delete(LogMessage logMessage)
        {
            _buffer.Remove(logMessage);
        }

        public LogMessage? GetById(int id)
        {
            return GetAll().FirstOrDefault(logMessage => logMessage.Id == id);
        }


        public IEnumerable<LogMessage> GetAll()
        {
            CreateFileIfDoesNotExist();

            var persistedMessages = File.ReadAllLines(_logFilePath)
                .Select(line =>
                {
                    var parts = line.Split('-');
                    if (parts.Length >= 2 && int.TryParse(parts[0].Trim(), out int id))
                    {
                        return new LogMessage { Id = id, Message = parts[1].Trim() };
                    }
                    return null;
                })
                .Where(logMessage => logMessage != null);

            return persistedMessages.Concat(_buffer);
        }

        public void SaveChanges()
        {
            CreateFileIfDoesNotExist();

            var logMessages = GetAll();

            var lastId = 0;

            foreach (LogMessage logMessage in logMessages)
            {
                if (logMessage.Id == 0)
                {
                    logMessage.Id = ++lastId;
                }

                lastId = logMessage.Id;
            }

            var lines = logMessages.Select(logMessage => $"{logMessage.Id} - {logMessage.Message}");
            File.WriteAllLines(_logFilePath, lines);
            _buffer.Clear();
        }

        private void CreateFileIfDoesNotExist()
        {
            // Create the folder if it doesn't exist
            var folderPath = Path.GetDirectoryName(_logFilePath);
            if (folderPath != null && !Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Create the file if it doesn't exist
            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Dispose();
            }
        }
    }

}
