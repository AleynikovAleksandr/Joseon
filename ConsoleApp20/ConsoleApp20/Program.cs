using System;
using System.Collections.Generic;

interface IRentable
{
    void Rent();
    void Return();
    bool IsAvailable { get; }
}

public struct CarInfo
{
    public string Mark;
    public string Model;
    public int Year;
    public string Numpad;

    public CarInfo(string mark = "", string model = "", int year = 2000, string num = "1")
    {
        Mark = mark;
        Model = model;
        Year = year;
        Numpad = num;
    }
}

class Car : IRentable
{
    private bool available = true;
    public bool IsAvailable => available;
    public double RentalPricePerDay;
    public CarInfo info;

    public Car(string mark = "", string model = "", int year = 2000, string num = "1", double price = 1)
    {
        info = new CarInfo(mark, model, year, num);
        RentalPricePerDay = price;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Марка: {info.Mark}\nМодель: {info.Model}\nГод выпуска: {info.Year}\nНомерной знак: {info.Numpad}\nДоступен: {IsAvailable}");
    }

    public void Rent()
    {
        if (available)
        {
            available = false;
            Console.WriteLine($"Машина с номером {info.Numpad} успешно арендована.");
        }
        else
        {
            throw new Exception($"Машина с номером {info.Numpad} уже арендована.");
        }
    }

    public void Return()
    {
        if (!available)
        {
            available = true;
            Console.WriteLine($"Машина с номером {info.Numpad} успешно возвращена.");
        }
        else
        {
            Console.WriteLine($"Машина с номером {info.Numpad} уже доступна.");
        }
    }
}

class CarRentalService
{
    private static List<Car> Cars = new List<Car>();

    public static void AddCar(Car car)
    {
        Cars.Add(car);
        Console.WriteLine("Автомобиль успешно добавлен.");
    }

    public static void RentCar(string license, int days)
    {
        Car foundCar = Cars.Find(car => car.info.Numpad == license);

        if (foundCar == null)
        {
            Console.WriteLine($"Ошибка: Автомобиль с номером {license} не найден.");
        }
        else
        {
            try
            {
                foundCar.Rent(); // Использование метода Rent()
                double totalCost = foundCar.RentalPricePerDay * days;
                Console.WriteLine($"Стоимость аренды автомобиля: {totalCost} за {days} дней.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static void ReturnCar(string license)
    {
        Car foundCar = Cars.Find(car => car.info.Numpad == license);

        if (foundCar == null)
        {
            Console.WriteLine($"Ошибка: Автомобиль с номером {license} не найден.");
        }
        else
        {
            foundCar.Return(); // Использование метода Return()
        }
    }

    public static void DisplayAvailableCars()
    {
        bool anyAvailable = false;
        foreach (Car car in Cars)
        {
            if (car.IsAvailable)
            {
                car.DisplayInfo();
                Console.WriteLine();
                anyAvailable = true;
            }
        }

        if (!anyAvailable)
        {
            Console.WriteLine("Нет доступных автомобилей для аренды.");
        }
    }

    // Метод для расчета общей стоимости аренды нескольких автомобилей
    public static double CalculateTotalRentalCost(List<string> licensePlates, int days)
    {
        double totalCost = 0;
        foreach (string license in licensePlates)
        {
            Car foundCar = Cars.Find(car => car.info.Numpad == license);

            if (foundCar != null && foundCar.IsAvailable)
            {
                totalCost += foundCar.RentalPricePerDay * days;
            }
            else
            {
                Console.WriteLine($"Ошибка: Автомобиль {license} не найден или уже арендован.");
            }
        }
        return totalCost;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int selected = 1;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Используйте стрелки для навигации и Enter для выбора:");

            string[] menuItems = { "Добавить авто", "Арендовать авто", "Вернуть авто", "Показать доступные авто", "Расчет аренды нескольких авто", "Выход" };

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i + 1 == selected)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"> {menuItems[i]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($"  {menuItems[i]}");
                }
            }

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.UpArrow)
            {
                selected = selected > 1 ? selected - 1 : menuItems.Length;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selected = selected < menuItems.Length ? selected + 1 : 1;
            }
            else if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                switch (selected)
                {
                    case 1:
                        // Добавление авто
                        Console.WriteLine("Введите марку:");
                        string mark = Console.ReadLine();
                        Console.WriteLine("Введите модель:");
                        string model = Console.ReadLine();
                        Console.WriteLine("Введите год выпуска:");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите номерной знак:");
                        string num = Console.ReadLine();
                        Console.WriteLine("Введите цену аренды за день:");
                        double price = double.Parse(Console.ReadLine());

                        Car newCar = new Car(mark, model, year, num, price);
                        CarRentalService.AddCar(newCar);
                        break;

                    case 2:
                        // Аренда авто
                        Console.WriteLine("Введите номерной знак автомобиля для аренды:");
                        string rentLicense = Console.ReadLine();
                        Console.WriteLine("Введите количество дней аренды:");
                        int days = int.Parse(Console.ReadLine());
                        CarRentalService.RentCar(rentLicense, days);
                        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case 3:
                        // Возврат авто
                        Console.WriteLine("Введите номерной знак автомобиля для возврата:");
                        string returnLicense = Console.ReadLine();
                        CarRentalService.ReturnCar(returnLicense);
                        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case 4:
                        // Показ доступных авто
                        Console.WriteLine("Доступные автомобили:");
                        CarRentalService.DisplayAvailableCars();
                        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case 5:
                        // Расчет аренды нескольких авто
                        List<string> licensePlates = new List<string>();
                        Console.WriteLine("Введите номерные знаки автомобилей (через Enter), введите пустую строку для окончания ввода:");
                        while (true)
                        {
                            string plate = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(plate)) break;
                            licensePlates.Add(plate);
                        }
                        Console.WriteLine("Введите количество дней аренды:");
                        days = int.Parse(Console.ReadLine());

                        double totalCost = CarRentalService.CalculateTotalRentalCost(licensePlates, days);
                        Console.WriteLine($"Общая стоимость аренды: {totalCost} за {days} дней.");
                        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case 6:
                        // Выход
                        running = false;
                        break;
                }
            }
        }
    }
}
