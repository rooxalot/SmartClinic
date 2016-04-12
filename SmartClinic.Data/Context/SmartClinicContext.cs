using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text.RegularExpressions;
using SmartClinic.Data.EntityConfig;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Data.Context
{
    public class SmartClinicContext : DbContext
    {
        public SmartClinicContext() : base("name=SmartClinicConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new CreateDatabaseIfNotExists<SmartClinicContext>());
            Database.Initialize(false);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Covenant> Covenants { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<User> Users { get; set; }

        //Ao criar o modelo, o faz adicionando as configurações personalizadas do mesmo.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remoção de convenções default do Entity Framework
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Adicção das configurações especificas das entidades
            modelBuilder.Configurations.Add(new DoctorConfig());
            modelBuilder.Configurations.Add(new AppointmentConfig());
            modelBuilder.Configurations.Add(new ClinicConfig());
            modelBuilder.Configurations.Add(new CovenantConfig());
            modelBuilder.Configurations.Add(new MedicalRecordConfig());
            modelBuilder.Configurations.Add(new PacientConfig());
            modelBuilder.Configurations.Add(new SecretaryConfig());
            modelBuilder.Configurations.Add(new UserConfig());

            //Configurações padrão
            modelBuilder.Properties()
                .Where(p => p.Name == "ID" || p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties()
                .Where(p => p.Name == "ID" || p.Name == "Id")
                .Configure(p => p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None));

            modelBuilder.Properties()
                .Where(p => Regex.IsMatch(p.Name, @"^\w*?Id$"))
                .Configure(p => p.HasColumnName(p.ClrPropertyInfo.Name.Replace("Id", "ID")));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(128));


            //Configurações dos tipos complexos

            //Cnpj
            modelBuilder.ComplexType<Cnpj>()
                .Property(p => p.Code)
                .IsOptional()
                .HasColumnName("Cnpj");

            //Address
            modelBuilder.ComplexType<Address>()
                .Property(p => p.PublicPlace)
                .IsOptional()
                .HasMaxLength(Address.PublicPlaceMaxLength)
                .HasColumnName("PublicPlace");

            modelBuilder.ComplexType<Address>()
                .Property(p => p.Complement)
                .IsOptional()
                .HasMaxLength(Address.ComplementMaxLength)
                .HasColumnName("Complement");

            modelBuilder.ComplexType<Address>()
                .Property(p => p.Number)
                .IsOptional()
                .HasMaxLength(Address.NumberMaxLength)
                .HasColumnName("Number");

            modelBuilder.ComplexType<Address>()
                .Property(p => p.Neighborhood)
                .IsOptional()
                .HasMaxLength(Address.NeighborhoodMaxLength)
                .HasColumnName("Neighborhood");

            modelBuilder.ComplexType<Address>()
                .Property(p => p.City)
                .IsOptional()
                .HasMaxLength(Address.CityMaxLength)
                .HasColumnName("City");

            modelBuilder.ComplexType<Address>()
                .Property(p => p.Uf)
                .IsOptional()
                .HasColumnName("State");

            //Phone
            modelBuilder.ComplexType<Phone>()
                .Property(p => p.Number)
                .IsOptional()
                .HasMaxLength(Phone.NumberMaxLength)
                .HasColumnName("PhoneNumber");

            modelBuilder.ComplexType<Phone>()
                .Property(p => p.Ddd)
                .IsOptional()
                .HasMaxLength(Phone.DddMaxLength)
                .HasColumnName("DDD");


            //Rg
            modelBuilder.ComplexType<Rg>()
                .Property(p => p.Code)
                .IsOptional()
                .HasColumnName("Rg");
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("CreatedOn") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedOn").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("CreatedOn").IsModified = false;
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("Id") != null))
            {
                if (entry.State != EntityState.Added)
                    continue;
                if(entry.Property("Id").CurrentValue == null || entry.Property("Id").CurrentValue.Equals(Guid.Empty))
                    entry.Property("Id").CurrentValue = Guid.NewGuid();
            }
            return base.SaveChanges();
        }
    }
}

