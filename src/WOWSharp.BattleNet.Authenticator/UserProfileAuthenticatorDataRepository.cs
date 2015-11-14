#region LICENSE
// Copyright (C) 2015 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Logging;
using Newtonsoft.Json;

namespace WOWSharp.BattleNet.Authenticator
{
    public class UserProfileAuthenticatorDataRepository : IAuthenticatorDataRepository
    {
        private readonly IDataProtector _dataProtector;
        private readonly IEnrollmentClient _enrollmentservice;
        private readonly ILogger _logger;

        public UserProfileAuthenticatorDataRepository(IDataProtectionProvider dataProtectionProvider, IEnrollmentClient enrollmentService, ILoggerFactory loggerFactory)
        {
            if (dataProtectionProvider == null) throw new ArgumentNullException(nameof(dataProtectionProvider));
            if (enrollmentService == null) throw new ArgumentNullException(nameof(enrollmentService));
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));

            _dataProtector = dataProtectionProvider.CreateProtector(GetType().FullName);
            _enrollmentservice = enrollmentService;
            _logger = loggerFactory.CreateLogger<UserProfileAuthenticatorDataRepository>();
        }

        public async Task<IEnumerable<AuthenticatorData>> GetAuthenticatorsAsync()
        {
            var folder = PathHelper.GetAuthenticatorsSaveFolder();
            if (!Directory.Exists(folder))
            {
                return new AuthenticatorData[0];
            }
            var files = Directory.GetFiles(folder, "*.dat");
            var tasks = files.Select(LoadAuthenticatorAsync);
            var result = await Task.WhenAll(tasks).ConfigureAwait(false);
            return result;
        }

        public bool CheckAccountNameExists(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            var file = PathHelper.GetAuthenticatorsSavePath(name);
            return File.Exists(file);
        }

        public Task<bool> CheckAccountNameExistsAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            return Task.FromResult(CheckAccountNameExists(name));
        }


        public Task<IEnumerable<string>> GetAuthenticatorsAccountNamesAsync()
        {
            return Task.FromResult(PathHelper.GetAccountNames());
        }

        public Task<AuthenticatorData> GetAuthenticatorByAccountNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            var file = PathHelper.GetAuthenticatorsSavePath(name);
            if (!File.Exists(file))
            {
                throw new ArgumentException($"Data for an account with the same name {name} was not found", nameof(name));
            }
            return LoadAuthenticatorAsync(file);
        }

        public Task DeleteAuthenticatorByAccountNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            var file = PathHelper.GetAuthenticatorsSavePath(name);
            if (File.Exists(file))
            {
                File.Delete(file);
                _logger.LogInformation($"Authenticator {name} deleted.");
            }
            else
            {
                _logger.LogWarning($"Attempt to delete non existent authenticator {name}. No action taken.");
            }
            return Task.FromResult<object>(null);
        }
        

        public async Task AddAuthenticatorAsync(AuthenticatorData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            ValidateAuthenticatorData(data);
            var file = PathHelper.GetAuthenticatorsSavePath(data.AccountName);
            Debug.Assert(file != null, "Authenticator Save Path cannot be null.");
            if (File.Exists(file))
            {
                var error = $"Data for an account with the same name {data.AccountName} already exist";
                _logger.LogWarning("Add authenticator failed. " + error);
                throw new ArgumentException(error, nameof(data));
            }
            // ReSharper disable once AssignNullToNotNullAttribute
            var dir = new DirectoryInfo(Path.GetDirectoryName(file));
            if (!dir.Exists)
            {
                dir.Create();
                _logger.LogWarning($"Authenticators store directory created at {dir.FullName}");
            }
            await GetEnrollmentDataAsync(data);
            await SaveAuthenticatorAsync(data, file).ConfigureAwait(false);
        }

        public async Task UpdateAuthenticatorAsync(AuthenticatorData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            ValidateAuthenticatorData(data);
            var file = PathHelper.GetAuthenticatorsSavePath(data.AccountName);
            if (!File.Exists(file))
            {
                var error = $"Data for an account with the same name {data.AccountName} doesn't exist.";
                _logger.LogWarning("Update authenticator failed. " + error);
                throw new ArgumentException(error, nameof(data.AccountName));
            }
            
            await GetEnrollmentDataAsync(data);
            await SaveAuthenticatorAsync(data, file).ConfigureAwait(false);
        }

        
        private static void ValidateAuthenticatorData(AuthenticatorData data)
        {
            if (string.IsNullOrEmpty(data.AccountName))
            {
                throw new ArgumentNullException(nameof(data.AccountName));
            }
            if (!string.IsNullOrEmpty(data.Serial))
            {
                Validation.ValidateSerial(data.Serial);
            }
            if (!string.IsNullOrEmpty(data.RestoreCode))
            {
                Validation.ValidateRestoreCode(data.RestoreCode);
            }
            if (data.SecretKey != null)
            {
                Validation.ValidateSecretKey(data.SecretKey);
            }
            if (data.Serial != null)
            {
                if (data.RestoreCode == null && data.SecretKey == null)
                    throw new ArgumentException($"Either {nameof(data.SecretKey)} or {nameof(data.RestoreCode)} must be set.");
            }
            if (string.IsNullOrEmpty(data.RegionCode))
            {
                if (!string.IsNullOrEmpty(data.Serial))
                {
                    data.RegionCode = data.Serial.Substring(0, 2).ToUpperInvariant();
                }
                else
                {
                    throw new ArgumentNullException(nameof(data.RegionCode));
                }
            }
            else
            {
                Validation.ValidateRegionCode(data.RegionCode);
            }
        }

        private async Task SaveAuthenticatorAsync(AuthenticatorData data, string fileName)
        {
            var json = JsonConvert.SerializeObject(data);
            var protectedData = _dataProtector.Protect(Encoding.UTF8.GetBytes(json));
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 8000, FileOptions.Asynchronous | FileOptions.WriteThrough))
            {
                await fs.WriteAsync(protectedData, 0, protectedData.Length).ConfigureAwait(false);
            }
        }

        private async Task<AuthenticatorData> LoadAuthenticatorAsync(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 8000, FileOptions.Asynchronous))
            {
                var protectedData = new byte[fs.Length];
                await fs.ReadAsync(protectedData, 0, protectedData.Length).ConfigureAwait(false);
                var json = Encoding.UTF8.GetString(_dataProtector.Unprotect(protectedData));
                return JsonConvert.DeserializeObject<AuthenticatorData>(json);
            }
        }

        private async Task GetEnrollmentDataAsync(AuthenticatorData data)
        {
            if (string.IsNullOrWhiteSpace(data.Serial))
            {
                var result = await _enrollmentservice.EnrollAuthenticatorAsync(data.RegionCode);
                data.RestoreCode = result.RestoreCode;
                data.Serial = result.Serial;
                data.ServerTimeDifference = result.ServerTimeDifference;
                data.SecretKey = result.SecretKey;
            }
            else
            {
                if (data.SecretKey == null)
                {
                    var result = await _enrollmentservice.RestoreAuthenticatorDataAsync(data.Serial, data.RestoreCode);
                    data.SecretKey = result.SecretKey;
                    if (result.ServerTimeDifference != TimeSpan.Zero)
                    {
                        data.ServerTimeDifference = result.ServerTimeDifference;
                    }
                }
                else if (data.RestoreCode == null)
                {
                    data.RestoreCode = _enrollmentservice.GetRestoreCode(data.Serial, data.SecretKey);
                    if (data.ServerTimeDifference == TimeSpan.Zero)
                    {
                        data.ServerTimeDifference = await _enrollmentservice.GetServerTimeDifferenceAsync(data.RegionCode);
                    }
                }
                else
                {
                    if (data.ServerTimeDifference == TimeSpan.Zero)
                    {
                        data.ServerTimeDifference = await _enrollmentservice.GetServerTimeDifferenceAsync(data.RegionCode);
                    }
                }
            }
        }
    }
}

