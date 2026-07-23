using Borea.Core.ModPacks;

namespace Borea.Core.State;

/// <summary>
/// Tracks the currently active mod pack (if any) and persists mod pack
/// configurations the user has saved locally.
/// </summary>
public interface IModPackStateRepository
{
    /// <summary>
    /// Returns the ModPackId of the currently active pack, or null if the
    /// active mod set does not correspond to any known saved pack.
    /// </summary>
    Task<string?> GetActiveModPackIdAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Records the given mod pack as the currently active one. Does not
    /// itself activate the pack's mods — that is IModActivationService's
    /// responsibility; this only records which pack the resulting state
    /// corresponds to.
    /// </summary>
    Task SetActiveModPackAsync(string modPackId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears the active mod pack marker, without changing which individual
    /// mods are active. Used when a user manually toggles mods away from a
    /// pack's exact configuration.
    /// </summary>
    Task ClearActiveModPackAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns all mod packs the user has saved locally.
    /// </summary>
    Task<IReadOnlyList<ModPackMetadata>> GetSavedModPacksAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves a mod pack locally (e.g. one downloaded from a remote source,
    /// or one the user built themselves from currently installed mods).
    /// </summary>
    Task SaveModPackAsync(ModPackMetadata modPack, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a saved mod pack. Does not uninstall or deactivate its mods.
    /// </summary>
    Task DeleteSavedModPackAsync(string modPackId, CancellationToken cancellationToken = default);
}