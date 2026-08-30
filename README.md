# Soenneker.Normalizers.Base
[![](https://img.shields.io/nuget/v/soenneker.normalizers.base.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.base/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.base/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.normalizers.base.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.base/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.base/actions/workflows/codeql.yml)

Defines a synchronous normalization contract and an optional base class that converts invalid input or normalization exceptions to `default`.

## Installation

```bash
dotnet add package Soenneker.Normalizers.Base
```

## Implement a normalizer

```csharp
using Microsoft.Extensions.Logging;
using Soenneker.Normalizers.Base;

public sealed class TrimmedNameNormalizer : BaseNormalizer<string, string>
{
    public TrimmedNameNormalizer(ILogger<TrimmedNameNormalizer> logger) : base(logger)
    {
    }

    protected override string NormalizeCore(string input)
    {
        string normalized = input.Trim();
        return normalized.Length == 0
            ? throw new FormatException("A name cannot be empty after trimming.")
            : normalized;
    }
}
```

Calling `Normalize(null)` returns `default` without invoking `NormalizeCore`. Other exceptions are passed to `OnNormalizationFailed` and then converted to `default`; `OperationCanceledException` is propagated.

The default failure handler logs the exception and input type, not the input value. Override it when different reporting is needed, but avoid writing identifiers, credentials, or personal data from `input` to logs.

## Result semantics

There is no separate success flag. For reference outputs, `null` means the input was null, normalization rejected it, or normalization threw. For value-type outputs, `default` may be a valid value and cannot be distinguished from failure. Use a nullable or result-wrapper output type when that distinction matters.

The base class does not validate a normalized result, retry failures, or provide thread synchronization. A singleton normalizer must keep `NormalizeCore` and `OnNormalizationFailed` thread-safe.
