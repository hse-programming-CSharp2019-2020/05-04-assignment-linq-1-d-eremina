﻿using System;
using System.Linq;
/*
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * На основе полученных чисел получить новое по формуле: 5 + a[0] - a[1] + a[2] - a[3] + ...
 * Это необходимо сделать двумя способами:
 * 1) с помощью встроенного LINQ метода Aggregate
 * 2) с помощью своего метода MyAggregate, сигнатура которого дана в классе MyClass
 * Вывести полученные результаты на экран (естесственно, они должны быть одинаковыми)
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 8
 * 8
 * 
 * Пояснение:
 * 5 + 1 - 2 + 3 - 4 + 5 = 8
 * 
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 */

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk04();
        }

        public static void RunTesk04()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => int.Parse(e)).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
                return;
            }
                // использовать синтаксис методов! SQL-подобные запросы не писать!
                try
                {
                    checked
                    {
                        int arrAggregate = 5 + arr.Select((x, i) => (int)
                                (x * Math.Pow(-1, i)))
                            .Aggregate((x, y) => x + y);

                        int arrMyAggregate = MyClass.MyAggregate(arr);
                        

                        Console.WriteLine(arrAggregate);
                        Console.WriteLine(arrMyAggregate);
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("OverflowException");
                }
           
        }
    }

    static class MyClass
    {
        public static int MyAggregate(int[] arr)
        {
            int result = 5;
            for (int i = 0; i < arr.Length; ++i)
                result += (int)Math.Pow(-1, i) * arr[i];
            return result;
        }
    }
}
