using omzo.Debugging;

namespace omzo
{
    public class omzoConsts
    {
        public const string LocalizationSourceName = "omzo";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "14127aae04164817aa634962aa2f2b6a";
    }
}
