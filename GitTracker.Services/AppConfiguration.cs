using GitTracker.Domain.Contracts.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace GitTracker.Services
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfiguration _configuration;

        public AppConfiguration(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GitHubUrl => GetValueOrDefault(nameof(GitHubUrl), @"https://api.github.com");

        public string GitHubAgent => GetValueOrDefault(nameof(GitHubAgent), @"GitTracker");

        protected List<string> GetSection(string appKey)
        {
            return _configuration.GetSection(appKey).Get<List<string>>();
        }

        protected string GetValue(string appKey)
        {
            var value = _configuration[appKey];

            if (string.IsNullOrWhiteSpace(value))
                throw new Exception($"Missing key {appKey} in app settings file.");

            return value;
        }

        protected string GetValueOrDefault(string appKey, string defaultValue)
        {
            return _configuration[appKey] ?? defaultValue;
        }

        protected int GetValueOrDefault(string appKey, int defaultValue)
        {
            var success = int.TryParse(_configuration[appKey], out var result);

            return success ? result : defaultValue;
        }

        protected bool GetValueOrDefault(string appKey, bool defaultValue)
        {
            return string.IsNullOrEmpty(_configuration[appKey]) ? defaultValue : bool.Parse(_configuration[appKey]);
        }
    }
}