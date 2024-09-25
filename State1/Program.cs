/*
 Semáforo de trânsito, pensar na modelagem e implementar como um estado

 */

public class Transito
{
    private Estado cor;
    public readonly Estado parar = new Vermelho();
    public readonly Estado desacelerar = new Amarelo();
    public readonly Estado sigaAdiante = new Verde();


    public void setEstado(Estado est)
    {
        this.cor = est;
    }

    public void mostrarCor()
    {
        if(this.cor != null)
        {
            this.cor.iluminar();
        }
        else
        {
            this.cor = new CorNula();
            this.cor.iluminar();
        }
    }
}

public interface Estado
{
    public void iluminar();
}

public class Verde : Estado
{
    public void iluminar()
    {
        Console.WriteLine("Siga em frente!");
    }
}

public class Amarelo : Estado
{
    public void iluminar()
    {
        Console.WriteLine("Desacelere! O semáforo já vai ficar vermelho!");
    }
}

public class Vermelho : Estado
{
    public void iluminar()
    {
        Console.WriteLine("PARADO, HEIN!");
    }
}

public class CorNula : Estado
{
    public void iluminar()
    {
        Console.WriteLine("Esqueceu de me configurar, cara!");
    }
}

public class Program
{
    public static void Main()
    {
        Transito transito = new Transito();


        // estado Nulo
        transito.mostrarCor();

        // verde
        transito.setEstado(transito.sigaAdiante);
        transito.mostrarCor();

        // amarelo
        transito.setEstado(transito.desacelerar);
        transito.mostrarCor();

        // vermelho
        transito.setEstado(transito.parar);
        transito.mostrarCor();

    }
}