using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartOOP
{
    class Repository
    {
        private List<Worker> workers = new List<Worker>();

        public void AddWorker(Worker worker)
        {
            workers.Add(worker);
            try
            {
                using (StreamWriter writer = new StreamWriter("workers.txt", true))
                {
                    string line = $"{worker.Id},{worker.FullName},{worker.Age},{worker.Height},{worker.DateOfBirth.ToShortDateString()},{worker.PlaceOfBirth}";
                    writer.WriteLine(line);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public List<Worker> GetAllWorkers()
        {
            workers.Clear();
            try
            {
                using (StreamReader reader = new StreamReader("workers.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Worker worker = ParseWorkerFromString(line);
                        workers.Add(worker);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not find. Create file workers.txt for saving data.");
            }

            return workers;
        }

        public Worker? GetWorkerById(int id)
        {
            try
            {
                using (StreamReader reader = new StreamReader("workers.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Worker worker = ParseWorkerFromString(line);
                        if (worker.Id == id)
                        {
                            return worker;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not find. Create file workers.txt for saving data.");
            }
            return null ;
        }

        public List<Worker> GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            List<Worker> filteredWorkers = new List<Worker>();

            try
            {
                using (StreamReader reader = new StreamReader("workers.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Worker worker = ParseWorkerFromString(line);
                        if (worker.DateOfBirth >= dateFrom && worker.DateOfBirth <= dateTo)
                        {
                            filteredWorkers.Add(worker);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден. Создайте файл workers.txt для сохранения данных.");
            }

            return filteredWorkers;
        }


        public void DeleteWorker(int id)
        {
            List<Worker> updatedWorkers = new List<Worker>();

            try
            {
                using (StreamReader reader = new StreamReader("workers.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Worker worker = ParseWorkerFromString(line);
                        if (worker.Id != id)
                        {
                            updatedWorkers.Add(worker);

                        }
                        else if (worker.Id == id)
                        {
                            Console.WriteLine("Deleted worker data: ");
                            Console.WriteLine($"ID: {worker.Id}");
                            Console.WriteLine($"Name: {worker.FullName}");
                            Console.WriteLine($"Age: {worker.Age}");
                            Console.WriteLine($"Height: {worker.Height}");
                            Console.WriteLine($"Date of birth: {worker.DateOfBirth.ToShortDateString()}");
                            Console.WriteLine($"Place of birth: {worker.PlaceOfBirth}");
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not find. Create file workers.txt for saving data.");
            }

            try
            {
                using (StreamWriter writer = new StreamWriter("workers.txt"))
                {
                    foreach (var worker in updatedWorkers)
                    {
                        string line = $"{worker.Id},{worker.FullName},{worker.Age},{worker.Height},{worker.DateOfBirth},{worker.PlaceOfBirth}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        // Вспомогательный метод для парсинга строки в экземпляр Worker
        private Worker ParseWorkerFromString(string line)
        {
            string[] parts = line.Split(',');
            return new Worker
            {
                Id = int.Parse(parts[0]),
                FullName = parts[1],
                Age = int.Parse(parts[2]),
                Height = int.Parse(parts[3]),
                DateOfBirth = DateTime.Parse(parts[4]),
                PlaceOfBirth = parts[5]
            };
        }
    }
}
