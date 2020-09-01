using System;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DatabaseApi.Models;

namespace DatabaseApi.Context
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bicycle> Bicycle { get; set; }
        public virtual DbSet<Bicycletubeusage> Bicycletubeusage { get; set; }
        public virtual DbSet<Bikeparts> Bikeparts { get; set; }
        public virtual DbSet<Biketubes> Biketubes { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Commonsizes> Commonsizes { get; set; }
        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<Componentname> Componentname { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customertransaction> Customertransaction { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Groupcomponents> Groupcomponents { get; set; }
        public virtual DbSet<Groupo> Groupo { get; set; }
        public virtual DbSet<Letterstyle> Letterstyle { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Manufacturertransaction> Manufacturertransaction { get; set; }
        public virtual DbSet<Modelsize> Modelsize { get; set; }
        public virtual DbSet<Modeltype> Modeltype { get; set; }
        public virtual DbSet<Paint> Paint { get; set; }
        public virtual DbSet<Preference> Preference { get; set; }
        public virtual DbSet<Purchaseitem> Purchaseitem { get; set; }
        public virtual DbSet<Purchaseorder> Purchaseorder { get; set; }
        public virtual DbSet<Retailstore> Retailstore { get; set; }
        public virtual DbSet<Revisionhistory> Revisionhistory { get; set; }
        public virtual DbSet<Samplename> Samplename { get; set; }
        public virtual DbSet<Samplestreet> Samplestreet { get; set; }
        public virtual DbSet<Statetaxrate> Statetaxrate { get; set; }
        public virtual DbSet<Tempdatemade> Tempdatemade { get; set; }
        public virtual DbSet<Tubematerial> Tubematerial { get; set; }
        public virtual DbSet<Workarea> Workarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("User Id=bike_shop;Password=root_password;Data Source=192.168.0.142:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "BIKE_SHOP");

            modelBuilder.Entity<Bicycle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BICYCLE");

                entity.HasIndex(e => e.Serialnumber)
                    .HasName("PK_BICYCLE")
                    .IsUnique();

                entity.Property(e => e.Chainstay)
                    .HasColumnName("CHAINSTAY")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Componentlist)
                    .HasColumnName("COMPONENTLIST")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Construction)
                    .HasColumnName("CONSTRUCTION")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Bonded'");

                entity.Property(e => e.Customerid)
                    .HasColumnName("CUSTOMERID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Customname)
                    .HasColumnName("CUSTOMNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Frameassembler)
                    .HasColumnName("FRAMEASSEMBLER")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Frameprice)
                    .HasColumnName("FRAMEPRICE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Framesize)
                    .HasColumnName("FRAMESIZE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Headtubeangle)
                    .HasColumnName("HEADTUBEANGLE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Letterstyleid)
                    .HasColumnName("LETTERSTYLEID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Listprice)
                    .HasColumnName("LISTPRICE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modeltype)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Orderdate)
                    .HasColumnName("ORDERDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Painter)
                    .HasColumnName("PAINTER")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Paintid)
                    .HasColumnName("PAINTID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Saleprice)
                    .HasColumnName("SALEPRICE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Salestate)
                    .HasColumnName("SALESTATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salestax)
                    .HasColumnName("SALESTAX")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Seattubeangle)
                    .HasColumnName("SEATTUBEANGLE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Serialnumber)
                    .HasColumnName("SERIALNUMBER")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Shipdate)
                    .HasColumnName("SHIPDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Shipemployee)
                    .HasColumnName("SHIPEMPLOYEE")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Shipprice)
                    .HasColumnName("SHIPPRICE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Startdate)
                    .HasColumnName("STARTDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Storeid)
                    .HasColumnName("STOREID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Toptube)
                    .HasColumnName("TOPTUBE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Waterbottlebrazeons)
                    .HasColumnName("WATERBOTTLEBRAZEONS")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("4");
            });

            modelBuilder.Entity<Bicycletubeusage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BICYCLETUBEUSAGE");

                entity.HasIndex(e => new { e.Serialnumber, e.Tubeid })
                    .HasName("PK_BICYCLETUBEUSAGE")
                    .IsUnique();

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Serialnumber)
                    .HasColumnName("SERIALNUMBER")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tubeid)
                    .HasColumnName("TUBEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Bikeparts>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BIKEPARTS");

                entity.HasIndex(e => new { e.Serialnumber, e.Componentid })
                    .HasName("PK_BIKEPARTS")
                    .IsUnique();

                entity.Property(e => e.Componentid)
                    .HasColumnName("COMPONENTID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dateinstalled)
                    .HasColumnName("DATEINSTALLED")
                    .HasColumnType("DATE");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Serialnumber)
                    .HasColumnName("SERIALNUMBER")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Substituteid)
                    .HasColumnName("SUBSTITUTEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Biketubes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BIKETUBES");

                entity.HasIndex(e => new { e.Serialnumber, e.Tubename })
                    .HasName("PK_BIKETUBES")
                    .IsUnique();

                entity.Property(e => e.Length)
                    .HasColumnName("LENGTH")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Serialnumber)
                    .HasColumnName("SERIALNUMBER")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tubeid)
                    .HasColumnName("TUBEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tubename)
                    .HasColumnName("TUBENAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CITY");

                entity.HasIndex(e => e.Cityid)
                    .HasName("PK_CITY")
                    .IsUnique();

                entity.Property(e => e.Areacode)
                    .HasColumnName("AREACODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City1)
                    .HasColumnName("CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnName("LATITUDE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Population1980)
                    .HasColumnName("POPULATION1980")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Population1990)
                    .HasColumnName("POPULATION1990")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Populationcdf)
                    .HasColumnName("POPULATIONCDF")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Commonsizes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COMMONSIZES");

                entity.HasIndex(e => new { e.Modeltype, e.Framesize })
                    .HasName("PK_COMMONSIZES")
                    .IsUnique();

                entity.Property(e => e.Framesize)
                    .HasColumnName("FRAMESIZE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Modeltype)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COMPONENT");

                entity.HasIndex(e => e.Componentid)
                    .HasName("PK_COMPONENT")
                    .IsUnique();

                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Componentid)
                    .HasColumnName("COMPONENTID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endyear)
                    .HasColumnName("ENDYEAR")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Estimatedcost)
                    .HasColumnName("ESTIMATEDCOST")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Height)
                    .HasColumnName("HEIGHT")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Length)
                    .HasColumnName("LENGTH")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Listprice)
                    .HasColumnName("LISTPRICE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Manufacturerid)
                    .HasColumnName("MANUFACTURERID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Productnumber)
                    .HasColumnName("PRODUCTNUMBER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantityonhand)
                    .HasColumnName("QUANTITYONHAND")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"10
   ");

                entity.Property(e => e.Road)
                    .HasColumnName("ROAD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Width)
                    .HasColumnName("WIDTH")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Year)
                    .HasColumnName("YEAR")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<Componentname>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COMPONENTNAME");

                entity.HasIndex(e => e.Componentname1)
                    .HasName("PK_COMPONENTNAME")
                    .IsUnique();

                entity.Property(e => e.Assemblyorder)
                    .HasColumnName("ASSEMBLYORDER")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Componentname1)
                    .HasColumnName("COMPONENTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMER");

                entity.HasIndex(e => e.Customerid)
                    .HasName("PK_CUSTOMER")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Balancedue)
                    .HasColumnName("BALANCEDUE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Customerid)
                    .HasColumnName("CUSTOMERID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customertransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMERTRANSACTION");

                entity.HasIndex(e => new { e.Customerid, e.Transactiondate })
                    .HasName("PK_CUSTOMERTRANSACTION")
                    .IsUnique();

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Customerid)
                    .HasColumnName("CUSTOMERID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnName("REFERENCE")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Transactiondate)
                    .HasColumnName("TRANSACTIONDATE")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMPLOYEE");

                entity.HasIndex(e => e.Employeeid)
                    .HasName("PK_EMPLOYEE")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Currentmanager)
                    .HasColumnName("CURRENTMANAGER")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Datehired)
                    .HasColumnName("DATEHIRED")
                    .HasColumnType("DATE");

                entity.Property(e => e.Datereleased)
                    .HasColumnName("DATERELEASED")
                    .HasColumnType("DATE");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Homephone)
                    .HasColumnName("HOMEPHONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Salarygrade)
                    .HasColumnName("SALARYGRADE")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Taxpayerid)
                    .HasColumnName("TAXPAYERID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Workarea)
                    .HasColumnName("WORKAREA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Groupcomponents>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GROUPCOMPONENTS");

                entity.HasIndex(e => new { e.Groupid, e.Componentid })
                    .HasName("PK_GROUPCOMPONENTS")
                    .IsUnique();

                entity.Property(e => e.Componentid)
                    .HasColumnName("COMPONENTID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Groupid)
                    .HasColumnName("GROUPID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Groupo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GROUPO");

                entity.HasIndex(e => e.Componentgroupid)
                    .HasName("PK_GROUPO")
                    .IsUnique();

                entity.Property(e => e.Biketype)
                    .HasColumnName("BIKETYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Componentgroupid)
                    .HasColumnName("COMPONENTGROUPID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Endyear)
                    .HasColumnName("ENDYEAR")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Groupname)
                    .HasColumnName("GROUPNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("NUMBER(15,4)");

                entity.Property(e => e.Year)
                    .HasColumnName("YEAR")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<Letterstyle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LETTERSTYLE");

                entity.HasIndex(e => e.Letterstyle1)
                    .HasName("PK_LETTERSTYLE")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Letterstyle1)
                    .HasColumnName("LETTERSTYLE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MANUFACTURER");

                entity.HasIndex(e => e.Manufacturerid)
                    .HasName("PK_MANUFACTURER")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Balancedue)
                    .HasColumnName("BALANCEDUE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Contactname)
                    .HasColumnName("CONTACTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturerid)
                    .HasColumnName("MANUFACTURERID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Manufacturername)
                    .HasColumnName("MANUFACTURERNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturertransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MANUFACTURERTRANSACTION");

                entity.HasIndex(e => new { e.Manufacturerid, e.Transactiondate, e.Reference })
                    .HasName("PK_MANUFTRANSACTION")
                    .IsUnique();

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Manufacturerid)
                    .HasColumnName("MANUFACTURERID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Reference)
                    .HasColumnName("REFERENCE")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Transactiondate)
                    .HasColumnName("TRANSACTIONDATE")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<Modelsize>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MODELSIZE");

                entity.HasIndex(e => new { e.Modeltype, e.Msize })
                    .HasName("PK_MODELSIZE")
                    .IsUnique();

                entity.Property(e => e.Chainstay)
                    .HasColumnName("CHAINSTAY")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Groundclearance)
                    .HasColumnName("GROUNDCLEARANCE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Headtubeangle)
                    .HasColumnName("HEADTUBEANGLE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modeltype)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Msize)
                    .HasColumnName("MSIZE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Seattubeangle)
                    .HasColumnName("SEATTUBEANGLE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Toptube)
                    .HasColumnName("TOPTUBE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Totallength)
                    .HasColumnName("TOTALLENGTH")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Modeltype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MODELTYPE");

                entity.HasIndex(e => e.Modeltype1)
                    .HasName("PK_MODELTYPE")
                    .IsUnique();

                entity.Property(e => e.Componentid)
                    .HasColumnName("COMPONENTID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modeltype1)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PAINT");

                entity.HasIndex(e => e.Paintid)
                    .HasName("PK_PAINT")
                    .IsUnique();

                entity.Property(e => e.Colorlist)
                    .HasColumnName("COLORLIST")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Colorname)
                    .HasColumnName("COLORNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Colorstyle)
                    .HasColumnName("COLORSTYLE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Solid'");

                entity.Property(e => e.Datediscontinued)
                    .HasColumnName("DATEDISCONTINUED")
                    .HasColumnType("DATE");

                entity.Property(e => e.Dateintroduced)
                    .HasColumnName("DATEINTRODUCED")
                    .HasColumnType("DATE");

                entity.Property(e => e.Paintid)
                    .HasColumnName("PAINTID")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PREFERENCE");

                entity.HasIndex(e => e.Itemname)
                    .HasName("PK_PREFERENCE")
                    .IsUnique();

                entity.Property(e => e.Datechanged)
                    .HasColumnName("DATECHANGED")
                    .HasColumnType("DATE");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Itemname)
                    .HasColumnName("ITEMNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("VALUE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Purchaseitem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PURCHASEITEM");

                entity.HasIndex(e => new { e.Purchaseid, e.Componentid })
                    .HasName("PK_PURCHASEITEM")
                    .IsUnique();

                entity.Property(e => e.Componentid)
                    .HasColumnName("COMPONENTID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pricepaid)
                    .HasColumnName("PRICEPAID")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Purchaseid)
                    .HasColumnName("PURCHASEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quantityreceived)
                    .HasColumnName("QUANTITYRECEIVED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql(@"0
   ");
            });

            modelBuilder.Entity<Purchaseorder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PURCHASEORDER");

                entity.HasIndex(e => e.Purchaseid)
                    .HasName("PK_PURCHASEORDER")
                    .IsUnique();

                entity.Property(e => e.Amountdue)
                    .HasColumnName("AMOUNTDUE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Manufacturerid)
                    .HasColumnName("MANUFACTURERID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("ORDERDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Purchaseid)
                    .HasColumnName("PURCHASEID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Receivedate)
                    .HasColumnName("RECEIVEDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Shippingcost)
                    .HasColumnName("SHIPPINGCOST")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Totallist)
                    .HasColumnName("TOTALLIST")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Retailstore>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RETAILSTORE");

                entity.HasIndex(e => e.Storeid)
                    .HasName("PK_RETAILSTORE")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql(@"0
   ");

                entity.Property(e => e.Contactfirstname)
                    .HasColumnName("CONTACTFIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contactlastname)
                    .HasColumnName("CONTACTLASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Storeid)
                    .HasColumnName("STOREID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Storename)
                    .HasColumnName("STORENAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Revisionhistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REVISIONHISTORY");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_REVISIONHISTORY")
                    .IsUnique();

                entity.Property(e => e.Changedate)
                    .HasColumnName("CHANGEDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Revisioncomments)
                    .HasColumnName("REVISIONCOMMENTS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasColumnName("VERSION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Samplename>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SAMPLENAME");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_SAMPLENAME")
                    .IsUnique();

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Samplestreet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SAMPLESTREET");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_SAMPLESTREET")
                    .IsUnique();

                entity.Property(e => e.Baseaddress)
                    .HasColumnName("BASEADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<Statetaxrate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("STATETAXRATE");

                entity.HasIndex(e => e.State)
                    .HasName("PK_STATETAXRATE")
                    .IsUnique();

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Taxrate)
                    .HasColumnName("TAXRATE")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"0
   ");
            });

            modelBuilder.Entity<Tempdatemade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TEMPDATEMADE");

                entity.HasIndex(e => e.Datevalue)
                    .HasName("PK_TEMPDATEMADE")
                    .IsUnique();

                entity.Property(e => e.Datevalue)
                    .HasColumnName("DATEVALUE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Madecount)
                    .HasColumnName("MADECOUNT")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql(@"0
   ");
            });

            modelBuilder.Entity<Tubematerial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TUBEMATERIAL");

                entity.HasIndex(e => e.Tubeid)
                    .HasName("PK_TUBEMATERIAL")
                    .IsUnique();

                entity.Property(e => e.Construction)
                    .HasColumnName("CONSTRUCTION")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"'Bonded'
   ");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Diameter)
                    .HasColumnName("DIAMETER")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Listprice)
                    .HasColumnName("LISTPRICE")
                    .HasColumnType("NUMBER(38,4)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Material)
                    .HasColumnName("MATERIAL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Roundness)
                    .HasColumnName("ROUNDNESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stiffness)
                    .HasColumnName("STIFFNESS")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Thickness)
                    .HasColumnName("THICKNESS")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tubeid)
                    .HasColumnName("TUBEID")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Workarea>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WORKAREA");

                entity.HasIndex(e => e.Workarea1)
                    .HasName("PK_WORKAREA")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Workarea1)
                    .HasColumnName("WORKAREA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
