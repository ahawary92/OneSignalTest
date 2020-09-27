using System;
using System.Collections.Generic;
using Core.Domain;

namespace Core.Services
{
    public interface IOneSignalService
    {
        List<App> ViewAllApps();
        App ViewAppById(string id);
        App CreateApp(App oneSignalApp);
        App UpdateApp(App oneSignalApp);
    }
}
