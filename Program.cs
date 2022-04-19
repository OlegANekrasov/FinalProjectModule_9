using System;
using System.Collections;
using System.Linq;

namespace FinalProjectModule_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lastNamesArray = new string[]
            {
                "Иванов",
                "Петров",
                "Сидоров",
                "Александров",
                "Сергеев"
            };

            Console.WriteLine("Исходный список: ");
            LastNames lastNames = new LastNames(lastNamesArray);
            lastNames.ShowLastNames();

            try
            {
                int s = ValueInput();
                if (s == 1)
                    lastNames.SortLastNamesEvent += OrderBy;
                else
                    lastNames.SortLastNamesEvent += OrderByDescending;

                lastNames.Sort();

                Console.WriteLine("\nПосле сортировки: ");
                lastNames.ShowLastNames();
            }
            catch (EnteringValueException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                foreach (DictionaryEntry de in e.Data)
                {
                    Console.WriteLine($"-> {de.Key}: {de.Value}");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Тип исключения: {e.GetType()}, Ошибка: {e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Тип исключения: {e.GetType()}, Ошибка: {e.Message}");
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine($"Тип исключения: {e.GetType()}, Ошибка: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Тип исключения: {e.GetType()}, Ошибка: {e.Message}");
            }
            finally
            {
                Console.WriteLine("\nПрограмма завершена!");
            }

            Console.ReadKey();
        }

        static public string[] OrderBy(string[] lastNamesArray)
        {
            return lastNamesArray.OrderBy(o => o.ToUpper()).ToArray();
        }

        static public string[] OrderByDescending(string[] lastNamesArray)
        {
            return lastNamesArray.OrderByDescending(o => o.ToUpper()).ToArray(); 
        }

        static int ValueInput()
        {
            Console.WriteLine("\nСортировка фамлий... ");
            Console.WriteLine("Введите либо число 1(сортировка А - Я), либо число 2(сортировка Я - А)");

            string str = Console.ReadLine();
            int result = int.Parse(str);
            if(result != 1 && result != 2)
            {
                throw new EnteringValueException("Введено не верное число!", DateTime.Now, str);
            }

            return result;
        }
    }
}
