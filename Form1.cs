using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VSSearchHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConvertToSearchRegex(textBox1.Text);
        }

        /// <summary>
        /// 將程式碼字串轉換為可以用來在 Visual Studio 中搜尋的規則運算式字串
        /// </summary>
        /// <param name="codeLine">輸入的程式碼字串</param>
        /// <returns>用於搜尋的規則運算式字串</returns>
        public string ConvertToSearchRegex(string codeLine)
        {
            // 將特殊字符轉義，例如 .、$、[、] 等
            string escapedLine = Regex.Escape(codeLine);

            // 處理空格、Tab和換行，以及C#特有的特殊字符
            string regexPattern = escapedLine.Replace("\\ ", "\\s*")
                                             .Replace("\\[", "\\s*\\[\\s*")
                                             .Replace("\\]", "\\s*\\]\\s*")
                                             .Replace("\\=", "\\s*\\=\\s*")
                                             .Replace("\"", "\\s*\"\\s*")
                                             .Replace("\\(", "\\s*\\(\\s*")
                                             .Replace("\\)", "\\s*\\)\\s*")
                                             .Replace("\\{", "\\s*\\{\\s*")
                                             .Replace("\\}", "\\s*\\}\\s*")
                                             .Replace("\\+", "\\s*\\+\\s*")
                                             .Replace("\\-", "\\s*\\-\\s*")
                                             .Replace("\\*", "\\s*\\*\\s*")
                                             .Replace("\\/", "\\s*\\/\\s*");

            return regexPattern.Replace("\\s*\\s*\\s*", "\\s*").Replace("\\s*\\s*", "\\s*");
        }
    }
}