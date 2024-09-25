/*
 class Client será o client requisitando a imagem
 interface ImageManager
    |
    |-> classe Proxy: "requisita" Imagem a execução de um código
    |-> classe Imagem: executa códigos
            |-> loadImage,getAltura,getLargura, ctor(string nome) "xxxxx.jpg"
    
    // as imagens terão uma função printDados, já que JFrame é especifico do java 
 
 */

public interface ImageManager
{
    double getAltura();
    double getLargura();
    string getName();
    void printImagem();
}
public class Proxy : ImageManager
{
    private Imagem jpg;

    public Proxy(Imagem file)
    {
        this.jpg = file;
    }

    public double getAltura()
    {
        //Console.WriteLine("Requisitando altura da imagem");
        return jpg.getAltura();
    } 
    public double getLargura()
    {
        //Console.WriteLine("Requisitando largura da imagem");
        return jpg.getLargura();
    }
    public string getName()
    {
        //Console.WriteLine("Requisitando nome da imagem");
        return jpg.getName();
    }
    public void printImagem()
    {
        Console.WriteLine("\"Print\" da imagem");
        jpg.printImagem();
    }
}
public class Imagem : ImageManager
{
    private double altura;
    private double largura;
    private string nome;
    private Imagem loading;

    // IMAGENS NOVAS
    public Imagem(double h,double l,string name)
    {
        this.altura = h;
        this.largura = l;
        this.nome = name;
    }
    public void getLoading(Imagem file)
    {
        this.loading = file;
    }
    public double getAltura()
    {
        return this.altura;
    }

    public double getLargura()
    {
        return this.largura;
    }
    public string getName()
    {
        return this.nome;
    }

    public void printImagem()
    {
        Console.WriteLine($"{loading.nome} tem dimensões iguais a {loading.altura} X {loading.largura} em pixels");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(" .");
        Thread.Sleep(500);
        Console.Write(" .\n");

        Console.WriteLine($"{this.nome} tem dimensões iguais a {this.altura} X {this.largura} em pixels\n");
    }
}
public class Client
{
    public void requestImg(ImageManager man)
    {
        Console.WriteLine("Cliente requisitou imagem...\n");
        man.printImagem();
    }
}
public class Program
{
    static void Main()
    {
        // IMAGEM DE CARREGAMENTO
        Imagem loading = new(1280, 720, "loading.jpg");
        Imagem gato = new(1280, 720, "gato.jpg");
        gato.getLoading(loading);
        Proxy proxy = new(gato);

        Client user = new();
        user.requestImg(proxy);
        // já que JFrame é exclusivo do java, o programa apenas printa os detalhes da imagem
    }
}