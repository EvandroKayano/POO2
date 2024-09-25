// Congresso é o cliente (class Congresso componente.getMembros dá o total)
// em Componente fazer o método de getMembros e fazer uma lista de individuos/instituiçoes

public class Congresso
{
    //Componente componente = new Componente();

    private int nParticipantes;
    private int nAssentos = 300;
    private Componente componente;

    public Congresso(Componente componente)
    {
        this.componente = componente;
        nParticipantes = componente.getMembros();
    }

    public int getParticipantes()
    {
        return this.nParticipantes;
    }

    public int getAssentos()
    {
        return this.nAssentos;
    }

}



public class Componente
{
    // public Componente() { }

    private int participantes = 0;
    List<Componente> listaComponentes = new List<Componente>();

    public virtual void inscrever(Componente componente)
    {
        listaComponentes.Add(componente);
    }

    public virtual bool ehFolha()
    {
        return false;
    }

    public virtual int getMembros()
    {
        foreach(Componente componente in  listaComponentes) {
        if(componente.ehFolha() == true)
            {
                this.participantes++;
            }
            else // é uma instituição
            {
                // se for instituição, chama novamente getMembros
                // e verifica no getMembros da instituição
                // quantos individuos tem
                this.participantes += componente.getMembros();
            }
        }

        return this.participantes;
    }

}




public class Individuo : Componente
{
    private string nome;
    public Individuo(string nome)
    {
        this.nome = nome;
    }

    public override bool ehFolha()
    {
        return true;
    }

}




public class Instituicao : Componente
{
    private int participantes = 0;
    List<Componente> listaInstituicao = new List<Componente>();

    public override void inscrever(Componente componente)
    {
        listaInstituicao.Add(componente);
    }

    public override bool ehFolha()
    {
        return false;
    }

    public override int getMembros()
    {
        foreach(Componente componente in listaInstituicao)
        {
            if (componente.ehFolha() == true)
            {
                this.participantes++;
            }
            else // é uma instituição
            {
                // se for instituição, chama novamente getMembros
                // e verifica no getMembros da instituição
                // quantos individuos tem
                this.participantes += componente.getMembros();
            }
        }
        return this.participantes;
    }

}

public class Program() {
    public static void Main()
    { 
        
        Componente unifesp = new Componente();
        Individuo aluno1 = new Individuo("Evandro");
        Individuo aluno2 = new Individuo("Thiago");
        Individuo aluno3 = new Individuo("Lazaro");
        Instituicao grupo = new Instituicao();

        grupo.inscrever(aluno1);
        grupo.inscrever(aluno2);
        unifesp.inscrever(aluno3);
        unifesp.inscrever(grupo);


        Congresso congresso = new Congresso(unifesp);
        // tenho uma instituição com 2 alunos e um aluno inscrito no Congresso

        Console.WriteLine($"Neste congresso temos {congresso.getParticipantes()} alunos");

    }
}
