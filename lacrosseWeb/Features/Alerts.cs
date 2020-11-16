using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Features
{
    public class Alerts
    {
        public const string TempDataKey = "TempDataAlerts";
        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
    }
    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "information";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }
}
