using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DatabaseApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    CITYID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ZIPCODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CITY = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    STATE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AREACODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    POPULATION1990 = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    POPULATION1980 = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    COUNTRY = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LATITUDE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    LONGITUDE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    POPULATIONCDF = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.CITYID);
                });

            migrationBuilder.CreateTable(
                name: "COMMONSIZES",
                columns: table => new
                {
                    MODELTYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FRAMESIZE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.MODELTYPE, x.FRAMESIZE });
                });

            migrationBuilder.CreateTable(
                name: "COMPONENTNAME",
                columns: table => new
                {
                    COMPONENTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ASSEMBLYORDER = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.COMPONENTNAME);
                });

            migrationBuilder.CreateTable(
                name: "GROUPO",
                columns: table => new
                {
                    COMPONENTGROUPID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GROUPNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BIKETYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    YEAR = table.Column<int>(nullable: true),
                    ENDYEAR = table.Column<int>(nullable: true),
                    WEIGHT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.COMPONENTGROUPID);
                });

            migrationBuilder.CreateTable(
                name: "LETTERSTYLE",
                columns: table => new
                {
                    LETTERSTYLE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.LETTERSTYLE);
                });

            migrationBuilder.CreateTable(
                name: "MODELTYPE",
                columns: table => new
                {
                    MODELTYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    COMPONENTID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MODELTYPE);
                });

            migrationBuilder.CreateTable(
                name: "PAINT",
                columns: table => new
                {
                    PAINTID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    COLORNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    COLORSTYLE = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValueSql: "'Solid'"),
                    COLORLIST = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DATEINTRODUCED = table.Column<DateTime>(type: "date", nullable: true),
                    DATEDISCONTINUED = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAINT", x => x.PAINTID);
                });

            migrationBuilder.CreateTable(
                name: "PREFERENCE",
                columns: table => new
                {
                    ITEMNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    VALUE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    DATECHANGED = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ITEMNAME);
                });

            migrationBuilder.CreateTable(
                name: "REVISIONHISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VERSION = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CHANGEDATE = table.Column<DateTime>(type: "date", nullable: true),
                    NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    REVISIONCOMMENTS = table.Column<string>(unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REVISIONHISTORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAMPLENAME",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LASTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FIRSTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    GENDER = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAMPLENAME", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAMPLESTREET",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BASEADDRESS = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAMPLESTREET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STATETAXRATE",
                columns: table => new
                {
                    STATE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TAXRATE = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.STATE);
                });

            migrationBuilder.CreateTable(
                name: "TEMPDATEMADE",
                columns: table => new
                {
                    DATEVALUE = table.Column<DateTime>(type: "date", nullable: false),
                    MADECOUNT = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.DATEVALUE);
                });

            migrationBuilder.CreateTable(
                name: "TUBEMATERIAL",
                columns: table => new
                {
                    TUBEID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MATERIAL = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DIAMETER = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    THICKNESS = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    ROUNDNESS = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    WEIGHT = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    STIFFNESS = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    LISTPRICE = table.Column<int>(nullable: true, defaultValueSql: "'1'"),
                    CONSTRUCTION = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValueSql: "'Bonded'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TUBEID);
                });

            migrationBuilder.CreateTable(
                name: "WORKAREA",
                columns: table => new
                {
                    WORKAREA = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.WORKAREA);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUSTOMERID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PHONE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FIRSTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LASTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ZIPCODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CITYID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    BALANCEDUE = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUSTOMERID);
                    table.ForeignKey(
                        name: "FK_CITYCUSTOMER",
                        column: x => x.CITYID,
                        principalTable: "CITY",
                        principalColumn: "CITYID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EMPLOYEEID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TAXPAYERID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LASTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FIRSTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    HOMEPHONE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ZIPCODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CITYID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    DATEHIRED = table.Column<DateTime>(type: "date", nullable: true),
                    DATERELEASED = table.Column<DateTime>(type: "date", nullable: true),
                    CURRENTMANAGER = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SALARYGRADE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SALARY = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    TITLE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    WORKAREA = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.EMPLOYEEID);
                    table.ForeignKey(
                        name: "FK_CITYEMPLOYEE",
                        column: x => x.CITYID,
                        principalTable: "CITY",
                        principalColumn: "CITYID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MANUFACTURER",
                columns: table => new
                {
                    MANUFACTURERID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MANUFACTURERNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CONTACTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PHONE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ZIPCODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CITYID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    BALANCEDUE = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUFACTURER", x => x.MANUFACTURERID);
                    table.ForeignKey(
                        name: "FK_CITYMANUFACTURER",
                        column: x => x.CITYID,
                        principalTable: "CITY",
                        principalColumn: "CITYID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RETAILSTORE",
                columns: table => new
                {
                    STOREID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    STORENAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PHONE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CONTACTFIRSTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CONTACTLASTNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ZIPCODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CITYID = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.STOREID);
                    table.ForeignKey(
                        name: "FK_CITYRETAILSTORE",
                        column: x => x.CITYID,
                        principalTable: "CITY",
                        principalColumn: "CITYID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MODELSIZE",
                columns: table => new
                {
                    MODELTYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    MSIZE = table.Column<int>(nullable: false),
                    TOPTUBE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    CHAINSTAY = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    TOTALLENGTH = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    GROUNDCLEARANCE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    HEADTUBEANGLE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SEATTUBEANGLE = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.MODELTYPE, x.MSIZE });
                    table.ForeignKey(
                        name: "FK_MODELTYPE",
                        column: x => x.MODELTYPE,
                        principalTable: "MODELTYPE",
                        principalColumn: "MODELTYPE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERTRANSACTION",
                columns: table => new
                {
                    CUSTOMERID = table.Column<int>(nullable: false),
                    TRANSACTIONDATE = table.Column<DateTime>(type: "date", nullable: false),
                    EMPLOYEEID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    AMOUNT = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    REFERENCE = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.CUSTOMERID, x.TRANSACTIONDATE });
                    table.ForeignKey(
                        name: "FK_REFERENCE18",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMERID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMPONENT",
                columns: table => new
                {
                    COMPONENTID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MANUFACTURERID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    PRODUCTINT = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ROAD = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CATEGORY = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LENGTH = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    HEIGHT = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    WIDTH = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    WEIGHT = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    YEAR = table.Column<int>(nullable: true),
                    ENDYEAR = table.Column<int>(nullable: true),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LISTPRICE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    ESTIMATEDCOST = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    QUANTITYONHAND = table.Column<int>(nullable: true, defaultValueSql: "'10'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPONENT", x => x.COMPONENTID);
                    table.ForeignKey(
                        name: "FK_REFERENCE",
                        column: x => x.CATEGORY,
                        principalTable: "COMPONENTNAME",
                        principalColumn: "COMPONENTNAME",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REFERENCE16",
                        column: x => x.MANUFACTURERID,
                        principalTable: "MANUFACTURER",
                        principalColumn: "MANUFACTURERID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MANUFACTURERTRANSACTION",
                columns: table => new
                {
                    MANUFACTURERID = table.Column<int>(nullable: false),
                    TRANSACTIONDATE = table.Column<DateTime>(type: "date", nullable: false),
                    REFERENCE = table.Column<int>(nullable: false),
                    EMPLOYEEID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    AMOUNT = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.MANUFACTURERID, x.TRANSACTIONDATE, x.REFERENCE });
                    table.ForeignKey(
                        name: "FK_MANUFTRANS",
                        column: x => x.MANUFACTURERID,
                        principalTable: "MANUFACTURER",
                        principalColumn: "MANUFACTURERID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASEORDER",
                columns: table => new
                {
                    PURCHASEID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EMPLOYEEID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    MANUFACTURERID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    TOTALLIST = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SHIPPINGCOST = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    DISCOUNT = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    ORDERDATE = table.Column<DateTime>(type: "date", nullable: true),
                    RECEIVEDATE = table.Column<DateTime>(type: "date", nullable: true),
                    AMOUNTDUE = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PURCHASEID);
                    table.ForeignKey(
                        name: "FK_REFERENCE23",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMPLOYEEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REFERENCE22",
                        column: x => x.MANUFACTURERID,
                        principalTable: "MANUFACTURER",
                        principalColumn: "MANUFACTURERID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BICYCLE",
                columns: table => new
                {
                    SERIALNUMBER = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CUSTOMERID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    MODELTYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PAINTID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    FRAMESIZE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    ORDERDATE = table.Column<DateTime>(type: "date", nullable: true),
                    STARTDATE = table.Column<DateTime>(type: "date", nullable: true),
                    SHIPDATE = table.Column<DateTime>(type: "date", nullable: true),
                    SHIPEMPLOYEE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    FRAMEASSEMBLER = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    PAINTER = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    CONSTRUCTION = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValueSql: "'Bonded'"),
                    WATERBOTTLEBRAZEONS = table.Column<int>(nullable: true, defaultValueSql: "'4'"),
                    CUSTOMNAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LETTERSTYLEID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    STOREID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    EMPLOYEEID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    TOPTUBE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    CHAINSTAY = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    HEADTUBEANGLE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SEATTUBEANGLE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    LISTPRICE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SALEPRICE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SALESTAX = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    SALESTATE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SHIPPRICE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    FRAMEPRICE = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    COMPONENTLIST = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SERIALNUMBER);
                    table.ForeignKey(
                        name: "FK_BIKECUSTOMER",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMERID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIKEEMPLOYEE",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMPLOYEEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIKELETTER",
                        column: x => x.LETTERSTYLEID,
                        principalTable: "LETTERSTYLE",
                        principalColumn: "LETTERSTYLE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIKEMODELTYPE",
                        column: x => x.MODELTYPE,
                        principalTable: "MODELTYPE",
                        principalColumn: "MODELTYPE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIKEPAINT",
                        column: x => x.PAINTID,
                        principalTable: "PAINT",
                        principalColumn: "PAINTID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIKERETAIL",
                        column: x => x.STOREID,
                        principalTable: "RETAILSTORE",
                        principalColumn: "STOREID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GROUPCOMPONENTS",
                columns: table => new
                {
                    GROUPID = table.Column<int>(nullable: false),
                    COMPONENTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.GROUPID, x.COMPONENTID });
                    table.ForeignKey(
                        name: "FK_REFERENCE14",
                        column: x => x.COMPONENTID,
                        principalTable: "COMPONENT",
                        principalColumn: "COMPONENTID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REFERENCE15",
                        column: x => x.GROUPID,
                        principalTable: "GROUPO",
                        principalColumn: "COMPONENTGROUPID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASEITEM",
                columns: table => new
                {
                    PURCHASEID = table.Column<int>(nullable: false),
                    COMPONENTID = table.Column<int>(nullable: false),
                    PRICEPAID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    QUANTITY = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    QUANTITYRECEIVED = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.PURCHASEID, x.COMPONENTID });
                    table.ForeignKey(
                        name: "FK_REFERENCE21",
                        column: x => x.COMPONENTID,
                        principalTable: "COMPONENT",
                        principalColumn: "COMPONENTID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REFERENCE20",
                        column: x => x.PURCHASEID,
                        principalTable: "PURCHASEORDER",
                        principalColumn: "PURCHASEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BICYCLETUBEUSAGE",
                columns: table => new
                {
                    SERIALNUMBER = table.Column<int>(nullable: false),
                    TUBEID = table.Column<int>(nullable: false),
                    QUANTITY = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.SERIALNUMBER, x.TUBEID });
                    table.ForeignKey(
                        name: "FK_REFERENCE26",
                        column: x => x.SERIALNUMBER,
                        principalTable: "BICYCLE",
                        principalColumn: "SERIALNUMBER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REFERENCE27",
                        column: x => x.TUBEID,
                        principalTable: "TUBEMATERIAL",
                        principalColumn: "TUBEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BIKEPARTS",
                columns: table => new
                {
                    SERIALNUMBER = table.Column<int>(nullable: false),
                    COMPONENTID = table.Column<int>(nullable: false),
                    SUBSTITUTEID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    LOCATION = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    QUANTITY = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    DATEINSTALLED = table.Column<DateTime>(type: "date", nullable: true),
                    EMPLOYEEID = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.SERIALNUMBER, x.COMPONENTID });
                    table.ForeignKey(
                        name: "FK_REFERENCE5",
                        column: x => x.COMPONENTID,
                        principalTable: "COMPONENT",
                        principalColumn: "COMPONENTID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REFERENCE4",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMPLOYEEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REFERENCE24",
                        column: x => x.SERIALNUMBER,
                        principalTable: "BICYCLE",
                        principalColumn: "SERIALNUMBER",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BIKETUBES",
                columns: table => new
                {
                    SERIALNUMBER = table.Column<int>(nullable: false),
                    TUBENAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TUBEID = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    LENGTH = table.Column<int>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.SERIALNUMBER, x.TUBENAME });
                    table.ForeignKey(
                        name: "FK_REFERENCE6",
                        column: x => x.SERIALNUMBER,
                        principalTable: "BICYCLE",
                        principalColumn: "SERIALNUMBER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TUBEMATERIALBIKETUBES",
                        column: x => x.TUBEID,
                        principalTable: "TUBEMATERIAL",
                        principalColumn: "TUBEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_BIKECUSTOMER",
                table: "BICYCLE",
                column: "CUSTOMERID");

            migrationBuilder.CreateIndex(
                name: "FK_BIKEEMPLOYEE",
                table: "BICYCLE",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "FK_BIKELETTER",
                table: "BICYCLE",
                column: "LETTERSTYLEID");

            migrationBuilder.CreateIndex(
                name: "FK_BIKEMODELTYPE",
                table: "BICYCLE",
                column: "MODELTYPE");

            migrationBuilder.CreateIndex(
                name: "FK_BIKEPAINT",
                table: "BICYCLE",
                column: "PAINTID");

            migrationBuilder.CreateIndex(
                name: "PK_BICYCLE",
                table: "BICYCLE",
                column: "SERIALNUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_BIKERETAIL",
                table: "BICYCLE",
                column: "STOREID");

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE27",
                table: "BICYCLETUBEUSAGE",
                column: "TUBEID");

            migrationBuilder.CreateIndex(
                name: "PK_BICYCLETUBEUSAGE",
                table: "BICYCLETUBEUSAGE",
                columns: new[] { "SERIALNUMBER", "TUBEID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE5",
                table: "BIKEPARTS",
                column: "COMPONENTID");

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE4",
                table: "BIKEPARTS",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "PK_BIKEPARTS",
                table: "BIKEPARTS",
                columns: new[] { "SERIALNUMBER", "COMPONENTID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_TUBEMATERIALBIKETUBES",
                table: "BIKETUBES",
                column: "TUBEID");

            migrationBuilder.CreateIndex(
                name: "PK_BIKETUBES",
                table: "BIKETUBES",
                columns: new[] { "SERIALNUMBER", "TUBENAME" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_CITY",
                table: "CITY",
                column: "CITYID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_COMMONSIZES",
                table: "COMMONSIZES",
                columns: new[] { "MODELTYPE", "FRAMESIZE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE",
                table: "COMPONENT",
                column: "CATEGORY");

            migrationBuilder.CreateIndex(
                name: "PK_COMPONENT",
                table: "COMPONENT",
                column: "COMPONENTID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE16",
                table: "COMPONENT",
                column: "MANUFACTURERID");

            migrationBuilder.CreateIndex(
                name: "PK_COMPONENTNAME",
                table: "COMPONENTNAME",
                column: "COMPONENTNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_CITYCUSTOMER",
                table: "CUSTOMER",
                column: "CITYID");

            migrationBuilder.CreateIndex(
                name: "PK_CUSTOMER",
                table: "CUSTOMER",
                column: "CUSTOMERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_CUSTOMERTRANSACTION",
                table: "CUSTOMERTRANSACTION",
                columns: new[] { "CUSTOMERID", "TRANSACTIONDATE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_CITYEMPLOYEE",
                table: "EMPLOYEE",
                column: "CITYID");

            migrationBuilder.CreateIndex(
                name: "PK_EMPLOYEE",
                table: "EMPLOYEE",
                column: "EMPLOYEEID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE14",
                table: "GROUPCOMPONENTS",
                column: "COMPONENTID");

            migrationBuilder.CreateIndex(
                name: "PK_GROUPCOMPONENTS",
                table: "GROUPCOMPONENTS",
                columns: new[] { "GROUPID", "COMPONENTID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_GROUPO",
                table: "GROUPO",
                column: "COMPONENTGROUPID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_LETTERSTYLE",
                table: "LETTERSTYLE",
                column: "LETTERSTYLE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_CITYMANUFACTURER",
                table: "MANUFACTURER",
                column: "CITYID");

            migrationBuilder.CreateIndex(
                name: "PK_MANUFACTURER",
                table: "MANUFACTURER",
                column: "MANUFACTURERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_MANUFTRANSACTION",
                table: "MANUFACTURERTRANSACTION",
                columns: new[] { "MANUFACTURERID", "TRANSACTIONDATE", "REFERENCE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_MODELSIZE",
                table: "MODELSIZE",
                columns: new[] { "MODELTYPE", "MSIZE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_MODELTYPE",
                table: "MODELTYPE",
                column: "MODELTYPE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_PAINT",
                table: "PAINT",
                column: "PAINTID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_PREFERENCE",
                table: "PREFERENCE",
                column: "ITEMNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE21",
                table: "PURCHASEITEM",
                column: "COMPONENTID");

            migrationBuilder.CreateIndex(
                name: "PK_PURCHASEITEM",
                table: "PURCHASEITEM",
                columns: new[] { "PURCHASEID", "COMPONENTID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE23",
                table: "PURCHASEORDER",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "FK_REFERENCE22",
                table: "PURCHASEORDER",
                column: "MANUFACTURERID");

            migrationBuilder.CreateIndex(
                name: "PK_PURCHASEORDER",
                table: "PURCHASEORDER",
                column: "PURCHASEID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_CITYRETAILSTORE",
                table: "RETAILSTORE",
                column: "CITYID");

            migrationBuilder.CreateIndex(
                name: "PK_RETAILSTORE",
                table: "RETAILSTORE",
                column: "STOREID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_REVISIONHISTORY",
                table: "REVISIONHISTORY",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_SAMPLENAME",
                table: "SAMPLENAME",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_SAMPLESTREET",
                table: "SAMPLESTREET",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_STATETAXRATE",
                table: "STATETAXRATE",
                column: "STATE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_TEMPDATEMADE",
                table: "TEMPDATEMADE",
                column: "DATEVALUE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_TUBEMATERIAL",
                table: "TUBEMATERIAL",
                column: "TUBEID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_WORKAREA",
                table: "WORKAREA",
                column: "WORKAREA",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BICYCLETUBEUSAGE");

            migrationBuilder.DropTable(
                name: "BIKEPARTS");

            migrationBuilder.DropTable(
                name: "BIKETUBES");

            migrationBuilder.DropTable(
                name: "COMMONSIZES");

            migrationBuilder.DropTable(
                name: "CUSTOMERTRANSACTION");

            migrationBuilder.DropTable(
                name: "GROUPCOMPONENTS");

            migrationBuilder.DropTable(
                name: "MANUFACTURERTRANSACTION");

            migrationBuilder.DropTable(
                name: "MODELSIZE");

            migrationBuilder.DropTable(
                name: "PREFERENCE");

            migrationBuilder.DropTable(
                name: "PURCHASEITEM");

            migrationBuilder.DropTable(
                name: "REVISIONHISTORY");

            migrationBuilder.DropTable(
                name: "SAMPLENAME");

            migrationBuilder.DropTable(
                name: "SAMPLESTREET");

            migrationBuilder.DropTable(
                name: "STATETAXRATE");

            migrationBuilder.DropTable(
                name: "TEMPDATEMADE");

            migrationBuilder.DropTable(
                name: "WORKAREA");

            migrationBuilder.DropTable(
                name: "BICYCLE");

            migrationBuilder.DropTable(
                name: "TUBEMATERIAL");

            migrationBuilder.DropTable(
                name: "GROUPO");

            migrationBuilder.DropTable(
                name: "COMPONENT");

            migrationBuilder.DropTable(
                name: "PURCHASEORDER");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "LETTERSTYLE");

            migrationBuilder.DropTable(
                name: "MODELTYPE");

            migrationBuilder.DropTable(
                name: "PAINT");

            migrationBuilder.DropTable(
                name: "RETAILSTORE");

            migrationBuilder.DropTable(
                name: "COMPONENTNAME");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "MANUFACTURER");

            migrationBuilder.DropTable(
                name: "CITY");
        }
    }
}
