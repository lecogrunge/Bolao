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
    [Migration("20190409081048_teste22")]
    partial class teste22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bolao.Domain.Domains.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("BankId");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Buy", b =>
                {
                    b.Property<Guid>("BuyId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("LotteryId");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("TotalTicket");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<Guid>("UserId");

                    b.HasKey("BuyId");

                    b.HasIndex("LotteryId");

                    b.HasIndex("UserId");

                    b.ToTable("Buy");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Lottery", b =>
                {
                    b.Property<Guid>("LoterryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EndDateBet");

                    b.Property<DateTime>("LotteryDateBet");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("StartDateBet");

                    b.Property<int>("StatusPagSeguro");

                    b.Property<int>("TypeBetId");

                    b.HasKey("LoterryId");

                    b.HasIndex("TypeBetId");

                    b.ToTable("Lottery");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.LotteryNumberBet", b =>
                {
                    b.Property<int>("LotteryNumberBetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number");

                    b.Property<Guid>("TicketId");

                    b.HasKey("LotteryNumberBetId");

                    b.HasIndex("TicketId");

                    b.ToTable("LotteryNumberBet");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.LotteryNumberResult", b =>
                {
                    b.Property<int>("LotteryNumberResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("LoterryId");

                    b.Property<string>("Number");

                    b.HasKey("LotteryNumberResultId");

                    b.HasIndex("LoterryId");

                    b.ToTable("LotteryNumberResult");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.OwnerJackpot", b =>
                {
                    b.Property<int>("OwnerJackpotId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Jackpot")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<Guid>("LotteryId");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("OwnerJackpotId");

                    b.HasIndex("LotteryId");

                    b.ToTable("OwnerJackpot");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuyId");

                    b.Property<Guid?>("BuyId1");

                    b.HasKey("TicketId");

                    b.HasIndex("BuyId1");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.TypeBet", b =>
                {
                    b.Property<int>("TypeBetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("TypeBetId");

                    b.ToTable("TypeBet");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FisrtName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("TokenConfirm");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.WinnerJackpot", b =>
                {
                    b.Property<int>("WinnerJackpotId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("JackPot")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<Guid>("LotteryId");

                    b.Property<Guid>("UserId");

                    b.HasKey("WinnerJackpotId");

                    b.HasIndex("LotteryId");

                    b.HasIndex("UserId");

                    b.ToTable("WinnerJackpot");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Buy", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Lottery", "Lottery")
                        .WithMany()
                        .HasForeignKey("LotteryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bolao.Domain.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Lottery", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.TypeBet", "TypeBet")
                        .WithMany()
                        .HasForeignKey("TypeBetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.LotteryNumberBet", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.LotteryNumberResult", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Lottery", "Lottery")
                        .WithMany("ListNumbersResult")
                        .HasForeignKey("LoterryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.OwnerJackpot", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Lottery", "Lottery")
                        .WithMany()
                        .HasForeignKey("LotteryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Ticket", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Buy", "Buy")
                        .WithMany()
                        .HasForeignKey("BuyId1");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.User", b =>
                {
                    b.OwnsOne("Bolao.Domain.ObjectValue.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasMaxLength(80);

                            b1.ToTable("User");

                            b1.HasOne("Bolao.Domain.Domains.User")
                                .WithOne("Email")
                                .HasForeignKey("Bolao.Domain.ObjectValue.Email", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Bolao.Domain.Domains.WinnerJackpot", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Lottery", "Lottery")
                        .WithMany()
                        .HasForeignKey("LotteryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bolao.Domain.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
