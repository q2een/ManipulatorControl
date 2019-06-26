using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using UM160CalculationLib;

namespace ManipulatorControl.Controls
{
    #pragma warning disable 1591
    public partial class DesignParametersControl : UserControl
    {
        public DesignParametersControl()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private LeverDesign active;

        private LeverDesign[] designs;

        public DesignParameters DesignParameters
        {
            get
            {
                if (designs == null)
                    return null;

                 var generalItems = designs.Single(d => d.DesignType == DesignType.General).Items;

                 return new DesignParameters(GetValue(generalItems, ValueType.L1),
                                             GetValue(generalItems, ValueType.L2),
                                             GetValue(generalItems, ValueType.Lc),
                                             GetHorizontalLeverDesign(),
                                             GetLeverDesign(DesignType.Lever1),
                                             GetLeverDesign(DesignType.Lever2));   
            }
            set
            {
                if (value == null)
                    return;

                designs = new LeverDesign[4];

                designs[0] = GetLeverDesign(DesignType.Lever1, value.Lever1);
                designs[1] = GetLeverDesign(DesignType.Lever2, value.Lever2);
                designs[2] = GetLeverDesign(DesignType.HorizontalLever, value.HorizontalLever);
                designs[3] = new LeverDesign()
                {
                    DesignType = DesignType.General,
                    Items = GetGeneralItems(value).ToList()
                };

                SetControls(GetSelectedDesignTypeTab());   
            }
        }

        private LeverDesign GetLeverDesign(DesignType type, IRobotLever lever)
        {
            return new LeverDesign()
            {
                DesignType = type,
                Items = GetLeverItems(lever),
                ABZero = lever.ABzero,
                IsAbIncreases = lever.IsABIncreasesOnStepperCW
            };
        }

        private void BindData(List<Item> items)
        {
            var source = new BindingSource();

            source.DataSource = items;
            dgv.DataSource = source;

            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].ReadOnly = true;

            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void SetControls(DesignType designType)
        {  
            gbAdditional.Visible = designType != DesignType.General;

            active = designs.Single(d => d.DesignType == designType);

            BindData(active.Items);

            lblAbIncreases.Text = "При вращении ротора шагового двигателя по часовой стрелке расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта...";

            if (designType == DesignType.HorizontalLever)
                lblAbIncreases.Text = "При вращении ротора шагового двигателя по часовой стрелке расстояние перемещения каретки робота...";

            cmbAbIncreases.SelectedIndex = active.IsAbIncreases ? 0 : 1;
        }

        private IEnumerable<Item> GetGeneralItems(DesignParameters parameters)
        {
            yield return new Item(parameters.L1)
            {
                Name = "Длина плеча 1, мм.",
                Type = ValueType.L1,
                Sign = "L1"
            };

            yield return new Item(parameters.L2)
            {
                Name = "Длина плеча 2, мм.",
                Type = ValueType.L2,
                Sign = "L2"
            };

            yield return new Item(parameters.Lc)
            {
                Name = "Расстояние от центра схвата до точки его подвеса на плече 2, мм.",
                Type = ValueType.Lc,
                Sign = "Lc"
            };
        }

        private List<Item> GetLeverItems(IRobotLever lever)
        {
            if (lever is UM160CalculationLib.LeverDesignParameters)
                return GetLeverItems(lever as UM160CalculationLib.LeverDesignParameters).ToList();

            if(lever is HorizontalLeverDesignParameters)
                return GetLeverItems(lever as HorizontalLeverDesignParameters).ToList();

            throw new NotImplementedException();
        }

        private IEnumerable<Item> GetLeverItems(LeverDesignParameters lever)
        {
            yield return new Item(lever.AB)
            {
                Name = "Текущее расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм",
                Type = ValueType.AB,
                Sign = "AB"
            };

            yield return new Item(lever.AO)
            {
                Name = "Расстояние между точкой подвеса плеча и ходового винта, поворачивающего плечо, мм",
                Type = ValueType.AO,
                Sign = "AO"
            };

            yield return new Item(lever.BO)
            {
                Name = "Расстояние между точкой подвеса плеча и точкой его крепления к гайке ходового винта, мм",
                Type = ValueType.BO,
                Sign = "BO"
            };

            yield return new Item(lever.ABmin)
            {
                Name = "Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм",
                Type = ValueType.ABmin,
                Sign = "ABmin"
            };

            yield return new Item(lever.ABmax)
            {
                Name = "Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм",
                Type = ValueType.ABmax,
                Sign = "ABmax"
            };

            yield return new Item(lever.P)
            {
                Name = "Шаг ходового винта, мм",
                Type = ValueType.P,
                Sign = "p"
            };

            yield return new Item(lever.Ro)
            {
                Name = "Характеристика шагового электродвигателя, градусы",
                Type = ValueType.Ro,
                Sign = "ρ"
            };

            yield return new Item(lever.Alpha)
            {
                Name = "Конструктивные параметры плеча робота, градусы",
                Type = ValueType.Alpha,
                Sign = "α"
            };

            yield return new Item(lever.Beta)
            {
                Name = "Конструктивные параметры плеча робота, градусы",
                Type = ValueType.Beta,
                Sign = "β"
            };

            yield return new Item(lever.I)
            {
                Name = "Передаточное отношение",
                Type = ValueType.I,
                Sign = "i"
            };
        }

