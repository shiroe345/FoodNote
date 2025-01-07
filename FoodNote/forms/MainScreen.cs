using System;
using System.ClientModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using OpenAI.Chat;
using System.Net.Http;
using System.Text.Json;
using System.Data.SqlClient;
using SautinSoft;
using System.IO;
using Final_Project.src;
using Final_Project.forms;
using static System.Net.Mime.MediaTypeNames;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Final_Project
{
	public partial class MainScreen : MaterialForm
	{
		private LoginPage parentForm;
		private readonly MaterialSkinManager materialSkinManager;
		public string username;
		public const int maxLength = 18;

		private List<GMapOverlay> mapLayers;
        private List<GMapControl> maps;

        public MainScreen(LoginPage login)
		{
			this.StartPosition = FormStartPosition.CenterScreen;
			parentForm = login;
			this.username = parentForm.username;

			materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);

			InitializeComponent();

			tabControl1.Visible = false;
			checkBoxHide();

			GMapProvider.Language = LanguageType.ChineseTraditional;
			mapLayers = new List<GMapOverlay>() {
				new GMapOverlay(),
				new GMapOverlay(),
				new GMapOverlay(),
				new GMapOverlay(),
				new GMapOverlay(),
				new GMapOverlay(),
			};
            maps = new List<GMapControl>(){ gMapControl1, gMapControl2, gMapControl3, gMapControl4, gMapControl5, gMapControl6 };
            for (int i=0;i<6;++i) {
				initMap(maps[i], mapLayers[i]);
			}
		}

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
			for(int i = 0; i < 6; ++i)
			{
				maps[i].Overlays.Remove(mapLayers[i]);
				mapLayers[i].Dispose();
				maps[i].Dispose();
			}
        }

        public void checkBoxHide()
		{
			checkBox4.Visible = false;
			checkBox4.Checked = false;
			checkBox3.Visible = false;
			checkBox3.Checked = false;
			checkBox2.Visible = false;
			checkBox2.Checked = false;
			checkBox1.Visible = false;
			checkBox1.Checked = false;
			checkBox6.Visible = false;
			checkBox6.Checked = false;
			checkBox5.Visible = false;
			checkBox5.Checked = false;
		}

		public void checkBoxShow()
		{
			checkBox4.Visible = true;
			checkBox3.Visible = true;
			checkBox2.Visible = true;
			checkBox1.Visible = true;
			checkBox6.Visible = true;
			checkBox5.Visible = true;
		}

		private void materialFlatButtonLogout_Click(object sender, EventArgs e)
		{
			Program.authService.logOut(parentForm.username);
			MessageBox.Show("登出成功");

			parentForm.Show();
			this.Close();
		}

		private async void materialFlatButton1_Click(object sender, EventArgs e)
		{
			string prompt = richTextBox1.Text;
			richTextBox1.Text = "請輸入你想要查詢的位置、範圍和餐廳類型";

			/* 以下皆可修改，僅為測適用 */
			richTextBox8.Text = "Loading...";

			string res = await OpenaiService.getKeyPoint(prompt);
			if (res != null)
			{
				richTextBox8.Text = res;
			}
			else
			{
				MessageBox.Show("請輸入相關查詢");
				return;
			}
			/* 到這裡皆可修改，為測試用 */

			List<Dictionary<string, object>> tmp = KeywordSearchService.RecommendRestaurant(res);

			if (tmp.Count < 6)
			{
				MessageBox.Show("資料範圍不足，請重新輸入");
				return;
			}

			linkLabel1.Links.Clear();
			linkLabel1.Text = FormatTextWithLimit((string)tmp[0]["name"]);
			linkLabel1.Links.Add(0, linkLabel1.Text.Length, (string)tmp[0]["url"]);
            

            linkLabel2.Links.Clear();
			linkLabel2.Text = FormatTextWithLimit((string)tmp[1]["name"]);
			linkLabel2.Links.Add(0, linkLabel2.Text.Length, (string)tmp[1]["url"]);
            

            linkLabel3.Links.Clear();
			linkLabel3.Text = FormatTextWithLimit((string)tmp[2]["name"]);
			linkLabel3.Links.Add(0, linkLabel3.Text.Length, (string)tmp[2]["url"]);
            

            linkLabel4.Links.Clear();
			linkLabel4.Text = FormatTextWithLimit((string)tmp[3]["name"]);
			linkLabel4.Links.Add(0, linkLabel4.Text.Length, (string)tmp[3]["url"]);
            

            linkLabel5.Links.Clear();
			linkLabel5.Text = FormatTextWithLimit((string)tmp[4]["name"]);
			linkLabel5.Links.Add(0, linkLabel5.Text.Length, (string)tmp[4]["url"]);
            

            linkLabel6.Links.Clear();
			linkLabel6.Text = FormatTextWithLimit((string)tmp[5]["name"]);
			linkLabel6.Links.Add(0, linkLabel6.Text.Length, (string)tmp[5]["url"]);

            richTextBox2.Text = "Loading...";
            richTextBox3.Text = "Loading...";
            richTextBox4.Text = "Loading...";
            richTextBox5.Text = "Loading...";
            richTextBox6.Text = "Loading...";
            richTextBox7.Text = "Loading...";



            for (int i = 0; i < 6; ++i)
			{
				markPt(maps[i], mapLayers[i], (float)tmp[i]["lat"], (float)tmp[i]["lng"]);
			}
			tabControl1.Visible = true;

			string[] reviews = await Task.WhenAll(
                OpenaiService.infoSummarize((string)tmp[0]["review"]),
                OpenaiService.infoSummarize((string)tmp[1]["review"]),
                OpenaiService.infoSummarize((string)tmp[2]["review"]),
                OpenaiService.infoSummarize((string)tmp[3]["review"]),
                OpenaiService.infoSummarize((string)tmp[4]["review"]),
                OpenaiService.infoSummarize((string)tmp[5]["review"])
            );
            richTextBox2.Text = reviews[0];
            richTextBox3.Text = reviews[1];
            richTextBox4.Text = reviews[2];
            richTextBox5.Text = reviews[3];
            richTextBox6.Text = reviews[4];
            richTextBox7.Text = reviews[5];
        }

		private void initMap(GMapControl mapController, GMapOverlay mapLayer) {
            mapController.CacheLocation = Environment.CurrentDirectory + "\\GMapCache\\";
            mapController.MapProvider = GMapProviders.GoogleMap;
            mapController.MinZoom = 0;
            mapController.MaxZoom = 24;
            mapController.Zoom = 20;
            mapController.ShowCenter = false;
            mapController.DragButton = MouseButtons.Left;
            mapController.Position = new PointLatLng(22.6, 120.332);
            mapController.ScaleMode = ScaleModes.Fractional;

            //Cution Layers
            mapController.Overlays.Add(mapLayer);
        }
		private void markPt(GMapControl mapController, GMapOverlay mapLayer, float lat, float lng)
		{
            mapController.Position = new PointLatLng(lat, lng);
            GMapMarker _currentMarker = new GMarkerGoogle(mapController.Position, GMarkerGoogleType.red_big_stop)
            {
                IsHitTestVisible = false,
            };
            mapLayer.Markers.Clear();
            mapLayer.Markers.Add(_currentMarker);
        }

		public string FormatTextWithLimit(string text)
		{
			if (text.Length > maxLength)
			{
				// 截斷文本並顯示省略號
				string truncatedText = text.Substring(0, maxLength) + "...";
				return truncatedText;
			}
			return text;
		}

		private void MainScreen_Shown(object sender, EventArgs e)
		{
			parentForm.Hide();
		}

		private void richTextBox1_Enter(object sender, EventArgs e)
		{
			richTextBox1.Text = "";
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url = e.Link.LinkData.ToString();
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
			{
				FileName = url,
				UseShellExecute = true
			});
		}

		private void materialFlatButton2_Click_1(object sender, EventArgs e)
		{
			NotePage notePage = new NotePage(this);
			notePage.Show();
			this.Hide();
		}

		private void materialFlatButton3_Click(object sender, EventArgs e)
		{
			checkBoxShow();
		}

		private void materialFlatButton4_Click(object sender, EventArgs e)
		{
			// 檢查每個組別的 CheckBox 狀態，並執行添加操作
			if (checkBox1.Checked)
			{
				AddRestaurantFromGroup(username, linkLabel1);
			}
			if (checkBox2.Checked)
			{
				AddRestaurantFromGroup(username, linkLabel2);
			}
			if (checkBox3.Checked)
			{
				AddRestaurantFromGroup(username, linkLabel3);
			}
			if (checkBox4.Checked)
			{
				AddRestaurantFromGroup(username, linkLabel4);
			}
			if (checkBox5.Checked)
			{
				AddRestaurantFromGroup(username, linkLabel5);
			}
			if (checkBox6.Checked)
			{
				AddRestaurantFromGroup(username, linkLabel6);
			}


			checkBoxHide();

			// 顯示完成訊息
			MessageBox.Show("選定的餐廳已添加到清單中！");

		}

		// 添加餐廳的輔助方法
		private void AddRestaurantFromGroup(string username, LinkLabel linkLabel)
		{
			// 獲取 LinkLabel 的顯示文字和對應的鏈接
			string restaurantName = linkLabel.Text;
			string restaurantURL = linkLabel.Links[0].LinkData?.ToString();

			// 檢查是否有有效的鏈接
			if (string.IsNullOrEmpty(restaurantURL))
			{
				MessageBox.Show($"URL無效：{restaurantName}");
				return;
			}

			// 呼叫添加餐廳的方法
			bool success = Program.authService.addRestaurant(username, restaurantName, restaurantURL);
			if (!success)
			{
				MessageBox.Show($"{restaurantName} 已被添加，無法重複添加。");
			}
		}
    }
}



