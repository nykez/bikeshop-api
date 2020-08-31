using System;
using System.Collections.Generic;
using Oracle.EntityFrameworkCore;
using System.Linq;

namespace SQLServer_Setup {
	class Program {
		static void Main(string[] args) {
			using(DBAccess database = new DBAccess()) {

				// If you want to run a SQL query(does not work for commands like DESC)...
				// WARNING THIS SPECIFIC QUERY BLEHS OUT A TON OF DATA THAT ISN'T REALLY FORMATTED
				/*List<String[]> data = database.Query("SELECT * FROM BIKE_SHOP.BICYCLE");
				foreach(String[] arr in data) {
					PrintArray(arr);
				}*/

				// You can access an idividual piece of data like this...
				//Console.WriteLine(data[0][0]);

				// You can get a table described like this...(we should decide what we want to be in the describe, we can replicate the SQLDeveloper "Columns" tab if we want)
				//database.Describe("BIKE_SHOP.BICYCLE");

				// You can show tables for a specific schema using this...
				//database.ShowTables("BIKE_SHOP");

				// Or if you want to show tables from YOUR schema, use the same function with no argument...
				//database.ShowTables();

			}
			
			
			
		}

		static void PrintArray(String[] arr) {
			foreach(String i in arr) {
				Console.Write($"{i} ");
			}
		}
	}
}
