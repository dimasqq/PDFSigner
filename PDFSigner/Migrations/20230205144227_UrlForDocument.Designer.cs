﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PDFSigner.Data;

#nullable disable

namespace PDFSigner.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230205144227_UrlForDocument")]
    partial class UrlForDocument
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PDFSigner.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("Details");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Company", "public");
                });

            modelBuilder.Entity("PDFSigner.Data.Entities.CompanyDocument", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsViewed")
                        .HasColumnType("boolean");

                    b.HasKey("CompanyId", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.ToTable("RLCompanyDocument");
                });

            modelBuilder.Entity("PDFSigner.Data.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DocumentURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PdfFile");

                    b.Property<bool>("IsSigned")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Document", "public");
                });

            modelBuilder.Entity("PDFSigner.Data.Entities.CompanyDocument", b =>
                {
                    b.HasOne("PDFSigner.Data.Entities.Company", "SignCompany")
                        .WithMany("DocumentSigners")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDFSigner.Data.Entities.Document", "SignDocument")
                        .WithMany("SignCompanies")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SignCompany");

                    b.Navigation("SignDocument");
                });

            modelBuilder.Entity("PDFSigner.Data.Entities.Company", b =>
                {
                    b.Navigation("DocumentSigners");
                });

            modelBuilder.Entity("PDFSigner.Data.Entities.Document", b =>
                {
                    b.Navigation("SignCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}