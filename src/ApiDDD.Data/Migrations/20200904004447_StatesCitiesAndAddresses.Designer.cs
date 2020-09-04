﻿// <auto-generated />
using System;
using ApiDDD.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiDDD.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200904004447_StatesCitiesAndAddresses")]
    partial class StatesCitiesAndAddresses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiDDD.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ZipCode");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ApiDDD.Domain.Entities.CityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IBGECode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<Guid>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IBGECode");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ApiDDD.Domain.Entities.StateEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(944),
                            Name = "Acre",
                            ShortName = "AC"
                        },
                        new
                        {
                            Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1068),
                            Name = "Alagoas",
                            ShortName = "AL"
                        },
                        new
                        {
                            Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1076),
                            Name = "Amazonas",
                            ShortName = "AM"
                        },
                        new
                        {
                            Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1080),
                            Name = "Amapá",
                            ShortName = "AP"
                        },
                        new
                        {
                            Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1099),
                            Name = "Bahia",
                            ShortName = "BA"
                        },
                        new
                        {
                            Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1102),
                            Name = "Ceará",
                            ShortName = "CE"
                        },
                        new
                        {
                            Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1104),
                            Name = "Distrito Federal",
                            ShortName = "DF"
                        },
                        new
                        {
                            Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1108),
                            Name = "Espírito Santo",
                            ShortName = "ES"
                        },
                        new
                        {
                            Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1111),
                            Name = "Goiás",
                            ShortName = "GO"
                        },
                        new
                        {
                            Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1114),
                            Name = "Maranhão",
                            ShortName = "MA"
                        },
                        new
                        {
                            Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1117),
                            Name = "Minas Gerais",
                            ShortName = "MG"
                        },
                        new
                        {
                            Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1121),
                            Name = "Mato Grosso do Sul",
                            ShortName = "MS"
                        },
                        new
                        {
                            Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1125),
                            Name = "Mato Grosso",
                            ShortName = "MT"
                        },
                        new
                        {
                            Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1128),
                            Name = "Pará",
                            ShortName = "PA"
                        },
                        new
                        {
                            Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1131),
                            Name = "Paraíba",
                            ShortName = "PB"
                        },
                        new
                        {
                            Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1134),
                            Name = "Pernambuco",
                            ShortName = "PE"
                        },
                        new
                        {
                            Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1137),
                            Name = "Piauí",
                            ShortName = "PI"
                        },
                        new
                        {
                            Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1140),
                            Name = "Paraná",
                            ShortName = "PR"
                        },
                        new
                        {
                            Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1145),
                            Name = "Rio de Janeiro",
                            ShortName = "RJ"
                        },
                        new
                        {
                            Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1148),
                            Name = "Rio Grande do Norte",
                            ShortName = "RN"
                        },
                        new
                        {
                            Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1152),
                            Name = "Rondônia",
                            ShortName = "RO"
                        },
                        new
                        {
                            Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1154),
                            Name = "Roraima",
                            ShortName = "RR"
                        },
                        new
                        {
                            Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1157),
                            Name = "Rio Grande do Sul",
                            ShortName = "RS"
                        },
                        new
                        {
                            Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1161),
                            Name = "Santa Catarina",
                            ShortName = "SC"
                        },
                        new
                        {
                            Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1164),
                            Name = "Sergipe",
                            ShortName = "SE"
                        },
                        new
                        {
                            Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1168),
                            Name = "São Paulo",
                            ShortName = "SP"
                        },
                        new
                        {
                            Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1172),
                            Name = "Tocantins",
                            ShortName = "TO"
                        });
                });

            modelBuilder.Entity("ApiDDD.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1cb193c5-4fd6-4e64-a054-1c21ff6c5460"),
                            CreatedAt = new DateTime(2020, 9, 3, 21, 44, 47, 217, DateTimeKind.Local).AddTicks(8455),
                            Email = "admin@mail.com",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("ApiDDD.Domain.Entities.AddressEntity", b =>
                {
                    b.HasOne("ApiDDD.Domain.Entities.CityEntity", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiDDD.Domain.Entities.CityEntity", b =>
                {
                    b.HasOne("ApiDDD.Domain.Entities.StateEntity", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}