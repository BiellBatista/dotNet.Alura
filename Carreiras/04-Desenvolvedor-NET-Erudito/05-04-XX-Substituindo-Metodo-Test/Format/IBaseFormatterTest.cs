namespace _05_04_XX_Substituindo_Metodo_Test.Test.Format
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