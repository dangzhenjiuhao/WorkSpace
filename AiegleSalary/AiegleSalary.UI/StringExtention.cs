using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AiegleSalary.UI
{
    public static class StringExtention
    {
        /// <summary>
        /// 判断字符串中是否包含中文
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <returns>判断结果</returns>
        public static bool HasChinese(this string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumeric(this string value)
        {
            return QuickValidate("^[-]?[1-9]*[0-9]*$", value);
        }

        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="express">正则表达式的内容。</param>
        /// <param name="value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(string express, string value)
        {
            var myRegex = new System.Text.RegularExpressions.Regex(express);
            return value.Length != 0 && myRegex.IsMatch(value);
        }

        //-----------------------------------------------------
        public static bool IsNumeric2(this string value)
        {

            try
            {
                //当数字字符串的为是少于4时，以下三种都可以转换，任选一种
                //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse()

                //result = int.Parse(message);
                //result = Convert.ToInt16(message);
                Convert.ToInt32(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDouble(this string value)
        {

            try
            {
                //当数字字符串的为是少于4时，以下三种都可以转换，任选一种
                //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse()

                //result = int.Parse(message);
                //result = Convert.ToInt16(message);
                Convert.ToDouble(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
