using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LptStepperMotorControl.PortControl
{
    /// <summary>
    /// Предоставляет класс для управления LPT портом.
    /// </summary>
    /// <remarks>
    /// 
    /// Параллельный порт содержит: Data Ports, Status Ports, Control Ports
    /// 
    /// Для управления при помощи LPT необходимы Data Ports и Control Ports.      
    /// 
    /// Data Ports: D0 to D7. Pins: 2 - 9. Для задания нуля на всех пинах необходимо передать на порт 0.
    /// Control Ports: C0 to C4. Pins: 1,14,16,17.
    /// C0: This pin is reversed.
    /// C1: This pin is reversed.
    /// C2: 
    /// C3: This pin is reversed.
    /// Для задания нуля на всех пинах необходимо передать на порт 11 (1 1 0 1).
    /// </remarks>
    public class LPTPort
    {
        #region Data and Control ports decimal value properties

        /// <summary>
        /// Десятичное значение, которое установлено в данный момент на DataPin.
        /// </summary>
        public int DataDecimal { get; set; }

        /// <summary>
        /// Десятичное значение, которое установлено в данный момент на ControlPin.
        /// </summary>
        public int ControlDecimal { get; set; }

        #endregion

        #region Конструкторы класса.

        /// <summary>
        /// Предоставляет класс для управления LPT портом со стандартными адресами портов.
        /// </summary>
        public LPTPort() : this(888, 890)
        {
        }

        /// <summary>
        /// Предоставляет класс для управления LPT портом.
        /// </summary>
        /// <param name="dataPortNumber">Адрес информационного порта</param>
        /// <param name="controlPortNumber">Адрес управляющего порта</param>
        public LPTPort(int dataPortNumber, int controlPortNumber)
        {
            this.dataPortNumber = dataPortNumber;
            this.controlPortNumber = controlPortNumber;
            SetDefaultValue();
        }

        #endregion

        #region Установка значения в порт.

        #region Импорт функций из библиотеки. 

        int counter;

#if (DEBUG)

        private void Output(int adress, int value)
        {
         //  Debug.WriteLine($"{++counter} {adress} {value}");
        }
#else

        /// <summary>
        /// Устанавливает заданное значение <c>value</c> на LPT порт <c>address</c>.
        /// </summary>
        /// <param name="address">Адрес порта</param>
        /// <param name="value">Значние</param>
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        private static extern void Output(int address, int value);
#endif
        #endregion

        /// <summary>
        /// Устанавливает 0 на всех PIN.
        /// </summary>
        public void SetDefaultValue()
        {
            DataDecimal = 0;
            ControlDecimal = 11;

            Output(controlPortNumber, ControlDecimal);
            Output(dataPortNumber, DataDecimal);
        }

        /// <summary>
        /// Устанавливает для <c>pin</c> значение <c>state</c>.
        /// </summary>
        /// <param name="pin">Номер Pin</param>
        /// <param name="state">Состояние, которое необходимо установить. True = 1, False = 0</param>
        public void SetPin(int pin, bool state)
        {
            var port = GetPortTypeByPinNumber(pin);

            if (port == PortType.Control)
                SetControlPin(pin, state);

            else SetDataPin(pin, state);
        }

        /// <summary>
        /// Устанавливает значение на PIN порта.
        /// </summary>
        /// <param name="port">Тип порта</param>
        /// <param name="decimalValue">Десятичное представление установленных данных</param>
        /// <param name="saveOtherPinsValues">Если ложь - устанавливает на порт значение <c>decimalValue</c>, 
        /// в обратном случае сохраняет предыдущее значение, установленное на порту и добавляет к нему новое значение.</param>
        public void SetLptValue(PortType port, int decimalValue, bool saveOtherPinsValues = true)
        {
            if (port == PortType.Control)
                this.ControlDecimal = saveOtherPinsValues ? ControlDecimal + decimalValue : decimalValue;
            else
                this.DataDecimal = saveOtherPinsValues ? DataDecimal + decimalValue : decimalValue;

            Output(GetPortByType(port), port == PortType.Control ? this.ControlDecimal : this.DataDecimal);
        }

        /// <summary>
        /// Устанавливает для <c>pin</c> значение <c>state</c> для Data Ports.
        /// </summary>
        /// <param name="pin">Номер Pin</param>
        /// <param name="state">Состояние, которое необходимо установить. True = 1, False = 0</param>
        private void SetDataPin(int pin, bool state)
        {
            var decimalNumber = GetDecimalByPin(pin);

            if (IsBitSet(DataDecimal, decimalNumber) == state)
                return;

            DataDecimal += (state ? decimalNumber : -decimalNumber);

            Output(dataPortNumber, DataDecimal);
        }

        /// <summary>
        /// Устанавливает для <c>pin</c> значение <c>state</c> для Control Ports.
        /// </summary>
        /// <param name="pin">Номер Pin</param>
        /// <param name="state">Состояние, которое необходимо установить. True = 1, False = 0</param>
        private void SetControlPin(int pin, bool state)
        {
            var decimalNumber = GetDecimalByPin(pin);

            // Проверяем, установлен ли бит для числа в нормальном представлении.
            var normalValue = ControlToNormal[ControlDecimal];
            var isSet = IsBitSet(normalValue, Math.Abs(decimalNumber));

            if (((isSet && decimalNumber > 0) || (isSet && decimalNumber < 0)) == state)
                return;

            ControlDecimal += (state ? decimalNumber : -decimalNumber);

            Output(controlPortNumber, ControlDecimal);
        }

        /// <summary>
        /// Возвращает истину если число <c>number</c> содержит бит числа <c>bit</c>.
        /// </summary>
        /// <remarks>
        /// Например: 
        /// IsBitSet(126, 64) - Истина.
        /// IsBitSet(126, 1) - Ложь.
        /// </remarks>
        /// <param name="number">Число для проверки на содержание бита</param>
        /// <param name="bit">Число, бит которого содержится в <c>number</c></param>
        /// <returns>Истина если число <c>number</c> содержит бит числа <c>bit</c>.</returns>
        private bool IsBitSet(int number, int bit)
        {
            return (number & bit) != 0;
        }

        /// <summary>
        /// Содержит коллекцию, где Ключ - значение для нормальной таблицы истинности, а Значение - для таблицы истинности с инверсными x1,x2,x4.
        /// Смотреть примечания к классу.
        /// </summary>
        private static readonly Dictionary<int, int> ControlToNormal = new Dictionary<int, int>()
        {
            {11, 0}, {10,1},{9,2}, {8,3},{15, 4},{14, 5},{13,6}, {12, 7}, {3, 8}, {2, 9}, {1, 10}, {0, 11}, {7, 12}, {6, 13}, {5, 14}, {4, 15}
        };

        #endregion

        #region Получение десятичного представления.

        private static Dictionary<int, int> PINDecimalPair = new Dictionary<int, int>()
        {
            {1, -1}, {14,-2},{16,4}, {17,-8},{2, 1},{3, 2},{4, 4}, {5, 8}, {6, 16}, {7, 32}, {8, 64}, {9, 128}
        };

        /// <summary>
        /// Возвращает десятичное представление значения для заданного PIN.
        /// </summary>
        /// <param name="pin">PIN</param>
        /// <returns>Десятичное представление значения</returns>
        public static int GetDecimalByPin(int pin)
        {
            if (!IsOutputPin(pin))
                throw new Exception("Задан некорректный номер PIN");

            return PINDecimalPair[pin];
        }

        /// <summary>
        /// Проверяет является ли указанный PIN - выводом.
        /// </summary>
        /// <param name="pin">Номер PIN</param>
        /// <returns>Истина если PIN - вывод</returns>
        public static bool IsOutputPin(int pin)
        {
            return PINDecimalPair.ContainsKey(pin);
        }

        #endregion

        #region Получение типа и номера порта.

        /// <summary>
        /// Возвращает номер порта для заданного PIN. 
        /// </summary>
        /// <param name="pin">PIN</param>
        /// <returns>Номер порта</returns>
        public int GetPortByPinNumber(int pin)
        {
            return pin == 1 || pin == 14 || pin == 16 || pin == 17 ? controlPortNumber : dataPortNumber;
        }

        /// <summary>
        /// Возвращает номер порта в зависимости от типа.
        /// </summary>
        /// <param name="Type">Тип порта</param>
        /// <returns>Номер порта</returns>
        public int GetPortByType(PortType Type)
        {
            return Type == PortType.Control ? controlPortNumber : dataPortNumber;
        }

        /// <summary>
        /// Возвращает тип порта для заданного PIN. 
        /// </summary>
        /// <param name="pin">PIN</param>
        /// <returns>Тип порта</returns>
        public static PortType GetPortTypeByPinNumber(int pin)
        {
            return pin == 1 || pin == 14 || pin == 16 || pin == 17 ? PortType.Control : PortType.Data;
        }

        #endregion

        #region Поля класса.

        /// <summary>
        /// Data pins port number. Pins: 2-9.
        /// </summary>
        private readonly int dataPortNumber;

        /// <summary>
        /// Control pins port number. Pins: 1,14,16,17.
        /// </summary>
        private readonly int controlPortNumber;

        #endregion
    }
}
