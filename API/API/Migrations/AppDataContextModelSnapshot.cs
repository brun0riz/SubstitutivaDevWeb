﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("API.Models.Aluno", b =>
                {
                    b.Property<string>("AlunoId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("API.Models.IMC", b =>
                {
                    b.Property<string>("ImcId")
                        .HasColumnType("TEXT");

                    b.Property<float>("Altura")
                        .HasColumnType("REAL");

                    b.Property<string>("AlunoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Classificacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<float>("Peso")
                        .HasColumnType("REAL");

                    b.HasKey("ImcId");

                    b.HasIndex("AlunoId");

                    b.ToTable("IMCs");
                });

            modelBuilder.Entity("API.Models.IMC", b =>
                {
                    b.HasOne("API.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.Navigation("Aluno");
                });
#pragma warning restore 612, 618
        }
    }
}
