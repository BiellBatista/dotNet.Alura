namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros_Test.Test.Format
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