/*
tipo o Ctrl+z

voltar algum objeto do estado que ele estava anteriormente, sem quebrar o encapsulamento
inclusive suas referências

memento guarda uma fonte

classes do mesmo pacote podem acessar o memento

memento não tem acesso ao conteudo 

estrutura de dados para Undos, no "Zelador", sucessivos Ctrl+z 's - usando Pilha

Zelador pede pra Fonte criar memento, fonte cria memento e set o estado atual no memento
Zelador seta memento na fonte, fonte da get no estado pro memento

exercicio dos pcd Observer
PCD é a fonte, set temperatura, set temperatura, set temperatura ...
preparar a PCD para retorna as 3 últimas temps
 */


class Zelador
{
    private List<Memento> list = new List<Memento>();
    private PCD plataforma = new PCD();

    public void setPCD(PCD p)
    {
        plataforma = p;
    }
    public void criarMemento()
    {
        var p = plataforma.createMemento();
        list.Add(p);
    }

    public Memento getMemento()
    {
        return this.list[0];
    }

    public void printRegistros(Memento m)
    {
        int i = 0;
        foreach (var p in m.getEstados())
        {
            i += 1;
            switch (i)
            {
                case 1:
                    Console.WriteLine($"Último registro de temperatura: {p}ºC");
                    break;
                case 2:
                    Console.WriteLine($"Penultimo registro de temperatura: {p}ºC");
                    break;
                case 3:
                    Console.WriteLine($"Antepenultimo registro de temperatura: {p}ºC");
                    break;
            }
        }
    }
}




public class PCD
{
    private double temperatura;
    private Memento memento;

    public void setTemp(double temp)
    {
        this.temperatura = temp;
        this.memento.setEstado(temp);
    }
    public double getTemp() => this.temperatura;

    public Memento createMemento()
    {
        return new Memento();
    }
    public void setMemento(Memento m)
    {
        this.memento = m;
    }

    public List<double> getMemento()
    {
        return memento.getEstados();
    }
}

public class Memento
{
    private List<double> registro = new List<double>();
    public void setEstado(double temp)
    {
        if (this.registro.Count < 3)
        {
            this.registro.Add(temp);
        }
        else
        {
            this.registro.RemoveAt(0);
            this.registro.Add(temp);
        }
    }
    public List<double> getEstados()
    {
        return this.registro;
    }
}

class Program
{
    public static void Main()
    {
        Zelador pesquisador = new Zelador();
        PCD Amazonia = new PCD();
        pesquisador.setPCD(Amazonia);

        pesquisador.criarMemento();
        Amazonia.setMemento(pesquisador.getMemento());
        var registro = pesquisador.getMemento();

        Amazonia.setTemp(28.4);
        Amazonia.setTemp(29.1);
        Amazonia.setTemp(30.0);

        pesquisador.printRegistros(registro);

        Amazonia.setTemp(27.7);

        pesquisador.printRegistros(registro);
    }
}