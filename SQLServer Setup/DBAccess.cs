using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace DentistOffice {


	class DBAccess : IDisposable {
		private MySqlConnection connection;
		private string server;
		private string database;
		private string uid;
		private string password;

		public DBAccess() {
			Initialize();
		}
		private void Initialize() {
			server = "71.87.195.218";
			database = "BIKE_SHOP";
			uid = "BIKE_SHOP";
			password = "TeamADatabase1!";
			string connectionString;
			connectionString = $"datasource={server}; Database={database}; uid={uid}; pwd={password};";
			connection = new MySqlConnection(connectionString);
		}
		public bool OpenConnection() {
			try {
				connection.Open();
				return true;
			} catch(MySqlException ex) {
				switch(ex.Number) {
					case 0:
						Console.WriteLine("Cannot connect to server.  Contact administrator");
						break;

					case 1045:
						Console.WriteLine("Invalid username/password, please try again");
						break;
				}
				Console.WriteLine($"{ex.Code} {ex.Message}");
				return false;
			}
		}
		private bool CloseConnection() {
			try {
				connection.Close();
				return true;
			} catch(MySqlException ex) {
				Console.WriteLine(ex.Message);
				return false;
			}
		}
		
		// This is for general queries, probably going to use something like this mostly
		public List<String[]> Query(String query) {
			//Create a list to store the result
			List<string[]> list = new List<string[]>();

			//Open connection
			if(this.OpenConnection() == true) {
				//Create Command
				MySqlCommand cmd = new MySqlCommand(query, connection);
				//Create a data reader and Execute the command
				MySqlDataReader dataReader = cmd.ExecuteReader();

				//Read the data and store them in the list
				while(dataReader.Read()) {
					String[] currObject = new String[dataReader.VisibleFieldCount];
					for(int i = 0; i < dataReader.VisibleFieldCount; i++) {
						currObject[i] = dataReader[i].ToString();
					}
					list.Add(currObject);
				}

				//close Data Reader
				dataReader.Close();

				//close Connection
				this.CloseConnection();
				cmd.Dispose();
				//return list to be displayed
				return list;
			} else {
				return list;
			}
		}

		public void Dispose() {
			CloseConnection();
		}
	}
}
