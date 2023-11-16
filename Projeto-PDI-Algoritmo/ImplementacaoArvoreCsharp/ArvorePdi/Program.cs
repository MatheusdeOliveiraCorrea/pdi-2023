using System;
using Core;

Int32 node;
AvlTree<Int32> arvore = new();

do
{
    try
    {
        node = ObterNode();

        arvore.Inserir(node);
        
        Console.WriteLine($"número {node} inserido.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        SairDaAplicacao();
    }

} while (true);

static Int32 ObterNode()
{
    Console.WriteLine("Insira um node na árvore: (int)");
    var argumento = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(argumento)) return default;

    if (!int.TryParse(argumento, out int node))
        SairDaAplicacao();

    return node;
}

static void SairDaAplicacao()
{
    Console.WriteLine("Fechando aplicação");
    Environment.Exit(0);
}