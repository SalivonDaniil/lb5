using System;

namespace _5._3
{
    class Matrix
    {
        private int _size;
        private int[,] _matrix;
        private int _score = 1;

        public int size
        {
            get
            {
                return _size;
            }
            set
            {
                this._size = value;
            }
        }
        public int score
        {
            get
            {
                return _score;
            }
            set
            {
                this._score = value;
            }
        }
        public int[,] matrix
        {
            get
            {
                return _matrix;
            }
            set
            {
                this._matrix = value;
            }
        }
        public virtual void Fill()
        {
            Console.WriteLine("\nПочніть вводити елементи матриці: ");
            matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Введіть {score++} елемент матриці: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

        }
        public virtual void GetInfo()
        {
            Console.WriteLine("\nМатриця: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    class Matrix1 : Matrix
    {
        public override void Fill()
        {
            
            matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    
                    if(i == j)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

        }
    }
    class MatrixTriangular : Matrix
    {
        public override void Fill()
        {
            Console.WriteLine("\nПочніть вводити матрицю: ");
            matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {

                    if (i <= j)
                    {
                        Console.Write($"Введіть {score++} елемент матриці: ");
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            
            Console.WriteLine("1) звичайна");
            Console.WriteLine("2) одинична");
            Console.WriteLine("3) верхня трикутна");
            Console.Write("Виберіть тип матриці: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Matrix act;

            if (num == 1)
            {
                act = new Matrix();
            }
            else if (num == 2)
            {
                act = new Matrix1();
            }
            else if (num == 3)
            {
                act = new MatrixTriangular();
            }
            else
            {
                throw new Exception("Введіть 1 або 2");
            }

            Console.Write("Введіть розмір матриці: ");
            act.size = Convert.ToInt32(Console.ReadLine());
            act.Fill();
            act.GetInfo();
        }
    }
}
