namespace _02_02_XX_Projetar_Interfaces.Antes
{
    class OperadoresISeAS : IAulaItem
    {
        public void Executar()
        {
            Animal animal = new Animal();
            Gato gato = new Gato();
            Cliente cliente = new Cliente("José da Silva", 30);
        }

        public void Alimentar(object obj)
        {
            Animal animal = (Animal)obj;
            animal.Beber();
            animal.Comer();
        }
    }
}
