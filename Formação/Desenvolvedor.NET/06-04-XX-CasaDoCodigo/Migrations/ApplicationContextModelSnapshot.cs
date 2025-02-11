﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _06_04_XX_CasaDoCodigo;

namespace _06_04_XX_CasaDoCodigo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.Cadastro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("Complemento")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<string>("Municipio")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.Property<string>("UF")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cadastro");
                });

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PedidoId");

                    b.Property<decimal>("PrecoUnitario");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CadastroId");

                    b.Property<string>("ClienteId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CadastroId")
                        .IsUnique();

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.ItemPedido", b =>
                {
                    b.HasOne("_06_04_XX_CasaDoCodigo.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_06_04_XX_CasaDoCodigo.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.Pedido", b =>
                {
                    b.HasOne("_06_04_XX_CasaDoCodigo.Models.Cadastro", "Cadastro")
                        .WithOne("Pedido")
                        .HasForeignKey("_06_04_XX_CasaDoCodigo.Models.Pedido", "CadastroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_06_04_XX_CasaDoCodigo.Models.Produto", b =>
                {
                    b.HasOne("_06_04_XX_CasaDoCodigo.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
