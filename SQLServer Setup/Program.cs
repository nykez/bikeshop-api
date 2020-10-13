using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer_Setup {
	/// <summary>
	/// Main class, Drops all tables then runs table creation, data loading, and constraints.
	/// </summary>
	class Program {
		static void Main(string[] args) {
			using(DBAccess database = new DBAccess()) {
				database.DropAllTables();
				database.RunScript("Bike_Shop.sql");
				database.LoadData();
				database.RunScript("Constraints.sql");
			}	
		}
	}
}
