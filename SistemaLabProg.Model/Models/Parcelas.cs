﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SistemaLabProg.Model.Models;

public partial class Parcelas
{
    public int ParCodigo { get; set; }

    public int? ParCodigoVenda { get; set; }

    public int? ParNumeroParcela { get; set; }

    public decimal? ParValorParcela { get; set; }

    public decimal? ParDataVencimento { get; set; }

    public DateTime? ParDataPagamento { get; set; }

    public virtual Venda ParCodigoVendaNavigation { get; set; }
}