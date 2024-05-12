using System;
using System.Collections;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using ClassLibrary;
using Lab_12_ht_2;

namespace Lab_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            int answer = 1;           
            while (answer != 6)
            {
                try
                {
                    Commands();
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Введите размер хеш-таблицы:");
                            int size = int.Parse(Console.ReadLine());
                            if (size > 0)
                            {
                                Console.WriteLine("Хеш-таблица создана.");
                                hashTable = new MyHashTable<MusicalInstrument>(size);
                                for (int i = 0; i < size; i++)
                                {
                                    MusicalInstrument muzq = new MusicalInstrument();
                                    muzq.RandomInit();
                                    hashTable.AddItem(muzq);
                                }
                            }
                            else Console.WriteLine("Ошибка ввода.");
                            break;

                        case 2:
                            Console.WriteLine("Ваша хеш-таблица:");
                            hashTable.Print();
                            break;

                        case 3:
                            Console.WriteLine("Какой элемиент хотите найти?");
                            MusicalInstrument muzb = new MusicalInstrument();
                            muzb.Init();
                            Console.WriteLine(hashTable.FindItem(muzb)); 
                            break;

                        case 4:
                            Console.WriteLine("Какой элемиент хотите удалить?");
                            MusicalInstrument muzz = new MusicalInstrument();
                            muzz.Init();
                            Console.WriteLine(hashTable.RemoveData(muzz));
                            break;

                        case 5:
                            Console.WriteLine("Какой элемент хотите добавить?");
                            MusicalInstrument muz3 = new MusicalInstrument();
                            muz3.Init();
                            hashTable.AddItem(muz3);
                            Console.WriteLine("Элемент добавлен в таблицу.");
                            break;

                        default:
                            Console.WriteLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void Commands()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Меню.\n" +
                              "----------------------------------------------------------------------------\n" +
                              "1. Создать хеш-таблицу.\n" +
                              "2. Распечатать хеш-таблицу.\n" +
                              "3. Найти элемент. \n" +
                              "4. Удалить элемент. \n" +
                              "5. Добавить элемент в хеш-таблицу.\n" +
                              "6. Завершение работы.\n" +
                              "----------------------------------------------------------------------------\n");
        }
    }
}