/*
MANTÉM O OBSERVER, APENAS SERÁ IMPLEMENTADO O MEDIATOR
mudou drasticamente a temperatura da água
alerta todo mundo

mantém o sistema de interesse do PCD - Instituto

mediator como sistema para avisar geral 
metodo que mande uma mensagem para geral 

mudou a temperatura, avisa INPE por exemplo

*/


public interface Instituto
{
    void atualizar(PCD plataforma);
}

public class Pesquisadores : Instituto
{
    private double temperatura = 0;
    private double pH = 0;
    private double pressao = 0;
    private string? nome;
    private Mediator mediator;

    public Pesquisadores(Mediator med = null)
    {
        this.mediator = med;
    }

    public void setMediator(Mediator med)
    {
        this.mediator = med;
    }

    public void avisoTemp(double temp,string qualDado)
    {
        Console.Write($"{this.getNome()}");
        mediator.confirmacao(temp, qualDado);
    }

    public void setNome(string? nome)
    {
        this.nome = nome;
    }

    public string? getNome()
    {
        return this.nome;
    }
    public void atualizar(PCD plataforma)
    {
        ZonaRemota z = (ZonaRemota)plataforma;
        this.temperatura = z.getTemp();
        this.pH = z.getPh();
        this.pressao = z.getP();
        Console.WriteLine($"Dados que {this.nome} recebeu:\nTemperatura:{this.temperatura}ºC\npH:{this.pH}\nPressão:{this.pressao} atm\n");
    }
}

public class PCD
{
    List<Instituto> institutos = new List<Instituto>();
    protected Mediator mediator;

    public PCD(Mediator med = null)
    {
        this.mediator = med;
    }

    public void setMediator(Mediator med)
    {
        this.mediator = med;
    }

    public virtual List<Instituto> interessados()
    {
        return this.institutos;
    }

    // ADD
    public virtual void seInteressou(Instituto inst)
    {
        this.institutos.Add(inst);
    }

    // REMOVE
    public virtual void seDesinteressou(Instituto inst)
    {
        this.institutos.Remove(inst);
    }
    // NOTIFICA
    public virtual void notifica()
    {
        foreach (Instituto inst in this.institutos)
        {
            inst.atualizar(this);
        }
    }
}

public class ZonaRemota : PCD
{
    private double temperatura;
    private double pH;
    private double pressao;


    public void setDados(double temp, double pH, double P)
    {
        this.temperatura = temp;
        this.pH = pH;
        this.pressao = P;

        int erroTemp = this.verifica(temp,"t");
        int erroPh = this.verifica(pH,"ph");
        int erroPressao = this.verifica(P,"pr");

        if(erroTemp < 0)
        {
            mediator.alerta(this, temp,"temperatura");
        }
        if(erroPh < 0)
        {
            mediator.alerta(this, pH,"pH");
        }
        if (erroPressao < 0)
        {
            mediator.alerta(this, P,"pressão");
        }
        else
            this.notifica();
    }

    public double getTemp()
    {
        return this.temperatura;
    }
    public double getPh()
    {

        return this.pH;
    }
    public double getP()
    {
        return this.pressao;

    }

    public int verifica(double valor,string key)
    {
        switch (key)
        {
            case "t":
                // temperatura normal
                if (valor <= 32 && valor >= 20)
                    return 0;
                // temperatura alterada
                else
                    return -1;

            case "ph":
                // pH normal
                if (valor <= 7 && valor >= 3)
                    return 0;
                // ph alterado
                else
                    return -1;

            case "pr":
                // pressao normal
                if (valor <= 2 && valor >= 0.8)
                    return 0;
                // pressao alterada
                else
                    return -1;

            default:
                return 1;
        }

    }
}

public interface Mediator
{
    // uma zona manda um alerta com base em um valor e qual 
    // dado está alterado
    void alerta(ZonaRemota zona, double valor, string qualDado);

    // o pesquisador confirma o recebimento do alerta
    // com base na string dado, ele confere se é temperatura
    // pressão ou pH, e o valor da variação
    void confirmacao(double valor, string dado);
}

public class Calor : Mediator
{
    private List<Pesquisadores> pesquisadores = new();
    private PCD plataforma = new();

    public void setZona(ZonaRemota zona)
    {
        this.plataforma = zona;
        plataforma.setMediator(this);
    }

    public void setPesq(List<Instituto> institutos)
    {
        foreach(Pesquisadores p in institutos)
        {
            p.setMediator(this);
        }
        //this.pesquisadores = pesq;
        //pesquisadores.setMediator(this);
    }

    public void alerta(ZonaRemota zona, double temp, string qualDado)
    {
        foreach(Pesquisadores p in zona.interessados())
        {
            p.avisoTemp(temp,qualDado);
        }
    }

    public void confirmacao(double var,string dado)
    {
        if(dado == "temperatura")
        {
            Console.WriteLine($" recebeu um alerta sobre a tempertura ter aumentado para {var}ºC");
        }
        if(dado == "pressão")
        {
            Console.WriteLine($" recebeu um alerta sobre a pressão atmosférica local ter alterado para {var} atm");
        }
        if(dado == "pH")
        {
            Console.WriteLine($" recebeu um alerta sobre o pH do local medir {var}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Declarei uma zona que é um pcd
        ZonaRemota mataAtlantica = new ZonaRemota();
        // dados iniciais da zona
        mataAtlantica.setDados(25.3, 5.5, 1);
        Console.WriteLine($"Os dados da zona inicialmente são:\nTemperatura:{mataAtlantica.getTemp()}ºC\npH:{mataAtlantica.getPh()}\nPressão:{mataAtlantica.getP()} atm\n\n");

        // UNIFESP
        Pesquisadores unifesp = new Pesquisadores();
        unifesp.setNome("UNIFESP");
        mataAtlantica.seInteressou(unifesp);

        //USP
        Pesquisadores usp = new Pesquisadores();
        usp.setNome("USP");
        mataAtlantica.seInteressou(usp);


        Calor mediador = new Calor();
        mediador.setZona(mataAtlantica);
        mediador.setPesq(mataAtlantica.interessados());

        //mataAtlantica.seDesinteressou(usp);

        // aumentou a temperatura da zona
        mataAtlantica.setDados(28, 5.5, 1);

        Console.WriteLine("Os interessados na Mata Atlântica são:");
        foreach (Pesquisadores pesq in mataAtlantica.interessados())
        {
            Console.WriteLine($"{pesq.getNome()}");
        }
        Console.WriteLine("\n------------------------\n");

        Console.WriteLine("TEMPERATURA ALTERADA\n");
        // temperatura alterada
        mataAtlantica.setDados(36, 5.5, 1);

        Console.WriteLine("\nPH ALTERADO\n");

        // pH alterado
        mataAtlantica.setDados(25, 2.3, 1);
        

        Console.WriteLine("\nPRESSÃO E PH ALTERADO\n");

        // pH alterado
        mataAtlantica.setDados(25, 2.3, 3);
    }
}