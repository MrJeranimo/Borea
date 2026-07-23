using Borea.Core.Mods;

namespace Borea.Core.Paths;

/// <summary>
/// Resolves filesystem locations relevant to KSA, StarMap, and Borea's own
/// library, abstracting away OS-specific path resolution (e.g. Documents
/// folder location differs between Windows and Linux).
/// </summary>
public interface IGamePathProvider
{
    /// <summary>
    /// The KSA mods folder KSA reads from directly, e.g.
    /// [Documents]\My Games\Kitten Space Agency\mods
    /// </summary>
    string GetModsFolder();

    /// <summary>
    /// Path to KSA's Documents manifest.toml tracking active/inactive mod state.
    /// </summary>
    string GetManifestPath();

    /// <summary>
    /// Root of Borea's own mod library, e.g.
    /// [Documents]\My Games\Kitten Space Agency\Borea
    /// </summary>
    string GetLibraryRoot();

    /// <summary>
    /// Full library install path for a specific mod version, e.g.
    /// [LibraryRoot]\[mod name]\[version]\
    /// </summary>
    string GetInstallPath(string modId, ModVersion version);

    /// <summary>
    /// The path KSA expects for an active mod inside the mods folder
    /// (i.e. the symlink/junction target location), e.g.
    /// [ModsFolder]\[mod name] or [ModsFolder]\[Mod-Name]-[Version]
    /// depending on how KSA's side-by-side support resolves.
    /// </summary>
    string GetActivationLinkPath(string modId, ModVersion version);

    /// <summary>
    /// Root directory of the KSA game installation itself (not the Documents
    /// folder).
    /// </summary>
    string GetGameDirectoryPath();

    /// <summary>
    /// Root directory of the StarMap installation. Used as the base
    /// path for launching StarMap.
    /// </summary>
    string GetStarMapDirectoryPath();
}