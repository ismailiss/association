﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using association.Services;

namespace association.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190217113111_mig19")]
    partial class mig19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("association.Models.asso_config.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("AssociationID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nom")
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Prenom")
                        .HasMaxLength(30);

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AssociationID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("association.Models.Association", b =>
                {
                    b.Property<int>("AssociationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasMaxLength(255);

                    b.Property<string>("Nom")
                        .HasMaxLength(30);

                    b.Property<string>("Telephone")
                        .HasMaxLength(15);

                    b.HasKey("AssociationID");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("association.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasMaxLength(255);

                    b.Property<int>("AssociationID");

                    b.Property<string>("CIN")
                        .HasMaxLength(10);

                    b.Property<string>("Nom")
                        .HasMaxLength(30);

                    b.Property<string>("Prenom")
                        .HasMaxLength(30);

                    b.Property<string>("Telephone")
                        .HasMaxLength(15);

                    b.HasKey("ClientID");

                    b.HasIndex("AssociationID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("association.Models.CompteurEau", b =>
                {
                    b.Property<int>("CompteurEauID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Actif");

                    b.Property<int>("ClientID");

                    b.Property<DateTime>("DateDebut");

                    b.Property<DateTime?>("DateFin");

                    b.Property<string>("Emplacement");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("CompteurEauID");

                    b.HasIndex("ClientID");

                    b.ToTable("CompteurEaus");
                });

            modelBuilder.Entity("association.Models.Facture", b =>
                {
                    b.Property<int>("FactureID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompteurEauID");

                    b.Property<DateTime>("DateFacture");

                    b.Property<DateTime>("FactureDe");

                    b.Property<int?>("FacturesGenereeID");

                    b.Property<int?>("TarifID");

                    b.Property<int>("ValeurCompteur");

                    b.Property<int>("ValeurCompteurPrecedente");

                    b.Property<bool>("isPayee");

                    b.HasKey("FactureID");

                    b.HasIndex("CompteurEauID");

                    b.HasIndex("FacturesGenereeID");

                    b.HasIndex("TarifID");

                    b.ToTable("Factures");
                });

            modelBuilder.Entity("association.Models.FacturesGeneree", b =>
                {
                    b.Property<int>("FacturesGenereeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssociationID");

                    b.Property<DateTime>("DateFactures");

                    b.Property<DateTime>("DateGeneration");

                    b.Property<DateTime>("FactureDe");

                    b.Property<int?>("FacturesGenereeID1");

                    b.HasKey("FacturesGenereeID");

                    b.HasIndex("AssociationID");

                    b.HasIndex("FacturesGenereeID1");

                    b.ToTable("FacturesGeneree");
                });

            modelBuilder.Entity("association.Models.Tarif", b =>
                {
                    b.Property<int>("TarifID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateApplication");

                    b.Property<DateTime?>("DateFinApplication");

                    b.Property<float>("Montant");

                    b.HasKey("TarifID");

                    b.ToTable("Tarif");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("association.Models.asso_config.ApplicationRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Description")
                        .HasMaxLength(30);

                    b.ToTable("ApplicationRole");

                    b.HasDiscriminator().HasValue("ApplicationRole");
                });

            modelBuilder.Entity("association.Models.asso_config.ApplicationUser", b =>
                {
                    b.HasOne("association.Models.Association", "Association")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("AssociationID");
                });

            modelBuilder.Entity("association.Models.Client", b =>
                {
                    b.HasOne("association.Models.Association", "Association")
                        .WithMany("Clients")
                        .HasForeignKey("AssociationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("association.Models.CompteurEau", b =>
                {
                    b.HasOne("association.Models.Client", "Client")
                        .WithMany("Compteurs")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("association.Models.Facture", b =>
                {
                    b.HasOne("association.Models.CompteurEau", "CompteurEau")
                        .WithMany("Factures")
                        .HasForeignKey("CompteurEauID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("association.Models.FacturesGeneree", "FacturesGeneree")
                        .WithMany()
                        .HasForeignKey("FacturesGenereeID");

                    b.HasOne("association.Models.Tarif", "Tarif")
                        .WithMany("Factures")
                        .HasForeignKey("TarifID");
                });

            modelBuilder.Entity("association.Models.FacturesGeneree", b =>
                {
                    b.HasOne("association.Models.Association", "Association")
                        .WithMany("FacturesGenerees")
                        .HasForeignKey("AssociationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("association.Models.FacturesGeneree")
                        .WithMany("FacturesGenerees")
                        .HasForeignKey("FacturesGenereeID1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("association.Models.asso_config.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("association.Models.asso_config.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("association.Models.asso_config.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("association.Models.asso_config.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
