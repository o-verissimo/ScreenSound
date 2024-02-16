using OpenAI_API;
using ScreenSound.Modelos;
namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.WriteLine("Esta Banda já foi registrada");
                Thread.Sleep(4000);
                Console.Clear();
            }
            else
            {
                Banda banda = new Banda(nomeDaBanda);
                bandasRegistradas.Add(nomeDaBanda, banda);
                banda.Resumo = ResumoDaBandaPeloChatGPT.ResumoDaBanda(nomeDaBanda);
                Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
                Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
                Console.ReadKey();
                Console.Clear();
        }
        }
}
