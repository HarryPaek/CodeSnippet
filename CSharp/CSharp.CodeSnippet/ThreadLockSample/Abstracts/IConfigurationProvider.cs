﻿using System.Collections.Specialized;
using System.Configuration;

namespace ThreadLockSample.Abstracts
{
    public interface IConfigurationProvider
    {
        Configuration Configuration { get; }

        KeyValueConfigurationCollection Appsettings { get; }

        ConnectionStringSettingsCollection ConnectionStrings { get; }

        string ConfigurationFilePath { get; }

        string GetConnectionString(string name);
    }
}
