using System.Collections.Generic;
using CandyCoded.env;
using FloppyBird.Domain.Drivers;

namespace FloppyBird.Infrastructure.Drivers
{
    public class EnvironmentManager : IEnvironmentManager
    {
        public string GetEnvironmentVariable(string variableName)
        {
            if (env.TryParseEnvironmentVariable(variableName, out string variableValue))
            {
                return variableValue;
            }

            throw new KeyNotFoundException($"The environment variable {variableName} was not found.");
        }
    }
}