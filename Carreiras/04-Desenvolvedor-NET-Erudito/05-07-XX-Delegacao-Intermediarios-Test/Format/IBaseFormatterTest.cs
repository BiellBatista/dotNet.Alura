namespace _05_07_XX_Delegacao_Intermediarios_Test.Test.Format
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