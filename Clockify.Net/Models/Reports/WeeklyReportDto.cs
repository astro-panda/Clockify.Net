using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Clockify.Net.Models.Reports
{
    public class WeeklyReportDto
    {
        public List<TotalsDto> Totals { get; set; }
        public List<WeeklyTotalByDay> TotalsByDay { get; set; }
        public List<WeeklyGroup> GroupOne { get; set; }
    }

    public class WeeklyGroup {
        public string Id { get; set; }
        public long Duration { get; set; }
        public List<WeeklyTotalByDay> Days { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string NameLowerCase { get; set; }
        public List<WeeklyGroup> Children { get; set; }
        public string Color { get; set; }
        public string ClientName { get; set; }
    }

    public class WeeklyTotalByDay {
        public long Amount { get; set; }
        public long Duration { get; set; }
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Date { get; set; }
    }
}