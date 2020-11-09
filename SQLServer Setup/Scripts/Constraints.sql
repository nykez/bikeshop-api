﻿   SET FOREIGN_KEY_CHECKS=0;
   ALTER TABLE CUSTOMER ADD CONSTRAINT FK_CITYCUSTOMER FOREIGN KEY (CITYID) REFERENCES CITY (CITYID) ON DELETE CASCADE;
   ALTER TABLE EMPLOYEE ADD CONSTRAINT FK_CITYEMPLOYEE FOREIGN KEY (CITYID) REFERENCES CITY (CITYID) ON DELETE CASCADE;
   ALTER TABLE RETAILSTORE ADD CONSTRAINT FK_CITYRETAILSTORE FOREIGN KEY (CITYID) REFERENCES CITY (CITYID) ON DELETE CASCADE;
   ALTER TABLE MANUFACTURER ADD CONSTRAINT FK_CITYMANUFACTURER FOREIGN KEY (CITYID) REFERENCES CITY (CITYID) ON DELETE CASCADE;
   ALTER TABLE COMPONENT ADD CONSTRAINT FK_REFERENCE FOREIGN KEY (CATEGORY) REFERENCES COMPONENTNAME (COMPONENTNAME) ON DELETE CASCADE;
   ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKECUSTOMER FOREIGN KEY (CUSTOMERID) REFERENCES CUSTOMER (CUSTOMERID) ON DELETE CASCADE;
   ALTER TABLE CUSTOMERTRANSACTION ADD CONSTRAINT FK_REFERENCE18 FOREIGN KEY (CUSTOMERID) REFERENCES CUSTOMER (CUSTOMERID) ON DELETE CASCADE;
   ALTER TABLE GROUPCOMPONENTS ADD CONSTRAINT FK_REFERENCE15 FOREIGN KEY (GROUPID) REFERENCES GROUPO (COMPONENTGROUPID) ON DELETE CASCADE;
   ALTER TABLE COMPONENT ADD CONSTRAINT FK_REFERENCE16 FOREIGN KEY (MANUFACTURERID) REFERENCES MANUFACTURER (MANUFACTURERID) ON DELETE CASCADE;
   ALTER TABLE MANUFACTURERTRANSACTION ADD CONSTRAINT FK_MANUFTRANS FOREIGN KEY (MANUFACTURERID) REFERENCES MANUFACTURER (MANUFACTURERID) ON DELETE CASCADE;
   ALTER TABLE PURCHASEORDER ADD CONSTRAINT FK_REFERENCE22 FOREIGN KEY (MANUFACTURERID) REFERENCES MANUFACTURER (MANUFACTURERID) ON DELETE CASCADE;
   ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKEMODELTYPE FOREIGN KEY (MODELTYPE) REFERENCES MODELTYPE (MODELTYPE) ON DELETE CASCADE;
   ALTER TABLE MODELSIZE ADD CONSTRAINT FK_MODELTYPE FOREIGN KEY (MODELTYPE) REFERENCES MODELTYPE (MODELTYPE) ON DELETE CASCADE;
   ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKEPAINT FOREIGN KEY (PAINTID)       REFERENCES PAINT (PAINTID) ON DELETE CASCADE;
   ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKELETTER FOREIGN KEY (LETTERSTYLEID) REFERENCES LETTERSTYLE (LETTERSTYLE) ON DELETE CASCADE;
   ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKERETAIL FOREIGN KEY (STOREID)	  REFERENCES RETAILSTORE (STOREID) ON DELETE CASCADE;
   ALTER TABLE BICYCLE ADD CONSTRAINT FK_BIKEEMPLOYEE FOREIGN KEY (EMPLOYEEID) REFERENCES EMPLOYEE (EMPLOYEEID) ON DELETE CASCADE;
   ALTER TABLE BICYCLETUBEUSAGE ADD CONSTRAINT FK_REFERENCE27 FOREIGN KEY (TUBEID)  REFERENCES TUBEMATERIAL (TUBEID) ON DELETE CASCADE;
   ALTER TABLE BICYCLETUBEUSAGE ADD CONSTRAINT FK_REFERENCE26 FOREIGN KEY (SERIALNUMBER) REFERENCES BICYCLE (SERIALNUMBER) ON DELETE CASCADE;
   ALTER TABLE PURCHASEORDER ADD CONSTRAINT FK_REFERENCE23 FOREIGN KEY (EMPLOYEEID) REFERENCES EMPLOYEE (EMPLOYEEID) ON DELETE CASCADE;
   ALTER TABLE BIKEPARTS ADD CONSTRAINT FK_REFERENCE24 FOREIGN KEY (SERIALNUMBER)  REFERENCES BICYCLE (SERIALNUMBER) ON DELETE CASCADE;
   ALTER TABLE BIKEPARTS ADD CONSTRAINT FK_REFERENCE4 FOREIGN KEY (EMPLOYEEID)  REFERENCES EMPLOYEE (EMPLOYEEID) ON DELETE CASCADE;
   ALTER TABLE BIKEPARTS ADD CONSTRAINT FK_REFERENCE5 FOREIGN KEY (COMPONENTID) REFERENCES COMPONENT (COMPONENTID) ON DELETE CASCADE;
   ALTER TABLE BIKETUBES ADD CONSTRAINT FK_REFERENCE6 FOREIGN KEY (SERIALNUMBER) REFERENCES BICYCLE (SERIALNUMBER) ON DELETE CASCADE;
   ALTER TABLE BIKETUBES ADD CONSTRAINT FK_TUBEMATERIALBIKETUBES FOREIGN KEY (TUBEID) REFERENCES TUBEMATERIAL (TUBEID) ON DELETE CASCADE;
   ALTER TABLE GROUPCOMPONENTS ADD CONSTRAINT FK_REFERENCE14 FOREIGN KEY (COMPONENTID) REFERENCES COMPONENT (COMPONENTID) ON DELETE CASCADE;
   ALTER TABLE PURCHASEITEM ADD CONSTRAINT FK_REFERENCE20 FOREIGN KEY (PURCHASEID) REFERENCES PURCHASEORDER (PURCHASEID) ON DELETE CASCADE;
   ALTER TABLE PURCHASEITEM ADD CONSTRAINT FK_REFERENCE21 FOREIGN KEY (COMPONENTID) REFERENCES COMPONENT (COMPONENTID) ON DELETE CASCADE;
   SET FOREIGN_KEY_CHECKS=1;