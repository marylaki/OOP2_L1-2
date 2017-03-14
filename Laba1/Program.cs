using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
     class figura
    {
       public int[,] t;
       public int n;
       public const int max_kol=10;
       static int kol;
       public readonly int ID;
       public figura()
        {
            Random rnd = new Random();
            t = new int[3, 3];
            n = 3;
            kol++;
             for(int i=0;i<n ;i++)
            {
                for (int j = 0; j < 3; j++)
                    t[i, j] = rnd.Next(-20, 20);
            }
             ID = t[0, 0] + t[1, 1] + t[2, 2];
        }

        public void Print()
       {
           Console.WriteLine("Figura");
           for (int i = 0; i < n; i++)
               Console.WriteLine("({0},{1},{2})", t[i, 0], t[i, 1], t[i, 2]);
       }

        public void consRead()
        {
            Console.WriteLine("{0} tochek (x,y,z)",n);

            for (int i = 0; i < n; i++)
            {
                t[i, 0] = Console.Read();
                t[i, 1] = Console.Read();
                t[i, 2] = Console.Read();
                Console.WriteLine("({0},{1},{2})", t[i, 0], t[i, 1], t[i, 2]);
            }
        }
        public figura(int N)
        {
            Random rnd = new Random();
            if (N > 3 && N < max_kol)
            {
                n = N;
            }
            else
            {
                n = 3;
            }
            t = new int[n, 3];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                    t[i, j] = rnd.Next(-20, 20);
            }
            ID = t[0, 0] + t[1, 1] + t[2, 2];
            kol++;
        }
        static figura()
        {
            kol = 0;
        }
        public int[,] Tochk
        {
            get
            {
               return t;
            }

            set
            {
                for (int i = 0; i < n; i++)
                {
                    t[i, 0] = value[i,0];
                    t[i, 1] = value[i,1];
                    t[i, 2] = value[i,2];
                }
            }
        }
        public int Kol
        {
            get { return kol; }
        }
        public int id
        {
            get { return ID; }
        }
        public int kol_t
        {
            get { return n; }
        }
        public static void ClassInfo()
        {
            Console.WriteLine("Класс фигура, количество соданных объектов {0}", kol);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            figura f = obj as figura;
            if ((System.Object)f == null)
            {
                return false;
            }
            if (n != f.n) return false;
            for(int i=0;i<n ;i++)
            {
                for (int j = 0; j < 3 ; j++)
                    if (t[i, j] != f.t[i, j]) return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return (t[0,0]+t[1,1]+t[2,2]);
        }
        public void perimetr(out double p)
        {
            p = MathObj.perimetr(this);
        }
    }
    static class MathObj
    {
        public static double perimetr( figura f)
        {
            double p = 0;
            for (int i = 0; i < f.n-1;i++ )
            {
                p += Math.Sqrt(Math.Pow((f.t[i, 0] - f.t[i + 1, 0]), 2) +
                    Math.Pow((f.t[i, 1] - f.t[i + 1, 1]),2) +
                    Math.Pow((f.t[i, 2] - f.t[i + 1, 2]),2));
            }
            p += Math.Sqrt(Math.Pow((f.t[f.n - 1, 0] - f.t[0, 0]),2) + Math.Pow((f.t[f.n - 1, 1] - f.t[0, 1]),2) + Math.Pow((f.t[f.n - 1, 2] - f.t[0, 2]) ,2));
            return p;
        }

        public static void change(ref figura f,int i)
        {
            if (i < f.n)
            {
                f.n--;
                for (; i < f.n; i++)
                {
                    f.t[i, 0] = f.t[i + 1, 0];
                    f.t[i, 1] = f.t[i + 1, 1];
                    f.t[i, 2] = f.t[i + 1, 2];
                }
            }
        }
        public static bool onBox(this figura f,int a,int b,int c)
        {
            int xmax = f.t[0, 0], xmin = f.t[0, 0], ymin = f.t[0, 1], ymax = f.t[0, 1], zmax = f.t[0, 0], zmin = f.t[0, 0];
            for(int i=1;i<f.n;i++)
            {
                if (xmax < f.t[i, 0]) xmax = f.t[i, 0];
                if (xmin > f.t[i, 0]) xmin = f.t[i, 0];
                if (ymax < f.t[i, 1]) ymax = f.t[i, 1];
                if (ymin > f.t[i, 1]) ymin = f.t[i, 1];
                if (zmax < f.t[i, 2]) ymax = f.t[i, 2];
                if (zmin > f.t[i, 2]) ymin = f.t[i, 2];
            }
            int x = Math.Abs(xmax - xmin);
            int y = Math.Abs(ymax - ymin);
            int z = Math.Abs(zmax - zmin);
            if (x <= a && y <= b && z <= c) return true;
            if (x <= a && y <= c && z <= b) return true;
            if (x <= b && y <= a && z <= c) return true;
            if (x <= b && y <= c && z <= a) return true;
            if (x <= c && y <= a && z <= b) return true;
            if (x <= c && y <= b && z <= c) return true;
            return false;
        }

      
    }
    class Program
    {
        static void Main()
        {
            figura f= new figura();
            f.Print();
            Console.WriteLine("Точек в фигуре {0,8}", f.kol_t);
            double p;
            f.perimetr(out p);
            Console.WriteLine("Периметр фигуры равен {0}",p);
            Console.WriteLine("HashCode {0}", f.id);
            figura.ClassInfo();
            Console.WriteLine("f.Equals(f) {0}", f.Equals(f));
            Console.WriteLine("Поместится ли фигура в ящик с размерами {0}x{1}x{2} : {3}", 10,15,10,f.onBox(10,15,10));
            figura f1 = new figura(5);
            f1.Print();
            Console.WriteLine("Периметр фигуры равен {0}", MathObj.perimetr(f1));
            Console.WriteLine("HashCode {0}", f1.id);
            figura.ClassInfo();
            Console.WriteLine("Поместится ли фигура в ящик с размерами {0}x{1}x{2} : {3}", 40, 40, 40, f1.onBox( 40, 40, 40));
            Console.WriteLine("f1.Equals(f1) {0}", f1.Equals(f1));
            Console.WriteLine("f.Equals(f1) {0}", f.Equals(f1));
            Console.WriteLine("f1.Equals(f) {0}", f1.Equals(f));
            figura.ClassInfo();
            figura f2 = f1;
            f2.Print();
            Console.WriteLine("f3 = f2\nf3.Equals(f2) {0}", f2.Equals(f1));
            MathObj.change(ref f2, 1);
            Console.WriteLine("Change f3");
            f2.Print();
            var anonimtype = new { name = "Tochka", x = 10, y = 5, z = 17 };
            Console.WriteLine("Анонимный тип: {0} ({1};{2};{3})", anonimtype.name, anonimtype.x, anonimtype.y, anonimtype.z);
        }
    } 
}
