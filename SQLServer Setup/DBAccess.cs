using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace SQLServer_Setup {


	class DBAccess : IDisposable {
		public MySqlConnection connection;

		private String server;
		private String database;
		private String uid;
		private String password;
		private bool Open;

		public DBAccess() {
			Initialize();
		}
		private void Initialize() {

			/*
			 Keep in mind that this is my personal server. The IP is one of mine, as the actual box is one of mine. Please be respectful.
			 The user here was created and granted permissions for all IPs so there should be no problem in connecting. If you do have one, let me know ASAP.
			
			 - Michael Edwards
			 */

			server = "71.87.195.218";
			database = "BIKE_SHOP";
			uid = "BIKE_SHOP";
			password = "TeamADatabase1!";
			String connectionString;
			connectionString = $"datasource={server}; Database={database}; uid={uid}; pwd={password}; AllowLoadLocalInfile=true;";
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
		public bool CloseConnection() {
			try {
				connection.Close();
				return true;
			} catch(MySqlException ex) {
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		public void RunScript(String script) {
			String scriptText = File.ReadAllText($"..\\..\\Scripts\\{script}");
			try {
				if(OpenConnection()) {
					MySqlCommand cmd = new MySqlCommand(scriptText, connection);
					cmd.ExecuteNonQuery();
					CloseConnection();
				}
			} catch(Exception) {

			}
		}

		public FileInfo[] GetFileInfo(String path) {
			String[] fileNames = Directory.GetFiles(path);
			FileInfo[] retFiles = new FileInfo[fileNames.Length];
			for(int i = 0; i < fileNames.Length; i++) {
				retFiles[i] = new FileInfo(fileNames[i]);
			}
			return retFiles;
		}

		public List<String> GetFileData(String file) {
			List<String> data = new List<String>();
			String[] text = File.ReadAllText(file).Split('\n');
			foreach(String line in text) {
				data.Add(line);
			}
			return data;
		}

		public void LoadData() {
			FileInfo[] files = GetFileInfo(@"..\..\CSV");
			MySqlCommand cmd = new MySqlCommand();
			List<String> fileData;
			String tableName;
			String tableFields = "";
			String[] currObject;
			String values = "";
			String path = "";
			if(OpenConnection()) {
				cmd.Connection = connection;
				foreach(FileInfo file in files) {
					fileData = GetFileData(file.FullName);
					tableName = file.Name.Replace(@"_DATA_TABLE.csv", "").Replace("\"", "");
					tableFields = fileData[0].Trim().Replace("\"", "").Replace("'", "");
					cmd.CommandText = "START TRANSACTION;";
					cmd.ExecuteNonQuery();
					try {
						Console.WriteLine($"Inserting into {tableName}");
						Console.WriteLine($"{file.FullName.Replace("\\", "/")}");
						cmd.CommandText = $"LOAD DATA LOCAL INFILE '{file.FullName.Replace("\\", "/")}' INTO TABLE {tableName} FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY \"'\" LINES TERMINATED BY '\n' IGNORE 1 ROWS  ";
						cmd.ExecuteNonQuery();
					} catch(MySqlException ex) {
						Console.WriteLine(ex.ErrorCode);
						Console.WriteLine(ex.Message);
						Console.WriteLine(cmd.CommandText);
						Console.WriteLine();
						Console.WriteLine();
						break;
					}
					cmd.CommandText = "COMMIT;";
					cmd.ExecuteNonQuery();
				}
				CloseConnection();
			}
		}

		static void PrintArray(String[] arr) {
			foreach(String i in arr) {
				Console.Write($"{i} ");
			}
		}

		public void DropAllTables() {
			List<String[]> tableNames = Query("SELECT table_name FROM information_schema.tables WHERE table_schema = 'BIKE_SHOP'");
			MySqlCommand cmd = new MySqlCommand();

			if(OpenConnection()) {
				cmd.Connection = connection;
				cmd.CommandTimeout = 86400;
				cmd.CommandText = "SET FOREIGN_KEY_CHECKS = 0;";
				cmd.ExecuteNonQuery();

				foreach(String[] tableName in tableNames) {
					Console.WriteLine($"Dropping table {tableName[0]}");
					cmd.CommandText = $"DROP TABLE IF EXISTS {tableName[0]};";
					cmd.ExecuteNonQuery();
				}

				cmd.CommandText = "SET FOREIGN_KEY_CHECKS = 1;";
				cmd.ExecuteNonQuery();

				CloseConnection();
			}
		}

		// This is for general queries, probably going to use something like this mostly
		public List<String[]> Query(String query) {
			//Create a list to store the result
			List<string[]> list = new List<string[]>();

			//Open connection
			if(OpenConnection()) {
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
				CloseConnection();
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
