public class Numero
{
    
    private List<Algarismo> numeros = new List<Algarismo>();

    public bool temAlgarismo(int n)
    {
        // Algarismo alg = new Algarismo(n);
        var a = numeros.Find(x => x.getAlgarismo() == n);

        if (a == null) // o numero não tem esse algarismo
        {
            return false;
        }
        else // já tem esse algarismo
        {
            Console.WriteLine($"Já tem {n}");
            return true;
        }
    }

    public void gerarNumero()
    {
        while(numeros.Count != 10) 
        {
            Random nRand = new Random();
            var x = nRand.Next(10);
            if (temAlgarismo(x) == false) // se não tiver esse algarismo
            {
                Algarismo alg = new Algarismo(x);
                this.numeros.Add(alg);
            }
            
        }
        Console.Write("Número gerado:");
        foreach (Algarismo alg in numeros)
        {
            Console.Write(alg.getAlgarismo());
        }
        Console.WriteLine();
    }
    
    public void gerarDezNumeros()
    {
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i+1}º número");
            Console.WriteLine();
            gerarNumero();
            this.numeros.Clear();
            Console.WriteLine();
        }
    }
    
}

public interface Flyweight{

}

public class Algarismo : Flyweight
{
    private int algarismo;
    public Algarismo(int alg)
    {
        this.algarismo = alg;
    }

    public int getAlgarismo()
    {
        return algarismo;
    }

}

public class Program
{
    static void Main()
    {
        Numero num = new Numero();
        num.gerarDezNumeros();
    }
}