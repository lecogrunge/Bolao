﻿// <auto-generated />
using System;
using Bolao.Infra.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bolao.Infra.Migrations
{
    [DbContext(typeof(BolaoContext))]
    partial class BolaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaBetNumber", b =>
                {
                    b.Property<int>("MegaSenaBetNumberId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number");

                    b.Property<Guid>("LotteryId");

                    b.HasKey("MegaSenaBetNumberId");

                    b.HasIndex("LotteryId");

                    b.ToTable("MegaSenaBetNumber");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaLottery", b =>
                {
                    b.Property<Guid>("MegaSenaLoterryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("LoterryDate");

                    b.Property<int>("LoterryOfficialNumberBet");

                    b.HasKey("MegaSenaLoterryId");

                    b.ToTable("MegaSenaLottery");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaLotteryNumber", b =>
                {
                    b.Property<int>("MegaSenaLoterryNumberId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("MegaSenaLoterryId");

                    b.Property<string>("Number");

                    b.HasKey("MegaSenaLoterryNumberId");

                    b.HasIndex("MegaSenaLoterryId");

                    b.ToTable("MegaSenaLotteryNumber");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.OwnerJackpot", b =>
                {
                    b.Property<int>("OwnerJackpotId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Jackpot");

                    b.Property<Guid>("MegaSenaLoterryId");

                    b.HasKey("OwnerJackpotId");

                    b.ToTable("OwnerJackpot");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.Lottery", b =>
                {
                    b.Property<Guid>("LotteryId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("EndDateBet");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StartDateBet");

                    b.Property<int>("StatusPagSeguro");

                    b.Property<int>("TypeBetId");

                    b.HasKey("LotteryId");

                    b.ToTable("Lottery");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.TypeBet", b =>
                {
                    b.Property<int>("TypeBetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("TypeBetId");

                    b.ToTable("TypeBet");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.User", b =>
                {
                    b.Property<Guid>("UserId")
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

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.WinnerJackpot", b =>
                {
                    b.Property<int>("WinnerJackpotId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("JackPot");

                    b.Property<Guid>("LotteryId");

                    b.Property<Guid>("UserId");

                    b.HasKey("WinnerJackpotId");

                    b.HasIndex("LotteryId");

                    b.HasIndex("UserId");

                    b.ToTable("WinnerJackpot");
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaBetNumber", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.Lottery", "Lottery")
                        .WithMany("ListBetNumbers")
                        .HasForeignKey("LotteryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bolao.Domain.Domains.MegaSenaLotteryNumber", b =>
                {
                    b.HasOne("Bolao.Domain.Domains.MegaSenaLottery", "MegaSenaLottery")
                        .WithMany("ListNumbers")
                        .HasForeignKey("MegaSenaLoterryId")
                        .OnDelete(DeleteBehavior.Cascade);
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
