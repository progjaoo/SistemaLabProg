﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SistemaLabProg.Model.Models;

public partial class DBSISTEMASContext : DbContext
{
    public DBSISTEMASContext(DbContextOptions<DBSISTEMASContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Data source=THRALLJR\\SQLEXPRESS;Database=DBSISTEMAS;Integrated Security=True;trustServerCertificate=true");

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Configuracao> Configuracao { get; set; }

    public virtual DbSet<Endereco> Endereco { get; set; }

    public virtual DbSet<Entrada> Entrada { get; set; }

    public virtual DbSet<EntradaProduto> EntradaProduto { get; set; }

    public virtual DbSet<Parcelas> Parcelas { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<TipoPagamento> TipoPagamento { get; set; }

    public virtual DbSet<TipoProduto> TipoProduto { get; set; }

    public virtual DbSet<Unidade> Unidade { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CliCodigo);

            entity.ToTable("CLIENTE");

            entity.Property(e => e.CliCpfcnpj)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CliCPFCNPJ");
            entity.Property(e => e.CliDataCadastro).HasColumnType("datetime");
            entity.Property(e => e.CliDataNascimento).HasColumnType("datetime");
            entity.Property(e => e.CliEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CliNome)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CliNomeMae)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CliSexo)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CliTelefone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Configuracao>(entity =>
        {
            entity.HasKey(e => e.CfgCodigo);

            entity.ToTable("CONFIGURACAO");

            entity.Property(e => e.CfgCodigo).ValueGeneratedNever();
            entity.Property(e => e.CfgAcrescimoCartao).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CfgDescontoAvista)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CfgDescontoAVista");
            entity.Property(e => e.CfgMargemLucro).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CfgUsuarioAlteracao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.EndCodigo);

            entity.ToTable("ENDERECO");

            entity.Property(e => e.EndBairro)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EndCep)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("EndCEP");
            entity.Property(e => e.EndCidade)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EndComplemento)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EndEstado)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EndLogradouro)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EndNumero)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EndCodigoClienteNavigation).WithMany(p => p.Endereco)
                .HasForeignKey(d => d.EndCodigoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENDERECO_CLIENTE");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.EntCodigo);

            entity.ToTable("ENTRADA");

            entity.Property(e => e.EnNuneroNotaFiscal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntDataHora).HasColumnType("datetime");
            entity.Property(e => e.EntUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EntradaProduto>(entity =>
        {
            entity.HasKey(e => e.EnpCodigoProduto);

            entity.ToTable("ENTRADA_PRODUTO");

            entity.Property(e => e.EnpCodigoProduto).ValueGeneratedNever();
            entity.Property(e => e.EnpValorCusto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnpValorVenda).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.EnpCodigoEntradaNavigation).WithMany(p => p.EntradaProduto)
                .HasForeignKey(d => d.EnpCodigoEntrada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENTRADA_PRODUTO_ENTRADA");

            entity.HasOne(d => d.EnpCodigoProdutoNavigation).WithOne(p => p.EntradaProduto)
                .HasForeignKey<EntradaProduto>(d => d.EnpCodigoProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENTRADA_PRODUTO_PRODUTO");
        });

        modelBuilder.Entity<Parcelas>(entity =>
        {
            entity.HasKey(e => e.ParCodigo);

            entity.ToTable("PARCELAS");

            entity.Property(e => e.ParDataPagamento).HasColumnType("datetime");
            entity.Property(e => e.ParDataVencimento).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ParValorParcela).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ParCodigoVendaNavigation).WithMany(p => p.Parcelas)
                .HasForeignKey(d => d.ParCodigoVenda)
                .HasConstraintName("FK_PARCELAS_VENDA");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.ProCodigo);

            entity.ToTable("PRODUTO");

            entity.Property(e => e.ProCodigoBarras)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.ProDataCadastro).HasColumnType("datetime");
            entity.Property(e => e.ProDescricao)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ProCodigoTipoProdutoNavigation).WithMany(p => p.Produto)
                .HasForeignKey(d => d.ProCodigoTipoProduto)
                .HasConstraintName("FK_PRODUTO_TIPO_PRODUTO");

            entity.HasOne(d => d.ProCodigoUnidadeNavigation).WithMany(p => p.Produto)
                .HasForeignKey(d => d.ProCodigoUnidade)
                .HasConstraintName("FK_PRODUTO_UNIDADE");
        });

        modelBuilder.Entity<TipoPagamento>(entity =>
        {
            entity.HasKey(e => e.TpgCodigo);

            entity.ToTable("TIPO_PAGAMENTO");

            entity.Property(e => e.TpgDescricao)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoProduto>(entity =>
        {
            entity.HasKey(e => e.TipCodigo);

            entity.ToTable("TIPO_PRODUTO");

            entity.Property(e => e.TipDescricao)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.UnCodigo);

            entity.ToTable("UNIDADE");

            entity.Property(e => e.UnDescricao)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.VenCodigo);

            entity.ToTable("VENDA");

            entity.Property(e => e.VenData).HasColumnType("datetime");
            entity.Property(e => e.VenUsuario)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.VenCodigoClienteNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.VenCodigoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENDA_CLIENTE");

            entity.HasOne(d => d.VenCodigoTipoPagamentoNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.VenCodigoTipoPagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENDA_TIPO_PAGAMENTO");

            entity.HasMany(d => d.ItvCodigoProduto).WithMany(p => p.ItvCodigoVenda)
                .UsingEntity<Dictionary<string, object>>(
                    "ItensVenda",
                    r => r.HasOne<Produto>().WithMany()
                        .HasForeignKey("ItvCodigoProduto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ITENS_VENDA_PRODUTO"),
                    l => l.HasOne<Venda>().WithMany()
                        .HasForeignKey("ItvCodigoVenda")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ITENS_VENDA_VENDA"),
                    j =>
                    {
                        j.HasKey("ItvCodigoVenda", "ItvCodigoProduto");
                        j.ToTable("ITENS_VENDA");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}