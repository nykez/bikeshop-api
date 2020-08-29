using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Oracle.EntityFrameworkCore;

namespace SQLServer_Setup {


	// Calls to this object should be inside a using statement to automatically call Dispose() and close the connection
	// Once the connection is no longer needed.
	class DBAccess : IDisposable {
		private OracleConnection Connection;
		private string Server;
		private string UID;
		private string Password;

		public DBAccess() {
			Initialize();
		}
		private void Initialize() {
			Server = @"pythia.etsu.edu:1521/csdb.etsu.edu";
			Console.Write("Username: ");
			UID = Console.ReadLine();
			Console.Write("Password: ");
			Password = NoDisplayPassword();
			String ConnectionString = $"Data Source={Server};User Id={UID};Password={Password};";
			Connection = new OracleConnection(ConnectionString);
		}
		public bool OpenConnection() {
			try {
				Connection.Open();
				Console.WriteLine("Connection Successful");
				return true;
			} catch(OracleException ex) {
				switch(ex.ErrorCode) {
					case 0:
						Console.WriteLine("Cannot connect to server.  Contact administrator");
						break;

					case -2147467259: // This error code represents an invalid username when trying to login to the database
						Console.WriteLine("Invalid username/password, please try again");
						break;
				}
				return false;
			}
		}
		private bool CloseConnection() {
			try {
				Connection.Close();
				Console.WriteLine("Connection closed");
				return true;
			} catch(OracleException ex) {
				Console.WriteLine(ex.Message);
				return false;
			}
		}


		public List<String[]> Query(String query) {
			List<String[]> list = new List<String[]>();
			if(OpenConnection() == true) {
				OracleCommand cmd = new OracleCommand(query, Connection);
				OracleDataReader dataReader = cmd.ExecuteReader();
				while(dataReader.Read()) {
					String[] currObject = new String[dataReader.VisibleFieldCount];
					for(int i = 0; i < dataReader.VisibleFieldCount; i++) {
						currObject[i] = dataReader[i].ToString();
					}
					list.Add(currObject);
				}
				dataReader.Close();
				cmd.Dispose();
				return list;
			} else {
				return list;
			}
		}

		private String NoDisplayPassword() {
			String retPassword = "";
			while(true) {
				ConsoleKeyInfo key = Console.ReadKey(true);
				if(key.Key == ConsoleKey.Enter) break;
				retPassword += key.KeyChar;
			}
			return retPassword;
		}

		public void Dispose() {
			CloseConnection();
		}
	}
}
