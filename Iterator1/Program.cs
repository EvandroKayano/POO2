/*
 acessar o conteudo, sem expor organização da coleção
 
 a classe que gerencia a coleção implementa o iterator, implemente next, hasnext

 escrever um type-safe iterator (add só um tipo) remover não precisa filtar...
 */

using System.Collections;
using System.Diagnostics.Metrics;

public class ListaFigura
{
    private List<Figura> lista = new List<Figura>();

    public void adc(Object obj)
    {
        if(obj.GetType() != typeof(Figura))
        {

            Figura f = (Figura)obj;
            lista.Add(f);
        }
        
    }

    public void rmv(Figura obj)
    {
        lista.Remove(obj);
    }

    public ConcreteIterator criaIterador()
    {
        var it = new ConcreteIterator();
        it.setList(this.lista);
        return it;
    }
}
public interface Figura
{
    public void euSou();
}

public class Circulo : Figura
{
    public void euSou()
    {
        Console.WriteLine("Eu sou um circulo");
    }
}
public class Retangulo : Figura
{
    public void euSou()
    {
        Console.WriteLine("Eu sou um retângulo");
    }
}
public class Quadrado : Figura
{
    public void euSou()
    {
        Console.WriteLine("Eu sou um quadrado");
    }
}
public class TrianguloEq : Figura
{
    public void euSou()
    {
        Console.WriteLine("Eu sou um triângulo equilátero");
    }
}

public interface Iterator
{
    public Figura getNext();
    public bool HasNext();
}

public class ConcreteIterator : Iterator
{
    private List<Figura> lista = new List<Figura>();
    private int count;

    public ConcreteIterator()
    {
        count = 0;
    }

    public void setList(List<Figura> lista)
    {
        this.lista = lista;
    }
    public Figura getNext()
    {
        if(count == 0)
        {
           lista[1].euSou();
        }
        if(count != lista.Count())
        {
            this.count++;
        }
        else if(count == lista.Count)
        {
            return lista[count - 1];
        }
        return lista[count-1];
    }

    public bool HasNext()
    {
        if (lista.Count() > this.count)
        {
            return true;
        }
        else
            return false;
    }
}


public class Program
{
    static void Main()
    {
        Circulo circulo = new Circulo();
        Quadrado quadrado = new Quadrado();
        Retangulo retangulo = new Retangulo();
        TrianguloEq eq = new TrianguloEq();
        
        ListaFigura lista = new ListaFigura();

        lista.adc(eq);
        lista.adc(circulo);
        lista.adc(quadrado);
        lista.adc(retangulo);

        Iterator it = lista.criaIterador();

        while (it.HasNext())
        {
            Figura f = it.getNext();
            f.euSou();
        }
    }
}