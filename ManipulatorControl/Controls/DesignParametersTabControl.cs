using System;
using System.ComponentModel;
using System.Windows.Forms;
using UM160CalculationLib;

namespace ManipulatorControl
{
    public partial class DesignParametersTabControl : UserControl
    {
        public DesignParametersTabControl()
        {
            InitializeComponent();
            IsABIncreasesOnStepperCW = false;
        }

        [Browsable(false)]
        public int L1
        {
            get
            {
                return int.Parse(tbL1.Text);
            }
            set
            {
                tbL1.Text = value.ToString();
            }
        }

        [Browsable(false)]
        public int L2
        {
            get
            {
                return int.Parse(tbL2.Text);
            }
            set
            {
                tbL2.Text = value.ToString();
            }
        }

        [Browsable(false)]
        public int Lc
        {
            get
            {
                return int.Parse(tbLC.Text);
            }
            set
            {
                tbLC.Text = value.ToString();
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

        public HorizontalLeverDesignParameters HorizontalLever
        {
            get
            {
                return new UM160CalculationLib.HorizontalLeverDesignParameters(IsABIncreasesOnStepperCW, Ro, AB, ABmin, ABmax, ABZero);
            }
            set
            {
                if (value == null)
                    return;

                AB = Convert.ToInt32(value.AB);
                ABmin = Convert.ToInt32(value.ABmin);
                ABmax = Convert.ToInt32(value.ABmax);
                ABZero = value.ABzero;
                Ro = value.Coefficient;
                IsABIncreasesOnStepperCW = value.IsABIncreasesOnStepperCW;
            }
        }

        public UM160CalculationLib.LeverDesignParameters Lever1
        {
            get
            {
                return designLever1.DesignParameters;
            }
            set
            {
                designLever1.DesignParameters = value;
            }
        }

        public UM160CalculationLib.LeverDesignParameters Lever2
        {
            get
            {
                return designLever2.DesignParameters;
            }
            set
            {
                designLever2.DesignParameters = value;
            }
        }

        public DesignParameters DesignParameters
        {
            get
            {
                return new DesignParameters(L1, L2, Lc, HorizontalLever, Lever1, Lever2);
            }
            set
            {
                L1 = Convert.ToInt32(value.L1);
                L2 = Convert.ToInt32(value.L2);
                Lc = Convert.ToInt32(value.Lc);
                Lever1 = value.Lever1;
                Lever2 = value.Lever2;
                HorizontalLever = value.HorizontalLever;
            }
        }

        private void DigitsOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
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
    }
}
