using System;

namespace ManipulatorControl.BL.Workspace
{
    /// <summary>
    /// Предоставляет класс, содержащий данные событий, связанных с рабочей зоной плеча.
    /// </summary>
    public class WorkspaceEventArgs: EventArgs
    {
        /// <summary>
        /// Возвращает или задает индекс рабочей зоны.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Возвращает или задает наименование рабочей зоны.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Предоставляет класс, содержащий данные событий, связанных с рабочей зоной плеча.
        /// </summary>
        public WorkspaceEventArgs()
        {

        }

        /// <summary>
        /// Предоставляет класс, содержащий данные событий, связанных с рабочей зоной плеча.
        /// </summary>
        /// <param name="name">Наименование рабочей зоны</param>
        public WorkspaceEventArgs(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Предоставляет класс, содержащий данные событий, связанных с рабочей зоной плеча.
        /// </summary>
        /// <param name="index">Индекс рабочей зоны</param>
        public WorkspaceEventArgs(int index)
        {
            Index = index;            
        }

        /// <summary>
        /// Предоставляет класс, содержащий данные событий, связанных с рабочей зоной плеча.
        /// </summary>
        /// <param name="name">Наименование рабочей зоны</param>
        /// <param name="index">Индекс рабочей зоны</param>
        public WorkspaceEventArgs(string name, int index):this(name)
        {
            Index = index;
        }
    }
}
