using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Lab_12_ht_2
{
    public class MyHashTable<T> where T : IInit, IComparable, new()
    {
        T[] table; // таблица
        int count = 0; // количество записей
        double fillRatio; // коэффицент заполняемой таблицы

        public int Capacity => table.Length; // ёмкость, количество выделенной памяти
        private int capacity;
        public int Count => count; // текущее количество элементов

        // конструктор
        public MyHashTable(int size = 10, double fillRatio = 0.72)
        {
            if (size <= 0) throw new Exception("Число не распознано. В хеш-таблице должен быть хотя бы 1 элемент.");
            capacity = size;
            table = new T[size];
            this.fillRatio = fillRatio;
        }

        public bool Contains(T data) // проверка на наличие элемента
        {
            return !(FindItem(data) < 0);
        }

        public bool RemoveData(T data) // удалить информацию
        {
            int index = FindItem(data);
            if (index < 0) return false;
            count--;
            table[index] = default;
            return true;
        }

        public void Print() // печать хеш-таблицы
        {
            int i = 0;
            foreach (T item in table)
            {
                Console.WriteLine($"{i} : {item}");
                i++;
            }
        }

        public void AddItem(T item) // добавление элемента
        {
            if ((((double)Count ) / Capacity) > fillRatio) // место в таблице закончилось
            {
                // увеличиваем таблицу в 2 раза и переписываем всю информацию
                T[] temp = (T[])table.Clone();
                table = new T[temp.Length * 2];
                capacity *= 2;
                count = 0;
                for (int i = 0; i < temp.Length; i++)
                    AddData(temp[i]);
            }
            // добавляем новый элемент
            AddData(item);
        }

        // private
        int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        // добавление элемента в таблицу
        void AddData(T data)
        {
            if (data == null) return; // добавляется пустой элемент
            // ищем место
            int index = GetIndex(data);
            int current = index; // запомнили индекс
            // если место уже занято
            if (table[index] != null)
            {
                // идём до конца таблицы или до первого пустого места
                while (current < table.Length && table[current] != null)
                    current++;
                // если таблица закончилась
                if (current == table.Length)
                {
                    // идём от начала таблицы до индекса, который запомнили
                    current = 0;
                    while (current < index && table[current] != null)
                        current++;
                    // места нет
                    if (current == index)
                    {
                        throw new Exception("Нет места в таблице");
                    }
                }
            }
            // место найдено
            table[current] = data;
            count++;
        }

        public int FindItem(T data)
        {
            // находим индекс
            int index = GetIndex(data);
            // нет элемента
            if (table[index] == null) return -1;
            // есть элемент, совпадает
            if (table[index].Equals(data))
                return index;
            else // не совпадает
            {
                int current = index; // идём вниз по таблице
                while (current < table.Length)
                {
                    if (table[current] != null 
                       && table[current].Equals(data)) // совпадает 
                    return current;

                    current++;
                }
                current = 0; // идём с начала таблицы
                while(current < index)
                {
                    if (table[current] != null
                        && table[current].Equals(data)) // совпадают
                        return current;
                    current++;
                }
                return -1;
            }
            // не нашли
        }
    }
}
