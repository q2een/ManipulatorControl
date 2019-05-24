using System;
using System.Windows.Forms;

namespace ManipulatorControl.MessageService
{
    public class MessageBoxMessageService : IMessageService
    {
        public UserResponse GetUserResponse(string message)
        {
            throw new NotImplementedException();
        }

        public UserResponse ShowError(string error)
        {
            var mbox = MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ConvertDialogResultToUserResponse(mbox);
        }

        public UserResponse ShowExclamation(string exclamation)
        {
            var mbox = MessageBox.Show(exclamation, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return ConvertDialogResultToUserResponse(mbox);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private UserResponse ConvertDialogResultToUserResponse(DialogResult dialogResult)
        {
            switch(dialogResult)
            {
                case DialogResult.OK:
                    return UserResponse.OK;
                case DialogResult.Cancel:
                    return UserResponse.Cancel;
                case DialogResult.Yes:
                    return UserResponse.Yes;
                case DialogResult.No:
                    return UserResponse.No;
                case DialogResult.Abort:
                    return UserResponse.Abort;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
