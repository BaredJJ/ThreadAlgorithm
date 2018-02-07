
using System;
using System.Collections.Generic;
using System.Threading;


namespace ThreadAlgorithm
{
    class MyThread
    {
        private readonly Thread _thread;//поток

        private AutoResetEvent _reset;//синхронизатор

        private int _primeNumber;//текущее простое число

        private static List<int> _primeList = new List<int>();

        private static MyArray _array;

        public static int _count;

        private static bool flag = false;

        public static int[] Matrix { get; set; }

        public static int Count => _count;

        public Thread Thread => _thread;

        public MyThread(int primeNumber, AutoResetEvent autoResetEvent, MyArray array)
        {
            _reset = autoResetEvent;
            _primeNumber = primeNumber;
            _primeList.Add(primeNumber);
            _array = array;
            Matrix = _array.Copy;

            _thread = new Thread(Run);
            _count++;
            _thread.Start();
        }

        /// <summary>
        /// Метод запуска потоков
        /// </summary>
        private void Run( )
        {
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Prime number: " + _primeNumber);
            
            while (true)
            {
                if(flag)
                    break;

                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Prime number: " + _primeNumber);

                _reset.WaitOne( );
                    Searcer( );
                    flag = Checker();
                _reset.Set( );


                if (flag)
                {
                    break;
                }


                _reset.WaitOne( );
                    _primeNumber = MyGeneral.GeneratePrimeNumber(GetMax());
                    _primeList.Add(_primeNumber);
                _reset.Set( );

            }

        }

        /// <summary>
        /// Поиск простых чисел в исходном массиве
        /// </summary>
        private void Searcer( )
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (Matrix[i] != 0 && Matrix[i] != 1)
                    if (_array[i] == _primeNumber)
                        Matrix[i] = 0;
                    else if (_array[i] % _primeNumber == 0)
                        Matrix[i] = 1;
            }
        }

        /// <summary>
        /// Проверка окончания работы алгоритма
        /// </summary>
        /// <returns></returns>
        private bool Checker( )
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                if (Matrix[i] != 0 && Matrix[i] != 1)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Поиск максимального значения в списке
        /// </summary>
        /// <returns></returns>
        private int GetMax()
        {
            _primeList.Sort();
            return _primeList[_primeList.Count - 1];
        }
    }
}
