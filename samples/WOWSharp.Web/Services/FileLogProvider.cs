using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;

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
            private readonly string _name;

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
                Debug.Assert(folder != null, "Folder cannot be null");
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
                string message;
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

            private const int Indentation = 2;


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
                        builder.Append(' ', level * Indentation - 1)
                               .Append('-');
                    }
                    else
                    {
                        builder.Append(' ', level * Indentation);
                    }
                    builder.Append(kvp.Key)
                           .Append(": ");
                    var enumerable = kvp.Value as IEnumerable;
                    if (enumerable != null && !(kvp.Value is string))
                    {
                        foreach (var value in enumerable)
                        {
                            var vs = value as ILogValues;
                            if (vs != null)
                            {
                                FormatLogValues(
                                    builder,
                                    vs,
                                    level + 1,
                                    true);
                            }
                            else
                            {
                                builder.AppendLine()
                                       .Append(' ', (level + 1) * Indentation)
                                       .Append(value);
                            }
                        }
                    }
                    else
                    {
                        var vs = kvp.Value as ILogValues;
                        if (vs != null)
                        {
                            FormatLogValues(
                                builder,
                                vs,
                                level + 1,
                                false);
                        }
                        else
                        {
                            builder.Append(kvp.Value);
                        }
                    }
                    isFirst = false;
                }
            }
        }
    }
}
