﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicmansoWebAPI.Models;

#nullable disable

namespace TicmansoWebAPI.Migrations
{
    [DbContext(typeof(TicmansoProContext))]
    [Migration("20240408103301_AddIdentityTables")]
    partial class AddIdentityTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TicmansoWebAPI.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Messages")
                        .HasColumnType("text")
                        .HasColumnName("messages");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("UserId1")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id1")
                        .HasComment("TRIAL");

                    b.HasKey("Id")
                        .HasName("pk_chat");

                    b.HasIndex(new[] { "UserId" }, "fk_chat_user1_idx");

                    SqlServerIndexBuilderExtensions.HasFillFactor(b.HasIndex(new[] { "UserId" }, "fk_chat_user1_idx"), 99);

                    b.HasIndex(new[] { "UserId1" }, "fk_chat_user2_idx");

                    SqlServerIndexBuilderExtensions.HasFillFactor(b.HasIndex(new[] { "UserId1" }, "fk_chat_user2_idx"), 99);

                    b.ToTable("chat", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasComment("TRIAL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address")
                        .HasComment("TRIAL");

                    b.Property<string>("Cif")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("cif")
                        .HasComment("TRIAL");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city")
                        .HasComment("TRIAL");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("country")
                        .HasComment("TRIAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name")
                        .HasComment("TRIAL");

                    b.Property<long>("PostalCode")
                        .HasColumnType("bigint")
                        .HasColumnName("postalCode")
                        .HasComment("TRIAL");

                    b.HasKey("Id")
                        .HasName("pk_company");

                    b.ToTable("company", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.GeneralViewTicket", b =>
                {
                    b.Property<long>("CreationUser")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("NumTicket")
                        .HasColumnType("bigint");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SuportUser")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.ToTable((string)null);

                    b.ToView("GeneralViewTicket", (string)null);
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Priority", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasComment("TRIAL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_priority");

                    b.ToTable("priority", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasComment("TRIAL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name")
                        .HasComment("TRIAL");

                    b.HasKey("Id")
                        .HasName("pk_role");

                    b.ToTable("role", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Signing", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date")
                        .HasComment("TRIAL");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("departure_time")
                        .HasComment("TRIAL");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("entry_time")
                        .HasComment("TRIAL");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasComment("TRIAL");

                    b.HasKey("Date")
                        .HasName("pk_signing");

                    b.HasIndex(new[] { "UserId" }, "idx_user_id");

                    SqlServerIndexBuilderExtensions.HasFillFactor(b.HasIndex(new[] { "UserId" }, "idx_user_id"), 99);

                    b.ToTable("signing", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_status");

                    b.ToTable("status", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ChangedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("changed_date");

                    b.Property<int?>("ChatId")
                        .HasColumnType("int")
                        .HasColumnName("chat_id");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime")
                        .HasColumnName("close_date");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("creation_date");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("creation_user_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long>("PriorityId")
                        .HasColumnType("bigint")
                        .HasColumnName("priority_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<long?>("SupportUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("Support_user_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_ticket");

                    b.HasIndex("ChatId");

                    b.HasIndex("CreationUserId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SupportUserId");

                    b.ToTable("ticket", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint")
                        .HasColumnName("company_id");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("mail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("password");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<string>("Surnames")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("surnames");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex(new[] { "CompanyId" }, "fk_user_company1_idx");

                    SqlServerIndexBuilderExtensions.HasFillFactor(b.HasIndex(new[] { "CompanyId" }, "fk_user_company1_idx"), 99);

                    b.HasIndex(new[] { "RoleId" }, "fk_user_role1_idx");

                    SqlServerIndexBuilderExtensions.HasFillFactor(b.HasIndex(new[] { "RoleId" }, "fk_user_role1_idx"), 99);

                    b.ToTable("user", null, t =>
                        {
                            t.HasComment("TRIAL");
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TicmansoWebAPI.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TicmansoWebAPI.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicmansoWebAPI.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TicmansoWebAPI.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Chat", b =>
                {
                    b.HasOne("TicmansoWebAPI.Models.User", "User")
                        .WithMany("ChatUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_chat_user1");

                    b.HasOne("TicmansoWebAPI.Models.User", "UserId1Navigation")
                        .WithMany("ChatUserId1Navigations")
                        .HasForeignKey("UserId1")
                        .IsRequired()
                        .HasConstraintName("fk_chat_user2");

                    b.Navigation("User");

                    b.Navigation("UserId1Navigation");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Signing", b =>
                {
                    b.HasOne("TicmansoWebAPI.Models.User", "User")
                        .WithMany("Signings")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("signing_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Ticket", b =>
                {
                    b.HasOne("TicmansoWebAPI.Models.Chat", "Chat")
                        .WithMany("Tickets")
                        .HasForeignKey("ChatId")
                        .HasConstraintName("ticket_ibfk_1");

                    b.HasOne("TicmansoWebAPI.Models.User", "CreationUser")
                        .WithMany("TicketCreationUsers")
                        .HasForeignKey("CreationUserId")
                        .IsRequired()
                        .HasConstraintName("fk_ticket_user1");

                    b.HasOne("TicmansoWebAPI.Models.Priority", "Priority")
                        .WithMany("Tickets")
                        .HasForeignKey("PriorityId")
                        .IsRequired()
                        .HasConstraintName("fk_ticket_priority1");

                    b.HasOne("TicmansoWebAPI.Models.Status", "Status")
                        .WithMany("Tickets")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("fk_ticket_status1");

                    b.HasOne("TicmansoWebAPI.Models.User", "SupportUser")
                        .WithMany("TicketSupportUsers")
                        .HasForeignKey("SupportUserId")
                        .HasConstraintName("fk_ticket_user2");

                    b.Navigation("Chat");

                    b.Navigation("CreationUser");

                    b.Navigation("Priority");

                    b.Navigation("Status");

                    b.Navigation("SupportUser");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.User", b =>
                {
                    b.HasOne("TicmansoWebAPI.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("fk_user_company1");

                    b.HasOne("TicmansoWebAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("fk_user_role1");

                    b.Navigation("Company");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Chat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Priority", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.Status", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicmansoWebAPI.Models.User", b =>
                {
                    b.Navigation("ChatUserId1Navigations");

                    b.Navigation("ChatUsers");

                    b.Navigation("Signings");

                    b.Navigation("TicketCreationUsers");

                    b.Navigation("TicketSupportUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
