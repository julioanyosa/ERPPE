using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Halley.Configuracion
{
    public class UpdateConfiguration
    {
        public void AppSettingsSectionModify(string keyValue, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appSettings = config.AppSettings;

            KeyValueConfigurationElement setting = appSettings.Settings[keyValue];
            setting.Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
