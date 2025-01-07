using System;
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

namespace Final_Project.forms
{
	public partial class NotePage : MaterialForm
	{
		private readonly MaterialSkinManager materialSkinManager;
		private MainScreen parentForm;
		public string username;
		public NotePage(MainScreen mainScreen)
		{
			this.StartPosition = FormStartPosition.CenterScreen;

			materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);

			parentForm = mainScreen;
			this.username = parentForm.username;

			InitializeComponent();
			//linkLabel1.Links.Add(0, linkLabel1.Text.Length, "https://www.google.com/");

			initializeDataGridView();

			
		}

		private void initializeDataGridView() {
			DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn
			{
				Name = "Restaurant",
				HeaderText = "餐廳名稱",
				UseColumnTextForLinkValue = false, 
				DataPropertyName = "RestaurantName",
				FillWeight = 50 
			};

			// 創建刪除按鈕列
			DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
			{
				Name = "Select",

				HeaderText = "",
				FillWeight = 5 
			};

			dataGridView1.Columns.Add(checkBoxColumn);
			dataGridView1.Columns.Add(linkColumn);

			dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
			dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;


			// 不顯示空白行
			dataGridView1.RowHeadersVisible = false;
			// 禁止用戶新增行
			dataGridView1.AllowUserToAddRows = false;
			// 禁止用戶調整長寬
			dataGridView1.AllowUserToResizeColumns = false;
			dataGridView1.AllowUserToResizeRows = false;

			LoadNoteDBtoDataGrid();

		}

		private void LoadNoteDBtoDataGrid()
		{
			Program.authService.getRestaurants(username).ToList().ForEach(x => AddRow(x.Key, x.Value));
		}

		private void AddRow(string restaurantName, string restaurantURL)
		{
			DataGridViewRow row = new DataGridViewRow();
			row.CreateCells(dataGridView1);
			row.Cells[0].Value = false; // CheckBox
			row.Cells[1].Value = restaurantName; // 顯示的文字
			row.Cells[1].Tag = restaurantURL;   // 隱藏的 URL
			dataGridView1.Rows.Add(row);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url = e.Link.LinkData.ToString();
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
			{
				FileName = url,
				UseShellExecute = true
			});
		}

		private void materialFlatButton1_Click(object sender, EventArgs e)
		{
			parentForm.Show();
			this.Close();
		}

		private void materialFlatButton2_Click(object sender, EventArgs e)
		{
			for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
			{
				// 檢查 CheckBox 是否被選中
				if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Select"].Value) == true)
				{
					Program.authService.deleteRestaurant(username, dataGridView1.Rows[i].Cells["Restaurant"].Value.ToString());
					dataGridView1.Rows.RemoveAt(i);
				}
			}


			MessageBox.Show("選擇的餐廳已刪除");
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Restaurant")
			{
				// 獲取對應的 URL
				string url = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();

				// 打開瀏覽器訪問 URL
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
				{
					FileName = url,
					UseShellExecute = true
				});
			}
		}
	}
}
