using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET.Utilities
{
    public class ControlConfig
    {
        public Control Control { get; set; }
        public Point Location { get; set; }
        public int Order { get; set; }
    }

    public class LayoutManager
    {
        //private readonly Control _container;
        private readonly Dictionary<string, List<ControlConfig>> _layouts;
        private readonly Point _baseLocation;
        private readonly int _spacing;

        /// <summary>        
        /// 已Lbl的座標當基準, Lbl 座標 轉 Txt座標(+59,-6), 如果偵測到Txt則Base = (+59,-6)
        /// 每個Control的Y差距都是30
        /// </summary>      
        //public LayoutManager(Control container, Point baseLocation, int spacing)
        public LayoutManager(Point baseLocation, int spacing)
        {
            //_container = container;
            _baseLocation = baseLocation;
            _spacing = spacing;
            _layouts = new Dictionary<string, List<ControlConfig>>();
        }

        /// <summary>
        /// 註冊一個佈局配置
        /// controlType 目前有"Txt", "Lbl", 因Base就是Lbl, 所以只有Txt要轉換
        /// </summary>
        /// <param name="key">佈局的識別名稱</param>
        /// <param name="controls">要顯示的控制項陣列（按順序）</param>
        /// <returns>返回自己以支援鏈式調用</returns>
        public LayoutManager RegisterLayout(string key, String controlType, params Control[] controls)
        {
            Point baseLocation = new Point(_baseLocation.X, _baseLocation.Y);
            int spacing = _spacing;

            switch (controlType)
            {
                case "Txt":
                    baseLocation.X = _baseLocation.X + 59;
                    baseLocation.Y = _baseLocation.Y - 6;
                    break;
                case "Lbl":

                    break;
            }

            var configs = controls.Select((c, i) => new ControlConfig
            {
                Control = c,
                Order = i,
                Location = new Point(baseLocation.X, baseLocation.Y + (i * spacing))
            }).ToList();

            _layouts[key] = configs;
            return this;
        }

        /// <summary>
        /// 顯示指定的佈局
        /// </summary>
        /// <param name="key">佈局的識別名稱</param>
        public void ShowLayout(string key)
        {
            HideAll();

            if (_layouts.ContainsKey(key))
            {
                foreach (var config in _layouts[key])
                {
                    config.Control.Location = config.Location;
                    config.Control.Visible = true;
                    config.Control.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 決定要顯示哪些組別的控制項, key1代表輸入項組別, key2代表標示組別 
        /// </summary>
        /// <param name="key1">輸入組別</param>
        /// <param name="key2">標示組別</param>
        public void Show2Layout(string key1, string key2)
        {
            HideAll();

            if (_layouts.ContainsKey(key1) && _layouts.ContainsKey(key2))
            {
                foreach (var config in _layouts[key1])
                {
                    config.Control.Location = config.Location;
                    config.Control.Visible = true;
                    config.Control.Enabled = true;
                }

                foreach (var config in _layouts[key2])
                {
                    config.Control.Location = config.Location;
                    config.Control.Visible = true;
                    config.Control.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 隱藏所有已註冊的控制項
        /// </summary>
        public void HideAll()
        {
            var allControls = _layouts.Values
                .SelectMany(l => l.Select(c => c.Control))
                .Distinct();

            foreach (var control in allControls)
            {
                control.Visible = false;
                control.Enabled = false;
            }
        }
        public void DisableAllInput(string key1)
        {
            if (_layouts.ContainsKey(key1))
            {
                foreach (var config in _layouts[key1])
                {
                    config.Control.Enabled = false;
                }
            }
        }

        public void EnableAllInput(bool tf)
        {
            /* //LinQ方式
            var allControls = _layouts.Values
                .SelectMany(l => l.Select(c => c.Control))
                .Distinct();
            foreach (var control in allControls)
            {
                control.Enabled = true;
            }
            */
            var allcontrols = new List<Control>();
            foreach (var layout in _layouts.Values)
            {
                foreach (var config in layout)
                {
                    if (!allcontrols.Contains(config.Control))
                    {
                        allcontrols.Add(config.Control);
                        if (config.Control is TextBox txt)
                        {
                            txt.ReadOnly = !tf;
                        }
                        if (config.Control is ComboBox cmb)
                        {
                            cmb.Enabled = tf;
                        }
                    }
                }
            }
        }


        public void SetTextBoxReadonly(string[] controlName)
        {
            /*
            foreach (var layout in _layouts.Values)
            {
                foreach (var config in layout)
                {
                    if (config.Control is TextBox textBox && textBox.Name.Equals("txtEID", StringComparison.OrdinalIgnoreCase))
                    {
                        textBox.ReadOnly = true;
                    }
                }
            }
            */
            if (_layouts.ContainsKey("AddTxt"))
            {
                foreach (var config in _layouts["AddTxt"])
                {
                    foreach (var p in controlName)
                    {
                        if (config.Control is TextBox textBox && textBox.Name.Equals(p, StringComparison.OrdinalIgnoreCase))
                        {
                            textBox.ReadOnly = true;
                        }
                    }
                    
                }
            }
            
        }
    }

}
