using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBShower
{
    public class Person
    {
        public int? Id { get; set; }
        public string? PrimaryName {  get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string? Professions { get; set; }
        public override string ToString()
        {
            string name = PrimaryName ?? "Ukendt navn";
            string birth = BirthYear?.ToString() ?? "N/A";
            string death = DeathYear?.ToString() ?? "N/A";
            string professions = Professions ?? "Ingen professioner";

            return $"[{Id}] {name} ({birth} - {death}) • {professions}";
        }

    }
}
