namespace Borea.Core.Mods;

/// <summary>
/// Removes an installed mod's files from Borea's library. Does not check
/// whether other installed mods depend on it — callers should consult
/// UninstallCheck first. Does not touch StarMap's manifest or activation
/// links; deactivation is IModActivationService's responsibility and should
/// happen before uninstalling an active mod.
/// </summary>
public interface IModUninstaller
{
    /// <summary>
    /// Deletes the given mod version's files from the library.
    /// </summary>
    Task UninstallAsync(
        string modId,
        ModVersion version,
        CancellationToken cancellationToken = default);
}