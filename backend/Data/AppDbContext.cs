using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Budget> Budgets { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<RecurringTransaction> RecurringTransactions { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=finance_db;Username=postgres;Password=Fcps1ts1g&pg&pg&p");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // USER
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.HasKey(e => e.UserId).HasName("user_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Username).HasColumnName("username").HasMaxLength(52);
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(100);
            entity.Property(e => e.Salt).HasColumnName("salt").HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp without time zone");
        });

        // BUDGET
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.ToTable("budget");

            entity.HasKey(e => e.BudgetId).HasName("budget_pk");

            entity.Property(e => e.BudgetId).HasColumnName("budget_id");
            entity.Property(e => e.MonthlyLimit).HasColumnName("monthlylimit").HasColumnType("money");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(e => e.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("budget_category");

            entity.HasOne(e => e.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("budget_user");
        });

        // CATEGORY
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.HasKey(e => e.CategoryId).HasName("category_pk");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name").HasMaxLength(52);
            entity.Property(e => e.CategoryColor).HasColumnName("category_color").HasMaxLength(7);
        });

        // RECURRING TRANSACTION
        modelBuilder.Entity<RecurringTransaction>(entity =>
        {
            entity.ToTable("recurringtransaction", t =>
                t.HasCheckConstraint("CK_RecurringTransaction_Frequency",
                    "frequency IN ('Daily', 'Weekly', 'Monthly', 'Yearly')")
            );

            entity.HasKey(e => e.RecurringTransactionId).HasName("recurringtransaction_pk");

            entity.Property(e => e.RecurringTransactionId).HasColumnName("recurringtransaction_id");
            entity.Property(e => e.Amount).HasColumnName("amount").HasColumnType("money");
            entity.Property(e => e.Frequency).HasColumnName("frequency").HasMaxLength(10);
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(e => e.Category)
                .WithMany(c => c.RecurringTransactions)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("recurringtransaction_category");

            entity.HasOne(e => e.User)
                .WithMany(u => u.RecurringTransactions)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("recurringtransaction_user");
        });

        // TRANSACTION
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("transaction");

            entity.HasKey(e => e.TransactionId).HasName("transaction_pk");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Amount).HasColumnName("amount").HasColumnType("money");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(e => e.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("transaction_category");

            entity.HasOne(e => e.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("transaction_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

