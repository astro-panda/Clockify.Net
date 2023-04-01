using System.Collections.Generic;

namespace Clockify.Net.Models.Reports; 

public class SummaryReportDto {
	public List<TotalsDto> Totals { get; set; }
	public List<SummaryGroup> GroupOne { get; set; }
}