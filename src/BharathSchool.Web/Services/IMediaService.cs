using BharathSchool.Web.Models;

namespace BharathSchool.Web.Services
{
    public interface IMediaService
    {
        Task<Media> AddMediaAsync(int activityId, string filePath, string mediaType, Guid uploadedBy);
        Task<bool> DeleteMediaAsync(int mediaId);
        Task<IEnumerable<Media>> GetActivityMediaAsync(int activityId);
        Task<Media> GetMediaByIdAsync(int mediaId);
    }
}
