using System;

namespace UM160CalculationLib
{
    public interface IPartMovable: IWorkspace, ICloneable
    {
        ///// <summary>
        ///// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        ///// </summary>
        double AB { get; set; }
    }
}
