﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheTaleOfU.NetCore.DataLayer;

namespace TheTaleOfU.NetCore.DataLayer.Migrations
{
    [DbContext(typeof(TheTaleOfUContext))]
    [Migration("20190114135307_fixInventory#")]
    partial class fixInventory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.GainItemEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GainItemEventId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomText");

                    b.Property<int?>("ItemId");

                    b.Property<int>("OptionId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OptionId");

                    b.ToTable("GainItemEvents");
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ItemId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("Durability");

                    b.Property<string>("Name");

                    b.Property<int>("Rarity");

                    b.Property<int>("Type");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OptionId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("NextScenarioId");

                    b.Property<int>("OptionIdentifier");

                    b.Property<int>("OriginScenarioId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("NextScenarioId");

                    b.HasIndex("OriginScenarioId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PlayerGuid");

                    b.Property<int>("Health");

                    b.Property<string>("Name");

                    b.Property<int>("PlayerType");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.PlayerInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PlayerInventoryId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<Guid>("PlayerGuid");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PlayerGuid");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ScenarioId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllowedPlayerTypes");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Scenarios");
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.GainItemEvent", b =>
                {
                    b.HasOne("TheTaleOfU.NetCore.EntityLayer.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("TheTaleOfU.NetCore.EntityLayer.Option", "Option")
                        .WithMany("GainItemEvents")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.Option", b =>
                {
                    b.HasOne("TheTaleOfU.NetCore.EntityLayer.Scenario", "NextScenario")
                        .WithMany()
                        .HasForeignKey("NextScenarioId");

                    b.HasOne("TheTaleOfU.NetCore.EntityLayer.Scenario", "OriginScenario")
                        .WithMany("Options")
                        .HasForeignKey("OriginScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheTaleOfU.NetCore.EntityLayer.PlayerInventory", b =>
                {
                    b.HasOne("TheTaleOfU.NetCore.EntityLayer.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TheTaleOfU.NetCore.EntityLayer.Player", "Player")
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
