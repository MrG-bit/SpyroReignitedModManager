///     Spyro Reignited Mod Manager
///     File: DiscordRP.cs
///     Last updated: 2020/02/28
///     Created by: MR.G-bit

using DiscordRPC;

namespace SpyroModManager
{
    public static class DiscordRP
    {
        private static DiscordRpcClient client;
        public static bool ClientActive { get; private set; }
        private static string _details = "";
        private static string _state = "";
        private static string _smallImageKey = "";
        private static string _smallImageText = "";
        private static string _largeImageKey = "";
        private static string _largeImageText = "";

        // Initialise discord client
        public static void Initialise(string details, string state)
        {
            client = new DiscordRpcClient("REDACTED");
            client.Initialize();
            ClientActive = true;
        }

        // Update the discord presence detials
        private static void UpdatePresence(string details, string state, string smallImageKey, string smallImageText, string largeImageKey, string largeImageText)
        {
            if (!ClientActive) return;

            _details = details == null ? _details : details;
            _state = state == null ? _state : state;
            _smallImageKey = smallImageKey == null ? _smallImageKey : smallImageKey;
            _smallImageText = smallImageText == null ? _smallImageText : smallImageText;
            _largeImageKey = largeImageKey == null ? _largeImageKey : largeImageKey;
            _largeImageText = largeImageText == null ? _largeImageText : largeImageText;

            client.SetPresence(new RichPresence()
            {
                Details = _details,
                State = _state,
                Assets = new Assets()
                {
                    SmallImageKey = _smallImageKey,
                    SmallImageText = _smallImageText,
                    LargeImageKey = _largeImageKey,
                    LargeImageText = _largeImageText
                }
            });

            client.Invoke();
        }

        // Set status: in game
        public static void SetInGame(int numberOfMods)
        {
            UpdatePresence(null, "Mods active: " + numberOfMods, "image_ingame", "In Game", null, null);
        }

        // Set status: in mod manager
        public static void SetInModder()
        {
            UpdatePresence(null, "", "image_inmodder", "In Mod Manager", null, null);
        }

        // Set game version display: 0 - none, 1, 2, 3, 4 - custom level, 5 - multiplayer
        public static void SetSpyroVersion(int spyroVersion)
        {
            if (spyroVersion == 0)
                UpdatePresence("", null, null, null, "image_spyroversion_boxart", "Spyro Reignited Trilogy");
            else if (spyroVersion == 1)
                UpdatePresence("Spyro the Dragon", null, null, null, "image_spyroversion_1", "Spyro the Dragon");
            else if (spyroVersion == 2)
                UpdatePresence("Spyro 2: Ripto's Rage", null, null, null, "image_spyroversion_2", "Spyro 2: Ripto's Rage");
            else if (spyroVersion == 3)
                UpdatePresence("Spyro Year of the Dragon", null, null, null, "image_spyroversion_3", "Spyro Year of the Dragon");
            else if (spyroVersion == 4)
                UpdatePresence("Custom Level", null, null, null, "image_spyroversion_boxart", "Custom Level");
            else if (spyroVersion == 5)
                UpdatePresence("Multiplayer", null, null, null, "image_spyroversion_boxart", "Multiplayer");
        }

        // Deinitialise discord client
        public static void Deinitialise()
        {
            client.Dispose();
            ClientActive = false;
        }
    }
}
