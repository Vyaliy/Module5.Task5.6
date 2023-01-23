using System.Runtime.InteropServices;

namespace Module_5._Task_5._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string LastName, int Age, string[] Pets, string[] FavColors) User;
            User = AskFromUser();
            UserToConsole(User);
            Console.ReadKey();
        }
        static (string Name, string LastName, int Age, string[] Pets, string[] FavColors) AskFromUser()
        {
            (string Name, string LastName, int Age, string[] Pets, string[] FavColors) User;

            Console.Write("Введите имя: ");
            User.Name = Console.ReadLine();
            
            Console.Write("Введите фамилию: ");
            User.LastName = Console.ReadLine();

            string checkStr;
            int check;
            bool petsOrColors;
            do
            {
                Console.Write("Введите возраст цифрами: ");
                checkStr = Console.ReadLine();
            } while (NumCheck(checkStr, out check) || check <= 0);

            User.Age = check;
            do
            {
                Console.WriteLine("Сколько у вас питомцев?");
                checkStr = Console.ReadLine();
            } while (NumCheck(checkStr, out check));

            User.Pets = FillingAnArray(check, true);

            petsOrColors = false;
            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                checkStr = Console.ReadLine();
            } while (NumCheck(checkStr, out check));

            User.FavColors = FillingAnArray(check, false);

            return User;
            
        }
        /// <summary>
        /// Метод для инициализации и заполнения массива пользователем с клавиатуры по переданному количеству элементов
        /// </summary>
        /// <param name="length">Количество элементов массива</param>
        /// <param name="petsOrColors">true если питомец, false если цвет</param>
        /// <returns>Массив введенных значений с клавиатуры по переданному количеству элементов массива</returns>
        static string[] FillingAnArray(int length, bool petsOrColors)
        {
            string[] arr = new string[length];
            if (petsOrColors)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    Console.Write($"Введите имя {i + 1} питомца:");
                    arr[i] = Console.ReadLine();
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    Console.Write($"Введите {i + 1} цвет:");
                    arr[i] = Console.ReadLine();
                }
            }
            return arr;
        }
        /// <summary>
        /// Проверка на положительное число
        /// </summary>
        /// <param name="num">Строка для проверки</param>
        /// <param name="result">Конвертированное в Int32 значение из num</param>
        /// <returns>true если успешно, false если нет</returns>
        static bool NumCheck(string num, out int result)
        {
            if (Int32.TryParse(num, out result))
            {
                if (result >= 0)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Вывод анкеты пользователя в консоль
        /// </summary>
        /// <param name="User">Кортеж с данными пользователя</param>
        static void UserToConsole((string Name, string LastName, int Age, string[] Pets, string[] FavColors) User)
        {
            Console.WriteLine("\nДанные пользователя.");
            Console.WriteLine($"Имя: {User.Name}\nФамилия: {User.LastName}\nВозраст: {User.Age}");
            if (User.Pets.Length > 0)
            {
                Console.WriteLine("Питомцы:");
                foreach (var pet in User.Pets)
                {
                    Console.WriteLine(pet);
                }
            }
            else Console.WriteLine("Питомцев нет =(");
            if (User.FavColors.Length > 0)
            {
                Console.WriteLine("Любимые цвета:");
                foreach (var favColor in User.FavColors)
                {
                    Console.WriteLine(favColor);
                }
            }
            else Console.WriteLine("Любимых цветов нет =(");
        }
    }
}