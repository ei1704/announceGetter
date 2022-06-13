using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;

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
            //タイトルバーを削除
            this.FormBorderStyle = FormBorderStyle.None;

            //リンクからHTMLを取得
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string htmlStr = wc.DownloadString("https://sites.google.com/view/trident-hashimoto/");
            if (htmlStr != null)
            {
                Console.WriteLine(htmlStr);
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(htmlStr);

                //divタグの情報が入った物のみ抽出
                HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='tyJCtd mGzaTb baZpAe']");
                
                //リンク集等の最下位二つを削除
                nodes.RemoveAt(nodes.Count - 1);
                nodes.RemoveAt(nodes.Count - 1);
                foreach (HtmlNode node in nodes)
                {
                    Console.WriteLine("content:"+node.InnerText);
                    //label1.Text += node.InnerText + "\n";
                    listView1.Items.Add(node.InnerText+"\n");
                }


            }
        }
    }
}
