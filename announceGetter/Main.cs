using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace announceGetter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // デスクトップ上の位置とサイズを定義
            Rectangle bounds = new Rectangle(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width-585, 0, 600, 600);
            Console.WriteLine(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width);
            // フォームのデスクトップ上の位置とサイズを設定
            this.DesktopBounds = bounds;
            //タイトルバー削除
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
