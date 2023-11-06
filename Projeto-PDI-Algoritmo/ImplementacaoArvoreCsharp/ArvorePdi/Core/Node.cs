using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Core;

public class Node<T> where T : struct, IComparisonOperators<T, T, bool>, IEqualityOperators<T, T, bool>
{
    public Node<T> Left { get; set; }

    public required T Valor { get; set; }

    public Node<T> Right { get; set; }

    public Node(){}

    [SetsRequiredMembers]
    public Node(T valor) => this.Valor = valor;
}
