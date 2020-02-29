///     Spyro Reignited Mod Manager
///     File: FormLevelCodeList.cs
///     Last updated: 2020/02/29
///     Created by: MR.G-bit

using System.Windows.Forms;

namespace SpyroModManager
{
    public partial class FormLevelCodeList : Form
    {
        public FormLevelCodeList()
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            DarkTheme.ToggleDarkTheme(this, DarkTheme.IsDarkTheme);

            AddVersion(1);
            AddLevelCode(1, "Artisans", 101);
            AddLevelCode(1, "Stone Hill", 102);
            AddLevelCode(1, "Dark Hollow", 103);
            AddLevelCode(1, "Town Square", 104);
            AddLevelCode(1, "Sunny Flight", 105);
            AddLevelCode(1, "Toasty", 106);

            AddBlankLine();
            AddLevelCode(1, "Peace Keepers", 107);
            AddLevelCode(1, "Dry Canyon", 108);
            AddLevelCode(1, "Cliff Town", 109);
            AddLevelCode(1, "Ice Cavern", 110);
            AddLevelCode(1, "Night Flight", 111);
            AddLevelCode(1, "Dr Shemp", 112);

            AddBlankLine();
            AddLevelCode(1, "Magic Crafters", 113);
            AddLevelCode(1, "Alpine Ridge", 114);
            AddLevelCode(1, "High Caves", 115);
            AddLevelCode(1, "Wizard Peak", 116);
            AddLevelCode(1, "Crystal Flight", 117);
            AddLevelCode(1, "Blowhard", 118);

            AddBlankLine();
            AddLevelCode(1, "Beast Makers", 119);
            AddLevelCode(1, "Terrace Village", 120);
            AddLevelCode(1, "Misty Bog", 121);
            AddLevelCode(1, "Tree Tops", 122);
            AddLevelCode(1, "Wild Flight", 123);
            AddLevelCode(1, "Metal Head", 124);

            AddBlankLine();
            AddLevelCode(1, "Dream Weavers", 125);
            AddLevelCode(1, "Dark Passage", 126);
            AddLevelCode(1, "Lofty Castle", 127);
            AddLevelCode(1, "Haunted Towers", 128);
            AddLevelCode(1, "Icy Flight", 129);
            AddLevelCode(1, "Jacques", 130);

            AddBlankLine();
            AddLevelCode(1, "Gnorc Gnexus", 131);
            AddLevelCode(1, "Gnorc Cove", 132);
            AddLevelCode(1, "Twilight Harbour", 133);
            AddLevelCode(1, "Gnasty Gnorc", 134);
            AddLevelCode(1, "Gnasty's Loot", 135);


            AddBlankLine();
            AddVersion(2);
            AddLevelCode(2, "Summer Forest", 201);
            AddLevelCode(2, "Glimmer", 202);
            AddLevelCode(2, "Idol Springs", 203);
            AddLevelCode(2, "Colossus", 204);
            AddLevelCode(2, "Hurricos", 205);
            AddLevelCode(2, "Sunny Beach", 206);
            AddLevelCode(2, "Aquaria Towers", 207);
            AddLevelCode(2, "Crush's Dungeon", 208);
            AddLevelCode(2, "Ocean Speedway", 209);

            AddBlankLine();
            AddLevelCode(2, "Autumn Plains", 210);
            AddLevelCode(2, "Crystal Glacier", 211);
            AddLevelCode(2, "Skelos Badlands", 212);
            AddLevelCode(2, "Zephyr", 213);
            AddLevelCode(2, "Breeze Harbour", 214);
            AddLevelCode(2, "Scorch", 215);
            AddLevelCode(2, "Fracture Hills", 216);
            AddLevelCode(2, "Magma Cone", 217);
            AddLevelCode(2, "Shady Oasis", 218);
            AddLevelCode(2, "Gulp's Overlook", 219);
            AddLevelCode(2, "Icy Speedway", 220);
            AddLevelCode(2, "Metro Speedway", 221);

