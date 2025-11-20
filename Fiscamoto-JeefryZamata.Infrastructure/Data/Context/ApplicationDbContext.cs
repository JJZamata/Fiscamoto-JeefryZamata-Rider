using System;
using System.Collections.Generic;
using Fiscamoto_JeefryZamata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Fiscamoto_JeefryZamata.Infrastructure.Data.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompliantRecord> CompliantRecords { get; set; }

    public virtual DbSet<ControlRecord> ControlRecords { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DrivingLicense> DrivingLicenses { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<NonCompliantRecord> NonCompliantRecords { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<RecordPhoto> RecordPhotos { get; set; }

    public virtual DbSet<RecordViolation> RecordViolations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TechnicalReview> TechnicalReviews { get; set; }

    public virtual DbSet<TrackingStatus> TrackingStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLastLocation> UserLastLocations { get; set; }

    public virtual DbSet<UserLocationLog> UserLocationLogs { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleType> VehicleTypes { get; set; }

    public virtual DbSet<Violation> Violations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=shortline.proxy.rlwy.net;port=46817;user=root;password=IkBTzZRpqpHfWeQBSjsgVDpAoNYoRCjR;database=railway", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.4.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("audit_logs");

            entity.HasIndex(e => e.CorrelationId, "audit_logs_correlation_id").IsUnique();

            entity.HasIndex(e => e.StatusCode, "audit_logs_status_code");

            entity.HasIndex(e => e.Timestamp, "audit_logs_timestamp");

            entity.HasIndex(e => e.UserId, "audit_logs_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorrelationId)
                .HasColumnName("correlationId")
                .UseCollation("utf8mb4_bin");
            entity.Property(e => e.DurationMs).HasColumnName("durationMs");
            entity.Property(e => e.Ip)
                .HasMaxLength(45)
                .HasColumnName("ip");
            entity.Property(e => e.Method)
                .HasMaxLength(10)
                .HasColumnName("method");
            entity.Property(e => e.Payload)
                .HasColumnType("json")
                .HasColumnName("payload");
            entity.Property(e => e.StatusCode).HasColumnName("statusCode");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(255)
                .HasColumnName("userAgent");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("audit_logs_ibfk_1");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Ruc).HasName("PRIMARY");

            entity
                .ToTable("companies")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Name, "companies_name");

            entity.HasIndex(e => e.Ruc, "companies_ruc").IsUnique();

            entity.HasIndex(e => e.RucStatus, "companies_ruc_status");

            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasComment("RUC de la empresa")
                .HasColumnName("ruc");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.ExpirationDate)
                .HasComment("fecha_vencimiento")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.RegistrationDate)
                .HasComment("fecha_emision")
                .HasColumnName("registration_date");
            entity.Property(e => e.RucStatus)
                .HasDefaultValueSql("'ACTIVO'")
                .HasComment("estado_ruc")
                .HasColumnType("enum('ACTIVO','BAJA PROV.','SUSPENDIDO')")
                .HasColumnName("ruc_status");
            entity.Property(e => e.RucUpdateDate)
                .HasComment("fecha_actualizacion_ruc")
                .HasColumnName("ruc_update_date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<CompliantRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("compliant_records")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ControlRecordId, "compliant_records_control_record_id");

            entity.HasIndex(e => e.InspectionDateTime, "compliant_records_inspection_date_time");

            entity.HasIndex(e => e.InspectorId, "compliant_records_inspector_id");

            entity.HasIndex(e => e.LicenseId, "compliant_records_license_id");

            entity.HasIndex(e => e.VehiclePlate, "compliant_records_vehicle_plate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ControlRecordId).HasColumnName("control_record_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.InspectionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("inspection_date_time");
            entity.Property(e => e.InspectorId).HasColumnName("inspector_id");
            entity.Property(e => e.LicenseId).HasColumnName("license_id");
            entity.Property(e => e.Location)
                .HasColumnType("text")
                .HasColumnName("location");
            entity.Property(e => e.Observations)
                .HasColumnType("text")
                .HasColumnName("observations");
            entity.Property(e => e.S3FileUrl)
                .HasColumnType("text")
                .HasColumnName("s3_file_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.VehiclePlate)
                .HasMaxLength(10)
                .HasColumnName("vehicle_plate");

            entity.HasOne(d => d.ControlRecord).WithMany(p => p.CompliantRecords)
                .HasForeignKey(d => d.ControlRecordId)
                .HasConstraintName("compliant_records_ibfk_25");

            entity.HasOne(d => d.Inspector).WithMany(p => p.CompliantRecords)
                .HasForeignKey(d => d.InspectorId)
                .HasConstraintName("compliant_records_ibfk_26");

            entity.HasOne(d => d.License).WithMany(p => p.CompliantRecords)
                .HasForeignKey(d => d.LicenseId)
                .HasConstraintName("compliant_records_ibfk_27");

            entity.HasOne(d => d.VehiclePlateNavigation).WithMany(p => p.CompliantRecords)
                .HasForeignKey(d => d.VehiclePlate)
                .HasConstraintName("compliant_records_ibfk_28");
        });

        modelBuilder.Entity<ControlRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("control_records")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cleanliness)
                .HasComment("Estado de limpieza del vehículo")
                .HasColumnName("cleanliness");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.FireExtinguisher)
                .HasComment("Presencia de extintor")
                .HasColumnName("fire_extinguisher");
            entity.Property(e => e.FirstAidKit)
                .HasComment("Presencia de botiquín")
                .HasColumnName("first_aid_kit");
            entity.Property(e => e.Lights)
                .HasComment("Estado de las luces")
                .HasColumnName("lights");
            entity.Property(e => e.Seatbelt)
                .HasComment("Cinturón de seguridad")
                .HasColumnName("seatbelt");
            entity.Property(e => e.Tires)
                .HasComment("Estado de los neumáticos")
                .HasColumnName("tires");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PRIMARY");

            entity
                .ToTable("drivers")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Dni, "drivers_dni").IsUnique();

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "drivers_first_name_last_name");

            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasComment("DNI del conductor")
                .HasColumnName("dni");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.PhotoUrl)
                .HasColumnType("text")
                .HasColumnName("photo_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<DrivingLicense>(entity =>
        {
            entity.HasKey(e => e.LicenseId).HasName("PRIMARY");

            entity
                .ToTable("driving_licenses")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Category, "driving_licenses_category");

            entity.HasIndex(e => e.DriverDni, "driving_licenses_driver_dni");

            entity.HasIndex(e => e.ExpirationDate, "driving_licenses_expiration_date");

            entity.HasIndex(e => e.LicenseId, "driving_licenses_license_id").IsUnique();

            entity.HasIndex(e => e.LicenseNumber, "driving_licenses_license_number").IsUnique();

            entity.Property(e => e.LicenseId)
                .HasComment("ID único de la licencia")
                .HasColumnName("license_id");
            entity.Property(e => e.Category)
                .HasColumnType("enum('A-I','A-IIa','A-IIb','A-IIIa','A-IIIb','A-IIIc','B-I','B-IIa','B-IIb','B-IIc')")
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DriverDni)
                .HasMaxLength(8)
                .HasColumnName("driver_dni");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.IssuingEntity)
                .HasMaxLength(100)
                .HasColumnName("issuing_entity");
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(15)
                .HasColumnName("license_number");
            entity.Property(e => e.Restrictions)
                .HasDefaultValueSql("'SIN RESTRICCIONES'")
                .HasColumnType("enum('SIN RESTRICCIONES','LENTES CORRECTIVOS','APARATOS AUDITIVOS','PROTESIS EN MIEMBROS','OTRAS RESTRICCIONES')")
                .HasColumnName("restrictions");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.DriverDniNavigation).WithMany(p => p.DrivingLicenses)
                .HasForeignKey(d => d.DriverDni)
                .HasConstraintName("driving_licenses_ibfk_1");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("insurances")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ExpirationDate, "insurances_expiration_date");

            entity.HasIndex(e => e.LicenseId, "insurances_license_id");

            entity.HasIndex(e => e.OwnerDni, "insurances_owner_dni");

            entity.HasIndex(e => new { e.PolicyNumber, e.InsuranceCompanyName }, "insurances_policy_number_insurance_company_name").IsUnique();

            entity.HasIndex(e => e.VehiclePlate, "insurances_vehicle_plate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coverage)
                .HasColumnType("text")
                .HasColumnName("coverage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.InsuranceCompanyName)
                .HasMaxLength(100)
                .HasColumnName("insurance_company_name");
            entity.Property(e => e.LicenseId).HasColumnName("license_id");
            entity.Property(e => e.OwnerDni)
                .HasMaxLength(8)
                .HasColumnName("owner_dni");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(20)
                .HasColumnName("policy_number");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.VehiclePlate)
                .HasMaxLength(10)
                .HasColumnName("vehicle_plate");

            entity.HasOne(d => d.License).WithMany(p => p.Insurances)
                .HasForeignKey(d => d.LicenseId)
                .HasConstraintName("insurances_ibfk_20");

            entity.HasOne(d => d.OwnerDniNavigation).WithMany(p => p.Insurances)
                .HasForeignKey(d => d.OwnerDni)
                .HasConstraintName("insurances_ibfk_21");

            entity.HasOne(d => d.VehiclePlateNavigation).WithMany(p => p.Insurances)
                .HasForeignKey(d => d.VehiclePlate)
                .HasConstraintName("insurances_ibfk_19");
        });

        modelBuilder.Entity<NonCompliantRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("non_compliant_records")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.CompanyRuc, "non_compliant_records_company_ruc");

            entity.HasIndex(e => e.ControlRecordId, "non_compliant_records_control_record_id");

            entity.HasIndex(e => e.InspectionDateTime, "non_compliant_records_inspection_date_time");

            entity.HasIndex(e => e.InspectorId, "non_compliant_records_inspector_id");

            entity.HasIndex(e => e.LicenseId, "non_compliant_records_license_id");

            entity.HasIndex(e => e.VehiclePlate, "non_compliant_records_vehicle_plate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyRuc)
                .HasMaxLength(11)
                .HasColumnName("company_ruc");
            entity.Property(e => e.ControlRecordId).HasColumnName("control_record_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.InspectionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("inspection_date_time");
            entity.Property(e => e.InspectorId).HasColumnName("inspector_id");
            entity.Property(e => e.LicenseId).HasColumnName("license_id");
            entity.Property(e => e.Location)
                .HasColumnType("text")
                .HasColumnName("location");
            entity.Property(e => e.Observations)
                .HasColumnType("text")
                .HasColumnName("observations");
            entity.Property(e => e.S3FileUrl)
                .HasColumnType("text")
                .HasColumnName("s3_file_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.VehiclePlate)
                .HasMaxLength(10)
                .HasColumnName("vehicle_plate");

            entity.HasOne(d => d.CompanyRucNavigation).WithMany(p => p.NonCompliantRecords)
                .HasForeignKey(d => d.CompanyRuc)
                .HasConstraintName("non_compliant_records_ibfk_33");

            entity.HasOne(d => d.ControlRecord).WithMany(p => p.NonCompliantRecords)
                .HasForeignKey(d => d.ControlRecordId)
                .HasConstraintName("non_compliant_records_ibfk_31");

            entity.HasOne(d => d.Inspector).WithMany(p => p.NonCompliantRecords)
                .HasForeignKey(d => d.InspectorId)
                .HasConstraintName("non_compliant_records_ibfk_32");

            entity.HasOne(d => d.License).WithMany(p => p.NonCompliantRecords)
                .HasForeignKey(d => d.LicenseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("non_compliant_records_ibfk_34");

            entity.HasOne(d => d.VehiclePlateNavigation).WithMany(p => p.NonCompliantRecords)
                .HasForeignKey(d => d.VehiclePlate)
                .HasConstraintName("non_compliant_records_ibfk_35");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PRIMARY");

            entity
                .ToTable("owners")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Dni, "owners_dni").IsUnique();

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "owners_first_name_last_name");

            entity.HasIndex(e => e.Phone, "owners_phone");

            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasComment("DNI del propietario")
                .HasColumnName("dni");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasComment("Email del propietario")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(9)
                .HasComment("Teléfono del propietario")
                .HasColumnName("phone");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("photos")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.CaptureDate, "photos_capture_date");

            entity.HasIndex(e => e.Coordinates, "photos_coordinates");

            entity.HasIndex(e => e.UserId, "photos_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CaptureDate)
                .HasColumnType("datetime")
                .HasColumnName("capture_date");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(50)
                .HasColumnName("coordinates");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Url)
                .HasColumnType("text")
                .HasColumnName("url");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Photos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("photos_ibfk_1");
        });

        modelBuilder.Entity<RecordPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("record_photos")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.CompliantRecordId, "record_photos_compliant_record_id");

            entity.HasIndex(e => new { e.CompliantRecordId, e.PhotoId }, "record_photos_compliant_record_id_photo_id").IsUnique();

            entity.HasIndex(e => e.NonCompliantRecordId, "record_photos_non_compliant_record_id");

            entity.HasIndex(e => new { e.NonCompliantRecordId, e.PhotoId }, "record_photos_non_compliant_record_id_photo_id").IsUnique();

            entity.HasIndex(e => e.PhotoId, "record_photos_photo_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompliantRecordId).HasColumnName("compliant_record_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.NonCompliantRecordId).HasColumnName("non_compliant_record_id");
            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CompliantRecord).WithMany(p => p.RecordPhotos)
                .HasForeignKey(d => d.CompliantRecordId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("record_photos_ibfk_19");

            entity.HasOne(d => d.NonCompliantRecord).WithMany(p => p.RecordPhotos)
                .HasForeignKey(d => d.NonCompliantRecordId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("record_photos_ibfk_20");

            entity.HasOne(d => d.Photo).WithMany(p => p.RecordPhotos)
                .HasForeignKey(d => d.PhotoId)
                .HasConstraintName("record_photos_ibfk_21");
        });

        modelBuilder.Entity<RecordViolation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("record_violations")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.NonCompliantRecordId, "record_violations_non_compliant_record_id");

            entity.HasIndex(e => new { e.NonCompliantRecordId, e.ViolationId }, "record_violations_non_compliant_record_id_violation_id").IsUnique();

            entity.HasIndex(e => e.ViolationId, "record_violations_violation_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.NonCompliantRecordId).HasColumnName("non_compliant_record_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.ViolationId).HasColumnName("violation_id");

            entity.HasOne(d => d.NonCompliantRecord).WithMany(p => p.RecordViolations)
                .HasForeignKey(d => d.NonCompliantRecordId)
                .HasConstraintName("record_violations_ibfk_13");

            entity.HasOne(d => d.Violation).WithMany(p => p.RecordViolations)
                .HasForeignKey(d => d.ViolationId)
                .HasConstraintName("record_violations_ibfk_14");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("roles")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Name, "roles_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("enum('admin','fiscalizador')")
                .HasColumnName("name");
            entity.Property(e => e.RequiresDeviceInfo).HasColumnName("requiresDeviceInfo");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<TechnicalReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PRIMARY");

            entity
                .ToTable("technical_reviews")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ExpirationDate, "technical_reviews_expiration_date");

            entity.HasIndex(e => e.InspectionResult, "technical_reviews_inspection_result");

            entity.HasIndex(e => e.ReviewId, "technical_reviews_review_id").IsUnique();

            entity.HasIndex(e => e.VehiclePlate, "technical_reviews_vehicle_plate");

            entity.Property(e => e.ReviewId)
                .HasMaxLength(30)
                .HasComment("ID único de la revisión técnica")
                .HasColumnName("review_id");
            entity.Property(e => e.CertifyingCompany)
                .HasColumnType("text")
                .HasColumnName("certifying_company");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.InspectionResult)
                .HasColumnType("enum('APROBADO','OBSERVADO')")
                .HasColumnName("inspection_result");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.VehiclePlate)
                .HasMaxLength(10)
                .HasColumnName("vehicle_plate");

            entity.HasOne(d => d.VehiclePlateNavigation).WithMany(p => p.TechnicalReviews)
                .HasForeignKey(d => d.VehiclePlate)
                .HasConstraintName("technical_reviews_ibfk_1");
        });

        modelBuilder.Entity<TrackingStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tracking_status");

            entity.HasIndex(e => e.UpdatedBy, "updatedBy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasComment("Indica si el tracking de ubicaciones está activo")
                .HasColumnName("active");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasComment("ID del administrador que actualizó el estado")
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TrackingStatuses)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tracking_status_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeviceConfigured)
                .HasComment("Indica si el fiscalizador ya configuró su dispositivo en el primer login")
                .HasColumnName("deviceConfigured");
            entity.Property(e => e.DeviceInfo)
                .HasColumnName("deviceInfo")
                .UseCollation("utf8mb4_bin");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("isActive");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("lastLogin");
            entity.Property(e => e.LastLoginDevice)
                .HasColumnType("text")
                .HasColumnName("lastLoginDevice");
            entity.Property(e => e.LastLoginIp)
                .HasMaxLength(45)
                .HasColumnName("lastLoginIp");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserLastLocation>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user_last_location");

            entity.HasIndex(e => e.UpdatedAt, "user_last_location_updated_idx");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasComment("ID del fiscalizador (1 registro por usuario)")
                .HasColumnName("userId");
            entity.Property(e => e.Accuracy)
                .HasPrecision(6, 2)
                .HasComment("Precisión del GPS en metros")
                .HasColumnName("accuracy");
            entity.Property(e => e.Latitude)
                .HasPrecision(10, 8)
                .HasComment("Latitud de la ubicación")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(11, 8)
                .HasComment("Longitud de la ubicación")
                .HasColumnName("longitude");
            entity.Property(e => e.Timestamp)
                .HasComment("Fecha y hora en que se capturó la ubicación")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.User).WithOne(p => p.UserLastLocation)
                .HasForeignKey<UserLastLocation>(d => d.UserId)
                .HasConstraintName("user_last_location_ibfk_1");
        });

        modelBuilder.Entity<UserLocationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_location_log");

            entity.HasIndex(e => e.Timestamp, "user_location_log_timestamp_idx");

            entity.HasIndex(e => new { e.UserId, e.Timestamp }, "user_location_log_user_timestamp_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accuracy)
                .HasPrecision(6, 2)
                .HasComment("Precisión del GPS en metros")
                .HasColumnName("accuracy");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Latitude)
                .HasPrecision(10, 8)
                .HasComment("Latitud de la ubicación")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(11, 8)
                .HasComment("Longitud de la ubicación")
                .HasColumnName("longitude");
            entity.Property(e => e.Timestamp)
                .HasComment("Fecha y hora en que se capturó la ubicación")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId)
                .HasComment("ID del fiscalizador que reportó la ubicación")
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.UserLocationLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_location_log_ibfk_1");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.UserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("user_roles")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_roles_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_roles_ibfk_2");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.PlateNumber).HasName("PRIMARY");

            entity
                .ToTable("vehicles")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.TypeId, "type_id");

            entity.HasIndex(e => e.CompanyRuc, "vehicles_company_ruc");

            entity.HasIndex(e => e.OwnerDni, "vehicles_owner_dni");

            entity.HasIndex(e => e.PlateNumber, "vehicles_plate_number").IsUnique();

            entity.HasIndex(e => e.VehicleStatus, "vehicles_vehicle_status");

            entity.Property(e => e.PlateNumber)
                .HasMaxLength(10)
                .HasComment("Placa del vehiculo")
                .HasColumnName("plate_number");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.CompanyRuc)
                .HasMaxLength(11)
                .HasColumnName("company_ruc");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.ManufacturingYear)
                .HasComment("anio_fabricacion")
                .HasColumnName("manufacturing_year");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.OwnerDni)
                .HasMaxLength(8)
                .HasColumnName("owner_dni");
            entity.Property(e => e.TypeId)
                .HasComment("ID del tipo de vehículo")
                .HasColumnName("type_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.VehicleStatus)
                .HasDefaultValueSql("'OPERATIVO'")
                .HasColumnType("enum('OPERATIVO','REPARACIÓN','FUERA DE SERVICIO','INSPECCIÓN')")
                .HasColumnName("vehicle_status");

            entity.HasOne(d => d.CompanyRucNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CompanyRuc)
                .HasConstraintName("vehicles_ibfk_19");

            entity.HasOne(d => d.OwnerDniNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.OwnerDni)
                .HasConstraintName("vehicles_ibfk_20");

            entity.HasOne(d => d.Type).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("vehicles_ibfk_21");
        });

        modelBuilder.Entity<VehicleType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity
                .ToTable("vehicle_types")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Name, "vehicle_types_name");

            entity.HasIndex(e => e.TypeId, "vehicle_types_type_id").IsUnique();

            entity.Property(e => e.TypeId)
                .HasComment("ID del tipo de vehículo")
                .HasColumnName("type_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasComment("Descripción del tipo de vehículo")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Nombre del tipo de vehículo")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Violation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("violations")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Code, "violations_code").IsUnique();

            entity.HasIndex(e => e.Severity, "violations_severity");

            entity.HasIndex(e => e.UitPercentage, "violations_uit_percentage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdministrativeMeasure)
                .HasColumnType("text")
                .HasColumnName("administrative_measure");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Severity)
                .HasColumnType("enum('very_serious','serious','minor')")
                .HasColumnName("severity");
            entity.Property(e => e.Target)
                .HasDefaultValueSql("'driver-owner'")
                .HasComment("driver: conductor/propietario, company: persona jurídica")
                .HasColumnType("enum('driver-owner','company')")
                .HasColumnName("target");
            entity.Property(e => e.UitPercentage)
                .HasPrecision(5, 2)
                .HasColumnName("uit_percentage");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
