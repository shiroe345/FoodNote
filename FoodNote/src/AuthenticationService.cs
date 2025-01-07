using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
	internal class AuthenticationService
	{
		private DatabaseHelper dbHelper;

		public AuthenticationService(string connectionString)
		{
			dbHelper = new DatabaseHelper(connectionString);
		}

		public bool logIn(string username, string password)
		{
			if (dbHelper.authenticateUserPwd(username, password)) { 
				dbHelper.updateLoginStatus(username, true);
				return true;
			}

			return false;
		}

		public void logOut(string username)
		{
			dbHelper.updateLoginStatus(username, false);
		}

		public bool signUp(string username, string password)
		{
			return dbHelper.addUser(username, password);
		}

		public bool addRestaurant(string username, string restaurantName, string restaurantURL)
		{
			return dbHelper.addRestaurantToUser(username, restaurantName, restaurantURL);
		}

		public bool deleteRestaurant(string username, string restaurantName)
		{
			return dbHelper.deleteRestaurantFromUser(username, restaurantName);
		}

		public Dictionary<string, string> getRestaurants(string username)
		{
			return dbHelper.loadRestaurantData(username);
		}
	}
}
