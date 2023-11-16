using System;
using System.Numerics;

namespace Core;

/*BF never greater than one */
public class AvlTree<T> : IArvoreBinaria<T> where T : struct, IComparisonOperators<T, T, bool>, IEqualityOperators<T, T, bool>
{
    public Node<T> Root { get; set; }

    public void Inserir(T valor)
    {
        var nodeAserInserido = new Node<T>
        {
            Valor = valor
        };

        if (Root is null)
        {
            Root = nodeAserInserido;
            return;
        }

        InserirNode(nodeAserInserido, Root);

        TransversalPreorder(Root,
                            (node) => 
                            { 
                               Console.WriteLine($"valor: [{node.Valor}] - BF [{CalcularBF(node)}] --- preorder"); 
                            });

        if (!IsBalanceada(Root, out Node<T> nodeASerBalanceado))
        {
            Console.WriteLine($"Node desbalanceado: {nodeASerBalanceado?.Valor}");
        }
    }

    private void InserirNode(Node<T> nodeAserInserido, Node<T> nodePai)
    {
        var inserirAEsquerda = nodePai.Valor < nodeAserInserido.Valor;

        if (nodePai.Left is null && inserirAEsquerda)
        {
            nodePai.Left = nodeAserInserido;
            return;
        }

        var inserirADireita = nodePai.Valor >= nodeAserInserido.Valor;

        if (nodePai.Right is null && inserirADireita)
        {
            nodePai.Right = nodeAserInserido;
            return;
        }

        if (inserirAEsquerda)
        {
            InserirNode(nodeAserInserido, nodePai.Left);
            return;
        }

        if (inserirADireita)
        {
            InserirNode(nodeAserInserido, nodePai.Right);
            return;
        } 
        
        throw new ArgumentException($"Valor do node invalido: [{nodeAserInserido.Valor}], provavelmente a interface IComparisonOperators foi implementada erroneamente." +
                                    $"Argumentos: [{nameof(inserirAEsquerda)}-{inserirAEsquerda}] - [{nameof(inserirADireita)}-{inserirADireita}] - [{nameof(nodePai)}-{nodePai.Valor}].");
    }

    public Node<T> Buscar()
    {
        return default;
    }

    public void Deletar(T valor)
    {
    }

    private int CalcularBF(Node<T> node) => Height(node.Right) - Height(node.Left);

    private void Balance()
    {
    }

    private bool IsBalanceada(Node<T> node, out Node<T> nodeDesbalanceado)
    {
        var balanceada = true; 
        Node<T> nodeDesbalanceadoResult = null; 

        TransversalPreorder(node, (node) => 
        { 
            if(balanceada is false) return;

            var bf = CalcularBF(node); 

            if(bf >= 2 || bf <= -2)
            {
                balanceada = false;
                nodeDesbalanceadoResult = node;
            }
        });

        nodeDesbalanceado = nodeDesbalanceadoResult;

        return balanceada;
    }

    private void TransversalPreorder(Node<T> node, Action<Node<T>> action)
    {
        if(node is null) return; 

        action(node);

        TransversalPreorder(node.Left, action);
        TransversalPreorder(node.Right, action);
    }

    private int Height(Node<T> node)
    {
        if (node is null) return HeightProperties.Unexistent;

        var leftHeight = Height(node.Left);
        var rightHeight = Height(node.Right);

        var currentNodeLength = Math.Max(leftHeight, rightHeight);

        return currentNodeLength + HeightProperties.MinimumHeight;
    }

    private struct HeightProperties
    {
        public const int MinimumHeight = 1;
        public const int Unexistent = 0;
    }
}