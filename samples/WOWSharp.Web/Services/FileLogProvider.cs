using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOWSharp.Web.Services
{
    public class FileLogProvider : ILoggerProvider
    {
        private readonly string _folder;
        private readonly Func<string, LogLevel, bool> _filter;

        public FileLogProvider(IApplicationEnvironment appEnv, Func<string, LogLevel, bool> filter)
        {
            _folder = Path.Combine(Path.GetTempPath(), "Aspnet5", "Logs", appEnv.ApplicationName);
            _filter = filter;

        }

        public ILogger CreateLogger(string name)
        {
            return new FileLogger(_folder, name, _filter);
        }

        private class FileLogger : ILogger
        {
            private readonly string _folder;
            private readonly Func<string, LogLevel, bool> _filter;
            private string _name;

            public FileLogger(string folder, string name, Func<string, LogLevel, bool> filter)
            {
                string folderName = name;
                int index;
                while ((index = folderName.IndexOfAny(Path.GetInvalidFileNameChars())) >= 0)
                {
                    folderName = folderName.Replace(folderName[index], '_');
                }
                _folder = Path.Combine(folder, folderName);
                _filter = filter ?? ((category, logLevel) => true);
                _name = name;
            }

            public IDisposable BeginScopeImpl(object state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return _filter(_name, logLevel);
            }

            private void DoWriteMessage(string message)
            {
                var date = DateTimeOffset.Now;
                var filename = date.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".log";
                var file = Path.Combine(_folder, filename);
                var finalMessage = $"{date:HH:mm:ss} {message}";
                var folder = Path.GetDirectoryName(file);
                if (!Directory.Exists(folder))
                {
                    new DirectoryInfo(folder).Create();
                }
                if (!File.Exists(file))
                {
                    File.WriteAllText(file, message);
                }
                else
                {
                    File.AppendAllText(filename, finalMessage, Encoding.UTF8);
                }
            }

            public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
            {
                if (!IsEnabled(logLevel))
                {
                    return;
                }
                var message = string.Empty;
                var values = state as ILogValues;
                if (formatter != null)
                {
                    message = formatter(state, exception);
                }
                else if (values != null)
                {
                    var builder = new StringBuilder();
                    FormatLogValues(
                        builder,
                        values,
                        level: 1,
                        bullet: false);
                    message = builder.ToString();
                    if (exception != null)
                    {
                        message += Environment.NewLine + exception;
                    }
                }
                else
                {
                    message = LogFormatter.Formatter(state, exception);
                }
                if (string.IsNullOrEmpty(message))
                {
                    return;
                }
                DoWriteMessage(message);
            }

            private const int _indentation = 2;


            private void FormatLogValues(StringBuilder builder, ILogValues logValues, int level, bool bullet)
            {
                var values = logValues.GetValues();
                if (values == null)
                {
                    return;
                }
                var isFirst = true;
                foreach (var kvp in values)
                {
                    builder.AppendLine();
                    if (bullet && isFirst)
                    {
                        builder.Append(' ', level * _indentation - 1)
                               .Append('-');
                    }
                    else
                    {
                        builder.Append(' ', level * _indentation);
                    }
                    builder.Append(kvp.Key)
                           .Append(": ");
                    if (kvp.Value is IEnumerable && !(kvp.Value is string))
                    {
                        foreach (var value in (IEnumerable)kvp.Value)
                        {
                            if (value is ILogValues)
                            {
                                FormatLogValues(
                                    builder,
                                    (ILogValues)value,
                                    level + 1,
                                    bullet: true);
                            }
                            else
                            {
                                builder.AppendLine()
                                       .Append(' ', (level + 1) * _indentation)
                                       .Append(value);
                            }
                        }
                    }
                    else if (kvp.Value is ILogValues)
                    {
                        FormatLogValues(
                            builder,
                            (ILogValues)kvp.Value,
                            level + 1,
                            bullet: false);
                    }
                    else
                    {
                        builder.Append(kvp.Value);
                    }
                    isFirst = false;
                }
            }
        }
    }
}
