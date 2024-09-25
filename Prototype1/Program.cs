/*
 Cada vez que eu uso tem um gasto
 Cria um objeto via fábrica, usa um método e transforma esse método
 "não é barato chegar até aqui",
 então eu quero cloná-lo e segue a customização

 clonar um objeto é depende da linguagem de programação,
 então foi necessario um padrão


 
 */



using System.Numerics;

interface Figura
{
    public double area();
}

class Circulo : Figura
{
    Ponto centro;
    private double raio;
    public Circulo(double r, Ponto p1)
    {
        this.raio = r;
        this.centro = p1;
    }
    public double area()
    {
        double area = Math.PI * Math.Pow(raio, 2);
        return area;
    }
    public Ponto getCentro() => centro;

    public Circulo clone()
    {
        return CriaCirculo.createCirculo(this.raio,this.centro);
    }
}
class Quadrado : Figura
{
    private Ponto ponto1, ponto2;
    private double lado;
    public Quadrado(double l, Ponto p1, Ponto p2)
    {
        this.ponto1 = p1;
        this.ponto2 = p2;
        this.lado = l;
    }
    public double area()
    {
        var area = lado * lado;
        return area;
    }

    public Ponto getp1() => ponto1;

    public Ponto getp2() => ponto2;

    public Quadrado clone()
    {
        return CriaQuadrado.createQuadrado(this.lado,this.ponto1,this.ponto2);
    }
}
class TrEquilatero : Figura
{
    private Ponto ponto1, ponto2, ponto3;
    private double lado;
    public TrEquilatero(double l, Ponto p1, Ponto p2, Ponto p3)
    {
        this.lado = l;
        this.ponto1 = p1;
        this.ponto2 = p2;
        this.ponto3 = p3;
    }
    public double area()
    {
        var area = lado * 0.5 * Math.Sqrt(3);
        return area;
    }


    public Ponto getp1() => ponto1;

    public Ponto getp2() => ponto2;

    public Ponto getp3() => ponto3;

    public TrEquilatero clone()
    {
        return CriaTrianguloEq.createTrianguloEq(this.lado,this.ponto1, this.ponto2,this.ponto3);
    }

}

interface Fabrica
{
    // factory normal
    /*
    public static Figura createFigura(double l, int shape)
    {
        switch (shape)
        {
            case 1: // circulo
                var a = CriaCirculo.createCirculo(l);
                return a;
                break;
            case 2: // Quadrado
                var b = CriaQuadrado.createQuadrado(l);
                return b;
                break;
            case 3: // TrianguloEq
                var c = CriaTrianguloEq.createTrianguloEq(l);
                return c;
                break;
            default:
                throw new NotImplementedException();
        }
    
    }
    */

    // abstractFactory

    public static Circulo createCirculo(double l, int x1, int y1)
    {
        Ponto p1 = CriaPonto.createPonto(x1, y1);
        return CriaCirculo.createCirculo(l, p1);
    }

    public static Quadrado createQuadrado(double l, int x1, int y1, int x2, int y2)
    {
        Ponto p1 = CriaPonto.createPonto(x1, y1);
        Ponto p2 = CriaPonto.createPonto(x2, y2);
        return CriaQuadrado.createQuadrado(l, p1, p2);
    }

    public static TrEquilatero createTrianguloEq(double l, int x1, int y1, int x2, int y2, int x3, int y3)
    {
        Ponto p1 = CriaPonto.createPonto(x1, y1);
        Ponto p2 = CriaPonto.createPonto(x2, y2);
        Ponto p3 = CriaPonto.createPonto(x3, y3);
        return CriaTrianguloEq.createTrianguloEq(l, p1, p2, p3);
    }

    public static Figura clonar(Figura f)
    {
        if (f is TrEquilatero)
        {
            Console.WriteLine("Clonando Triângulo Equilatero");
            TrEquilatero t = (TrEquilatero)f;
            return t.clone();
        }
        else if (f is Quadrado)
        {
            Console.WriteLine("Clonando Quadrado");
            Quadrado q = (Quadrado)f;
            return q.clone();
        }
        else if (f is Circulo)
        {
            Console.WriteLine("Clonando Círculo");
            Circulo c = (Circulo)f;
            return c.clone();
        }
        else
            throw new Exception();
    }
}

class CriaCirculo : Fabrica
{
    public static Circulo createCirculo(double l, Ponto p1)
    {
        Circulo c = new Circulo(l, p1);
        return c;
    }
}
class CriaQuadrado : Fabrica
{
    public static Quadrado createQuadrado(double l, Ponto p1, Ponto p2)
    {
        Quadrado q = new Quadrado(l, p1, p2);
        return q;
    }
}
class CriaTrianguloEq : Fabrica
{
    public static TrEquilatero createTrianguloEq(double l, Ponto p1, Ponto p2, Ponto p3)
    {
        TrEquilatero tri = new TrEquilatero(l, p1, p2, p3);
        return tri;
    }
}
class CriaPonto : Fabrica
{
    public static Ponto createPonto(int x, int y)
    {
        Ponto p = new Ponto(x, y);
        return p;
    }
}

class Ponto
{
    private int x;
    private int y;
    public Ponto(int x, int y)
    {
        this.y = y;
        this.x = x;
    }

    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
}



public class Program
{
    public static void Main()
    {
        // cria círculo
        var c = Fabrica.createCirculo(1.5, 2, 3);
        Console.Write("Area do círculo: ");
        Console.WriteLine(c.area().ToString("F"));
        Ponto p = c.getCentro();
        Console.WriteLine($"Coordenadas do centro\nx:{p.getX()}\ny:{p.getY()}");

        Console.WriteLine();

        Circulo circ = Fabrica.createCirculo(0,0,0); 
        circ = (Circulo) Fabrica.clonar( c );
        
        Console.Write("Area do círculo: ");
        Console.WriteLine(circ.area().ToString("F"));
        Ponto pt = circ.getCentro();
        Console.WriteLine($"Coordenadas do centro\nx:{pt.getX()}\ny:{pt.getY()}");
    }
}