namespace Borea.Core.Mods
{
    public enum InstallReason
    {
        /// <summary>The user explicitly chose to install this mod on its own.</summary>
        Manual,

        /// <summary>Installed because it's required by a mod pack the user installed.</summary>
        ModPack,

        /// <summary>Installed automatically because another mod declared it as a dependency.</summary>
        Dependency,
    }
}
