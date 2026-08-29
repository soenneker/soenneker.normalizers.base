[![](https://img.shields.io/nuget/v/soenneker.normalizers.base.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.base/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.base/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.normalizers.base.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.base/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.base/actions/workflows/codeql.yml)

# Soenneker.Normalizers.Base

Defines a contract for safe normalization of input data into a standard output format.

## Install

```bash
dotnet add package Soenneker.Normalizers.Base
```

## Quick start

```csharp
using Soenneker.Normalizers.Base.Abstract;

IBaseNormalizer<TInput, TOutput> baseNormalizer = /* resolve from DI */;
var result = baseNormalizer.Normalize(/* supply input */ default!);
```

Normalizes the input value into a consistent output format. Returns default if input is null or normalization fails.

## What you get

- `IBaseNormalizer<TInput, TOutput>` — Defines a contract for safe normalization of input data into a standard output format.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IBaseNormalizer<TInput, TOutput>.Normalize(input)` | Normalizes the input value into a consistent output format. Returns default if input is null or normalization fails. | The normalized output, or null/default if normalization fails. |
