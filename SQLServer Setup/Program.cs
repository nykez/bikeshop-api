using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer_Setup {
	class Program {
		static void Main(string[] args) {
			using(DBAccess database = new DBAccess()) {
				database.DropAllTables();
				database.RunScript("Bike_Shop.sql");
				database.LoadData();
				//database.Query("INSERT INTO BICYCLE(SERIALNUMBER,CUSTOMERID,MODELTYPE,PAINTID,FRAMESIZE,ORDERDATE,STARTDATE,SHIPDATE,SHIPEMPLOYEE,FRAMEASSEMBLER,PAINTER,CONSTRUCTION,WATERBOTTLEBRAZEONS,CUSTOMNAME,LETTERSTYLEID,STOREID,EMPLOYEEID,TOPTUBE,CHAINSTAY,HEADTUBEANGLE,SEATTUBEANGLE,LISTPRICE,SALEPRICE,SALESTAX,SALESTATE,SHIPPRICE,FRAMEPRICE,COMPONENTLIST) VALUES(221,181,'Hybrid',10,23,STR_TO_DATE('1994-11-06', '%Y-%m-%d'),STR_TO_DATE('1994-11-06', '%Y-%m-%d'),STR_TO_DATE('1994-11-06', '%Y-%m-%d'),51512,89097,87295,'TIG Welded',4,'Buck Cole','Roman',2068,37453,58,43,71.5,73,1295.34,1250,62.5,'ID',70,386.28,1020)");
				//database.Query("INSERT INTO CUSTOMERTRANSACTION VALUES(1, '1994-11-06', 1, 1, '1', 1)");
			}	
			
			
			
		}

		static void PrintArray(String[] arr) {
			foreach(String i in arr) {
				Console.Write($"{i} ");
			}
		}
	}
}
