namespace ManipulatorControl.MessageService
{
    public interface IMessageService
    {
        void ShowMessage(string message);

        UserResponse ShowError(string error);

        UserResponse ShowExclamation(string exclamation);

        UserResponse GetUserResponse(string message);
    }
}
