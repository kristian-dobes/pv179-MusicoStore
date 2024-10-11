using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly string _parentPath;
        private readonly List<Image> _buffer = new();

        public ImageRepository(string parentPath)
        {
            _parentPath = parentPath;
        }

        public void Add(Image image)
        {
            _buffer.Add(image);
        }

        public void Delete(Image image)
        {
            _buffer.Remove(image);
        }

        public Image? GetById(int id)
        {
            return GetAll().FirstOrDefault(image => image.Id == id);
        }

        public IEnumerable<Image> GetAll()
        {
            var persistedImages = Directory.GetFiles(_parentPath)
                .Select(filePath =>
                {
                    var data = File.ReadAllBytes(filePath);
                    return new Image { Id = GetImageIdFromFilePath(filePath), Data = data, FilePath = filePath };
                });

            return persistedImages.Concat(_buffer);
        }

        public void SaveChanges()
        {
            foreach (var image in _buffer)
            {
                var filePath = Path.Combine(_parentPath, GetFilePathFromImageId(image.Id));
                File.WriteAllBytes(filePath, image.Data);
            }

            _buffer.Clear();
        }

        private int GetImageIdFromFilePath(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            if (int.TryParse(fileName, out int imageId))
            {
                return imageId;
            }

            return 0;
        }

        private string GetFilePathFromImageId(int imageId)
        {
            if (imageId == 0)
            {
                imageId = Random.Shared.Next();
            }

            string fileName = $"{imageId}.jpg";
            return Path.Combine(_parentPath, fileName);
        }
    }
}
