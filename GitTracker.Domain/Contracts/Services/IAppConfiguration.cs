﻿namespace GitTracker.Domain.Contracts.Services
{
    public interface IAppConfiguration
    {
        string GitHubUrl { get; }
    }
}