        private IEnumerable<Item> GetLeverItems(HorizontalLeverDesignParameters lever)
        {
            yield return new Item(lever.AB)
            {
                Name = "Текущее расстояние положения каретки робота, мм",
                Type = ValueType.AB,
                Sign = "AB"
            };   
    

            yield return new Item(lever.ABmin)
            {
                Name = "Минимальное расстояние положения каретки робота, мм",
                Type = ValueType.ABmin,
                Sign = "ABmin"
            };

            yield return new Item(lever.ABmax)
            {
                Name = "Максимальное расстояние положения каретки робота, мм",
                Type = ValueType.ABmax,
                Sign = "ABmax"
            };


            yield return new Item(lever.Coefficient)
            {
                Name = "Количество шагов шагового двигателя необходимых для изменения значения текущего положения на 1мм",
                Type = ValueType.Ro,
                Sign = "C"
            }; 
        }

        private LeverDesignParameters GetLeverDesign(DesignType designType)
        {
            var design = designs.Single(d => d.DesignType == designType);

            var lever = new UM160CalculationLib.LeverDesignParameters(GetValue(design.Items, ValueType.AO),
                                                                 GetValue(design.Items, ValueType.BO),
                                                                 GetValue(design.Items, ValueType.P),
                                                                 GetValue(design.Items, ValueType.Ro),
                                                                 GetValue(design.Items, ValueType.Alpha),
                                                                 GetValue(design.Items, ValueType.Beta),
                                                                 GetValue(design.Items, ValueType.I),
                                                                 design.IsAbIncreases,
                                                                 GetValue(design.Items, ValueType.AB),
                                                                 GetValue(design.Items, ValueType.ABmin),
                                                                 GetValue(design.Items, ValueType.ABmax));
            lever.ABzero = GetAbZero(design, lever);

            return lever;
        }

        private HorizontalLeverDesignParameters GetHorizontalLeverDesign()
        {
            var design = designs.Single(d => d.DesignType == DesignType.HorizontalLever);

            var lever = new HorizontalLeverDesignParameters(design.IsAbIncreases,
                                                       GetValue(design.Items, ValueType.Ro),
                                                       GetValue(design.Items, ValueType.AB),
                                                       GetValue(design.Items, ValueType.ABmin),
                                                       GetValue(design.Items, ValueType.ABmax));

            lever.ABzero = GetAbZero(design, lever);

            return lever;
        }

        private double? GetAbZero(LeverDesign design, IRobotLever lever)
        {
            return lever.ABmin > design.ABZero || lever.ABmax > design.ABZero ? null : design.ABZero;
        }

        private double GetValue(List<Item> items, ValueType type)
        {
            return items.Single(item => item.Type == type).Value;
        }

        private DesignType GetSelectedDesignTypeTab()
        {
            DesignType type = DesignType.HorizontalLever;

            if (tabLinks.SelectedTab == tpGeneral)
                type = DesignType.General;
            if (tabLinks.SelectedTab == tpLever1)
                type = DesignType.Lever1;
            if (tabLinks.SelectedTab == tpLever2)
                type = DesignType.Lever2;

            return type;
        }

        private void tabLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControls(GetSelectedDesignTypeTab());
        }

        private void cmbAbIncreases_SelectedIndexChanged(object sender, EventArgs e)
        {
            active.IsAbIncreases = cmbAbIncreases.SelectedIndex == 0;
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите корректное значение:\nРазрешен ввод только чисел, в том числе с плавающей запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            e.ThrowException = false;
        }

        private enum DesignType
        {
            General,
            Lever1,
            Lever2,
            HorizontalLever
        }

        private enum ValueType
        {
            AB,
            ABmax,
            ABmin,
            AO,
            BO,
            P,
            Ro,
            Alpha,
            Beta,
            I,
            L1,
            L2,
            Lc
        }

        private class Item
        {
            [DisplayName("Наименование")]
            public string Name { get; set; }

            [DisplayName("Обозначение")]   
            public string Sign { get; set; }

            [Browsable(false)]
            public ValueType Type { get; set; }

            [DisplayName("Значение")]    
            public double Value { get; set; }

            public Item(double value)
            {
                Value = value;
            }

            public Item(string name, string sign, double value)
            {
                Name = name;
                Sign = sign;
                Value = value;
            }
        }

        private class LeverDesign
        {
            public DesignType DesignType { get; set; }

            public List<Item> Items { get; set; }

            public double? ABZero { get; set; }

            public bool IsAbIncreases { get; set; }
        } 
    }
}
