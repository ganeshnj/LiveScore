using System;
using System.Collections.Generic;
using LiveScore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveScore.Admin.Models
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        public string SelectedTeam1 { get; set; }
        public IEnumerable<SelectListItem> Teams1 { get; set; }

        public string SelectedTeam2 { get; set; }
        public IEnumerable<SelectListItem> Teams2 { get; set; }

        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public MatchStatus Status { get; set; }
    }
}
