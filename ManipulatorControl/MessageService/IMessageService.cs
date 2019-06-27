namespace ManipulatorControl.MessageService
{
    /// <summary>
    /// Предоставляет интерфейс, описывающий взаимодействие представления с пользователем.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Отображает сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowMessage(string message);

        /// <summary>
        /// Отображает ошибку.
        /// </summary>
        /// <param name="error">Текст ошибки</param>
        /// <returns>Ответ пользователя</returns>
        UserResponse ShowError(string error);

        /// <summary>
        /// Отображает предупреждение. 
        /// </summary>
        /// <param name="exclamation">Текст предупреждения</param>
        /// <returns>Ответ пользователя</returns>
        UserResponse ShowExclamation(string exclamation);

        /// <summary>
        /// Отображает запрос к пользователю.
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <returns>Ответ пользователя</returns>
        UserResponse GetUserResponse(string message);
    }
}
