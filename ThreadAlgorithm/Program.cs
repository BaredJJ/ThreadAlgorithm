using System;
using System.Collections.Generic;
using System.Threading;


namespace ThreadAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод начальных значений
            Console.Write("Please enter to length of array: ");
            int length = MyGeneral.GetInt(Console.ReadLine());

            Console.Write("Please enter to number of threds: ");
            int numberOfThreads = MyGeneral.GetInt(Console.ReadLine());

            List<int> primeNumberList = new List<int>();
            
            MyArray array = new MyArray(length);

            AutoResetEvent reset = new AutoResetEvent(false);

            array.Show();

            //Запуск потоков
            List<int> primeList = new List<int>();
            primeList.Add(2);
            MyThread[] threads = new MyThread[numberOfThreads];
            for (int i = 1; i < numberOfThreads; i++)
            {
                primeList.Add(MyGeneral.GeneratePrimeNumber(primeList[i-1]));
            }
            for (int i = 0; i < numberOfThreads; i++)
            {
                int index = i;
                threads[i] = new MyThread(primeList[index], reset, array);
            }

            while (true)//Ожидания загрузки всех потоков
            {
                if (MyThread.Count == numberOfThreads)
                {
                    reset.Set( );
                    break;                    
                }                
            }
            

            //Ожидание завершения потоков
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i].Thread.Join();
            }
           
            //Вывод результата
            for (int i = 0; i < MyThread.Matrix.Length; i++)
            {
                Console.Write(MyThread.Matrix[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            array.Show();
            Console.WriteLine("Compleated!");
            Console.ReadKey();
        }
    }
}
