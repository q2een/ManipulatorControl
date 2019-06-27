using System;
using System.Windows.Forms;

namespace ManipulatorControl.MessageService
{
    /// <summary>
    /// Предоставляет класс, описывающий взаимодействие с пользователем в виде окна сообщения Windows.
    /// </summary>
    public class MessageBoxMessageService : IMessageService
    {
        /// <summary>
        /// Отображает окно - запрос к пользователю.
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <returns>Ответ пользователя</returns>
        public UserResponse GetUserResponse(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Отображает окно с уведомлением об ошибке.
        /// </summary>
        /// <param name="error">Текст ошибки</param>
        /// <returns>Ответ пользователя</returns>
        public UserResponse ShowError(string error)
        {
            var mbox = MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ConvertDialogResultToUserResponse(mbox);
        }

        /// <summary>
        /// Отображает окно с предупреждение. 
        /// </summary>
        /// <param name="exclamation">Текст предупреждения</param>
        /// <returns>Ответ пользователя</returns>
        public UserResponse ShowExclamation(string exclamation)
        {
            var mbox = MessageBox.Show(exclamation, "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            return ConvertDialogResultToUserResponse(mbox);
        }

        /// <summary>
        /// Отображает окно с сообщением.
        /// </summary>
        /// <param name="message">Текст сообщения</param>
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
