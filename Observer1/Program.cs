//// PCDs e Institutos
//// simular que a temperatura do PCDx mudou
//// aqueles que tem interesse nesse PCDx recebe um aviso da alteração
//// sujeito e observador -> PCD e Instituto

//using System.Diagnostics;

//public class PCD
//{


//    List<Instituto> institutos = new List<Instituto>();

//    // ADD
//    public virtual void seInteressou(Instituto inst) 
//    {
//        this.institutos.Add(inst);
//    }

//    // REMOVE
//    public virtual void seDesinteressou(Instituto inst)
//    {
//        this.institutos.Remove(inst);
//    }

//    // NOTIFY
//    public virtual void notifica()
//    {
//        foreach(Instituto inst in institutos)
//        {
//            inst.atualizar(this);
//        }
//    }
//}

//public class ZonaRemota : PCD
//{
//    private double temperatura;
//    private double pH;
//    private double pressao;
//    List<Pesquisadores> institutos = new List<Pesquisadores>();


//    public List<Pesquisadores> interessados()
//    {
//        return institutos;
//    }
//    public void setDados(double temperatura,double pH,double P)
//    {
//        this.temperatura = temperatura;
//        this.pH = pH;
//        this.pressao = P;
//        this.notifica();
//    }

//    public double getTemp()
//    {
//        return this.temperatura;
//    }
//    public double getPh( )
//    {

//        return this.pH;
//    }
//    public double getP()
//    {
//        return this.pressao;

//    }


//    public override void seInteressou(Instituto inst)
//    {
//       this.institutos.Add((Pesquisadores)inst);
//    }
//    public override void seDesinteressou(Instituto inst)
//    {
//        this.institutos.Remove((Pesquisadores)inst);
//    }
//    public override void notifica()
//    {
//        foreach(Pesquisadores p in institutos)
//        {
//            p.atualizar(this);
//        }
//    }
//}



//public class Instituto
//{
//    public virtual void atualizar(PCD p) { }
//}

//public class Pesquisadores : Instituto
//{
//    private double temperatura = 0;
//    private double pH = 0;
//    private double pressao = 0;
//    private string? nome;

//    public Pesquisadores(string? nome)
//    {
//        this.nome = nome;
//    }

//    public override void atualizar(PCD p)
//    {
//        ZonaRemota z = (ZonaRemota) p;
//        this.temperatura = z.getTemp();
//        this.pH =z.getPh();
//        this.pressao =z.getP();
//        Console.WriteLine($"Dados de {this.nome} atualizados:\nTemperatura:{this.temperatura}\npH:{this.pH}\nPressão:{this.pressao}\n\n");
//    }
//}



//class Program
//{
//    static void Main()
//    {
//        ZonaRemota zona = new ZonaRemota();
//        zona.setDados(25.3, 7.4, 1);
//        Console.WriteLine($"Os dados da zona são:\nTemperatura:{zona.getTemp()}\npH:{zona.getPh()}\nPressão:{zona.getP()}\n\n");

//        Pesquisadores unifesp = new Pesquisadores("UNIFESP");
//        zona.seInteressou(unifesp);
//        Pesquisadores usp = new Pesquisadores("USP");
//        zona.seInteressou(usp);

//        // aumentou a temperatura da zona
//        zona.setDados(28, 7.4, 1);






//    }
//}

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

    public Pesquisadores(string? nome)
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

    public void setDados(double temperatura, double pH, double P)
    {
        this.temperatura = temperatura;
        this.pH = pH;
        this.pressao = P;
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


}




class Program
{
    static void Main()
    {
        // Declarei uma zona que é um pcd
        ZonaRemota mataAtlantica = new ZonaRemota();
        // dados iniciais da zona
        mataAtlantica.setDados(25.3, 7.4, 1);
        Console.WriteLine($"Os dados da zona inicialmente são:\nTemperatura:{mataAtlantica.getTemp()}ºC\npH:{mataAtlantica.getPh()}\nPressão:{mataAtlantica.getP()} atm\n\n");


        Pesquisadores unifesp = new Pesquisadores("UNIFESP");
        mataAtlantica.seInteressou(unifesp);
        Pesquisadores usp = new Pesquisadores("USP");
        mataAtlantica.seInteressou(usp);

        // aumentou a temperatura da zona
        mataAtlantica.setDados(28, 7.4, 1);

        Console.WriteLine("Os interessados na Mata Atlântica são:");
        foreach (Pesquisadores pesq in mataAtlantica.interessados())
        {
            Console.WriteLine($"{pesq.getNome()}");
        }
    }
}