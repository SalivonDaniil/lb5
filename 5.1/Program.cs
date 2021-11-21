using System;
using System.Drawing;


namespace _5._1
{
    class Move
    {
        
        private PointF[] _points;

        public PointF[] points
        {
            get
            {
                return _points;
            }
            set
            {
                this._points = value;
            }
        }

        public void Sides()
        {
            
            Console.Write("Введіть x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть сторону: ");
            int side = Convert.ToInt32(Console.ReadLine());
            points = new PointF[]
            {
                new PointF( x, y ), new PointF( x + side, y ), new PointF( x, y - side ), new PointF( x + side, y - side ) 
            };
        }

        public virtual void Text()
        {
            Console.WriteLine("Натисніть <-- для, щоб здвинути квадрат ліворуч");
            Console.WriteLine("Натисніть --> для, щоб здвинути квадрат праворуч");
            Console.WriteLine("Натисніть Esc для виходу");
        }

        public virtual void Left()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X--;
            }
        }

        public virtual void Right()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X++;
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"1) x: {points[0].X}, y: {points[0].Y}\t2) x: {points[1].X}, y: {points[1].Y}");
            Console.WriteLine($"3) x: {points[2].X}, y: {points[2].Y}\t4) x: {points[3].X}, y: {points[3].Y}");
        }
    }
    class Rotate : Move
    {
        
        public override void Left()
        {
            for (int i = 0; i < points.Length; i++)
            {
                double x = points[i].X;
                double y = points[i].Y;
                double x1 = x * Math.Cos(-1 / 180d * Math.PI) - y * Math.Sin(-1 / 180d * Math.PI);
                double y1 = x * Math.Cos(-1 / 180d * Math.PI) + y * Math.Sin(-1 / 180d * Math.PI);
                points[i].X = Convert.ToSingle(x1);
                points[i].Y = Convert.ToSingle(y1);
            }
        }

        public override void Right()
        {
            for (int i = 0; i < points.Length; i++)
            {
                double x = points[i].X;
                double y = points[i].Y;
                double x1 = x * Math.Cos(1 / 180d * Math.PI) - y * Math.Sin(1 / 180d * Math.PI);
                double y1 = x * Math.Cos(1 / 180d * Math.PI) + y * Math.Sin(1 / 180d * Math.PI);
                points[i].X = Convert.ToSingle(x1);
                points[i].Y = Convert.ToSingle(y1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            
            Console.WriteLine("1) переміщення");
            Console.WriteLine("2) повертання");
            Console.Write("Виберіть операцію з квадратом: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Move act;
            
            if (num == 1) {
                act = new Move();   
            }
            else if (num == 2)
            {
                act = new Rotate();
            }
            else
            {
                throw new Exception("Введіть 1 або 2");
            }

            act.Sides();
            while (true)
            {
                var keyInfo = Console.ReadKey();

                bool exit = false;

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    act.Left();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    act.Right();
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    exit = true;
                }

                if (exit) 
                { 
                    return; 
                }
                    
                Console.Clear();
                act.Text();
                Console.WriteLine();
                act.GetInfo();
            }
        }
    }
}
