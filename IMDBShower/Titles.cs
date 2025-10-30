using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBShower
{
    public class Titles
    {
        public int? Id { get; set; }
        public string? PrimaryTitle {  get; set; }
        public int? StartYear { get; set; }
        public int? RunTimeMinutes { get; set; }
        public string? TitleTypeId { get; set; }
        public string? Genres { get; set; }

        public override string ToString()
        {
            string title = PrimaryTitle ?? "Ukendt titel";
            string year = StartYear?.ToString() ?? "N/A";
            string runtime = RunTimeMinutes?.ToString() ?? "N/A";
            string type = TitleTypeId ?? "N/A";
            string genres = Genres ?? "Ingen genre";

            return $"[{Id}] {title} ({year}) • {runtime} min • {type} • {genres}";
        }
    }
}
