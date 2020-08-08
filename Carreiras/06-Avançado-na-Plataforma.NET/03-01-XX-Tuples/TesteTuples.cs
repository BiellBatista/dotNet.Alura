namespace _03_01_XX_Tuples
{
    static class TesteTuples
    {
        public static void TesteTuple()
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
    }
}
