﻿// <auto-generated />
using System;
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmesApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class FilmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("FilmesApi.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("GerenteId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("FilmesApi.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("FilmesApi.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<byte[]>("Cartaz")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<int>("ClassificacaoEtaria")
                        .HasColumnType("int");

                    b.Property<string>("Diretor")
                        .HasColumnType("longtext");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("FilmesApi.Entities.Gerente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("FilmesApi.Entities.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioDeEncerramento")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("FilmesApi.Entities.Cinema", b =>
                {
                    b.HasOne("FilmesApi.Entities.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("FilmesApi.Entities.Cinema", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmesApi.Entities.Gerente", "Gerente")
                        .WithMany("Cinemas")
                        .HasForeignKey("GerenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("FilmesApi.Entities.Sessao", b =>
                {
                    b.HasOne("FilmesApi.Entities.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmesApi.Entities.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("FilmesApi.Entities.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("FilmesApi.Entities.Endereco", b =>
                {
                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("FilmesApi.Entities.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("FilmesApi.Entities.Gerente", b =>
                {
                    b.Navigation("Cinemas");
                });
#pragma warning restore 612, 618
        }
    }
}
