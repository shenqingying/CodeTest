using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sonluk.MES.MES.publics
{
    public class Judge
    {
        //判断textbox是否是日期
        public   bool IsDate(string strDate)
        {
            try
            {
                DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //判断textbox是否输入的是数字
        public void isNum(TextBox textbox, KeyPressEventArgs e)
        {
            //数字0~9所对应的keychar为48~57，小数点是46，Backspace是8
            e.Handled = true;
            //输入0-9和Backspace del 有效
            if ((e.KeyChar >= 47 && e.KeyChar <= 58) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == 46)                       //小数点      
            {
                if (textbox.Text.Length <= 0)
                    e.Handled = true;           //小数点不能在第一位      
                else
                {
                    float f;
                    if (float.TryParse(textbox.Text + e.KeyChar.ToString(), out f))
                    {
                        e.Handled = false;
                    }
                }
            }
        }
        public void MaxLength(TextBox tx, int length)
        {
           
            if (tx.Text.Length > length)
            {
                MessageBox.Show("输入长度不能大于" + length.ToString(), "消息框");
            }
           
        }
        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public  bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }
        public bool IsNo(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            return Regex.IsMatch(s, "^([0-9]{1,}[.][0-9]*)$");
        }
        public bool IsNo_3(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return Regex.IsMatch(s, "^([1-9]\\d*|0)(\\.\\d{1,3})?$");
        }
    }
}
