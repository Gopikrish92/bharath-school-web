using BharathSchool.Web.Data;
using BharathSchool.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BharathSchool.Web.Services
{
    public class MediaService : IMediaService
    {
        private readonly ApplicationDbContext _db;

        public MediaService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Media> AddMediaAsync(int activityId, string filePath, string mediaType, Guid uploadedBy)
        {
            var media = new Media
            {
                ActivityId = activityId,
                FilePath = filePath,
                MediaType = mediaType,
                UploadedBy = uploadedBy,
                UploadedAt = DateTime.UtcNow
            };

            _db.Media.Add(media);
            await _db.SaveChangesAsync();
            return media;
        }

        public async Task<bool> DeleteMediaAsync(int mediaId)
        {
            var media = await _db.Media.FindAsync(mediaId);
            if (media == null)
                return false;

            _db.Media.Remove(media);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Media>> GetActivityMediaAsync(int activityId)
        {
            return await _db.Media
                .Where(m => m.ActivityId == activityId)
                .OrderByDescending(m => m.UploadedAt)
                .ToListAsync();
        }

        public async Task<Media> GetMediaByIdAsync(int mediaId)
        {
            return await _db.Media.FindAsync(mediaId);
        }
    }
}
