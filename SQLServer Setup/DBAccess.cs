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
		/// <summary>
		/// All private fields, set in the inizializer
		/// </summary>
		private MySqlConnection connection;
		private String server;
		private String database;
		private String uid;
		private String password;


		/*
			 Keep in mind that this is my personal server. The IP is one of mine, as the actual box is one of mine. Please be respectful.
			 The user here was created and granted permissions for all IPs so there should be no problem in connecting. If you do have one, let me know ASAP.
			
			 - Michael Edwards
		*/

		/// <summary>
		/// Constructor, creates a connection to the database with our project user.
		/// </summary>
		public DBAccess() {
			server = "71.87.195.218";
			database = "BIKE_SHOP";
			uid = "BIKE_SHOP";
			password = "TeamADatabase1!";
			String connectionString;
			connectionString = $"datasource={server}; Database={database}; uid={uid}; pwd={password}; AllowLoadLocalInfile=true;";
			connection = new MySqlConnection(connectionString);
		}

		/// <summary>
		/// Opens the connection to the server
		/// </summary>
		/// <returns>true if connection passed, false if it failed.</returns>
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

		/// <summary>
		/// Closes the connection.
		/// </summary>
		/// <returns>True if close passed, false if failed.</returns>
		public bool CloseConnection() {
			try {
				connection.Close();
				return true;
			} catch(MySqlException ex) {
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		/// <summary>
		/// Allows the database to run an external script in the solution "script" folder.
		/// </summary>
		/// <param name="script">The file name of the script to be ran.</param>
		public void RunScript(String script) {
			String scriptText = File.ReadAllText($"..\\..\\Scripts\\{script}");
			MySqlCommand cmd = new MySqlCommand(scriptText);
			cmd.CommandTimeout = 3600;
			//try {
				if(OpenConnection()) {
					cmd.Connection = connection;
					cmd.ExecuteNonQuery();
					CloseConnection();
				}
			/*} catch(MySqlException ex) {
				Console.WriteLine(ex.InnerException);
*//*				Console.WriteLine(ex.Number);
				Console.WriteLine(ex.Message);*//*
				Console.WriteLine(ex);
			}*/
		}

		/// <summary>
		/// Gets info for files in the specified path.
		/// </summary>
		/// <param name="path">The path to be collected from.</param>
		/// <returns>An array of FileInfo objects containing the files.</returns>
		public FileInfo[] GetFileInfo(String path) {
			String[] fileNames = Directory.GetFiles(path);
			FileInfo[] retFiles = new FileInfo[fileNames.Length];
			for(int i = 0; i < fileNames.Length; i++) {
				retFiles[i] = new FileInfo(fileNames[i]);
			}
			return retFiles;
		}
		
		/// <summary>
		/// Loads all data from the CSV files in the CSV solution folder to the database, assuming the database is set up for those files.
		/// </summary>
		public void LoadData() {
			FileInfo[] files = GetFileInfo(@"..\..\CSV");
			MySqlCommand cmd = new MySqlCommand();
			String tableName;
			if(OpenConnection()) {
				cmd.Connection = connection;
				foreach(FileInfo file in files) {
					tableName = file.Name.Replace(@"_DATA_TABLE.csv", "").Replace("\"", "");
					cmd.CommandText = "START TRANSACTION;";
					cmd.ExecuteNonQuery();
					try {
						Console.WriteLine($"Inserting into {tableName}");
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

		/// <summary>
		/// Drops all tables from the project database.
		/// </summary>
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

		/// <summary>
		/// General query execution, pass in the entire query.
		/// </summary>
		/// <param name="query">The query to be executed.</param>
		/// <returns>A list of all of the rows returned by the query.</returns>
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

		/// <summary>
		/// Closes the connection, gets called when using statements close.
		/// </summary>
		public void Dispose() {
			CloseConnection();
		}
	}
}
