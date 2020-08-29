using System;
using System.Collections.Generic;
using Oracle.EntityFrameworkCore;
using System.Linq;

namespace SQLServer_Setup {
	class Program {
		static void Main(string[] args) {
			//DBAccess database = new DBAccess();
			using(DBAccess database = new DBAccess()) {
				List<String[]> data = database.Query("SELECT * FROM BIKE_SHOP.BICYCLE");
				Console.WriteLine(data[0]);
			}
			
			
			
		}

		static void PrintArray(String[] arr) {
			foreach(String i in arr) {
				Console.Write($"{i} ");
			}
		}
	}
}
