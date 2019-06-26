namespace ManipulatorControl.MessageService
{
    /// <summary>
    /// Предоставляет перечисление с возможными вариантами ответа пользователя.
    /// </summary>
    public enum UserResponse
    {
        /// <summary>
        /// Прекратить.
        /// </summary>
        Abort,
        /// <summary>
        /// Подтвердить.
        /// </summary>
        OK,
        /// <summary>
        /// Отменить.
        /// </summary>
        Cancel,
        /// <summary>
        /// Да.
        /// </summary>
        Yes,
        /// <summary>
        /// Нет.
        /// </summary>
        No
    }
}
