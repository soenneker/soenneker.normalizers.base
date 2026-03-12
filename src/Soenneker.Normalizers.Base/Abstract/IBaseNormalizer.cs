namespace Soenneker.Normalizers.Base.Abstract;

/// <summary>
/// Defines a contract for safe normalization of input data into a standard output format.
/// </summary>
/// <typeparam name="TInput">The input type to normalize from.</typeparam>
/// <typeparam name="TOutput">The output type to normalize to.</typeparam>
public interface IBaseNormalizer<in TInput, out TOutput>
{
    /// <summary>
    /// Normalizes the input value into a consistent output format.
    /// Returns default if input is null or normalization fails.
    /// </summary>
    /// <param name="input">The input value to normalize.</param>
    /// <returns>The normalized output, or null/default if normalization fails.</returns>
    TOutput? Normalize(TInput? input);
}