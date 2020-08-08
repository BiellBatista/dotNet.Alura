namespace _03_01_XX_Tuples
{
    static class TesteTuples
    {
        public static void TestaIgualdade()
        {
            var origem = ("Avenida Paulista", "900", "São Paulo");
            var destino = ("Avenida Paulista", "300", "São Paulo");

            //var mesmoLugar = 
            //    origem.Item1 == destino.Item2 &&
            //    origem.Item2 == destino.Item2 &&
            //    origem.Item3 == destino.Item3;

            //isso foi adicionado no C# 7.3, é equivalente ao de cima
            var mesmoLugar = origem == destino;

            System.Console.WriteLine(mesmoLugar);
        }

        public static void TestaIgualdade2()
        {
            var origem = (
                rua: "Avenida Paulista",
                numero: "900",
                cidade: "São Paulo"
                );

            var destino = (
                numero: "900",
                rua: "Avenida Paulista",
                cidade: "São Paulo"
                );

            /**
             * Isso será falso, porque o C# não levará em consideração os nomes (rua, numero, cidade) dos itens. Por baixo dos pano ele irá comparar
             * x.Item1 == y.Item1 (onde o x.item1 é a rua e o y.item1 é o numero)
             * Devo tomar cuidado ao utilizar esse acuca sintatico
             */
            var mesmoLugar = origem == destino;

            System.Console.WriteLine(mesmoLugar);
        }
    }
}
