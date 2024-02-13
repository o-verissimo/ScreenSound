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
                var client = new OpenAIAPI("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");
                var chat = client.Chat.CreateConversation();
                chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 paragrafo. Adote um estilo informal.");
                string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
                banda.Resumo = resposta;
                Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
                Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
                Console.ReadKey();
                Console.Clear();
        }
        }
}
