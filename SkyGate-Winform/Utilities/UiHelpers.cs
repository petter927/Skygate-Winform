using System;
using System.Windows.Forms;

namespace SkyGate_ADONET.Utilities
{
    public static class UiHelpers
    {
        /// <summary>
        /// 安全地設定 ComboBox 的 SelectedIndex：
        /// - combo 為 null 則不動。
        /// - 有項目時設定為 0（選第一項）。
        /// - 無項目時設定為 -1（不選取任何項目）。
        /// </summary>
        public static void SetComboDefault(ComboBox combo)
        {
            if (combo == null) return;

            try
            {
                if (combo.Items != null && combo.Items.Count > 0)
                {
                    combo.SelectedIndex = 0;
                }
                else
                {
                    combo.SelectedIndex = -1;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                combo.SelectedIndex = -1;
            }
            catch
            {
                // 忽略其他例外以避免影響 UI 流程
            }
        }
    }
}