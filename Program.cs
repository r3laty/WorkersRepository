namespace StartOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            Worker worker = new Worker();
            
            while (true)
            {
                Console.WriteLine("Press 1 to add worker" +
                    "\nPress 2 to read file" +
                    "\nPress 3 to get worker by id" +
                    "\nPress 4 to delete worker" +
                    "\nPress 5 to get workers between to date" +
                    "\nor press ESC to leave");
                var keyInfo = Console.ReadKey(true); 
                if (keyInfo.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("Enter id of wanted worker");
                    bool askID = int.TryParse(Console.ReadLine(), out int inputId);
                    worker.Id = inputId;

                    Console.WriteLine("Enter the name of the worker");
                    string inputName = Console.ReadLine();
                    worker.FullName = inputName;

                    Console.WriteLine("Enter the age of the worker");
                    bool askAge = int.TryParse(Console.ReadLine(), out int inputAge);
                    worker.Age = inputAge;

                    Console.WriteLine("Enter the height");
                    bool askHeight = int.TryParse(Console.ReadLine(), out int inputHeight);
                    worker.Height = inputHeight;

                    Console.WriteLine("Enter worker's date of bith");
                    bool askDate  = DateTime.TryParse(Console.ReadLine(), out DateTime inputDate);
                    if (!askDate)
                    {
                        inputDate = DateTime.Now;
                    }
                    worker.DateOfBirth = inputDate;

                    Console.WriteLine("Type worker's place of birth");
                    string inputPlace = Console.ReadLine();
                    worker.PlaceOfBirth = inputPlace;
                    repository.AddWorker(worker);

                    Console.WriteLine();

                    Console.WriteLine($"ID: {worker.Id}"); 
                    Console.WriteLine($"Name: {worker.FullName}");
                    Console.WriteLine($"Age: {worker.Age}");
                    Console.WriteLine($"Height: {worker.Height}");
                    Console.WriteLine($"Date of birth: {worker.DateOfBirth.ToShortDateString()}");
                    Console.WriteLine($"Place of birth: {worker.PlaceOfBirth}");
                    Console.WriteLine();

                    Console.WriteLine("Clear the console?");
                    Console.WriteLine("1 - yes, 0 - no");
                    if (Console.ReadKey(true).Key == ConsoleKey.D1)
                    {
                        Console.Clear();
                    }
                    continue;
                }
                if (keyInfo.Key == ConsoleKey.D2)
                {
                    foreach (var currentWorker in repository.GetAllWorkers())
                    {
                        Console.WriteLine();
                        Console.WriteLine($"ID: {currentWorker.Id}");
                        Console.WriteLine($"Name: {currentWorker.FullName}");
                        Console.WriteLine($"Age: {currentWorker.Age}");
                        Console.WriteLine($"Height: {currentWorker.Height}");
                        Console.WriteLine($"Date of birth: {currentWorker.DateOfBirth.ToShortDateString()}");
                        Console.WriteLine($"Place of birth: {currentWorker.PlaceOfBirth}");
                        Console.WriteLine();
                    }

                    Console.WriteLine("Clear the console?");
                    Console.WriteLine("1 - yes, 0 - no");
                    if (Console.ReadKey(true).Key == ConsoleKey.D1)
                    {
                        Console.Clear();
                    }
                    continue;

                }
                if (keyInfo.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("Enter id of worker to find");
                    bool askedId = int.TryParse(Console.ReadLine(), out int inputId);
                    if (askedId)
                    {
                        Worker? foundWorkerById = repository.GetWorkerById(inputId);

                        Console.WriteLine($"ID: {foundWorkerById?.Id}");
                        Console.WriteLine($"Name: {foundWorkerById?.FullName}");
                        Console.WriteLine($"Age: {foundWorkerById?.Age}");
                        Console.WriteLine($"Height: {foundWorkerById?.Height}");
                        Console.WriteLine($"Date of birth: {foundWorkerById?.DateOfBirth.ToShortDateString()}");
                        Console.WriteLine($"Place of birth: {foundWorkerById?.PlaceOfBirth}");
                        Console.WriteLine();
                    }

                    Console.WriteLine("Clear the console?");
                    Console.WriteLine("1 - yes, 0 - no");
                    if (Console.ReadKey(true).Key == ConsoleKey.D1)
                    {
                        Console.Clear();
                    }
                    continue;
                }
                if (keyInfo.Key == ConsoleKey.D4)
                {
                    Console.WriteLine("Enter the id of the worker to be removed");
                    bool askedId = int.TryParse(Console.ReadLine(), out int inputId);
                    if (askedId)
                    {
                        repository.DeleteWorker(inputId);
                        Console.WriteLine();
                    }

                    Console.WriteLine("Clear the console?");
                    Console.WriteLine("1 - yes, 0 - no");
                    if (Console.ReadKey(true).Key == ConsoleKey.D1)
                    {
                        Console.Clear();
                    }
                    continue;
                }
                if (keyInfo.Key == ConsoleKey.D5)
                {
                    Console.WriteLine("Enter date from");
                    bool askedDateFrom = DateTime.TryParse(Console.ReadLine(), out DateTime inputDateFrom);
                    Console.WriteLine("Enter date to");
                    bool askedDateTo = DateTime.TryParse(Console.ReadLine(), out DateTime inputDateTo);

                    if (askedDateFrom && askedDateTo)
                    {
                        List <Worker> workersBetweenTwoDates = repository.GetWorkersBetweenTwoDates(inputDateFrom, inputDateTo);
                        foreach (var workerBetweenTwoDates in workersBetweenTwoDates)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"ID: {workerBetweenTwoDates.Id}");
                            Console.WriteLine($"Name: {workerBetweenTwoDates.FullName}");
                            Console.WriteLine($"Age: {workerBetweenTwoDates.Age}");
                            Console.WriteLine($"Height: {workerBetweenTwoDates.Height}");
                            Console.WriteLine($"Date of birth: {workerBetweenTwoDates.DateOfBirth.ToShortDateString()}");
                            Console.WriteLine($"Place of birth: {workerBetweenTwoDates.PlaceOfBirth}");
                            Console.WriteLine();
                        }

                        Console.WriteLine("Clear the console?");
                        Console.WriteLine("1 - yes, 0 - no");
                        if (Console.ReadKey(true).Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                        }
                        continue;
                    }
                }
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Good bye!");
                    break;
                }
            }
        }
    }
}