/*
    Recebe uma string
    
    Elo 1 - número de espaços encontrados
    Elo 2 - número de letras 'a'
    Elo 3 - número de '.'


    Nesse caso farei interativo

*/

public interface Elo
{
    Elo setSucessor(Elo proximo);
    void processar(string input);
}

public class Espacos : Elo
{
    private Elo sucessor;
    public Espacos(Elo proximo = null)
    {
        this.sucessor = proximo;
    }
    public Elo setSucessor(Elo proximo)
    {
        this.sucessor = proximo;
        return this;
    }
    public void processar(string? input)
    {
        if(input != null)
        {
            int x = input.Count(c => c == ' ');
            Console.WriteLine($"Foram encontrados {x} espaços na string.");
        }
        if (this.sucessor != null)
            sucessor.processar(input);
    }

}
public class As : Elo
{
    private Elo sucessor;
    public As(Elo proximo = null)
    {
        this.sucessor = proximo;
    }
    public Elo setSucessor(Elo proximo)
    {
        this.sucessor = proximo;
        return this;
    }
    public void processar(string? input)
    {
        if(input != null)
        {
            int x = input.Count(c => c == 'a');
            Console.WriteLine($"Foram encontrados {x} 'a's na string.");
        }
        if (this.sucessor != null)
            sucessor.processar(input);
    }

}
public class Pontos : Elo
{
    private Elo sucessor;

    public Pontos(Elo proximo = null)
    {
        this.sucessor = proximo;
    }
    public Elo setSucessor(Elo proximo)
    {
        this.sucessor = proximo;
        return this;
    }
    public void processar(string? input)
    {
        if(input != null)
        {
            int x = input.Count(c => c == '.');
            x += input.Count(c => c == '?');
            x += input.Count(c => c == '!');
                Console.WriteLine($"Foram encontrados {x} pontos na string.");
        }
        if(this.sucessor != null)
            sucessor.processar(input);
    }

}
public class Client
{
    private Elo analisador;

    public Client(Elo generico)
    {
        this.analisador = generico;
    }
    public void requisicao(string? input)
    {
        if (input != null)
            this.analisador.processar(input);
    }
}
public class Program
{
    static void Main()
    {
        // recebe a string a ser analisada
        Console.WriteLine("Digite a string que será processada");
        string? input = Console.ReadLine();
 
        // declara os elos da corrente
        var pontos = new Pontos();
        var ases = new As();
        var espacos = new Espacos();

        // seta os sucessores
        espacos.setSucessor(ases);
        ases.setSucessor(pontos);

        // um cliente requesita a analise da string
        var cliente = new Client(espacos);
        cliente.requisicao(input);
    }
}