using System.Numerics;

namespace Core;
public interface IArvoreBinaria<T> where T : struct, IComparisonOperators<T, T, bool>, IEqualityOperators<T, T, bool>
{
    void Inserir(T valor);

    void Deletar(T valor);

    Node<T> Buscar();
}
