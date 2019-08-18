using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveScore.Xam.Services
{
    public interface IHttpRequester
    {
        Task<IEnumerable<T>> GetItemsAsync<T>(string url);
        Task<T> GetItemAsync<T>(string url);
    }
}
