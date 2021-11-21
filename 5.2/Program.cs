using System;
using System.Drawing;

namespace _5._2
{
    class Cone
    {
        private int _R;
        private int _h;
        private int _V;
        private int _S;

        public int R
        {
            get
            {
                return _R;
            }
            set
            {
                this._R = value;
            }
        }
        public int h
        {
            get
            {
                return _h;
            }
            set
            {
                this._h = value;
            }
        }
        public int V
        {
            get
            {
                return _V;
            }
            set
            {
                this._V = value;
            }
        }
        public int S
        {
            get
            {
                return _S;
            }
            set
            {
                this._S = value;
            }
        }

        public virtual void Info()
        {
            Console.Write("Введіть висоту конуса: ");
            h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть радіус основи: ");
            R = Convert.ToInt32(Console.ReadLine());
        }

        public virtual void Area()
        {
            S = (int)(Math.PI * Math.Pow(R, 2));
        }

        public virtual void Volume()
        {
            
            V = S * h / 3;
            
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"\nРадіус основи: {R}\nВисота конуса: {h}\nПлоща основи: {S}\nОб'єм конуса: {V}");
            
        }
    }
    class CutCone : Cone
    {
        private int _r;
        private int _S2;
        public int r
        {
            get
            {
                return _r;
            }
            set
            {
                this._r = value;
            }
        }
        public int S2
        {
            get
            {
                return _S2;
            }
            set
            {
                this._S2 = value;
            }
        }
        public override void Info()
        {
            Console.Write("Введіть висоту конуса: ");
            h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть радіус нижньої основи: ");
            R = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть радіус верхньої основи: ");
            r = Convert.ToInt32(Console.ReadLine());
        }

        public override void Area()
        {
            S = (int)(Math.PI * Math.Pow(R, 2));
            S2 = (int)(Math.PI * Math.Pow(r, 2));
        }

        public override void Volume()
        {

            V = (int)(Math.PI * h * (Math.Pow(R, 2) + Math.Pow(r, 2) + R * r) / 3);

        }
        public override void GetInfo()
        {
            Console.WriteLine($"\nРадіус нижньої основи: {R}\nРадіус верхньої основи: {r}\nВисота конуса: {h}\nПлоща нижьної основи: {S}\nПлоща верхньої основи: {S2}\nОб'єм конуса: {V}");

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            
            Console.WriteLine("1) звичайний");
            Console.WriteLine("2) зрізаний");
            Console.Write("Виберіть тип конуса: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Cone act;

            if (num == 1)
            {
                act = new Cone();
            }
            else if (num == 2)
            {
                act = new CutCone();
            }
            else
            {
                throw new Exception("Введіть 1 або 2");
            }


            act.Info();
            act.Area();
            act.Volume();
            act.GetInfo();
        }
    }
}
