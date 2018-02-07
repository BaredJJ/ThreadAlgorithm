using System;

//TODO Неплохо бы разделить все через интерфейсы


namespace ThreadAlgorithm
{
    /// <summary>
    /// Статические разделяемые методы
    /// </summary>
    static class MyGeneral
    {
        public static int GetInt<T>(T t)
        {
            int res;
            if (!int.TryParse(t.ToString( ), out res))
                throw new FormatException("Incorrect data type");

            return res;
        }

        private static bool IsPrimal(int number)
        {
            for (int i = 2; i <= number/i; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public static int GeneratePrimeNumber(int primeNumber)
        {
            for (int i = primeNumber + 1; i < int.MaxValue; i++)
            {
                if (IsPrimal(i))
                    return i;
            }

            throw new Exception("That all)");
        }

    }
}
