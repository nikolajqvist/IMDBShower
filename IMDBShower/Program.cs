namespace IMDBShower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IMDBReader reader = new IMDBReader();

            List<Titles> list = reader.SearchMovie("Lord of the rings");

            //foreach (Titles title in list)
            //{
                //Console.WriteLine(title.ToString());
            //}
            Console.WriteLine();
            List<Person> plist = reader.SearchPerson("Johnny Depp");
            foreach (Person person in plist)
            {
                Console.WriteLine(person.ToString());
            }
        }// dasd
    }
}
