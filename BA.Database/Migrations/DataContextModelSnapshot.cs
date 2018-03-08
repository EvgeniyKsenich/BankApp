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
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BA.Database.Enteties.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<int?>("UserInfoId");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BA.Database.Enteties.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountInfoInitiatorId");

                    b.Property<int?>("AccountInfoRecipientId");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Summa");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountInfoInitiatorId");

                    b.HasIndex("AccountInfoRecipientId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BA.Database.Enteties.User", b =>
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

            modelBuilder.Entity("BA.Database.Enteties.Account", b =>
                {
                    b.HasOne("BA.Database.Enteties.User", "UserInfo")
                        .WithMany("AccountInfo")
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("BA.Database.Enteties.Transaction", b =>
                {
                    b.HasOne("BA.Database.Enteties.Account", "AccountInfoInitiator")
                        .WithMany()
                        .HasForeignKey("AccountInfoInitiatorId");

                    b.HasOne("BA.Database.Enteties.Account", "AccountInfoRecipient")
                        .WithMany()
                        .HasForeignKey("AccountInfoRecipientId");
                });
#pragma warning restore 612, 618
        }
    }
}
