/*
 Ao invés de fazer varios "if"s criar n subclasses q executam() de forma diferente

Descubra o dia da semana e repasse pra definir uma estratégia especifica
 */

public class Agenda
{
    private int diaDaSemana;
    private Plano plano;

    // dia atual como padrão
    public Agenda()
    {
        DateTime hoje = DateTime.Now;
        this.diaDaSemana = (int) hoje.DayOfWeek;
    }
    // dia especifico
    public Agenda(DateTime dia)
    {
        this.diaDaSemana = (int)dia.DayOfWeek;
    }

    public void planejar()
    {
        if(this.diaDaSemana == 1 || this.diaDaSemana == 3)
        {
            this.plano = new SegEQua();
        }
        else if(this.diaDaSemana == 2 || this.diaDaSemana == 4)
        {
            this.plano = new TerEQui();
        }
        else if(this.diaDaSemana == 5)
        {
            this.plano = new Sex();
        }
        else if(diaDaSemana == 6 || diaDaSemana == 0)
        {
            this.plano = new SabEDom();
        }
    }

    public void executarDia() 
    { 
        if(this.plano == null)
        {
            this.plano = new Nulo();
            this.plano.executarPlano();
        }
        else
            this.plano.executarPlano(); 
    }
}

public interface Plano
{
    public void executarPlano();
}

public class SegEQua : Plano
{
    public void executarPlano()
    {
        Console.WriteLine("Estudar LFA e POO2");
    }
}

public class TerEQui : Plano
{
    public void executarPlano()
    {
        Console.WriteLine("Estudar AL e SO");
    }
}

public class Sex : Plano
{
    public void executarPlano()
    {
        Console.WriteLine("Society 19:00");
    }
}
public class SabEDom : Plano
{
    public void executarPlano()
    {
        Console.WriteLine("Fazer exercícios das matérias e pedir lanche");
    }
}
public class Nulo : Plano
{
    public void executarPlano()
    {
        Console.WriteLine("Você não planejou nada!");
    }
}


public class Program
{
    public static void Main()
    {
        Agenda qts = new Agenda();
        qts.executarDia();

        qts.planejar();
        qts.executarDia();
    }
}