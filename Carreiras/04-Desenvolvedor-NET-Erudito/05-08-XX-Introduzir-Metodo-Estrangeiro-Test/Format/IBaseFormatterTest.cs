namespace _05_08_XX_Introduzir_Metodo_Estrangeiro_Test.Test.Format
{
    public interface IBaseFormatterTest
    {
        void TestInitialize();
        void TestFormat();
        void TestUnformat();
        void ShouldDetectIfAValueIsFormattedOrNot();
        void ShouldDetectIfAValueCanBeFormattedOrNot();
    }
}