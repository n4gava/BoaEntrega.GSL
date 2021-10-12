﻿// <auto-generated />
using System;
using BoaEntrega.GSL.Cadastros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoaEntrega.GSL.Cadastros.Data.Migrations
{
    [DbContext(typeof(CadastrosContext))]
    partial class CadastrosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoaEntrega.GSL.Cadastros.Domain.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BoaEntrega.GSL.Cadastros.Domain.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("BoaEntrega.GSL.Cadastros.Domain.Cliente", b =>
                {
                    b.OwnsOne("BoaEntrega.GSL.Cadastros.Domain.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Complemento")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Numero")
                                .HasColumnType("int");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("UF")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });
                });

            modelBuilder.Entity("BoaEntrega.GSL.Cadastros.Domain.Fornecedor", b =>
                {
                    b.OwnsOne("BoaEntrega.GSL.Cadastros.Domain.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Complemento")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Numero")
                                .HasColumnType("int");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("UF")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedores");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
