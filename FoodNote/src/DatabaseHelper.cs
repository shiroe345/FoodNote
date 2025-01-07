using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Final_Project
{
	internal class DatabaseHelper
	{
		private readonly string connectionString;

		public DatabaseHelper(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public bool authenticateUserPwd(string username, string password)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				try
				{
					sqlConnection.Open();

					string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

					using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
					{
						sqlCommand.Parameters.AddWithValue("@Username", username);
						sqlCommand.Parameters.AddWithValue("@Password", password);

						int count = (int)sqlCommand.ExecuteScalar();

						return count > 0;
					}
				}
				catch (Exception ex)
				{
					// 處理可能的例外情況，並記錄錯誤
					MessageBox.Show($"資料庫驗證失敗: {ex.Message}");
					return false;
				}
			}
		}

		public void updateLoginStatus(string username, bool isLoggedIn)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "UPDATE Users SET IsLoggedIn = @IsLoggedIn WHERE Username = @Username";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					try
					{
						command.Parameters.AddWithValue("@IsLoggedIn", isLoggedIn);
						command.Parameters.AddWithValue("@Username", username);
						command.ExecuteNonQuery();
					}
					catch(Exception ex)
					{
						MessageBox.Show($"資料庫驗證失敗: {ex.Message}");
					}
				}
			}
		}

		public bool addUser(string username, string password)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// 檢查用戶名是否已存在
					string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
					using (SqlCommand checkCommand = new SqlCommand(checkUserQuery, connection))
					{
						checkCommand.Parameters.AddWithValue("@Username", username);
						int userExists = (int)checkCommand.ExecuteScalar();

						if (userExists > 0)
						{
							// 用戶已存在
							return false;
						}
					}

					// 插入新用戶
					string addUserQuery = "INSERT INTO Users (Username, Password, IsLoggedIn) VALUES (@Username, @Password, 0)";
					using (SqlCommand addCommand = new SqlCommand(addUserQuery, connection))
					{
						addCommand.Parameters.AddWithValue("@Username", username);
						addCommand.Parameters.AddWithValue("@Password", password); // 密碼應該加密後存儲

						int rowsAffected = addCommand.ExecuteNonQuery();
						return rowsAffected > 0; // 如果插入成功，返回 true
					}
				}
			}
			catch (Exception ex)
			{
				// 捕捉異常，並記錄錯誤（可以用於日誌記錄）
				MessageBox.Show($"Error: {ex.Message}");
				return false;
			}
		}

		public bool addRestaurantToUser(string username, string restaurantName, string restaurantURL)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// 根據 username 獲取 UserID
					string getUserIdQuery = "SELECT Id FROM Users WHERE Username = @Username";
					using (SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, connection))
					{
						getUserIdCommand.Parameters.AddWithValue("@Username", username);
						int userId = (int)getUserIdCommand.ExecuteScalar(); // 假設用戶必然存在

						if (checkSameRestaurantExist(connection, restaurantName, userId)) { 
							// 插入 Notebook 資料
							string addNotebookQuery = "INSERT INTO Notebooks (UserID, RestaurantName, RestaurantURL) VALUES (@UserID, @RestaurantName, @RestaurantURL)";
							using (SqlCommand addNotebookCommand = new SqlCommand(addNotebookQuery, connection))
							{
								addNotebookCommand.Parameters.AddWithValue("@UserID", userId);
								addNotebookCommand.Parameters.AddWithValue("@RestaurantName", restaurantName);
								addNotebookCommand.Parameters.AddWithValue("@RestaurantURL", restaurantURL);

								int rowsAffected = addNotebookCommand.ExecuteNonQuery();
								return rowsAffected > 0; // 如果插入成功，返回 true
							}
						}
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"新增餐廳時發生錯誤: {ex.Message}");
				return false;
			}
		}
		public bool checkSameRestaurantExist(SqlConnection connection, string restaurantName, int userId)
		{
			string checkDuplicateQuery = "SELECT COUNT(*) FROM Notebooks WHERE UserID = @UserID AND RestaurantName = @RestaurantName";
			using (SqlCommand checkDuplicateCommand = new SqlCommand(checkDuplicateQuery, connection))
			{
				checkDuplicateCommand.Parameters.AddWithValue("@UserID", userId);
				checkDuplicateCommand.Parameters.AddWithValue("@RestaurantName", restaurantName);

				int count = (int)checkDuplicateCommand.ExecuteScalar();
				if (count > 0) // 看有沒有重複
				{
					return false;
				}
				return true;
			}
		}

		public bool deleteRestaurantFromUser(string username, string restaurantName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// 根據 username 獲取 UserID
					string getUserIdQuery = "SELECT Id FROM Users WHERE Username = @Username";
					using (SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, connection))
					{
						getUserIdCommand.Parameters.AddWithValue("@Username", username);
						int userId = (int)getUserIdCommand.ExecuteScalar(); // 假設用戶必然存在

						// 刪除 Notebook 資料
						string deleteNotebookQuery = "DELETE FROM Notebooks WHERE UserID = @UserID AND RestaurantName = @RestaurantName";
						using (SqlCommand deleteNotebookCommand = new SqlCommand(deleteNotebookQuery, connection))
						{
							deleteNotebookCommand.Parameters.AddWithValue("@UserID", userId);
							deleteNotebookCommand.Parameters.AddWithValue("@RestaurantName", restaurantName);

							int rowsAffected = deleteNotebookCommand.ExecuteNonQuery();
							return rowsAffected > 0; // 如果刪除成功，返回 true
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"刪除餐廳時發生錯誤: {ex.Message}");
				return false;
			}
		}

		public Dictionary<string, string> loadRestaurantData(string username)
		{
			Dictionary<string, string> restaurantData = new Dictionary<string, string>();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// 根據 username 獲取 UserID
					string getUserIdQuery = "SELECT Id FROM Users WHERE Username = @Username";
					using (SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, connection))
					{
						getUserIdCommand.Parameters.AddWithValue("@Username", username);
						int userId = (int)getUserIdCommand.ExecuteScalar(); // 假設用戶必然存在

						// 查詢該用戶的餐廳數據
						string getRestaurantsQuery = "SELECT RestaurantName, RestaurantURL FROM Notebooks WHERE UserID = @UserID";
						using (SqlCommand getRestaurantsCommand = new SqlCommand(getRestaurantsQuery, connection))
						{
							getRestaurantsCommand.Parameters.AddWithValue("@UserID", userId);

							using (SqlDataReader reader = getRestaurantsCommand.ExecuteReader())
							{
								while (reader.Read())
								{
									string restaurantName = reader["RestaurantName"].ToString();
									string restaurantURL = reader["RestaurantURL"].ToString();
									restaurantData[restaurantName] = restaurantURL;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"加載餐廳數據時發生錯誤: {ex.Message}");
			}

			return restaurantData;
		}

	}
}
