namespace _04_XX_xUnit_Moq.Services.Handlers
{
    public class CommandResult
    {
        public bool IsSuccess { get; }

        public CommandResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
