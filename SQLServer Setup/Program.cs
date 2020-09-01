using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer_Setup {
	class Program {
		static void Main(string[] args) {
			using(DBAccess database = new DBAccess()) {
				// Currently no data is loaded, working on that ASAP
				Console.WriteLine(database.OpenConnection());

				

			}
			
			
			
		}

		static void PrintArray(String[] arr) {
			foreach(String i in arr) {
				Console.Write($"{i} ");
			}
		}
	}
}
