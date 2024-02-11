namespace ScreenSound.Modelos;
internal class Avaliacao
{
    public Avaliacao(int nota)
    {
        if (nota <= 0) nota = 0;
        if (nota >= 10) nota = 10;
        Nota = nota;
    }
    public int Nota { get; }

    public static Avaliacao Parse(string texto) //o static quer dizer que não precisamos instanciar o metodo para utiliza-lo (new Avaliacao) é só simplesmente colocarmos Avaliacao.Parse que conseguiremos utilizar a função pois a função não esta utilizando nenhuma informação da classe
    {
        int nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}