            AddBlankLine();
            AddLevelCode(2, "Winter Tundra", 222);
            AddLevelCode(2, "Mystic Marsh", 223);
            AddLevelCode(2, "Cloud Temples", 224);
            AddLevelCode(2, "Metropolis", 225);
            AddLevelCode(2, "Robotica Farms", 226);
            AddLevelCode(2, "Ripto's Arena", 227);
            AddLevelCode(2, "Canyon Speedway", 228);
            AddLevelCode(2, "Dragon Shores", 229);


            AddBlankLine();
            AddVersion(3);
            AddLevelCode(3, "Sunrise Spring", 301);
            AddLevelCode(3, "Sunny Villa", 302);
            AddLevelCode(3, "Cloud Spires", 303);
            AddLevelCode(3, "Molten Crater", 304);
            AddLevelCode(3, "Seashell Shore", 305);
            AddLevelCode(3, "Sheila's Alp", 306);
            AddLevelCode(3, "Mushroom Speedway", 307);
            AddLevelCode(3, "Buzz's Dungeon", 308);
            AddLevelCode(3, "Crawded Farm", 309);

            AddBlankLine();
            AddLevelCode(3, "Midday Gardens", 310);
            AddLevelCode(3, "Icy Peak", 311);
            AddLevelCode(3, "Enchanted Towers", 312);
            AddLevelCode(3, "Spooky Swamp", 313);
            AddLevelCode(3, "Bamboo Terrace", 314);
            AddLevelCode(3, "Sgt. Byrd's Base", 315);
            AddLevelCode(3, "Country Speedway", 316);
            AddLevelCode(3, "Spike's Arena", 317);
            AddLevelCode(3, "Spider Town", 318);

            AddBlankLine();
            AddLevelCode(3, "Evening Lake", 319);
            AddLevelCode(3, "Lost Fleet", 320);
            AddLevelCode(3, "Frozen Altars", 321);
            AddLevelCode(3, "Fireworks Factory", 322);
            AddLevelCode(3, "Charmed Ridge", 323);
            AddLevelCode(3, "Bentley's Outpost", 324);
            AddLevelCode(3, "Honey Speedway", 325);
            AddLevelCode(3, "Scorch's Pit", 326);
            AddLevelCode(3, "Starfish Reef", 327);

            AddBlankLine();
            AddLevelCode(3, "Midnight Mountain", 328);
            AddLevelCode(3, "Crystal Islands", 329);
            AddLevelCode(3, "Desert Ruins", 330);
            AddLevelCode(3, "Haunted Tomb", 331);
            AddLevelCode(3, "Dino Mines", 332);
            AddLevelCode(3, "Agent 9's Lab", 333);
            AddLevelCode(3, "Harbour Speedway", 334);
            AddLevelCode(3, "Sorceress's Lair", 335);
            AddLevelCode(3, "Bugbot Factory", 336);
            AddLevelCode(3, "Super Bonus Round", 337);
        }

        // Add blank line to list
        private void AddBlankLine()
        {
            list_levelNames.Items.Add("");
        }

        // Add version item to list
        private void AddVersion(int gameVersion)
        {
            ListViewItem listViewItem = new ListViewItem();
            if (gameVersion == 1)
                listViewItem.Text = "Spyro 1";
            else if (gameVersion == 2)
                listViewItem.Text = "Spyro 2";
            else if (gameVersion == 3)
                listViewItem.Text = "Spyro 3";
            listViewItem.Font = new System.Drawing.Font(listViewItem.Font, System.Drawing.FontStyle.Bold);
            list_levelNames.Items.Add(listViewItem);
        }

        // Add level code item to list
        private void AddLevelCode(int gameVersion, string levelName, int internalCode)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.SubItems.Add(levelName);
            listViewItem.SubItems.Add("LS" + internalCode + "_ART_MASTER");
            list_levelNames.Items.Add(listViewItem);
        }
    }
}
