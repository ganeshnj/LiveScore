using System;
using System.Collections.Generic;
using System.Text;

namespace LiveScore.Xam.Models
{
    public enum MenuItemType
    {
        Matches,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
