namespace IMDBShower
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * 
             * 
             * 
             * 
             * 
             * 
             **********************
             *                    *
             *                    *
             *  ALT + F4 = Start  *
             *                    *
             *                    *
             **********************
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             **********************
             *                    *
             *                    *
             *  eller var det     *
             *  F5 = Start        *
             *  WhO kNoWs?        *
             *                    *
             **********************
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
            */



            Console.WriteLine("Hello, World!");
            IMDBReader reader = new IMDBReader();

            bool running = true;

            while (running)
            {

                Console.Clear();
                Console.WriteLine("   IMDB MENU");
                Console.WriteLine("1. Søg efter film");
                Console.WriteLine("2. Søg efter person");
                Console.WriteLine("3. Tilføj film");
                Console.WriteLine("4. Tilføj person");
                Console.WriteLine("5. Opdater film");
                Console.WriteLine("6. Slet film");
                Console.WriteLine("0. Afslut");
                Console.WriteLine("Vælg et nummer: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        Console.Write("Indtast søgeord for film: ");
                        string? searchMovie = Console.ReadLine();

                        var movies = reader.SearchMovie(searchMovie ?? "");
                        Console.WriteLine("\n🎥 Resultater:");
                        foreach (var movie in movies)
                        {
                            Console.WriteLine(movie.ToString());
                        }
                        running = false;
                        break;

                    case "2": 
                        Console.Write("Indtast søgeord for person: ");
                        string? searchPerson = Console.ReadLine();

                        var people = reader.SearchPerson(searchPerson ?? "");
                        Console.WriteLine("\n🧍 Resultater:");
                        foreach (var person in people)
                        {
                            Console.WriteLine(person.ToString());
                        }
                        running = false;
                        break;

                    case "3": 
                        Console.Write("Titel: ");
                        string? title = Console.ReadLine();

                        Console.Write("Er voksenfilm (true/false): ");

                        /* 
                           Til drengene 
                           out bool a) ? a : null;
                           bliver brugt på alle de int værdien så programmet ikke crasher hvis der fx. bliver sat it bokstav med i en int.TryParse. out = bool så hvis parse er true,
                           sender den væriden afsted, hvis flase null; håber det giver mening. 
                        */

                        bool? isAdult = bool.TryParse(Console.ReadLine(), out bool a) ? a : null;

                        Console.Write("Startår (tom = NULL): ");
                        int? startYear = int.TryParse(Console.ReadLine(), out int s) ? s : null;

                        Console.Write("Slutår (tom = NULL): ");
                        int? endYear = int.TryParse(Console.ReadLine(), out int e) ? e : null;

                        Console.Write("Varighed (minutter, tom = NULL): ");
                        int? runtime = int.TryParse(Console.ReadLine(), out int r) ? r : null;

                        Console.Write("TitleTypeId (tom = NULL): ");
                        int? typeId = int.TryParse(Console.ReadLine(), out int t) ? t : null;

                        reader.AddMovie(title ?? "Ukendt", isAdult, startYear, endYear, runtime, typeId);
                        Console.WriteLine("\n Film tilføjet!");
                        break;

                    case "4": 
                        Console.WriteLine("Lad det være blankt og tryk Enter du ikke kender informationen\n");
                        Console.Write("Navn: ");
                        string? name = Console.ReadLine();

                        Console.Write("Fødselsår (tom = NULL): ");
                        int? birth = int.TryParse(Console.ReadLine(), out int b) ? b : null;

                        Console.Write("Dødsår (tom = NULL): ");
                        int? death = int.TryParse(Console.ReadLine(), out int d) ? d : null;

                        reader.AddPerson(name ?? "Ukendt", birth, death);
                        Console.WriteLine("\nPerson tilføjet!");
                        break;

                    case "5":
                        Console.WriteLine("Lad det være blankt og tryk Enter, hvis intet skal opdateres\n");
                        Console.Write("Film-ID der skal opdateres: ");
                        int? id = int.TryParse(Console.ReadLine(), out int i) ? i : null;

                        Console.Write("Ny titel (tom = behold): ");
                        string? newTitle = Console.ReadLine();

                        Console.Write("Er voksenfilm (true/false/tom): ");
                        bool? newIsAdult = bool.TryParse(Console.ReadLine(), out bool ia) ? ia : null;

                        Console.Write("Startår (tom = NULL): ");
                        int? newStart = int.TryParse(Console.ReadLine(), out int st) ? st : null;

                        Console.Write("Slutår (tom = NULL): ");
                        int? newEnd = int.TryParse(Console.ReadLine(), out int en) ? en : null;

                        Console.Write("Varighed (tom = NULL): ");
                        int? newRun = int.TryParse(Console.ReadLine(), out int ru) ? ru : null;

                        reader.UpdateMovie(id, newTitle, newIsAdult, newStart, newEnd, newRun);
                        Console.WriteLine("\nFilm opdateret!");
                        break;

                    case "6": 
                        Console.Write("Film-ID der skal slettes: ");
                        int idToDelete = int.Parse(Console.ReadLine() ?? "0");

                        reader.DeleteMovie(idToDelete);
                        Console.WriteLine("\nFilm slettet!");
                        break;

                    case "0": 
                        running = false;
                        Console.WriteLine("\n \n OK HAJ HAJ! ses senere");
                        break;

                    default:
                        Console.WriteLine("\n Er du ok? indtast et tal imellem 0 - 6?");
                        break;
                }
            }
        }
    }
}