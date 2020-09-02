 use BIKE_SHOP;
 CREATE TABLE BICYCLE 
   (	SERIALINT INT, 
	CUSTOMERID INT DEFAULT 0, 
	MODELTYPE VARCHAR(50), 
	PAINTID INT DEFAULT 0, 
	FRAMESIZE INT DEFAULT 0, 
	ORDERDATE DATE, 
	STARTDATE DATE, 
	SHIPDATE DATE, 
	SHIPEMPLOYEE INT DEFAULT 0, 
	FRAMEASSEMBLER INT DEFAULT 0, 
	PAINTER INT DEFAULT 0, 
	CONSTRUCTION VARCHAR(50) DEFAULT 'Bonded', 
	WATERBOTTLEBRAZEONS INT DEFAULT 4, 
	CUSTOMNAME VARCHAR(50), 
	LETTERSTYLEID VARCHAR(50), 
	STOREID INT DEFAULT 0, 
	EMPLOYEEID INT DEFAULT 0, 
	TOPTUBE INT DEFAULT 0, 
	CHAINSTAY INT DEFAULT 0, 
	HEADTUBEANGLE INT DEFAULT 0, 
	SEATTUBEANGLE INT DEFAULT 0, 
	LISTPRICE INT DEFAULT 0, 
	SALEPRICE INT DEFAULT 0, 
	SALESTAX INT DEFAULT 0, 
	SALESTATE VARCHAR(50), 
	SHIPPRICE INT DEFAULT 0, 
	FRAMEPRICE INT DEFAULT 0, 
	COMPONENTLIST INT DEFAULT 0
);

  CREATE TABLE BICYCLETUBEUSAGE 
   (	SERIALINT INT DEFAULT 0, 
	TUBEID INT DEFAULT 0, 
	QUANTITY INT DEFAULT 0
);

  CREATE TABLE BIKEPARTS 
   (	SERIALINT INT DEFAULT 0, 
	COMPONENTID INT DEFAULT 0, 
	SUBSTITUTEID INT DEFAULT 0, 
	LOCATION VARCHAR(50), 
	QUANTITY INT DEFAULT 0, 
	DATEINSTALLED DATE, 
	EMPLOYEEID INT DEFAULT 0
);

  CREATE TABLE BIKETUBES 
   (	SERIALINT INT DEFAULT 0, 
	TUBENAME VARCHAR(50), 
	TUBEID INT DEFAULT 0, 
	LENGTH INT DEFAULT 0
);

  CREATE TABLE CITY 
   (	CITYID INT, 
	ZIPCODE VARCHAR(50), 
	CITY VARCHAR(50), 
	STATE VARCHAR(50), 
	AREACODE VARCHAR(50), 
	POPULATION1990 INT DEFAULT 0, 
	POPULATION1980 INT DEFAULT 0, 
	COUNTRY VARCHAR(50), 
	LATITUDE INT DEFAULT 0, 
	LONGITUDE INT DEFAULT 0, 
	POPULATIONCDF INT DEFAULT 0
);

  CREATE TABLE COMMONSIZES 
   (	MODELTYPE VARCHAR(50), 
	FRAMESIZE INT DEFAULT 0
);

  CREATE TABLE COMPONENT 
   (	COMPONENTID INT DEFAULT 0, 
	MANUFACTURERID INT DEFAULT 0, 
	PRODUCTINT VARCHAR(50), 
	ROAD VARCHAR(50), 
	CATEGORY VARCHAR(50), 
	LENGTH INT DEFAULT 0, 
	HEIGHT INT DEFAULT 0, 
	WIDTH INT DEFAULT 0, 
	WEIGHT INT DEFAULT 0, 
	YEAR INT, 
	ENDYEAR INT, 
	DESCRIPTION VARCHAR(100), 
	LISTPRICE INT DEFAULT 0, 
	ESTIMATEDCOST INT DEFAULT 0, 
	QUANTITYONHAND INT DEFAULT 10
);

  CREATE TABLE COMPONENTNAME 
   (	COMPONENTNAME VARCHAR(50), 
	ASSEMBLYORDER INT DEFAULT 0, 
	DESCRIPTION VARCHAR(50)
);

  CREATE TABLE CUSTOMER 
   (	CUSTOMERID INT, 
	PHONE VARCHAR(50), 
	FIRSTNAME VARCHAR(50), 
	LASTNAME VARCHAR(50), 
	ADDRESS VARCHAR(50), 
	ZIPCODE VARCHAR(50), 
	CITYID INT DEFAULT 0, 
	BALANCEDUE INT DEFAULT 0
);

  CREATE TABLE CUSTOMERTRANSACTION 
   (	CUSTOMERID INT DEFAULT 0, 
	TRANSACTIONDATE DATE, 
	EMPLOYEEID INT DEFAULT 0, 
	AMOUNT INT DEFAULT 0, 
	DESCRIPTION VARCHAR(250), 
	REFERENCE INT DEFAULT 0
);

  CREATE TABLE EMPLOYEE 
   (	EMPLOYEEID INT DEFAULT 0, 
	TAXPAYERID VARCHAR(50), 
	LASTNAME VARCHAR(50), 
	FIRSTNAME VARCHAR(50), 
	HOMEPHONE VARCHAR(50), 
	ADDRESS VARCHAR(50), 
	ZIPCODE VARCHAR(50), 
	CITYID INT DEFAULT 0, 
	DATEHIRED DATE, 
	DATERELEASED DATE, 
	CURRENTMANAGER INT DEFAULT 0, 
	SALARYGRADE INT DEFAULT 0, 
	SALARY INT DEFAULT 0, 
	TITLE VARCHAR(100), 
	WORKAREA VARCHAR(50)
);

  CREATE TABLE GROUPCOMPONENTS 
   (	GROUPID INT DEFAULT 0, 
	COMPONENTID INT DEFAULT 0
);

  CREATE TABLE GROUPO 
   (	COMPONENTGROUPID INT, 
	GROUPNAME VARCHAR(50), 
	BIKETYPE VARCHAR(50), 
	YEAR INT, 
	ENDYEAR INT, 
	WEIGHT INT
);

  CREATE TABLE LETTERSTYLE 
   (	LETTERSTYLE VARCHAR(50), 
	DESCRIPTION VARCHAR(50)
);

  CREATE TABLE MANUFACTURER 
   (	MANUFACTURERID INT, 
	MANUFACTURERNAME VARCHAR(50), 
	CONTACTNAME VARCHAR(50), 
	PHONE VARCHAR(50), 
	ADDRESS VARCHAR(50), 
	ZIPCODE VARCHAR(50), 
	CITYID INT DEFAULT 0, 
	BALANCEDUE INT DEFAULT 0
);

  CREATE TABLE MANUFACTURERTRANSACTION 
   (	MANUFACTURERID INT DEFAULT 0, 
	TRANSACTIONDATE DATE, 
	EMPLOYEEID INT DEFAULT 0, 
	AMOUNT INT DEFAULT 0, 
	DESCRIPTION VARCHAR(250), 
	REFERENCE INT DEFAULT 0
);

  CREATE TABLE MODELSIZE 
   (	MODELTYPE VARCHAR(50), 
	MSIZE INT DEFAULT 0, 
	TOPTUBE INT DEFAULT 0, 
	CHAINSTAY INT DEFAULT 0, 
	TOTALLENGTH INT DEFAULT 0, 
	GROUNDCLEARANCE INT DEFAULT 0, 
	HEADTUBEANGLE INT DEFAULT 0, 
	SEATTUBEANGLE INT DEFAULT 0
);

  CREATE TABLE MODELTYPE 
   (	MODELTYPE VARCHAR(50), 
	DESCRIPTION VARCHAR(50), 
	COMPONENTID INT
);

  CREATE TABLE PAINT 
   (	PAINTID INT, 
	COLORNAME VARCHAR(50), 
	COLORSTYLE VARCHAR(50) DEFAULT 'Solid', 
	COLORLIST VARCHAR(50), 
	DATEINTRODUCED DATE, 
	DATEDISCONTINUED DATE
);

  CREATE TABLE PREFERENCE 
   (	ITEMNAME VARCHAR(50), 
	VALUE INT DEFAULT 0, 
	DESCRIPTION VARCHAR(250), 
	DATECHANGED DATE
);

  CREATE TABLE PURCHASEITEM 
   (	PURCHASEID INT DEFAULT 0, 
	COMPONENTID INT DEFAULT 0, 
	PRICEPAID INT DEFAULT 0, 
	QUANTITY INT DEFAULT 0, 
	QUANTITYRECEIVED INT DEFAULT 0
);

  CREATE TABLE PURCHASEORDER 
   (	PURCHASEID INT, 
	EMPLOYEEID INT DEFAULT 0, 
	MANUFACTURERID INT DEFAULT 0, 
	TOTALLIST INT DEFAULT 0, 
	SHIPPINGCOST INT DEFAULT 0, 
	DISCOUNT INT DEFAULT 0, 
	ORDERDATE DATE, 
	RECEIVEDATE DATE, 
	AMOUNTDUE INT DEFAULT 0
);

  CREATE TABLE RETAILSTORE 
   (	STOREID INT, 
	STORENAME VARCHAR(50), 
	PHONE VARCHAR(50), 
	CONTACTFIRSTNAME VARCHAR(50), 
	CONTACTLASTNAME VARCHAR(50), 
	ADDRESS VARCHAR(50), 
	ZIPCODE VARCHAR(50), 
	CITYID INT DEFAULT 0
);

  CREATE TABLE REVISIONHISTORY 
   (	ID INT, 
	VERSION VARCHAR(50), 
	CHANGEDATE DATE, 
	NAME VARCHAR(50), 
	REVISIONCOMMENTS VARCHAR(250)
);

  CREATE TABLE SAMPLENAME 
   (	ID INT, 
	LASTNAME VARCHAR(50), 
	FIRSTNAME VARCHAR(50), 
	GENDER VARCHAR(50)
);

  CREATE TABLE SAMPLESTREET 
   (	ID INT, 
	BASEADDRESS VARCHAR(50)
);

  CREATE TABLE STATETAXRATE 
   (	STATE VARCHAR(50), 
	TAXRATE INT DEFAULT 0
);

  CREATE TABLE TEMPDATEMADE 
   (	DATEVALUE DATE, 
	MADECOUNT INT DEFAULT 0
);

  CREATE TABLE TUBEMATERIAL 
   (	TUBEID INT DEFAULT 0, 
	MATERIAL VARCHAR(50), 
	DESCRIPTION VARCHAR(100), 
	DIAMETER INT DEFAULT 0, 
	THICKNESS INT DEFAULT 0, 
	ROUNDNESS VARCHAR(50), 
	WEIGHT INT DEFAULT 0, 
	STIFFNESS INT DEFAULT 0, 
	LISTPRICE INT DEFAULT 1, 
	CONSTRUCTION VARCHAR(50) DEFAULT 'Bonded'
);

  CREATE TABLE WORKAREA 
   (	WORKAREA VARCHAR(50), 
	DESCRIPTION VARCHAR(50)
);

  CREATE UNIQUE INDEX PK_BICYCLE ON BICYCLE (SERIALINT);

  CREATE UNIQUE INDEX PK_BICYCLETUBEUSAGE ON BICYCLETUBEUSAGE (SERIALINT, TUBEID);

  CREATE UNIQUE INDEX PK_BIKEPARTS ON BIKEPARTS (SERIALINT, COMPONENTID);

  CREATE UNIQUE INDEX PK_BIKETUBES ON BIKETUBES (SERIALINT, TUBENAME);

  CREATE UNIQUE INDEX PK_CITY ON CITY (CITYID);

  CREATE UNIQUE INDEX PK_COMMONSIZES ON COMMONSIZES (MODELTYPE, FRAMESIZE);

  CREATE UNIQUE INDEX PK_COMPONENT ON COMPONENT (COMPONENTID);

  CREATE UNIQUE INDEX PK_COMPONENTNAME ON COMPONENTNAME (COMPONENTNAME);

  CREATE UNIQUE INDEX PK_CUSTOMER ON CUSTOMER (CUSTOMERID);

  CREATE UNIQUE INDEX PK_CUSTOMERTRANSACTION ON CUSTOMERTRANSACTION (CUSTOMERID, TRANSACTIONDATE);

  CREATE UNIQUE INDEX PK_EMPLOYEE ON EMPLOYEE (EMPLOYEEID);

  CREATE UNIQUE INDEX PK_GROUPCOMPONENTS ON GROUPCOMPONENTS (GROUPID, COMPONENTID);

  CREATE UNIQUE INDEX PK_GROUPO ON GROUPO (COMPONENTGROUPID);

  CREATE UNIQUE INDEX PK_LETTERSTYLE ON LETTERSTYLE (LETTERSTYLE);

  CREATE UNIQUE INDEX PK_MANUFACTURER ON MANUFACTURER (MANUFACTURERID);

  CREATE UNIQUE INDEX PK_MANUFTRANSACTION ON MANUFACTURERTRANSACTION (MANUFACTURERID, TRANSACTIONDATE, REFERENCE);

  CREATE UNIQUE INDEX PK_MODELSIZE ON MODELSIZE (MODELTYPE, MSIZE);

  CREATE UNIQUE INDEX PK_MODELTYPE ON MODELTYPE (MODELTYPE);

  CREATE UNIQUE INDEX PK_PAINT ON PAINT (PAINTID);

  CREATE UNIQUE INDEX PK_PREFERENCE ON PREFERENCE (ITEMNAME);

  CREATE UNIQUE INDEX PK_PURCHASEITEM ON PURCHASEITEM (PURCHASEID, COMPONENTID);

  CREATE UNIQUE INDEX PK_PURCHASEORDER ON PURCHASEORDER (PURCHASEID);

  CREATE UNIQUE INDEX PK_RETAILSTORE ON RETAILSTORE (STOREID);

  CREATE UNIQUE INDEX PK_REVISIONHISTORY ON REVISIONHISTORY (ID);

  CREATE UNIQUE INDEX PK_SAMPLENAME ON SAMPLENAME (ID);

  CREATE UNIQUE INDEX PK_SAMPLESTREET ON SAMPLESTREET (ID);

  CREATE UNIQUE INDEX PK_STATETAXRATE ON STATETAXRATE (STATE);

  CREATE UNIQUE INDEX PK_TEMPDATEMADE ON TEMPDATEMADE (DATEVALUE);

  CREATE UNIQUE INDEX PK_TUBEMATERIAL ON TUBEMATERIAL (TUBEID);

  CREATE UNIQUE INDEX PK_WORKAREA ON WORKAREA (WORKAREA);

  ALTER TABLE BICYCLE ADD CONSTRAINT PK_BICYCLE PRIMARY KEY (SERIALINT);

  ALTER TABLE BICYCLETUBEUSAGE ADD CONSTRAINT PK_BICYCLETUBEUSAGE PRIMARY KEY (SERIALINT, TUBEID);

  ALTER TABLE BIKEPARTS ADD CONSTRAINT PK_BIKEPARTS PRIMARY KEY (SERIALINT, COMPONENTID);

  ALTER TABLE BIKETUBES ADD CHECK (TubeName IN ('Top', 'Seat', 'Rear', 'Chain', 'Down', 'Front'));
  ALTER TABLE BIKETUBES ADD CONSTRAINT PK_BIKETUBES PRIMARY KEY (SERIALINT, TUBENAME);

  ALTER TABLE CITY ADD CONSTRAINT PK_CITY PRIMARY KEY (CITYID);

  ALTER TABLE COMMONSIZES ADD CONSTRAINT PK_COMMONSIZES PRIMARY KEY (MODELTYPE, FRAMESIZE);

  ALTER TABLE COMPONENT ADD CONSTRAINT PK_COMPONENT PRIMARY KEY (COMPONENTID);

  ALTER TABLE COMPONENTNAME ADD CONSTRAINT PK_COMPONENTNAME PRIMARY KEY (COMPONENTNAME);

  ALTER TABLE CUSTOMER ADD CONSTRAINT PK_CUSTOMER PRIMARY KEY (CUSTOMERID);

  ALTER TABLE CUSTOMERTRANSACTION ADD CONSTRAINT PK_CUSTOMERTRANSACTION PRIMARY KEY (CUSTOMERID, TRANSACTIONDATE);

  ALTER TABLE EMPLOYEE ADD CONSTRAINT PK_EMPLOYEE PRIMARY KEY (EMPLOYEEID);

  ALTER TABLE GROUPCOMPONENTS ADD CONSTRAINT PK_GROUPCOMPONENTS PRIMARY KEY (GROUPID, COMPONENTID);

  ALTER TABLE GROUPO ADD CONSTRAINT PK_GROUPO PRIMARY KEY (COMPONENTGROUPID);

  ALTER TABLE LETTERSTYLE ADD CONSTRAINT PK_LETTERSTYLE PRIMARY KEY (LETTERSTYLE);

  ALTER TABLE MANUFACTURER ADD CONSTRAINT PK_MANUFACTURER PRIMARY KEY (MANUFACTURERID);

  ALTER TABLE MANUFACTURERTRANSACTION ADD CONSTRAINT PK_MANUFTRANSACTION PRIMARY KEY (MANUFACTURERID, TRANSACTIONDATE, REFERENCE);

  ALTER TABLE MODELSIZE ADD CONSTRAINT PK_MODELSIZE PRIMARY KEY (MODELTYPE, MSIZE);

  ALTER TABLE MODELTYPE ADD CONSTRAINT PK_MODELTYPE PRIMARY KEY (MODELTYPE);

 ALTER TABLE PAINT ADD CHECK (ColorStyle IN ('Solid', 'Two Color', 'Three Color', 'Special'));
  ALTER TABLE PAINT ADD CONSTRAINT PK_PAINT PRIMARY KEY (PAINTID);

  ALTER TABLE PREFERENCE ADD CONSTRAINT PK_PREFERENCE PRIMARY KEY (ITEMNAME);

  ALTER TABLE PURCHASEITEM ADD CONSTRAINT PK_PURCHASEITEM PRIMARY KEY (PURCHASEID, COMPONENTID);

  ALTER TABLE PURCHASEORDER ADD CONSTRAINT PK_PURCHASEORDER PRIMARY KEY (PURCHASEID);

  ALTER TABLE RETAILSTORE ADD CONSTRAINT PK_RETAILSTORE PRIMARY KEY (STOREID);

  ALTER TABLE REVISIONHISTORY ADD CONSTRAINT PK_REVISIONHISTORY PRIMARY KEY (ID);

  ALTER TABLE SAMPLENAME ADD CHECK (Gender IN ('M', 'F'));
  ALTER TABLE SAMPLENAME ADD CONSTRAINT PK_SAMPLENAME PRIMARY KEY (ID);

  ALTER TABLE SAMPLESTREET ADD CONSTRAINT PK_SAMPLESTREET PRIMARY KEY (ID);

  ALTER TABLE STATETAXRATE ADD CONSTRAINT PK_STATETAXRATE PRIMARY KEY (STATE);

  ALTER TABLE TEMPDATEMADE ADD CONSTRAINT PK_TEMPDATEMADE PRIMARY KEY (DATEVALUE);

  ALTER TABLE TUBEMATERIAL ADD CONSTRAINT PK_TUBEMATERIAL PRIMARY KEY (TUBEID);

  ALTER TABLE WORKAREA ADD CONSTRAINT PK_WORKAREA PRIMARY KEY (WORKAREA);

  ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKEMODELTYPE FOREIGN KEY (MODELTYPE) REFERENCES MODELTYPE (MODELTYPE) ON DELETE CASCADE;
  ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKEEMPLOYEE FOREIGN KEY (EMPLOYEEID) REFERENCES EMPLOYEE (EMPLOYEEID) ON DELETE CASCADE;
  ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKERETAIL FOREIGN KEY (STOREID)	  REFERENCES RETAILSTORE (STOREID) ON DELETE CASCADE;
  ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKECUSTOMER FOREIGN KEY (CUSTOMERID) REFERENCES CUSTOMER (CUSTOMERID) ON DELETE CASCADE;
  ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKELETTER FOREIGN KEY (LETTERSTYLEID) REFERENCES LETTERSTYLE (LETTERSTYLE) ON DELETE CASCADE;
  ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKEPAINT FOREIGN KEY (PAINTID)       REFERENCES PAINT (PAINTID) ON DELETE CASCADE;

  ALTER TABLE BICYCLETUBEUSAGE ADD CONSTRAINT FK_REFERENCE26 FOREIGN KEY (SERIALINT) REFERENCES BICYCLE (SERIALINT) ON DELETE CASCADE;
  ALTER TABLE BICYCLETUBEUSAGE ADD CONSTRAINT FK_REFERENCE27 FOREIGN KEY (TUBEID)  REFERENCES TUBEMATERIAL (TUBEID) ON DELETE CASCADE;

  ALTER TABLE BIKEPARTS ADD CONSTRAINT FK_REFERENCE24 FOREIGN KEY (SERIALINT)  REFERENCES BICYCLE (SERIALINT) ON DELETE CASCADE;
  ALTER TABLE BIKEPARTS ADD CONSTRAINT FK_REFERENCE4 FOREIGN KEY (EMPLOYEEID)  REFERENCES EMPLOYEE (EMPLOYEEID) ON DELETE CASCADE;
  ALTER TABLE BIKEPARTS ADD CONSTRAINT FK_REFERENCE5 FOREIGN KEY (COMPONENTID) REFERENCES COMPONENT (COMPONENTID) ON DELETE CASCADE;

  ALTER TABLE BIKETUBES ADD CONSTRAINT FK_REFERENCE6 FOREIGN KEY (SERIALINT)
	  REFERENCES BICYCLE (SERIALINT) ON DELETE CASCADE;
  ALTER TABLE BIKETUBES ADD CONSTRAINT FK_TUBEMATERIALBIKETUBES FOREIGN KEY (TUBEID)
	  REFERENCES TUBEMATERIAL (TUBEID) ON DELETE CASCADE;

  ALTER TABLE COMPONENT ADD CONSTRAINT FK_REFERENCE FOREIGN KEY (CATEGORY)
	  REFERENCES COMPONENTNAME (COMPONENTNAME) ON DELETE CASCADE;
  ALTER TABLE COMPONENT ADD CONSTRAINT FK_REFERENCE16 FOREIGN KEY (MANUFACTURERID)
	  REFERENCES MANUFACTURER (MANUFACTURERID) ON DELETE CASCADE;

  ALTER TABLE CUSTOMER ADD CONSTRAINT FK_CITYCUSTOMER FOREIGN KEY (CITYID)
	  REFERENCES CITY (CITYID);

  ALTER TABLE CUSTOMERTRANSACTION ADD CONSTRAINT FK_REFERENCE18 FOREIGN KEY (CUSTOMERID)
	  REFERENCES CUSTOMER (CUSTOMERID) ON DELETE CASCADE;

  ALTER TABLE EMPLOYEE ADD CONSTRAINT FK_CITYEMPLOYEE FOREIGN KEY (CITYID)
	  REFERENCES CITY (CITYID);

  ALTER TABLE GROUPCOMPONENTS ADD CONSTRAINT FK_REFERENCE14 FOREIGN KEY (COMPONENTID)
	  REFERENCES COMPONENT (COMPONENTID) ON DELETE CASCADE;
  ALTER TABLE GROUPCOMPONENTS ADD CONSTRAINT FK_REFERENCE15 FOREIGN KEY (GROUPID)
	  REFERENCES GROUPO (COMPONENTGROUPID) ON DELETE CASCADE;

  ALTER TABLE MANUFACTURER ADD CONSTRAINT FK_CITYMANUFACTURER FOREIGN KEY (CITYID)
	  REFERENCES CITY (CITYID);

  ALTER TABLE MANUFACTURERTRANSACTION ADD CONSTRAINT FK_MANUFTRANS FOREIGN KEY (MANUFACTURERID)
	  REFERENCES MANUFACTURER (MANUFACTURERID) ON DELETE CASCADE;

  ALTER TABLE MODELSIZE ADD CONSTRAINT FK_MODELTYPE FOREIGN KEY (MODELTYPE)
	  REFERENCES MODELTYPE (MODELTYPE) ON DELETE CASCADE;

  ALTER TABLE PURCHASEITEM ADD CONSTRAINT FK_REFERENCE20 FOREIGN KEY (PURCHASEID)
	  REFERENCES PURCHASEORDER (PURCHASEID) ON DELETE CASCADE;
  ALTER TABLE PURCHASEITEM ADD CONSTRAINT FK_REFERENCE21 FOREIGN KEY (COMPONENTID)
	  REFERENCES COMPONENT (COMPONENTID) ON DELETE CASCADE;

  ALTER TABLE PURCHASEORDER ADD CONSTRAINT FK_REFERENCE22 FOREIGN KEY (MANUFACTURERID)
	  REFERENCES MANUFACTURER (MANUFACTURERID) ON DELETE CASCADE;
  ALTER TABLE PURCHASEORDER ADD CONSTRAINT FK_REFERENCE23 FOREIGN KEY (EMPLOYEEID)
	  REFERENCES EMPLOYEE (EMPLOYEEID) ON DELETE CASCADE;

  ALTER TABLE RETAILSTORE ADD CONSTRAINT FK_CITYRETAILSTORE FOREIGN KEY (CITYID)
	  REFERENCES CITY (CITYID);
