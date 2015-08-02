using System.Threading.Tasks;

namespace WOWSharp.Core
{
    /// <summary>
    /// Battle.NET client service
    /// </summary>
    public interface IBattleNetClient
    {
        /// <summary>
        /// Fetches an and parse data from battle.net API
        /// </summary>
        /// <typeparam name="TResult">Type of data to get</typeparam>
        /// <param name="path">Relative path of data</param>
        /// <returns>Result data</returns>
        Task<TResult> GetAsync<TResult>(string path) where TResult : ApiResponse;
    }
}