namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameManager = new VideogameManager();

            //Chiedo all'utente cosa vuole fare
            Console.WriteLine("1. Inserisci un nuovo videogioco");
            Console.WriteLine("2. Ricerca videogioco per ID");
            Console.WriteLine("3. Ricerca tutti i videogiochi");
            Console.WriteLine("4. Cancella un videogioco");
            Console.WriteLine("5. Chiudere il programma");

            //Controllo che l'input inserito sia un numero intero
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Scelta non valida. Riprova.");
                continue;
            }

            switch(choice)
            {
                case 1:
                    Console.Write("Nome: ");
                    var name = Console.ReadLine();

                    Console.Write("Descrizione: ");
                    var overview = Console.ReadLine();

                    Console.Write("Data di Rilascio (dd/MM/yyyy): ");
                    var releaseDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Software house id: ");
                    var softwareHouseId = Convert.ToInt64(Console.ReadLine());

                    var game = new Videogame(0, name, overview, releaseDate, softwareHouseId);
                    gameManager.AddGame(game);

                    break;

                case 2:
                    Console.Write("Inserisci id gioco:");
                    var id = Convert.ToInt64(Console.ReadLine());
                    gameManager.SearchById(id);
                    break;

                case 3:
                    Console.Write("Inserisci il nome di un gioco: ");
                    var gameName = Console.ReadLine();
                    gameManager.SearchByName(gameName);
                    break;

                case 4:
                    Console.Write("Inserisci id gioco da eliminare: ");
                    var deleteId = Convert.ToInt64(Console.ReadLine()); 
                    gameManager.DeleteGame(deleteId);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Scelta non valida,ù riprova!");
                    break;
            }

        }
    }
}