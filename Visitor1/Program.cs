/*
 
 plugar um nova funcionalidade em objetos sem mexer na estrutura de herança


 
 */


public interface Operacao
{
    public void setn1(N1 n);
    public void setn2(N2 n);
    public int calcular();
    public string imprimir();   
}

public class Multiplicacao : Operacao
{
    private N1 n1;
    private N2 n2;

    public void setn1(N1 n) => n1 = n;
    public void setn2(N2 n) => n2 = n;
    public int calcular() => n1.getn1() * n2.getn2();

    public string imprimir() => calcular().ToString();
}

public class Adicao : Operacao
{
    private N1 n1;
    private N2 n2;

    public void setn1(N1 n) => n1 = n;
    public void setn2(N2 n) => n2 = n;
    public int calcular() => n1.getn1() + n2.getn2();

    public string imprimir() => calcular().ToString();
}

public interface Numeros
{
    public void aceitarVisitante(Operacao op);
}

public class N1 : Numeros
{
    private int x;
    public N1() { }
    public N1(int n)
    {
        x = n;
    }

    public void aceitarVisitante(Operacao operacao)
    {
        operacao.setn1(this);
    }
    public int getn1() => x;
}

public class N2 : Numeros
{
    private int x;
    public N2() { }
    public N2(int n)
    {
        x = n;
    }

    public void aceitarVisitante(Operacao operacao)
    {
        operacao.setn2(this);
    }
    public int getn2() => x;
}

public class Program
{
    public static void Main()
    {
        Multiplicacao multiplicacao = new Multiplicacao();
        Adicao adicao = new Adicao();
        N1 n1 = new N1(20);
        N2 n2 = new N2(10);

        n1.aceitarVisitante(adicao);
        n1.aceitarVisitante(multiplicacao);
        n2.aceitarVisitante(adicao);
        n2.aceitarVisitante(multiplicacao);
        Console.WriteLine($"Multiplicação: {multiplicacao.imprimir()}");
        Console.WriteLine($"Adição: {adicao.imprimir()}");
    }
}