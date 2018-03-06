﻿// <auto-generated />
using BA.Database.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BA.Database.Migrations
{
    [DbContext(typeof(DataContext.DataContext))]
    [Migration("20180306175402_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BA.Database.Modeles.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<int?>("UserInfoId");

                    b.Property<int>("UsurId");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BA.Database.Modeles.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountInfo1Id");

                    b.Property<int?>("AccountInfoId");

                    b.Property<int?>("AccountInitiator");

                    b.Property<int>("AccountRecipient");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Summa");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountInfo1Id");

                    b.HasIndex("AccountInfoId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BA.Database.Modeles.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Useers");
                });

            modelBuilder.Entity("BA.Database.Modeles.Account", b =>
                {
                    b.HasOne("BA.Database.Modeles.User", "UserInfo")
                        .WithMany("AccountInfo")
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("BA.Database.Modeles.Transaction", b =>
                {
                    b.HasOne("BA.Database.Modeles.Account", "AccountInfo1")
                        .WithMany()
                        .HasForeignKey("AccountInfo1Id");

                    b.HasOne("BA.Database.Modeles.Account", "AccountInfo")
                        .WithMany()
                        .HasForeignKey("AccountInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}