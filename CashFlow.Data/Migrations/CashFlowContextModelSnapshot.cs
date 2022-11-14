﻿// <auto-generated />
using System;
using CashFlow.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashFlow.Data.Migrations
{
    [DbContext(typeof(CashFlowContext))]
    partial class CashFlowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashFlow.Domain.Entities.Flow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 11, 12, 20, 23, 49, 701, DateTimeKind.Local).AddTicks(7103));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlowType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Flows");

                    b.HasData(
                        new
                        {
                            Id = new Guid("022c5946-ba72-4706-9d7d-5015dd574978"),
                            DateCreated = new DateTime(2022, 11, 12, 20, 23, 49, 709, DateTimeKind.Local).AddTicks(1180),
                            FlowType = "C",
                            IsDeleted = false,
                            Value = 12.300000000000001
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
