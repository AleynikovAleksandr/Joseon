using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBorrowable
{
    void Borrow();
    void Return();
    bool IsAvailable { get; }
}

public abstract class LibraryItem
{
    public string Title { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; private set; } = true;
    public string Type { get; set; } = "Книга";
    public int ID;

    public LibraryItem(string title, int year, string type = "Книга")
    {
        Title = title;
        Year = year;
        Type = type;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Type}: {Title}, Год: {Year}, Статус: {(IsAvailable ? "Доступно" : "Арендовано")}");
    }

    public void Borrow()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"{Title} было успешно арендовано.");
        }
        else
        {
            Console.WriteLine($"{Title} недоступно для аренды.");
        }
    }

    public void Return()
    {
        IsAvailable = true;
        Console.WriteLine($"{Title} было возвращено.");
    }
}

public class Book : LibraryItem
{
    public Book(string title, int year, string type) : base(title, year, "Книга") { }
}

public class Journal : LibraryItem
{
    public Journal(string title, int year, string type) : base(title, year, "Журнал") { }
}

public class User
{
    public string Name { get; set; }
    public int UserId;
    public List<LibraryItem> BorrowedItems { get; } = new List<LibraryItem>();

    public User(string name)
    {
        Name = name;
    }

    public void BorrowItem(LibraryItem item)
    {
        if (item.IsAvailable)
        {
            item.Borrow();
            BorrowedItems.Add(item);
        }
        else
        {
            Console.WriteLine($"Предмет {item.Title} недоступен.");
        }
    }

    public void ReturnItem(LibraryItem item)
    {
        if (BorrowedItems.Contains(item))
        {
            item.Return();
            BorrowedItems.Remove(item);
        }
        else
        {
            Console.WriteLine($"Предмет {item.Title} не найден среди арендованных пользователем.");
        }
    }

    public void ListBorrowedItems()
    {
        if (BorrowedItems.Count > 0)
        {
            Console.WriteLine($"Арендованные предметы пользователя {Name}:");
            foreach (var item in BorrowedItems)
            {
                item.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("Нет арендованных предметов.");
        }
    }
}

public class Library
{
    private List<LibraryItem> items = new List<LibraryItem>();
    private List<User> users = new List<User>();

    public void AddItem(LibraryItem item)
    {
        items.Add(item);
        Console.WriteLine($"{item.Title} было добавлено в библиотеку.");
    }

    public void AddUser(User user)
    {
        users.Add(user);
        Console.WriteLine($"Пользователь {user.Name} был добавлен.");
    }

    public IEnumerable<LibraryItem> ListAvailableItems()
    {
        return items.Where(item => item.IsAvailable);
    }

    public LibraryItem FindItem(string title)
    {
        return items.Find(item => item.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public User FindUser(string name)
    {
        return users.FirstOrDefault(user => user.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool running = true;
        int selected = 1;
        int FreeId = 1;
        int FreeItemId = 1;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Используйте стрелки для навигации и Enter для выбора:");
            string[] menuItems = {
                "Добавить пользователя",
                "Добавить предмет",
                "Арендовать предмет",
                "Вернуть предмет",
                "Показать доступные предметы",
                "Показать арендованные предметы пользователя",
                "Выход"
            };

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
                    case 1: // Add User
                        Console.Write("Введите имя пользователя: ");
                        string name = Console.ReadLine();
                        Console.WriteLine($"Пользователь {name} успешно добавлен.");

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Имя пользователя не может быть пустым. Пожалуйста, введите действительное имя.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            break;
                        }

                        User newUser = new User(name);
                        newUser.UserId = FreeId;
                        FreeId += 1;
                        library.AddUser(newUser);
                        break;

                    case 2: // Add Item
                        Console.Write("Введите название предмета: ");
                        string title = Console.ReadLine();
                        Console.Write("Введите год выпуска: ");
                        if (!int.TryParse(Console.ReadLine(), out int year) || year < 2000 || year > DateTime.Now.Year)
                        {
                            Console.WriteLine($"Некорректный ввод года. Год должен быть между 2000 и {DateTime.Now.Year}.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Тип (1: Книга, 2: Журнал): ");
                        string type = Console.ReadLine();
                        if (type == "1")
                        {
                            Book newbook = new Book(title, year, "Книга");
                            newbook.ID = FreeItemId;
                            FreeItemId += 1;
                            library.AddItem(newbook);
                        }
                        else if (type == "2")
                        {
                            Journal newbook = new Journal(title, year, "Журнал");
                            newbook.ID = FreeItemId;
                            FreeItemId += 1;
                            library.AddItem(newbook);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод типа предмета.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                        }
                        break;

                    case 3: // Borrow Item
                        Console.Write("Введите имя пользователя: ");
                        name = Console.ReadLine();
                        User userToBorrow = library.FindUser(name);

                        if (userToBorrow == null)
                        {
                            Console.WriteLine("Пользователь не найден.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Введите название предмета для аренды: ");
                        title = Console.ReadLine();
                        var itemToBorrow = library.FindItem(title);
                        if (itemToBorrow != null)
                        {
                            userToBorrow.BorrowItem(itemToBorrow);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Предмет не найден.");
                        }
                        break;

                    case 4: // Return Item
                        Console.Write("Введите имя пользователя: ");
                        name = Console.ReadLine();
                        User userToReturn = library.FindUser(name);

                        if (userToReturn == null)
                        {
                            Console.WriteLine("Пользователь не найден.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Введите название предмета для возврата: ");
                        title = Console.ReadLine();
                        var itemToReturn = library.FindItem(title);
                        if (itemToReturn != null)
                        {
                            userToReturn.ReturnItem(itemToReturn);
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Предмет не найден.");
                        }
                        break;

                    case 5: // Show Available Items
                        Console.WriteLine("Доступные предметы в библиотеке:");
                        bool hasAvailableItems = false;
                        foreach (var item in library.ListAvailableItems())
                        {
                            item.DisplayInfo();
                            hasAvailableItems = true;
                        }

                        if (!hasAvailableItems)
                        {
                            Console.WriteLine("На данный момент нет доступных предметов для аренды.");
                        }

                        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case 6: // Show Borrowed Items
                        Console.Write("Введите имя пользователя: ");
                        name = Console.ReadLine();
                        User userToList = library.FindUser(name);

                        if (userToList != null)
                        {
                            userToList.ListBorrowedItems();

                        }
                        else
                        {
                            Console.WriteLine("Пользователь не найден.");
                        }

                        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case 7: // Exit
                        running = false;
                        break;
                }
            }
        }
    }
}
