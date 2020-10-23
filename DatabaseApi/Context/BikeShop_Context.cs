using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseApi
{
    public partial class BikeShop_Context : IdentityDbContext<IdentityUser>
    {
        public BikeShop_Context(DbContextOptions<BikeShop_Context> options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));

            modelBuilder.Entity<Bicycle>(entity =>
            {
                entity.HasKey(e => e.Serialnumber)
                    .HasName("PRIMARY");

                entity.ToTable("BICYCLE");

                entity.HasIndex(e => e.Customerid)
                    .HasName("FK_BIKECUSTOMER");

                entity.HasIndex(e => e.Employeeid)
                    .HasName("FK_BIKEEMPLOYEE");

                entity.HasIndex(e => e.Letterstyleid)
                    .HasName("FK_BIKELETTER");

                entity.HasIndex(e => e.Modeltype)
                    .HasName("FK_BIKEMODELTYPE");

                entity.HasIndex(e => e.Paintid)
                    .HasName("FK_BIKEPAINT");

                entity.HasIndex(e => e.Serialnumber)
                    .HasName("PK_BICYCLE")
                    .IsUnique();

                entity.HasIndex(e => e.Storeid)
                    .HasName("FK_BIKERETAIL");

                entity.Property(e => e.Serialnumber).HasColumnName("SERIALNUMBER");

                entity.Property(e => e.Chainstay)
                    .HasColumnName("CHAINSTAY")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Componentlist)
                    .HasColumnName("COMPONENTLIST")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Construction)
                    .HasColumnName("CONSTRUCTION")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Bonded'");

                entity.Property(e => e.Customerid)
                    .HasColumnName("CUSTOMERID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Customname)
                    .HasColumnName("CUSTOMNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Frameassembler)
                    .HasColumnName("FRAMEASSEMBLER")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Frameprice)
                    .HasColumnName("FRAMEPRICE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Framesize)
                    .HasColumnName("FRAMESIZE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Headtubeangle)
                    .HasColumnName("HEADTUBEANGLE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Letterstyleid)
                    .HasColumnName("LETTERSTYLEID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Listprice)
                    .HasColumnName("LISTPRICE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Modeltype)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Orderdate)
                    .HasColumnName("ORDERDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Painter)
                    .HasColumnName("PAINTER")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Paintid)
                    .HasColumnName("PAINTID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Saleprice)
                    .HasColumnName("SALEPRICE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Salestate)
                    .HasColumnName("SALESTATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salestax)
                    .HasColumnName("SALESTAX")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Seattubeangle)
                    .HasColumnName("SEATTUBEANGLE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Shipdate)
                    .HasColumnName("SHIPDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Shipemployee)
                    .HasColumnName("SHIPEMPLOYEE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Shipprice)
                    .HasColumnName("SHIPPRICE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Startdate)
                    .HasColumnName("STARTDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Storeid)
                    .HasColumnName("STOREID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Toptube)
                    .HasColumnName("TOPTUBE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Waterbottlebrazeons)
                    .HasColumnName("WATERBOTTLEBRAZEONS")
                    .HasDefaultValueSql("'4'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bicycle)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_BIKECUSTOMER");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bicycle)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("FK_BIKEEMPLOYEE");

                entity.HasOne(d => d.Letterstyle)
                    .WithMany(p => p.Bicycle)
                    .HasForeignKey(d => d.Letterstyleid)
                    .HasConstraintName("FK_BIKELETTER");

                entity.HasOne(d => d.ModeltypeNavigation)
                    .WithMany(p => p.Bicycle)
                    .HasForeignKey(d => d.Modeltype)
                    .HasConstraintName("FK_BIKEMODELTYPE");

                // entity.HasOne(d => d.Paint)
                //     .WithMany(p => p.Bicycle)
                //     .HasForeignKey(d => d.Paintid)
                //     .HasConstraintName("FK_BIKEPAINT");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Bicycle)
                    .HasForeignKey(d => d.Storeid)
                    .HasConstraintName("FK_BIKERETAIL");
            });

            modelBuilder.Entity<Bicycletubeusage>(entity =>
            {
                entity.HasKey(e => new { e.Serialnumber, e.Tubeid })
                    .HasName("PRIMARY");

                entity.ToTable("BICYCLETUBEUSAGE");

                entity.HasIndex(e => e.Tubeid)
                    .HasName("FK_REFERENCE27");

                entity.HasIndex(e => new { e.Serialnumber, e.Tubeid })
                    .HasName("PK_BICYCLETUBEUSAGE")
                    .IsUnique();

                entity.Property(e => e.Serialnumber).HasColumnName("SERIALNUMBER");

                entity.Property(e => e.Tubeid).HasColumnName("TUBEID");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.SerialnumberNavigation)
                    .WithMany(p => p.Bicycletubeusage)
                    .HasForeignKey(d => d.Serialnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE26");

                entity.HasOne(d => d.Tube)
                    .WithMany(p => p.Bicycletubeusage)
                    .HasForeignKey(d => d.Tubeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE27");
            });

            modelBuilder.Entity<Bikeparts>(entity =>
            {
                entity.HasKey(e => new { e.Serialnumber, e.Componentid })
                    .HasName("PRIMARY");

                entity.ToTable("BIKEPARTS");

                entity.HasIndex(e => e.Componentid)
                    .HasName("FK_REFERENCE5");

                entity.HasIndex(e => e.Employeeid)
                    .HasName("FK_REFERENCE4");

                entity.HasIndex(e => new { e.Serialnumber, e.Componentid })
                    .HasName("PK_BIKEPARTS")
                    .IsUnique();

                entity.Property(e => e.Serialnumber).HasColumnName("SERIALNUMBER");

                entity.Property(e => e.Componentid).HasColumnName("COMPONENTID");

                entity.Property(e => e.Dateinstalled)
                    .HasColumnName("DATEINSTALLED")
                    .HasColumnType("date");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Substituteid)
                    .HasColumnName("SUBSTITUTEID")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.Bikeparts)
                    .HasForeignKey(d => d.Componentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE5");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bikeparts)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("FK_REFERENCE4");

                // entity.HasOne(d => d.SerialnumberNavigation)
                //     .WithMany(p => p.Bikeparts)
                //     .HasForeignKey(d => d.Serialnumber)
                //     .OnDelete(DeleteBehavior.ClientSetNull)
                //     .HasConstraintName("FK_REFERENCE24");
            });

            modelBuilder.Entity<Biketubes>(entity =>
            {
                entity.HasKey(e => new { e.Serialnumber, e.Tubename })
                    .HasName("PRIMARY");

                entity.ToTable("BIKETUBES");

                entity.HasIndex(e => e.Tubeid)
                    .HasName("FK_TUBEMATERIALBIKETUBES");

                entity.HasIndex(e => new { e.Serialnumber, e.Tubename })
                    .HasName("PK_BIKETUBES")
                    .IsUnique();

                entity.Property(e => e.Serialnumber).HasColumnName("SERIALNUMBER");

                entity.Property(e => e.Tubename)
                    .HasColumnName("TUBENAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Length)
                    .HasColumnName("LENGTH")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Tubeid)
                    .HasColumnName("TUBEID")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.SerialnumberNavigation)
                    .WithMany(p => p.Biketubes)
                    .HasForeignKey(d => d.Serialnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE6");

                entity.HasOne(d => d.Tube)
                    .WithMany(p => p.Biketubes)
                    .HasForeignKey(d => d.Tubeid)
                    .HasConstraintName("FK_TUBEMATERIALBIKETUBES");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.HasIndex(e => e.Cityid)
                    .HasName("PK_CITY")
                    .IsUnique();

                entity.Property(e => e.Cityid).HasColumnName("CITYID");

                entity.Property(e => e.Areacode)
                    .HasColumnName("AREACODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City1)
                    .HasColumnName("CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnName("LATITUDE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Population1980)
                    .HasColumnName("POPULATION1980")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Population1990)
                    .HasColumnName("POPULATION1990")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Populationcdf)
                    .HasColumnName("POPULATIONCDF")
                    .HasDefaultValueSql("'0'");

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
                entity.HasKey(e => new { e.Modeltype, e.Framesize })
                    .HasName("PRIMARY");

                entity.ToTable("COMMONSIZES");

                entity.HasIndex(e => new { e.Modeltype, e.Framesize })
                    .HasName("PK_COMMONSIZES")
                    .IsUnique();

                entity.Property(e => e.Modeltype)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Framesize).HasColumnName("FRAMESIZE");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("COMPONENT");

                entity.HasIndex(e => e.Category)
                    .HasName("FK_REFERENCE");

                entity.HasIndex(e => e.Componentid)
                    .HasName("PK_COMPONENT")
                    .IsUnique();

                entity.HasIndex(e => e.Manufacturerid)
                    .HasName("FK_REFERENCE16");

                entity.Property(e => e.Componentid).HasColumnName("COMPONENTID");

                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endyear).HasColumnName("ENDYEAR");

                entity.Property(e => e.Estimatedcost)
                    .HasColumnName("ESTIMATEDCOST")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Height)
                    .HasColumnName("HEIGHT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Length)
                    .HasColumnName("LENGTH")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Listprice)
                    .HasColumnName("LISTPRICE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Manufacturerid)
                    .HasColumnName("MANUFACTURERID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Productint)
                    .HasColumnName("PRODUCTINT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantityonhand)
                    .HasColumnName("QUANTITYONHAND")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Road)
                    .HasColumnName("ROAD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Width)
                    .HasColumnName("WIDTH")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Year).HasColumnName("YEAR");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Component)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_REFERENCE");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Component)
                    .HasForeignKey(d => d.Manufacturerid)
                    .HasConstraintName("FK_REFERENCE16");
            });

            modelBuilder.Entity<Componentname>(entity =>
            {
                entity.HasKey(e => e.Componentname1)
                    .HasName("PRIMARY");

                entity.ToTable("COMPONENTNAME");

                entity.HasIndex(e => e.Componentname1)
                    .HasName("PK_COMPONENTNAME")
                    .IsUnique();

                entity.Property(e => e.Componentname1)
                    .HasColumnName("COMPONENTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Assemblyorder)
                    .HasColumnName("ASSEMBLYORDER")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.HasIndex(e => e.Cityid)
                    .HasName("FK_CITYCUSTOMER");

                entity.HasIndex(e => e.Customerid)
                    .HasName("PK_CUSTOMER")
                    .IsUnique();

                entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Balancedue)
                    .HasColumnName("BALANCEDUE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasDefaultValueSql("'0'");

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

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK_CITYCUSTOMER");
            });

            modelBuilder.Entity<Customertransaction>(entity =>
            {
                entity.HasKey(e => new { e.Customerid, e.Transactiondate })
                    .HasName("PRIMARY");

                entity.ToTable("CUSTOMERTRANSACTION");

                entity.HasIndex(e => new { e.Customerid, e.Transactiondate })
                    .HasName("PK_CUSTOMERTRANSACTION")
                    .IsUnique();

                entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");

                entity.Property(e => e.Transactiondate)
                    .HasColumnName("TRANSACTIONDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Reference)
                    .HasColumnName("REFERENCE")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Customertransaction)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE18");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.HasIndex(e => e.Cityid)
                    .HasName("FK_CITYEMPLOYEE");

                entity.HasIndex(e => e.Employeeid)
                    .HasName("PK_EMPLOYEE")
                    .IsUnique();

                entity.Property(e => e.Employeeid).HasColumnName("EMPLOYEEID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Currentmanager)
                    .HasColumnName("CURRENTMANAGER")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Datehired)
                    .HasColumnName("DATEHIRED")
                    .HasColumnType("date");

                entity.Property(e => e.Datereleased)
                    .HasColumnName("DATERELEASED")
                    .HasColumnType("date");

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
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Salarygrade)
                    .HasColumnName("SALARYGRADE")
                    .HasDefaultValueSql("'0'");

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

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK_CITYEMPLOYEE");
            });

            modelBuilder.Entity<Groupcomponents>(entity =>
            {
                entity.HasKey(e => new { e.Groupid, e.Componentid })
                    .HasName("PRIMARY");

                entity.ToTable("GROUPCOMPONENTS");

                entity.HasIndex(e => e.Componentid)
                    .HasName("FK_REFERENCE14");

                entity.HasIndex(e => new { e.Groupid, e.Componentid })
                    .HasName("PK_GROUPCOMPONENTS")
                    .IsUnique();

                entity.Property(e => e.Groupid).HasColumnName("GROUPID");

                entity.Property(e => e.Componentid).HasColumnName("COMPONENTID");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.Groupcomponents)
                    .HasForeignKey(d => d.Componentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE14");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Groupcomponents)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE15");
            });

            modelBuilder.Entity<Groupo>(entity =>
            {
                entity.HasKey(e => e.Componentgroupid)
                    .HasName("PRIMARY");

                entity.ToTable("GROUPO");

                entity.HasIndex(e => e.Componentgroupid)
                    .HasName("PK_GROUPO")
                    .IsUnique();

                entity.Property(e => e.Componentgroupid).HasColumnName("COMPONENTGROUPID");

                entity.Property(e => e.Biketype)
                    .HasColumnName("BIKETYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Endyear).HasColumnName("ENDYEAR");

                entity.Property(e => e.Groupname)
                    .HasColumnName("GROUPNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnName("WEIGHT");

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });

            modelBuilder.Entity<Letterstyle>(entity =>
            {
                entity.HasKey(e => e.Letterstyle1)
                    .HasName("PRIMARY");

                entity.ToTable("LETTERSTYLE");

                entity.HasIndex(e => e.Letterstyle1)
                    .HasName("PK_LETTERSTYLE")
                    .IsUnique();

                entity.Property(e => e.Letterstyle1)
                    .HasColumnName("LETTERSTYLE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("MANUFACTURER");

                entity.HasIndex(e => e.Cityid)
                    .HasName("FK_CITYMANUFACTURER");

                entity.HasIndex(e => e.Manufacturerid)
                    .HasName("PK_MANUFACTURER")
                    .IsUnique();

                entity.Property(e => e.Manufacturerid).HasColumnName("MANUFACTURERID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Balancedue)
                    .HasColumnName("BALANCEDUE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Contactname)
                    .HasColumnName("CONTACTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Manufacturer)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK_CITYMANUFACTURER");
            });

            modelBuilder.Entity<Manufacturertransaction>(entity =>
            {
                entity.HasKey(e => new { e.Manufacturerid, e.Transactiondate, e.Reference })
                    .HasName("PRIMARY");

                entity.ToTable("MANUFACTURERTRANSACTION");

                entity.HasIndex(e => new { e.Manufacturerid, e.Transactiondate, e.Reference })
                    .HasName("PK_MANUFTRANSACTION")
                    .IsUnique();

                entity.Property(e => e.Manufacturerid).HasColumnName("MANUFACTURERID");

                entity.Property(e => e.Transactiondate)
                    .HasColumnName("TRANSACTIONDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Reference).HasColumnName("REFERENCE");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Manufacturertransaction)
                    .HasForeignKey(d => d.Manufacturerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MANUFTRANS");
            });

            modelBuilder.Entity<Modelsize>(entity =>
            {
                entity.HasKey(e => new { e.Modeltype, e.Msize })
                    .HasName("PRIMARY");

                entity.ToTable("MODELSIZE");

                entity.HasIndex(e => new { e.Modeltype, e.Msize })
                    .HasName("PK_MODELSIZE")
                    .IsUnique();

                entity.Property(e => e.Modeltype)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Msize).HasColumnName("MSIZE");

                entity.Property(e => e.Chainstay)
                    .HasColumnName("CHAINSTAY")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Groundclearance)
                    .HasColumnName("GROUNDCLEARANCE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Headtubeangle)
                    .HasColumnName("HEADTUBEANGLE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Seattubeangle)
                    .HasColumnName("SEATTUBEANGLE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Toptube)
                    .HasColumnName("TOPTUBE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Totallength)
                    .HasColumnName("TOTALLENGTH")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.ModeltypeNavigation)
                    .WithMany(p => p.Modelsize)
                    .HasForeignKey(d => d.Modeltype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MODELTYPE");
            });

            modelBuilder.Entity<Modeltype>(entity =>
            {
                entity.HasKey(e => e.Modeltype1)
                    .HasName("PRIMARY");

                entity.ToTable("MODELTYPE");

                entity.HasIndex(e => e.Modeltype1)
                    .HasName("PK_MODELTYPE")
                    .IsUnique();

                entity.Property(e => e.Modeltype1)
                    .HasColumnName("MODELTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Componentid).HasColumnName("COMPONENTID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paint>(entity =>
            {
                entity.ToTable("PAINT");

                entity.HasIndex(e => e.Paintid)
                    .HasName("PK_PAINT")
                    .IsUnique();

                entity.Property(e => e.Paintid).HasColumnName("PAINTID");

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
                    .HasColumnType("date");

                entity.Property(e => e.Dateintroduced)
                    .HasColumnName("DATEINTRODUCED")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasKey(e => e.Itemname)
                    .HasName("PRIMARY");

                entity.ToTable("PREFERENCE");

                entity.HasIndex(e => e.Itemname)
                    .HasName("PK_PREFERENCE")
                    .IsUnique();

                entity.Property(e => e.Itemname)
                    .HasColumnName("ITEMNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datechanged)
                    .HasColumnName("DATECHANGED")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("VALUE")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Purchaseitem>(entity =>
            {
                entity.HasKey(e => new { e.Purchaseid, e.Componentid })
                    .HasName("PRIMARY");

                entity.ToTable("PURCHASEITEM");

                entity.HasIndex(e => e.Componentid)
                    .HasName("FK_REFERENCE21");

                entity.HasIndex(e => new { e.Purchaseid, e.Componentid })
                    .HasName("PK_PURCHASEITEM")
                    .IsUnique();

                entity.Property(e => e.Purchaseid).HasColumnName("PURCHASEID");

                entity.Property(e => e.Componentid).HasColumnName("COMPONENTID");

                entity.Property(e => e.Pricepaid)
                    .HasColumnName("PRICEPAID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Quantityreceived)
                    .HasColumnName("QUANTITYRECEIVED")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.Purchaseitem)
                    .HasForeignKey(d => d.Componentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE21");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.Purchaseitem)
                    .HasForeignKey(d => d.Purchaseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE20");
            });

            modelBuilder.Entity<Purchaseorder>(entity =>
            {
                entity.HasKey(e => e.Purchaseid)
                    .HasName("PRIMARY");

                entity.ToTable("PURCHASEORDER");

                entity.HasIndex(e => e.Employeeid)
                    .HasName("FK_REFERENCE23");

                entity.HasIndex(e => e.Manufacturerid)
                    .HasName("FK_REFERENCE22");

                entity.HasIndex(e => e.Purchaseid)
                    .HasName("PK_PURCHASEORDER")
                    .IsUnique();

                entity.Property(e => e.Purchaseid).HasColumnName("PURCHASEID");

                entity.Property(e => e.Amountdue)
                    .HasColumnName("AMOUNTDUE")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("EMPLOYEEID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Manufacturerid)
                    .HasColumnName("MANUFACTURERID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("ORDERDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Receivedate)
                    .HasColumnName("RECEIVEDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Shippingcost)
                    .HasColumnName("SHIPPINGCOST")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Totallist)
                    .HasColumnName("TOTALLIST")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Purchaseorder)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("FK_REFERENCE23");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Purchaseorder)
                    .HasForeignKey(d => d.Manufacturerid)
                    .HasConstraintName("FK_REFERENCE22");
            });

            modelBuilder.Entity<Retailstore>(entity =>
            {
                entity.HasKey(e => e.Storeid)
                    .HasName("PRIMARY");

                entity.ToTable("RETAILSTORE");

                entity.HasIndex(e => e.Cityid)
                    .HasName("FK_CITYRETAILSTORE");

                entity.HasIndex(e => e.Storeid)
                    .HasName("PK_RETAILSTORE")
                    .IsUnique();

                entity.Property(e => e.Storeid).HasColumnName("STOREID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cityid)
                    .HasColumnName("CITYID")
                    .HasDefaultValueSql("'0'");

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

                entity.Property(e => e.Storename)
                    .HasColumnName("STORENAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Retailstore)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK_CITYRETAILSTORE");
            });

            modelBuilder.Entity<Revisionhistory>(entity =>
            {
                entity.ToTable("REVISIONHISTORY");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_REVISIONHISTORY")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Changedate)
                    .HasColumnName("CHANGEDATE")
                    .HasColumnType("date");

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
                entity.ToTable("SAMPLENAME");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_SAMPLENAME")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Samplestreet>(entity =>
            {
                entity.ToTable("SAMPLESTREET");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_SAMPLESTREET")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Baseaddress)
                    .HasColumnName("BASEADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Statetaxrate>(entity =>
            {
                entity.HasKey(e => e.State)
                    .HasName("PRIMARY");

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
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Tempdatemade>(entity =>
            {
                entity.HasKey(e => e.Datevalue)
                    .HasName("PRIMARY");

                entity.ToTable("TEMPDATEMADE");

                entity.HasIndex(e => e.Datevalue)
                    .HasName("PK_TEMPDATEMADE")
                    .IsUnique();

                entity.Property(e => e.Datevalue)
                    .HasColumnName("DATEVALUE")
                    .HasColumnType("date");

                entity.Property(e => e.Madecount)
                    .HasColumnName("MADECOUNT")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Tubematerial>(entity =>
            {
                entity.HasKey(e => e.Tubeid)
                    .HasName("PRIMARY");

                entity.ToTable("TUBEMATERIAL");

                entity.HasIndex(e => e.Tubeid)
                    .HasName("PK_TUBEMATERIAL")
                    .IsUnique();

                entity.Property(e => e.Tubeid).HasColumnName("TUBEID");

                entity.Property(e => e.Construction)
                    .HasColumnName("CONSTRUCTION")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Bonded'");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Diameter)
                    .HasColumnName("DIAMETER")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Listprice)
                    .HasColumnName("LISTPRICE")
                    .HasDefaultValueSql("'1'");

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
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Thickness)
                    .HasColumnName("THICKNESS")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Workarea>(entity =>
            {
                entity.HasKey(e => e.Workarea1)
                    .HasName("PRIMARY");

                entity.ToTable("WORKAREA");

                entity.HasIndex(e => e.Workarea1)
                    .HasName("PK_WORKAREA")
                    .IsUnique();

                entity.Property(e => e.Workarea1)
                    .HasColumnName("WORKAREA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
