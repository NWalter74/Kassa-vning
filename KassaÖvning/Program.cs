public class Program
{
    private static void Main(string[] args)
    {
        int valAvAnvändaren = 0;
        List<string> wrongLoggLista = new List<string>();

        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("========== NICOLES KASSASYSTEM ==========");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Logga in (kassa)\n2. Läs logg (admin)\n3. Avsluta\n");

                valAvAnvändaren = int.Parse(Console.ReadLine());

                switch (valAvAnvändaren)
                {
                    case 1:
                        Console.WriteLine("Logga in med lösenord \"abc123\": ");
                        string userInput = Console.ReadLine();

                        if (userInput.Trim() == "abc123")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nInloggad!\n");

                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            string dateTime = DateTime.Now.ToString();
                            string wrongLoggin = " Misslyckat inloggningsförsök";

                            string writeToFile = dateTime + wrongLoggin;

                            wrongLoggLista.Add(writeToFile);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOgiltig lösenord! Försök igen.\n");

                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        using (StreamWriter streamWriter = new StreamWriter("kassasystem.log"))
                        {
                            foreach (var item in wrongLoggLista)
                            {
                                streamWriter.WriteLine(item);
                            }
                        }

                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("========== KASSASYSTEM.LOG ==========");

                        Console.ForegroundColor = ConsoleColor.White;
                        string line = "";
                        using (StreamReader streamReader = new StreamReader("kassasystem.log"))
                        {
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }

                        Console.WriteLine();

                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nKassasystemet avslutas!\n");

                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.WriteLine("\nVänligen välj en menupunkt mellan 1 - 3!\n");
                        break;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OOPS! Något gick fel!");
                Console.ForegroundColor = ConsoleColor.White;
            }

        } while (valAvAnvändaren != 3);
    }
}