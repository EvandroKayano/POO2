/*
 "new" só nas implementações concretas das fábricas
  Ao invés de usar "new" uma classe abstrata fará o instanciamento, deixando assim 
uma subclasse fazer o trabalho.
    
  Cliente só sabe que tem que pedir.
  Dependendo do horario, o user precisa instanciar objetos

  +1 cada de abstração, mas sem desacoplar (REDUZIR O ACOPLAMENTO)

  Não saber o objeto concreto, perdir para uma fábrica

    Delega pra subclasses a criação de objetos
*/
interface Figura
{
    public double area();
}
class Circulo : Figura
{
    private double raio;
    public Circulo(double r)
    {
        this.raio = r;
    }
    public double area()
    {
        double area = Math.PI * Math.Pow(raio,2);
        return area;
    }
}
class Quadrado : Figura
{
    private double lado;
    public Quadrado(double lado)
    {
        this.lado = lado;
    }
    public double area()
    {
        var area = lado * lado;
        return area;
    }
}
class TrEquilatero : Figura
{
    private double lado;
    public TrEquilatero(double l)
    {
        this.lado = l;
    }
    public double area()
    {
        var area = lado * 0.5 * Math.Sqrt(3);
        return area;
    }
}

interface Fabrica
{
    public static Figura createFigura(double l, int shape)
    {
        switch (shape)
        {
            case 1: // circulo
                var a = CriaCirculo.createFigura(l);
                return a;
               break;
            case 2: // Quadrado
                var b = CriaQuadrado.createFigura(l);
                return b;
                break;
            case 3: // TrianguloEq
                var c = CriaTrianguloEq.createFigura(l);
                return c;
                break;
            default:
                throw new NotImplementedException();
        }
    }
}

class CriaCirculo : Fabrica
{
    public static Figura createFigura(double l)
    {
        Circulo circulo = new Circulo(l);
        return circulo;
    }
}
class CriaQuadrado: Fabrica
{
    public static Figura createFigura(double l)
    {
        Quadrado q = new Quadrado(l);
        return q;
    }
}
class CriaTrianguloEq: Fabrica
{
    public static Figura createFigura(double l)
    {
        TrEquilatero tri = new TrEquilatero(l);
        return tri;
    }
}




public class Program
{
    public static void Main()
    {
        // cria círculo
        Figura f = Fabrica.createFigura(1.5 , 1);
        Console.WriteLine(f.area().ToString("F"));

        // cria quadrado
        f = Fabrica.createFigura(1.5, 2);
        Console.WriteLine(f.area().ToString("F"));

        // cria trEq
        f = Fabrica.createFigura(1.5, 3);
        Console.WriteLine( f.area().ToString("F") );
    }
}