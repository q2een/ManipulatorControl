using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ManipulatorControl
{
    public partial class LeverDesignParameters : UserControl
    {
        public UM160CalculationLib.LeverDesignParameters DesignParameters
        {
            get
            {
                return new UM160CalculationLib.LeverDesignParameters(AO, BO, P, Ro, Alpha, Beta, I,IsABIncreasesOnStepperCW,AB, ABmin, ABmax, ABZero);
            }
            set
            {
                if (value == null)
                    return;

                AO = Convert.ToInt32(value.AO);
                BO = Convert.ToInt32(value.BO);
                AB = Convert.ToInt32(value.AB);
                ABmin = Convert.ToInt32(value.ABmin);
                ABmax = Convert.ToInt32(value.ABmax);
                ABZero = value.ABzero;
                P = Convert.ToInt32(value.P);
                Ro = value.Ro;
                Alpha = value.Alpha;
                Beta = value.Beta;
                I = value.I;
                IsABIncreasesOnStepperCW = value.IsABIncreasesOnStepperCW;
            }
        }

        /// <summary>
        /// Возвращает расстояние между точкой подвеса плеча и ходового винта, поворачивающего плечо, мм.
        /// </summary>
        [Browsable(false)]
        public int AO
        {
            get
            {
                return int.Parse(tbAO.Text);
            }
            set
            {
                tbAO.Text = value.ToString();
            }
        }

        /// <summary>
        /// Возвращает расстояние между точкой подвеса плеча и точкой его крепления к гайке ходового винта, мм.
        /// </summary>
        [Browsable(false)]
        public int BO
        {
            get
            {
                return int.Parse(tbBO.Text);
            }
            set
            {
                tbBO.Text = value.ToString();
            }
        }

        /// <summary>
        /// Возвращает шаг ходового винта, мм.
        /// </summary>
        [Browsable(false)]
        public int P
        {
            get
            {
                return int.Parse(tbP.Text);
            }
            set
            {
                tbP.Text = value.ToString();
            }
        }

        /// <summary>
        /// Возвращает характеристику шагового электродвигателя.
        /// </summary>
        [Browsable(false)]
        public double Ro
        {
            get
            {
                double ro = double.NaN;
                double.TryParse(tbRo.Text, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out ro);
                return ro;
            }
            set
            {
                tbRo.Text = value == float.NaN ? "" : value.ToString().Replace(',', '.');
            }
        }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, градусы.
        /// </summary>
        [Browsable(false)]
        public double Alpha
        {
            get
            {
                double alpha = double.NaN;
                double.TryParse(tbAlpha.Text, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out alpha);
                return alpha;
            }
            set
            {
                tbAlpha.Text = value == double.NaN ? "" : value.ToString().Replace(',', '.');
            }
        }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, грудусы.
        /// </summary>
        [Browsable(false)]
        public double Beta
        {
            get
            {
                double beta = double.NaN;
                double.TryParse(tbBeta.Text, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out beta);
                return beta;
            }
            set
            {
                tbBeta.Text = value == double.NaN ? "" : value.ToString().Replace(',','.');
            }
        }

        /// <summary>
        /// Возвращает передаточное отношение.
        /// </summary>
        [Browsable(false)]
        public double I
        {
            get
            {
                double i = double.NaN;
                double.TryParse(tbI.Text, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out i);
                return i;
            }
            set
            {
                tbI.Text = value == double.NaN ? "" : value.ToString().Replace(',', '.');
            }
        }


        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        [Browsable(false)]
        public int AB
        {
            get
            {
                return int.Parse(tbAB.Text);
            }
            set
            {
                tbAB.Text = value.ToString();
            }
        }

        /// <summary>
        /// Возвращает максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        [Browsable(false)]
        public int ABmax
        {
            get
            {
                return int.Parse(tbABmax.Text);
            }
            set
            {
                tbABmax.Text = value.ToString();
            }
        }

        /// <summary>
        /// Возвращает минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        [Browsable(false)]
        public int ABmin
        {
            get
            {
                return int.Parse(tbABmin.Text);
            }
            set
            {
                tbABmin.Text = value.ToString();
            }
        }

        [Browsable(false)]
        public double? ABZero { get; set; }

        [Browsable(false)]
        public bool IsABIncreasesOnStepperCW
        {
            get
            {
                return cmbIncreases.SelectedIndex == 0;
            }
            set
            {
                cmbIncreases.SelectedIndex = value ? 0 : 1;
            }
        }

        public LeverDesignParameters()
        {
            InitializeComponent();
        }

        private void KeyValidatingDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void KeyValidating_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
