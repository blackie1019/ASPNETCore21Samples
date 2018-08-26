using System;

namespace mvc0826.Models
{
    public class AppSettings : IAppSettingsTransient,IAppSettingsScoped,IAppSettingsSingleton
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public AppSettings()
        {
            this.Name = Guid.NewGuid().ToString();
        }
    }
}