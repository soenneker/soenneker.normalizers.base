using Soenneker.Normalizers.Base.Abstract;
using System;
using Microsoft.Extensions.Logging;

namespace Soenneker.Normalizers.Base;

/// <inheritdoc cref="IBaseNormalizer{TInput, TOutput}"/>
public abstract class BaseNormalizer<TInput, TOutput> : IBaseNormalizer<TInput, TOutput> where TInput : notnull
{
    private readonly ILogger? _logger;

    protected BaseNormalizer(ILogger? logger = null)
    {
        _logger = logger;
    }

    public TOutput? Normalize(TInput? input)
    {
        if (input is null)
            return default;

        try
        {
            return NormalizeCore(input);
        }
        catch (Exception ex)
        {
            OnNormalizationFailed(input, ex);
            return default;
        }
    }

    /// <summary>
    /// Called when <see cref="Normalize(TInput)"/> encounters an exception during normalization.
    /// Allows derived classes to handle or log the failure.
    /// </summary>
    /// <param name="input">The original input that caused the failure.</param>
    /// <param name="ex">The exception that was thrown during normalization.</param>
    protected virtual void OnNormalizationFailed(TInput input, Exception ex)
    {
        _logger?.LogError(ex, "Normalization failed for input: {Input}", input);
    }

    /// <summary>
    /// Performs the core normalization logic on a non-null input.
    /// </summary>
    /// <param name="input">The input value to normalize. Guaranteed to be non-null.</param>
    /// <returns>The normalized output.</returns>
    /// <exception cref="Exception">
    /// Implementations may throw if normalization fails unexpectedly. 
    /// The base class handles exceptions and returns default from <see cref="Normalize(TInput)"/>.
    /// </exception>
    protected abstract TOutput NormalizeCore(TInput input);
}