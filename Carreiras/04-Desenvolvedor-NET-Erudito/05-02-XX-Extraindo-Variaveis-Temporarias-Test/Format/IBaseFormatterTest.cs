namespace _05_02_XX_Extraindo_Variaveis_Temporarias_Test.Test.Format
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