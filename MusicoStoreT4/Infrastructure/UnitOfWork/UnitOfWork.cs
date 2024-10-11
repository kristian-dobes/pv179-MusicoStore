using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _logFilePath;
        private readonly string _imageFilePath;

        private LogMessageRepository? _logMessageRepository;
        private ImageRepository? _imageRepository;

        public UnitOfWork(string logFilePath, string imageFilePath)
        {
            _logFilePath = logFilePath;
            _imageFilePath = imageFilePath;
        }

        public IRepository<LogMessage> LogMessageRepository => _logMessageRepository ??= new LogMessageRepository(_logFilePath);
        public IRepository<Image> ImageRepository => _imageRepository ??= new ImageRepository(_imageFilePath);

        public void Commit()
        {
            _logMessageRepository?.SaveChanges();
        }

        public void Rollback()
        {
            // No rollback operation will be implemented for this example (it requires a bigger overhead)
        }
    }

}
