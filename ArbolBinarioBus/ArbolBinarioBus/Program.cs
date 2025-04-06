public class ArbolBinarioBusquedaNode
{
    public int valor;
    public ArbolBinarioBusquedaNode izquierda, derecha;
    public ArbolBinarioBusquedaNode(int valor)
    {
        this.valor = valor;
        izquierda = derecha = null;

    }

}
public class ArbolBinarioBusqueda
{
    public ArbolBinarioBusquedaNode raiz;
    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }
    private ArbolBinarioBusquedaNode InsertarRec(ArbolBinarioBusquedaNode raiz, int valor)
    {
        if (raiz == null)
        {
            raiz = new ArbolBinarioBusquedaNode(valor);
            return raiz;
        }
        if (valor < raiz.valor)
            raiz.izquierda = InsertarRec(raiz.izquierda, valor);
        else if (valor > raiz.valor)
            raiz.derecha = InsertarRec(raiz.derecha, valor);
        return raiz;
    }
    public Boolean Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }
    private Boolean BuscarRec(ArbolBinarioBusquedaNode raiz, int valor)
    {
        if (raiz == null)
            return false;
        if (raiz.valor == valor)
            return true;
        else if (valor < raiz.valor)
            return BuscarRec(raiz.izquierda, valor);
        else
        {
            return BuscarRec(raiz.derecha, valor);
        }
    }
    public void eliminar(int valor)
    {
        raiz = eliminarRec(raiz, valor);
    }
    private ArbolBinarioBusquedaNode eliminarRec(ArbolBinarioBusquedaNode raiz, int valor)
    {
        if (raiz == null)
            return raiz;
        if (valor < raiz.valor)
            raiz.izquierda = eliminarRec(raiz.izquierda, valor);
        else if (valor > raiz.valor)
            raiz.derecha = eliminarRec(raiz.derecha, valor);
        else
        {
            if (raiz.izquierda == null)
                return raiz.derecha;
            else if (raiz.derecha == null)
                return raiz.izquierda;
            raiz.valor = MinValor(raiz.derecha);
            raiz.derecha = eliminarRec(raiz.derecha, raiz.valor);
        }
        return raiz;
    }
    private int MinValor(ArbolBinarioBusquedaNode raiz)
    {
        int minValor = raiz.valor;
        while (raiz.izquierda != null)
        {
            minValor = raiz.izquierda.valor;
            raiz = raiz.izquierda;
        }
        return minValor;
    }
    public void InOrden()
    {
        InOrdenRec(raiz);
    }
    private void InOrdenRec(ArbolBinarioBusquedaNode raiz)
    {
        if (raiz != null)
        {
            InOrdenRec(raiz.izquierda);
            Console.Write(raiz.valor + " ");
            InOrdenRec(raiz.derecha);
        }
    }
    public void PreOrden()
    {
        PreOrdenRec(raiz);
    }
    private void PreOrdenRec(ArbolBinarioBusquedaNode raiz)
    {
        if (raiz != null)
        {
            Console.Write(raiz.valor + " ");
            PreOrdenRec(raiz.izquierda);
            PreOrdenRec(raiz.derecha);
        }
    }
    public void PostOrden()
    {
        PostOrdenRec(raiz);
    }
    private void PostOrdenRec(ArbolBinarioBusquedaNode raiz)
    {
        if (raiz != null)
        {
            PostOrdenRec(raiz.izquierda);
            PostOrdenRec(raiz.derecha);
            Console.Write(raiz.valor + " ");
        }
    }

}

public class Program
{
    public static void Main(string[] args)
    {

    }
}