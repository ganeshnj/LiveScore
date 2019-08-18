using System;
using LiveScore.Xam.ViewModels;

namespace LiveScore.Xam.Models
{
    public class TeamViewModel : ExtendedBindableObject
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
    }
}
