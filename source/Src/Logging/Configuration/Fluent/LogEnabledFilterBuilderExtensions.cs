﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using System.Diagnostics;
using System.Messaging;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Fluent;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary/>
    public static class LogEnabledFilterBuilderExtensions
    {
        /// <summary/>
        public static ILoggingConfigurationFilterLogEnabled FilterEnableOrDisable(this ILoggingConfigurationOptions context, string logEnabledFilterName)
        {
            if (string.IsNullOrEmpty(logEnabledFilterName)) 
                throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "logEnabledFilterName");

            return new FilterLogEnabledBuilder(context, logEnabledFilterName);
        }

        private class FilterLogEnabledBuilder : LoggingConfigurationExtension, ILoggingConfigurationFilterLogEnabled
        {
            LogEnabledFilterData logEnabledFilterData;

            public FilterLogEnabledBuilder(ILoggingConfigurationOptions context, string logEnabledFilterName)
                :base(context)
            {
                logEnabledFilterData = new LogEnabledFilterData()
                {
                    Name = logEnabledFilterName
                };

                base.LoggingSettings.LogFilters.Add(logEnabledFilterData);
            }

            public ILoggingConfigurationOptions Enable()
            {
                logEnabledFilterData.Enabled = true;

                return base.LoggingOptions;
            }
        }
    }
}
