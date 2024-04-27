﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.Api.Data;

namespace SmartSchool.Api.Migrations
{
    [DbContext(typeof(SmartSchoolContext))]
    partial class SmartSchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("SmartSchool.Api.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("SobreNome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(52),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Matricula = 1,
                            Nome = "Marta",
                            SobreNome = "Kent",
                            Telefone = "33225555"
                        },
                        new
                        {
                            Id = 2,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2795),
                            DataNascimento = new DateTime(2005, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Matricula = 2,
                            Nome = "Paula",
                            SobreNome = "Isabela",
                            Telefone = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2866),
                            DataNascimento = new DateTime(2005, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Matricula = 3,
                            Nome = "Laura",
                            SobreNome = "Antonia",
                            Telefone = "55668899"
                        },
                        new
                        {
                            Id = 4,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2874),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Matricula = 4,
                            Nome = "Luiza",
                            SobreNome = "Maria",
                            Telefone = "6565659"
                        },
                        new
                        {
                            Id = 5,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2881),
                            DataNascimento = new DateTime(2005, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Matricula = 5,
                            Nome = "Lucas",
                            SobreNome = "Machado",
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2894),
                            DataNascimento = new DateTime(2005, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Matricula = 6,
                            Nome = "Pedro",
                            SobreNome = "Alvares",
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2901),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Matricula = 7,
                            Nome = "Paulo",
                            SobreNome = "José",
                            Telefone = "9874512"
                        });
                });

            modelBuilder.Entity("SmartSchool.Api.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("SmartSchool.Api.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(4779)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5692)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5739)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5742)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5743)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5748)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5750)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5752)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5753)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5757)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5758)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5760)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5761)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5763)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5764)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5766)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5768)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5770)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5772)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5774)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5775)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5777)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5778)
                        });
                });

            modelBuilder.Entity("SmartSchool.Api.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tecnologia da Informação"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sistema de Informação"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ciência da Computação"
                        });
                });

            modelBuilder.Entity("SmartSchool.Api.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PreRequisitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PreRequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Name = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Name = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Name = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Name = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Name = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 6,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Name = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 7,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Name = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 8,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Name = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 9,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Name = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 10,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Name = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.Api.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Registro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SobreNome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 532, DateTimeKind.Local).AddTicks(1168),
                            IsActive = true,
                            Nome = "Lauro",
                            Registro = 1,
                            SobreNome = "Oliveira"
                        },
                        new
                        {
                            Id = 2,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7045),
                            IsActive = true,
                            Nome = "Roberto",
                            Registro = 2,
                            SobreNome = "Soares"
                        },
                        new
                        {
                            Id = 3,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7111),
                            IsActive = true,
                            Nome = "Ronaldo",
                            Registro = 3,
                            SobreNome = "Carvalho"
                        },
                        new
                        {
                            Id = 4,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7114),
                            IsActive = true,
                            Nome = "Rodrigo",
                            Registro = 4,
                            SobreNome = "Marconi"
                        },
                        new
                        {
                            Id = 5,
                            DataInicio = new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7117),
                            IsActive = true,
                            Nome = "Alexandre",
                            Registro = 5,
                            SobreNome = "Montanha"
                        });
                });

            modelBuilder.Entity("SmartSchool.Api.Models.AlunoCurso", b =>
                {
                    b.HasOne("SmartSchool.Api.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.Api.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartSchool.Api.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("SmartSchool.Api.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.Api.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartSchool.Api.Models.Disciplina", b =>
                {
                    b.HasOne("SmartSchool.Api.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.Api.Models.Disciplina", "PreRequisito")
                        .WithMany()
                        .HasForeignKey("PreRequisitoId");

                    b.HasOne("SmartSchool.Api.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
