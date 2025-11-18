using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class GiaiPTBac1
{
    protected double a, b;

    public GiaiPTBac1(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public virtual void Giai()
    {
        if (a == 0)
        {
            if (b == 0)
                Console.WriteLine("Phương trình vô số nghiệm.");
            else
                Console.WriteLine("Phương trình vô nghiệm.");
        }
        else
        {
            double x = -b / a;
            Console.WriteLine("Nghiệm x = " + x);
        }
    }
}

// Lớp giải phương trình bậc 2: ax^2 + bx + c = 0, kế thừa giải phương trình bậc 1
class GiaiPTBac2 : GiaiPTBac1
{
    private double c;

    public GiaiPTBac2(double a, double b, double c) : base(a, b)
    {
        this.c = c;
    }

    public override void Giai()
    {
        if (a == 0)
        {
            // Nếu a = 0, trở thành phương trình bậc 1: bx + c = 0
            GiaiPTBac1 pt1 = new GiaiPTBac1(b, c);
            Console.Write("Phương trình trở thành bậc 1: ");
            pt1.Giai();
        }

        else
        {
            double delta = b * b - 4 * a * c;
            if (delta < 0)
            {
                Console.WriteLine("Phương trình vô nghiệm thực.");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Phương trình có nghiệm kép x1 = x2 = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Phương trình có 2 nghiệm phân biệt:");
                Console.WriteLine("x1 = " + x1);
                Console.WriteLine("x2 = " + x2);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Giải phương trình bậc 2: ax^2 + bx + c = 0");
        Console.Write("Nhập a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhập b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhập c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        GiaiPTBac1 pt2 = new GiaiPTBac2(a, b, c);
        pt2.Giai();
    }
}