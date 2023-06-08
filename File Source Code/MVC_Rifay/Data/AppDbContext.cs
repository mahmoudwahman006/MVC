using System;
using Microsoft.EntityFrameworkCore;
using MVC_Rifay.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Booking_Details> BookingDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Credit_Card> CreditCards { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Admin> Admins{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add any additional configuration here
    }
}