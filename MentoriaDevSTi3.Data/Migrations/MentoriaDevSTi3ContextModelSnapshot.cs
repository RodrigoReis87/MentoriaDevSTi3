﻿// <auto-generated />
using System;
using MentoriaDevSTi3.data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MentoriaDevSTi3.Data.Migrations
{
    [DbContext(typeof(MentoriaDevSTi3Context))]
    partial class MentoriaDevSTi3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("MentoriaDevSTi3.data.Entidades.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MentoriaDevSTi3.data.Entidades.ItemPedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("PedidoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("MentoriaDevSTi3.data.Entidades.Pedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("FormaPagamento")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MentoriaDevSTi3.data.Entidades.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MentoriaDevSTi3.data.Entidades.ItemPedido", b =>
                {
                    b.HasOne("MentoriaDevSTi3.data.Entidades.Pedido", "Pedidos")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MentoriaDevSTi3.data.Entidades.Produto", "Produtos")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedidos");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("MentoriaDevSTi3.data.Entidades.Pedido", b =>
                {
                    b.HasOne("MentoriaDevSTi3.data.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MentoriaDevSTi3.data.Entidades.Pedido", b =>
                {
                    b.Navigation("ItensPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
