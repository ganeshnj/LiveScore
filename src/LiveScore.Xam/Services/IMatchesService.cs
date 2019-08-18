using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveScore.Xam.Models;

namespace LiveScore.Xam.Services
{
    public interface IMatchesService
    {
        Task<IEnumerable<MatchViewModel>> GetMatches();
        Task<MatchViewModel> GetMatchById(int id);
    }
}
