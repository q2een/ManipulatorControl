using System;
using System.Collections.Generic;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс содержащий данные о положении плеча робота-манипулятора.
    /// </summary>
    public class LeverPosition : EventArgs, IEquatable<LeverPosition>, IEqualityComparer<LeverPosition>
    {
        /// <summary>
        /// Возвращает тип плеча робота.
        /// </summary>
        public LeverType LeverType { get; private set; }

        /// <summary>
        /// Возвращает или задает положение плеча робота.
        /// </summary>
        public double Position{ get; set; }

        /// <summary>
        /// Предоставляет класс содержащий данные о положении плеча робота-манипулятора.
        /// </summary>
        /// <param name="leverType">Тип плеча робота</param>
        /// <param name="position">Положение плеча робота.</param>
        public LeverPosition(LeverType leverType, double position)
        {
            LeverType = leverType;
            Position = position;
        }

        /// <summary>
        /// Определяет, равен ли заданный объект текущему объекту.
        /// </summary>
        /// <param name="other">Объект, который требуется сравнить с текущим объектом</param>
        /// <returns>Значение true, если указанный объект равен текущему объекту; в противном случае — значение false</returns>
        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.Equals(other as LeverPosition);
        }

        /// <summary>
        /// Указывает, эквивалентен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом</param>
        /// <returns>true, если текущий объект эквивалентен параметру other, в противном случае — false</returns>
        public bool Equals(LeverPosition other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.LeverType == other.LeverType && Math.Round(this.Position, 0).Equals(Math.Round(other.Position, 0));
        }

        /// <summary>
        /// Служит хэш-функцией по умолчанию.
        /// </summary>
        /// <returns>Хэш-код указанного объекта</returns>
        public override int GetHashCode()
        {
            return Position.GetHashCode() ^ LeverType.GetHashCode();
        }

        /// <summary>
        /// Определяет, равны ли два указанных объекта.
        /// </summary>
        /// <param name="x">Первый объект для сравнения</param>
        /// <param name="y">Второй объект для сравнения</param>
        /// <returns>true, если указанные объекты равны; в противном случае — false</returns>
        public bool Equals(LeverPosition x, LeverPosition y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Возвращает хэш-код указанного объекта <paramref name="obj"/>/
        /// </summary>
        /// <returns>Хэш-код указанного объекта</returns>
        public int GetHashCode(LeverPosition obj)
        {
            return obj.GetHashCode();
        }
    }
}
