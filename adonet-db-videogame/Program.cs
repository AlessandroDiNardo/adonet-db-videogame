namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Scelta non valida riprova!");
                    break;
            }

        }
    }
}