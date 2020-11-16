using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace lacrosseWeb.Features
{
    public class AlertServices
    {
        private readonly ITempDataDictionary _tempData;

        public AlertServices(IHttpContextAccessor contextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(contextAccessor.HttpContext);
        }

        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }
        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }
        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }
        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = _tempData.ContainsKey(Alerts.TempDataKey)
                ? (List<Alerts>)_tempData[Alerts.TempDataKey]
                : new List<Alerts>();

            alerts.Add(new Alerts
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            _tempData[Alerts.TempDataKey] = alerts;
        }
    }
}
