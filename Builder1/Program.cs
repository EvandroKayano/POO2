using System.Globalization;

class Diretor
{
    Builder? builder;

    public void create(Builder build, string name, string id)
    {
        this.builder = build;
        builder.setNome(name);
        builder.setID(id);
    }

}

interface Builder
{
    public void setNome(string name);
    public void setID(string id);
}
class PessoaBuilder : Builder
{
    private Pessoa pessoa = new Pessoa();

    public void setNome(string name)
    {
        pessoa.setName(name);
    }
    public void setID(string id)
    {
        pessoa.setId(id);
    }

    public Pessoa getPessoa()
    {
        return this.pessoa;
    }
}
class Pessoa
{
    private string nome;
    private string identidade;

    public void setName(string name)
    {
        this.nome = name;
    }
    public void setId(string id)
    {
        this.identidade = id;
    }

    public string getName()
    {
        return this.nome;
    }
    public string getID()
    {
        return this.identidade;
    }
}
class EmpresaBuilder : Builder
{
    private Empresa empresa = new Empresa();

    public void setNome(string nome)
    {
        empresa.setName(nome);
    }
    public void setID(string id)
    {
        empresa.setId(id);
    }

    public Empresa getEmpresa()
    {
        return this.empresa;
    }
}
class Empresa
{
    private Pessoa responsavel = new Pessoa();

    public void setName(string nome)
    {
        responsavel.setName(nome);
    }
    public void setId(string id)
    {
        responsavel.setId(id);
    }
    public string getName()
    {
        return this.responsavel.getName();
    }
    public string getID()
    {
        return this.responsavel.getID();
    }
}




class Program
{
    public static void Main()
    {
        Diretor diretor = new Diretor();

        PessoaBuilder pBuilder = new PessoaBuilder();
        diretor.create(pBuilder,"Evandro","444.670.698-52");
        Pessoa eu = pBuilder.getPessoa();

        Console.WriteLine($"Pessoa criada\nNome:{eu.getName()}\nID:{eu.getID()}");

        Console.WriteLine();

        EmpresaBuilder eBuilder = new EmpresaBuilder();
        diretor.create(eBuilder, "Filipe", "012.345.678-90");
        Empresa empresa = eBuilder.getEmpresa();

        Console.WriteLine($"Empresa criada\nNome:{empresa.getName()}\nID:{empresa.getID()}");

    }
}