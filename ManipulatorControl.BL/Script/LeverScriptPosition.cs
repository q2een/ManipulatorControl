using System;

namespace ManipulatorControl.BL.Script
{
    /// <summary>
    /// Предоставляет класс содержащий данные об одном шаге в сценарии.
    /// </summary>
    public class LeverScriptPosition : EventArgs, IEquatable<LeverScriptPosition>
    {
        /// <summary>
        /// Возвращает тип плеча робота.
        /// </summary>
        public LeverType LeverType { get; private set; }

        /// <summary>
        /// Возвращает начальную точку плеча робота.
        /// </summary>
        public double From { get; set; }

        /// <summary>
        /// Возвращает конечную точку плеча робота.
        /// </summary>
        public double To { get; set; }

        /// <summary>
        /// Предоставляет класс содержащий данные об одном шаге в сценарии.
        /// </summary>
        /// <param name="leverType">Тип плеча робота</param>
        public LeverScriptPosition(LeverType leverType)
        {
            LeverType = leverType;
        }

        /// <summary>
        /// Возвращает экземпляр класса в котором значения поменяны местами 
        /// для выполнения сценария в обратном порядке. 
        /// </summary>
        /// <returns>Экземпляр класса в котором значения <see cref="From"/> и <seealso cref="To"/> поменяны местами</returns>
        public LeverScriptPosition GetReversed()
        {
            return new LeverScriptPosition(LeverType)
            {
                From = To,
                To = From
            };
        }

        /// <summary>
        /// Определяет, равен ли заданный объект текущему объекту.
        /// </summary>
        /// <param name="other">Объект, который требуется сравнить с текущим объектом</param>
        /// <returns>Значение true, если указанный объект равен текущему объекту; в противном случае - значение false</returns>
        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.Equals(other as LeverScriptPosition);
        }

        /// <summary>
        /// Указывает, эквивалентен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом</param>
        /// <returns>true, если текущий объект эквивалентен параметру other, в противном случае — false</returns>
        public bool Equals(LeverScriptPosition other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.LeverType == other.LeverType && this.From.Equals(other.From) && this.To.Equals(other.To);
        }

        /// <summary>
        /// Служит хэш-функцией по умолчанию
        /// </summary>
        /// <returns>Хэш-код для текущего объекта</returns>
        public override int GetHashCode()
        {
            return From.GetHashCode() ^ To.GetHashCode() ^ LeverType.GetHashCode();
        }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1} ---> {2}", LeverType.ToRuString(), From, To);
        }
    }
}
