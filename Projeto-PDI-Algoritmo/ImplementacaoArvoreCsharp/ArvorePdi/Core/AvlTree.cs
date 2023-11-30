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

            switch (ObterRotacao(nodeASerBalanceado))
            {
                case AvlTree<T>.Rotacao.LL:
                    RotationLL(nodeASerBalanceado);
                    break;
                case AvlTree<T>.Rotacao.LR:
                    RotationLR(nodeASerBalanceado);
                    break;
            }
        }
    }

    private Rotacao ObterRotacao(Node<T> nodeASerBalanceado)
    {
        var existemNodesLL = nodeASerBalanceado?.Left?.Left is not null;

        if (existemNodesLL)
        {
            var segundoNodeABaixo = CalcularBF(nodeASerBalanceado.Left);
            var terceiroNodeABaixo = CalcularBF(nodeASerBalanceado.Left.Left);

            bool[] condicoesParaSerLL =
            {
                segundoNodeABaixo == 1,
                terceiroNodeABaixo == 2
            };

            if(condicoesParaSerLL.All(a => true))
                return Rotacao.LL;
        }

        var existemNodesLR = nodeASerBalanceado?.Left?.Right is not null;

        if (existemNodesLR)
        {
            var segundoNodeABaixo = CalcularBF(nodeASerBalanceado.Left);
            var terceiroNodeABaixo = CalcularBF(nodeASerBalanceado.Left.Right);

            bool[] condicoesParaSerLR =
            {
                segundoNodeABaixo == -1,
                terceiroNodeABaixo == 0
            };

            if(condicoesParaSerLR.All(a => true))
                return Rotacao.LR;
        }

        throw new NotImplementedException("aaaaaaaaaaa");
    }

    private void RotationLL(Node<T> nodeASerBalanceado)
    {
        if (nodeASerBalanceado == Root)
            Root = nodeASerBalanceado.Left;

        nodeASerBalanceado.Left.Right = new Node<T>(nodeASerBalanceado.Valor)
        {
            Left = nodeASerBalanceado.Left.Right,
            Right = nodeASerBalanceado.Right
        };
    }

    private void RotationLR(Node<T> nodeASerBalanceado)
    {
        var nodeAEsquerdaParaBalancear = new Node<T>
        {
            Left = new Node<T> 
            { 
                Left = nodeASerBalanceado.Left.Left,  //subtree
                Valor = nodeASerBalanceado.Left.Valor,
                Right = nodeASerBalanceado.Left.Right.Left //subtree
            },
            Valor = nodeASerBalanceado.Left.Right.Valor,
            Right = nodeASerBalanceado.Left.Right.Right
        };

        nodeASerBalanceado.Left = nodeAEsquerdaParaBalancear; 

        RotationLL(nodeASerBalanceado);
    }

    private Node<T> NovoNode(T valor, Node<T> leftSubTree, Node<T> rightSubTree) => new Node<T> 
    { 
        Left = leftSubTree is null ? null : new Node<T>(leftSubTree.Valor) { Left = leftSubTree.Left, Right = leftSubTree.Right },
        Valor = valor,
        Right = rightSubTree is null ? null : new Node<T>(rightSubTree.Valor) { Left = rightSubTree.Left, Right = rightSubTree.Right }
    };

    private void InserirNode(Node<T> nodeAserInserido, Node<T> nodePai)
    {
        var inserirAEsquerda = nodePai.Valor > nodeAserInserido.Valor;

        if (nodePai.Left is null && inserirAEsquerda)
        {
            nodePai.Left = nodeAserInserido;
            return;
        }

        var inserirADireita = nodePai.Valor <= nodeAserInserido.Valor;

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

    private enum Rotacao
    {
        LL,
        LR
    }
}