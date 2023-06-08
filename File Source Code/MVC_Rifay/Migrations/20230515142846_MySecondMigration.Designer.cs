﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Rifay.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230515142846_MySecondMigration")]
    partial class MySecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_Rifay.Models.Booking", b =>
                {
                    b.Property<int>("booking_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("booking_id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<float>("total_amount")
                        .HasColumnType("real");

                    b.HasKey("booking_id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Booking_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BookingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("RoomCategoryId")
                        .IsUnique();

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Credit_Card", b =>
                {
                    b.Property<int>("CreditCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditCardId"));

                    b.Property<string>("CVV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CreditCardId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("credit_cardCreditCardId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("credit_cardCreditCardId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("RoomCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("imge")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("RoomCategoryId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Room_Category", b =>
                {
                    b.Property<int>("RoomCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomCategoryId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RCFloor")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("RCPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RoomCategoryId");

                    b.ToTable("RoomCategories");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Booking", b =>
                {
                    b.HasOne("MVC_Rifay.Models.Customer", null)
                        .WithMany("bookings")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Booking_Details", b =>
                {
                    b.HasOne("MVC_Rifay.Models.Booking", "Booking")
                        .WithOne("booking_details")
                        .HasForeignKey("MVC_Rifay.Models.Booking_Details", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Rifay.Models.Room_Category", "RoomCategory")
                        .WithOne("booking_details")
                        .HasForeignKey("MVC_Rifay.Models.Booking_Details", "RoomCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Rifay.Models.Room", "Room")
                        .WithOne("booking_details")
                        .HasForeignKey("MVC_Rifay.Models.Booking_Details", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Room");

                    b.Navigation("RoomCategory");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Credit_Card", b =>
                {
                    b.HasOne("MVC_Rifay.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Payment", b =>
                {
                    b.HasOne("MVC_Rifay.Models.Booking", "Booking")
                        .WithOne("payment")
                        .HasForeignKey("MVC_Rifay.Models.Payment", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Rifay.Models.Credit_Card", "credit_card")
                        .WithMany("payments")
                        .HasForeignKey("credit_cardCreditCardId");

                    b.Navigation("Booking");

                    b.Navigation("credit_card");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Room", b =>
                {
                    b.HasOne("MVC_Rifay.Models.Room_Category", "RoomCategory")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomCategory");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Booking", b =>
                {
                    b.Navigation("booking_details");

                    b.Navigation("payment");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Credit_Card", b =>
                {
                    b.Navigation("payments");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Customer", b =>
                {
                    b.Navigation("bookings");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Room", b =>
                {
                    b.Navigation("booking_details");
                });

            modelBuilder.Entity("MVC_Rifay.Models.Room_Category", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("booking_details");
                });
#pragma warning restore 612, 618
        }
    }
}