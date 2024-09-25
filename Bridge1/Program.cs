using System.Numerics;

public class Lista
{
    List<object> lista = new List<object>();
    public virtual void pegaFila(object x) { 
        this.lista.Add(x);
    }
    public virtual void saiFila() {
        this.lista.RemoveAt(0);
    }
    public virtual int tamanho(){ 
        return this.lista.Count();
    }

    public virtual List<object> getList()
    {
        return this.lista;
    }

}

// queue e dequeue está na abstração, muito especifico
// a lógica de adicionar e remover está nas implementações, heranças

// List
public class ArrayListQueue : Lista
{
    List<object> lista = new List<object>();
    public override void pegaFila(object x) { 
        this.lista.Add(x);
    }
    public override void saiFila() {
        this.lista.RemoveAt(0);
    }
    public override int tamanho(){ 
        return this.lista.Count();
    }

    public override List<object> getList()
    {
        return this.lista;
    }

}

public class VectorQueue : Lista
{
    List<object> lista = new List<object>();
    public override void pegaFila(object x)
    {
        this.lista.Add(x);
    }
    public override void saiFila()
    {
        this.lista.RemoveAt(0);
    }
    public override int tamanho()
    {
        return this.lista.Count();
    }
    public override List<object> getList()
    {
        return this.lista;
    }

}


public abstract class Queue
{
    private object x = new object();
    private Lista lista = new Lista();
    public abstract bool ehVazia(Lista lista);
    public abstract int tamanho(Lista lista);
    public abstract void adiciona(object x);
    public abstract void remove();
}


// lógica de quem sai primeiro
public class FIFO : Queue
{
    private Lista lista = new Lista();
    public FIFO(Lista lisch) {
        this.lista = lisch;
    }
    private object x = new object();
    public override void adiciona(object x)
    {
        this.lista.pegaFila(x);
    }

    public override bool ehVazia(Lista lista)
    {
        if (this.lista.tamanho() == 0)
            return true;

        return false;
    }

    public override void remove()
    {
        if (ehVazia(this.lista))
        {
            Console.WriteLine("Não é possível remover, lista vazia\n");
        }
        else
        {
            this.lista.saiFila();
        }
    }

    public override int tamanho(Lista lista)
    {
        return this.lista.tamanho();
    }
}



public class Program
{
    public static void Main()
    {
        Lista lista = new Lista();
        FIFO fifo = new FIFO(lista);

        fifo.adiciona("Evandro");
        fifo.adiciona("Thiago");
        fifo.adiciona("Robert");
        // sai Evandro
        lista.saiFila();
        foreach(object x in lista.getList())
        {
            Console.WriteLine(x);
        }
    }
}