namespace PruebasArbolBus
{
    [TestClass]
    public class ArbolBinarioBusquedaTests
    {
        [TestMethod]
        public void ArbolBinarioBusqueda_Constructor_RaizNula()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Assert
            Assert.IsNull(arbol.raiz);
        }

        [TestMethod]
        public void Insertar_UnNodo_RaizNoNula()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            arbol.Insertar(5);

            // Assert
            Assert.IsNotNull(arbol.raiz);
            Assert.AreEqual(5, arbol.raiz.valor);
            Assert.IsNull(arbol.raiz.izquierda);
            Assert.IsNull(arbol.raiz.derecha);
        }

        [TestMethod]
        public void Insertar_MultiplesNodos_OrdenCorrecto()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);
            arbol.Insertar(2);
            arbol.Insertar(4);
            arbol.Insertar(6);
            arbol.Insertar(8);

            // Assert
            Assert.AreEqual(5, arbol.raiz.valor);

            Assert.AreEqual(3, arbol.raiz.izquierda.valor);
            Assert.AreEqual(7, arbol.raiz.derecha.valor);

            Assert.AreEqual(2, arbol.raiz.izquierda.izquierda.valor);
            Assert.AreEqual(4, arbol.raiz.izquierda.derecha.valor);

            Assert.AreEqual(6, arbol.raiz.derecha.izquierda.valor);
            Assert.AreEqual(8, arbol.raiz.derecha.derecha.valor);
        }

        [TestMethod]
        public void Insertar_ValorDuplicado_NoInserta()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);

            // Act
            arbol.Insertar(5);

            // Assert
            Assert.AreEqual(5, arbol.raiz.valor);
            Assert.IsNull(arbol.raiz.izquierda);
            Assert.IsNull(arbol.raiz.derecha);
        }

        [TestMethod]
        public void Buscar_ValorExistente_DevuelveTrue()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);

            // Act
            bool encontrado = arbol.Buscar(3);

            // Assert
            Assert.IsTrue(encontrado);
        }

        [TestMethod]
        public void Buscar_ValorNoExistente_DevuelveFalse()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);

            // Act
            bool encontrado = arbol.Buscar(10);

            // Assert
            Assert.IsFalse(encontrado);
        }

        [TestMethod]
        public void Buscar_ArbolVacio_DevuelveFalse()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            bool encontrado = arbol.Buscar(5);

            // Assert
            Assert.IsFalse(encontrado);
        }

        [TestMethod]
        public void Eliminar_Hoja_EliminaCorrectamente()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);
            arbol.Insertar(2);
            arbol.Insertar(4);
            arbol.Insertar(6);
            arbol.Insertar(8);

            // Act
            arbol.eliminar(2);

            // Assert
            Assert.AreEqual(5, arbol.raiz.valor);
            Assert.AreEqual(3, arbol.raiz.izquierda.valor);
            Assert.IsNull(arbol.raiz.izquierda.izquierda);
            Assert.AreEqual(4, arbol.raiz.izquierda.derecha.valor);
            Assert.AreEqual(7, arbol.raiz.derecha.valor);
            Assert.AreEqual(6, arbol.raiz.derecha.izquierda.valor);
            Assert.AreEqual(8, arbol.raiz.derecha.derecha.valor);
        }

        [TestMethod]
        public void Eliminar_NodoConUnHijoIzquierdo_EliminaCorrectamente()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(2);

            // Act
            arbol.eliminar(3);

            // Assert
            Assert.AreEqual(5, arbol.raiz.valor);
            Assert.AreEqual(2, arbol.raiz.izquierda.valor);
            Assert.IsNull(arbol.raiz.izquierda.izquierda);
            Assert.IsNull(arbol.raiz.izquierda.derecha);
            Assert.IsNull(arbol.raiz.derecha);
        }

        [TestMethod]
        public void Eliminar_NodoConUnHijoDerecho_EliminaCorrectamente()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(3);
            arbol.Insertar(5);
            arbol.Insertar(7);

            // Act
            arbol.eliminar(5);

            // Assert
            Assert.AreEqual(3, arbol.raiz.valor);
            Assert.IsNull(arbol.raiz.izquierda);
            Assert.AreEqual(7, arbol.raiz.derecha.valor);
            Assert.IsNull(arbol.raiz.derecha.izquierda);
            Assert.IsNull(arbol.raiz.derecha.derecha);
        }

        [TestMethod]
        public void Eliminar_NodoConDosHijos_EliminaCorrectamente()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);
            arbol.Insertar(6);
            arbol.Insertar(8);

            // Act
            arbol.eliminar(7);

            // Assert
            Assert.AreEqual(5, arbol.raiz.valor);
            Assert.AreEqual(3, arbol.raiz.izquierda.valor);
            Assert.AreEqual(8, arbol.raiz.derecha.valor);
            Assert.AreEqual(6, arbol.raiz.derecha.izquierda.valor);
            Assert.IsNull(arbol.raiz.derecha.derecha);
        }

        [TestMethod]
        public void Eliminar_RaizConDosHijos_EliminaCorrectamente()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);
            arbol.Insertar(6);
            arbol.Insertar(8);

            // Act
            arbol.eliminar(5);

            // Assert
            Assert.AreEqual(6, arbol.raiz.valor);
            Assert.AreEqual(3, arbol.raiz.izquierda.valor);
            Assert.AreEqual(7, arbol.raiz.derecha.valor);
            Assert.IsNull(arbol.raiz.derecha.izquierda);
            Assert.AreEqual(8, arbol.raiz.derecha.derecha.valor);
        }

        [TestMethod]
        public void Eliminar_ValorNoExistente_NoModificaArbol()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);

            // Act
            arbol.eliminar(10);

            // Assert
            Assert.AreEqual(5, arbol.raiz.valor);
            Assert.AreEqual(3, arbol.raiz.izquierda.valor);
            Assert.AreEqual(7, arbol.raiz.derecha.valor);
        }

        [TestMethod]
        public void Eliminar_ArbolVacio_NoHaceNada()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            arbol.eliminar(5);

            // Assert
            Assert.IsNull(arbol.raiz);
        }

        [TestMethod]
        public void InOrden_ArbolNoVacio_ImprimeOrdenCorrecto()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);
            arbol.Insertar(2);
            arbol.Insertar(4);
            arbol.Insertar(6);
            arbol.Insertar(8);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                arbol.InOrden();
                string expectedOutput = "2 3 4 5 6 7 8 ";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // Restablecer la salida estándar
        }

        [TestMethod]
        public void InOrden_ArbolVacio_NoImprimeNada()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                arbol.InOrden();
                string expectedOutput = "";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // Restablecer la salida estándar
        }

        [TestMethod]
        public void PreOrden_ArbolNoVacio_ImprimeOrdenCorrecto()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);
            arbol.Insertar(2);
            arbol.Insertar(4);
            arbol.Insertar(6);
            arbol.Insertar(8);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                arbol.PreOrden();
                string expectedOutput = "5 3 2 4 7 6 8 ";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // Restablecer la salida estándar
        }

        [TestMethod]
        public void PreOrden_ArbolVacio_NoImprimeNada()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                arbol.PreOrden();
                string expectedOutput = "";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // Restablecer la salida estándar
        }

        [TestMethod]
        public void PostOrden_ArbolNoVacio_ImprimeOrdenCorrecto()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(5);
            arbol.Insertar(3);
            arbol.Insertar(7);
            arbol.Insertar(2);
            arbol.Insertar(4);
            arbol.Insertar(6);
            arbol.Insertar(8);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                arbol.PostOrden();
                string expectedOutput = "2 4 3 6 8 7 5 ";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // Restablecer la salida estándar
        }

        [TestMethod]
        public void PostOrden_ArbolVacio_NoImprimeNada()
        {
            // Arrange
            var arbol = new ArbolBinarioBusqueda();

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                arbol.PostOrden();
                string expectedOutput = "";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // Restablecer la salida estándar
        }
    }
}
