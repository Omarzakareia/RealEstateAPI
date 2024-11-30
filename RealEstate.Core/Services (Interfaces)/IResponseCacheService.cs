namespace RealEstate.Core.Services;
public interface IResponseCacheService
{
    Task CacheResponseAsync(string cacheKey, object response, TimeSpan ExpireTime);    // Cache Data 
    Task<string?> GetCachedResponse(string cacheKey);    // Get Cached Data 
    Task RemoveCachedResponse(string cacheKey);  // Method to remove cache
}
