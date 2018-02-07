using System;

namespace ThreadAlgorithm
{
    /// <summary>
    /// Класс массив
    /// </summary>
    class MyArray
    {
        private static int[] _array;

        public int Length => _array.Length;

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                    return _array[index];
                throw new Exception("Incorrect indexer");
            }
            set
            {
                if (index >= 0 && index < Length)
                    _array[index] = value;
                else Console.WriteLine("Incorrect indexer");
            }
        }

        public MyArray(int size)
        {
            _array = GetArray(size);
        }

        public int[] Copy
        {
            get
            {
                int[] result = new int[Length];
                for (int i = 0; i < Length; i++)
                {
                    result[i] = _array[i];
                }

                return result;
            }
        }

        private static int[] GetArray(int size)
        {
            Random random = new Random( );
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }

            return array;
        }

        public void Show( )
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('*', 50));

            for (int i = 0; i < Length; i++)
            {
                if (i % 40 == 0)
                    Console.WriteLine( );
                Console.Write(_array[i] + " ");
            }

            Console.WriteLine( );
            Console.WriteLine(new string('*', 50));

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
