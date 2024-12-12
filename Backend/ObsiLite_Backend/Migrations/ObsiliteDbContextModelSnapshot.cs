﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObsiLite_Backend.models;

#nullable disable

namespace ObsiLite_Backend.Migrations
{
    [DbContext(typeof(ObsiliteDbContext))]
    partial class ObsiliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObsiLite_Backend.models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FolderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Folder");
                });

            modelBuilder.Entity("ObsiLite_Backend.models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("FolderId")
                        .HasColumnType("int");

                    b.Property<int?>("NoteId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("NoteId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("ObsiLite_Backend.models.Folder", b =>
                {
                    b.HasOne("ObsiLite_Backend.models.Folder", null)
                        .WithMany("ChildrenFolders")
                        .HasForeignKey("FolderId");
                });

            modelBuilder.Entity("ObsiLite_Backend.models.Note", b =>
                {
                    b.HasOne("ObsiLite_Backend.models.Folder", null)
                        .WithMany("Notes")
                        .HasForeignKey("FolderId");

                    b.HasOne("ObsiLite_Backend.models.Note", null)
                        .WithMany("References")
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("ObsiLite_Backend.models.Folder", b =>
                {
                    b.Navigation("ChildrenFolders");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("ObsiLite_Backend.models.Note", b =>
                {
                    b.Navigation("References");
                });
#pragma warning restore 612, 618
        }
    }
}
