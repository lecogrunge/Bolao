﻿// <auto-generated />
using System;
using Bolao.Infra.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bolao.Infra.Migrations
{
    [DbContext(typeof(BolaoContext))]
    [Migration("20190331112551_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaBetNumber", b =>
                {
                    b.Property<int>("IdMegaSenaBetNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("IdLottery");

                    b.Property<string>("Number");

                    b.HasKey("IdMegaSenaBetNumber");

                    b.HasIndex("IdLottery");

                    b.ToTable("MegaSenaBetNumber");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaLottery", b =>
                {
                    b.Property<Guid>("IdMegaSenaLoterry")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("LoterryDate");

                    b.Property<int>("LoterryOfficialNumberBet");

                    b.HasKey("IdMegaSenaLoterry");

                    b.ToTable("MegaSenaLottery");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaLotteryNumber", b =>
                {
                    b.Property<int>("IdMegaSenaLoterryNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("IdMegaSenaLoterry");

                    b.Property<string>("Number");

                    b.HasKey("IdMegaSenaLoterryNumber");

                    b.HasIndex("IdMegaSenaLoterry");

                    b.ToTable("MegaSenaLotteryNumber");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Lottery", b =>
                {
                    b.Property<Guid>("IdLottery")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("EndDateBet");

                    b.Property<int>("IdTypeBet");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StartDateBet");

                    b.Property<int>("StatusPagSeguro");

                    b.HasKey("IdLottery");

                    b.ToTable("Lottery");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.TypeBet", b =>
                {
                    b.Property<int>("IdTypeBet")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("IdTypeBet");

                    b.ToTable("TypeBet");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.User", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("FisrtName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<Guid>("TokenConfirm");

                    b.HasKey("IdUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaBetNumber", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Lottery", "Lottery")
                        .WithMany("ListBetNumbers")
                        .HasForeignKey("IdLottery")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaLotteryNumber", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.MegaSenaLottery")
                        .WithMany("ListNumbers")
                        .HasForeignKey("IdMegaSenaLoterry")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.User", b =>
                {
                    b.OwnsOne("Bolao.Domain.ObjectValue.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserIdUser");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasMaxLength(80);

                            b1.ToTable("User");

                            b1.HasOne("Bolao.Domain.Domains.User")
                                .WithOne("Email")
                                .HasForeignKey("Bolao.Domain.ObjectValue.Email", "UserIdUser")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
