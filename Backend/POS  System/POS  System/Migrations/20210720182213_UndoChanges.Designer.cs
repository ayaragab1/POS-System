// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS__System;

namespace POS__System.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20210720182213_UndoChanges")]
    partial class UndoChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POS__System.Models.Invoice", b =>
                {
                    b.Property<int>("Invoice_Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("Invoice_Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total_Price")
                        .HasColumnType("float");

                    b.HasKey("Invoice_Number");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("POS__System.Models.Invoice_Details", b =>
                {
                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<int>("Invoice_Number")
                        .HasColumnType("int");

                    b.Property<int>("TQuantity_PerItem")
                        .HasColumnType("int");

                    b.Property<double>("Total_Payment")
                        .HasColumnType("float");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Product_ID", "Invoice_Number");

                    b.HasIndex("Invoice_Number");

                    b.ToTable("Invoice_Details");
                });

            modelBuilder.Entity("POS__System.Models.Products", b =>
                {
                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Unit_Price")
                        .HasColumnType("float");

                    b.HasKey("Product_ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("POS__System.Models.Invoice_Details", b =>
                {
                    b.HasOne("POS__System.Models.Invoice", null)
                        .WithMany("Invoice_Details")
                        .HasForeignKey("Invoice_Number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS__System.Models.Products", null)
                        .WithMany("Invoice_Details")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("POS__System.Models.Invoice", b =>
                {
                    b.Navigation("Invoice_Details");
                });

            modelBuilder.Entity("POS__System.Models.Products", b =>
                {
                    b.Navigation("Invoice_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
