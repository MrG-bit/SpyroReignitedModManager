///     Spyro Reignited Mod Manager
///     File: FormCheatCodeList.cs
///     Last updated: 2020/02/28
///     Created by: MR.G-bit

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpyroModManager
{
    public partial class FormCheatCodeList : Form
    {
        public static readonly int INPUT_PS4 = 0;
        public static readonly int INPUT_Xbox = 1;
        public static readonly int INPUT_Keyboard = 2;

        private enum ECheat
        {
            MaxLives,
            SuperflameToggle,
            Sunglasses,
            Retro,
            BigHead,
            SmallHead,
            Flat,
            Squid,
            SmallWings,
            Black,
            Blue,
            Green,
            Pink,
            Purple,
            Red,
            Yellow
        }

        public int PreferredInput { get; private set; }
        private List<Cheat> m_cheats = new List<Cheat>();

        private class Cheat
        {
            public ECheat CheatType { get; private set; }
            public string Name { get; private set; }
            public string Description { get; private set; }
            public Image Image { get; private set; }
            public string PS4Input { get; private set; }
            public string XboxInput { get; private set; }
            public string KeyboardInput { get; private set; }

            public Cheat(ECheat cheatType, string name, string description, Image image, string ps4Input, string xboxInput, string keyboardInput)
            {
                CheatType = cheatType;
                Name = name;
                Description = description;
                Image = image;
                PS4Input = ps4Input;
                XboxInput = xboxInput;
                KeyboardInput = keyboardInput;
            }
        
            public string GetCode(int inputType)
            {
                if (inputType == INPUT_PS4)
                    return PS4Input;
                else if (inputType == INPUT_Xbox)
                    return XboxInput;
                else if (inputType == INPUT_Keyboard)
                    return KeyboardInput;
                return "";
            }
        }

        public FormCheatCodeList(Data dataCopy)
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            DarkTheme.ToggleDarkTheme(this, DarkTheme.IsDarkTheme);

            combo_platform.SelectedIndex = dataCopy.m_preferredInput;

            m_cheats.Add(new Cheat(
                cheatType: ECheat.MaxLives,
                name: "99 Lives",
                description: "Gives Spyro 99 lives.",
                null,
                ps4Input: "R2, L2, R2, L2, Up, Up, Up, Up, Circle",
                xboxInput: "RT, LT, RT, LT, Up, Up, Up, Up, B",
                keyboardInput: "3, 1, 3, 1, W, W, W, W, Left Mouse"
                ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.SuperflameToggle,
                 name: "Superflame Powerup",
                 description: "For Spyro 2 only.",
                 null,
                 ps4Input: "Left, Right, Left, Right, R1, R1, R1, R1, Square",
                 xboxInput: "Left, Right, Left, Right, RB, RB, RB, RB, X",
                 keyboardInput: "A, D, A, D, E, E, E, E, Left Shift"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Sunglasses,
                 name: "Sunglasses",
                 description: "Rock some shades.",
                 Properties.Resources.image_cheat_sunglasses,
                 ps4Input: "R1, R1, R1, R1, Left, Left, Left, Left, Down, Up, Triangle",
                 xboxInput: "RB, RB, RB, RB, Left, Left, Left, Left, Down, Up, Y",
                 keyboardInput: "E, E, E, E, A, A, A, A, S, W, F"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Retro,
                 name: "Retro Spyro",
                 description: "Play like it's 1999.",
                 Properties.Resources.image_cheat_retro,
                 ps4Input: "L1, L1, L1, L1, Up, Down, Up, Down, Up, Down, Triangle",
                 xboxInput: "LB, LB, LB, LB, Up, Down, Up, Down, Up, Down, Y",
                 keyboardInput: "Q, Q, Q, Q, W, S, W, S, W, S, F"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.BigHead,
                 name: "Big Head Mode",
                 description: "",
                 Properties.Resources.image_cheat_bighead,
                 ps4Input: "Up, Up, Up, Up, R1, R1, R1, R1, Circle",
                 xboxInput: "Up, Up, Up, Up, RB, RB, RB, RB, B",
                 keyboardInput: "W, W, W, W, E, E, E, E, Left Mouse"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.SmallHead,
                 name: "Small Head Mode",
                 description: "",
                 Properties.Resources.image_cheat_smallhead,
                 ps4Input: "Right, Right, Right, Right, R1, L1, Left, Left, Left, Left, X",
                 xboxInput: "Right, Right, Right, Right, RB, LB, Left, Left, Left, Left, A",
                 keyboardInput: "D, D, D, D, E, Q, A, A, A, A, Spacebar"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Flat,
                 name: "Flat Mode",
                 description: "",
                 Properties.Resources.image_cheat_flat,
                 ps4Input: "Left, Right, Left, Right, L2, R2, L2, R2, Square",
                 xboxInput: "Left, Right, Left, Right, LT, RT, LT, RT, X",
                 keyboardInput: "A, D, A, D, 1, 3, 1, 3, Left Shift"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.SmallWings,
                 name: "Small Wings Mode",
                 description: "",
                 Properties.Resources.image_cheat_smallWing,
                 ps4Input: "Left, Left, Left, Left, L1, R1, Right, Right, Right, Right, X",
                 xboxInput: "Left, Left, Left, Left, LB, RB, Right, Right, Right, Right, A",
                 keyboardInput: "A, A, A, A, Q, E, D, D, D, D, Spacebar"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Squid,
                 name: "Squid Skateboard",
                 description: "Affects the skateboards in Spyro 3.",
                 Properties.Resources.image_cheat_squid,
                 ps4Input: "Up, Up, Left, Left, Right, Right, Down, Down, Square, Square, Circle",
                 xboxInput: "Up, Up, Left, Left, Right, Right, Down, Down, X, X, B",
                 keyboardInput: "W, W, A, A, D, D, Right Click, Right Click, Left Click"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Black,
                 name: "Black Spyro",
                 description: "",
                 Properties.Resources.image_cheat_black,
                 ps4Input: "Up, Left, Down, Right, Up, Square, R1, R2, L1, L2, Up, Right, Down, Left, Up, Down",
                 xboxInput: "Up, Left, Down, Right, Up, X, RB, RT, LB, LT, Up, Right, Down, Left, Up, Down",
                 keyboardInput: "W, A, S, D, W, Left Shift, E, 3, Q, 1, W, D, S, A, W, S"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Blue,
                 name: "Blue Spyro",
                 description: "",
                 Properties.Resources.image_cheat_blue,
                 ps4Input: "Up, Left, Down, Right, Up, Square, R1, R2, L1, L2, Up, Right, Down, Left, Up, X",
                 xboxInput: "Up, Left, Down, Right, Up, X, RB, RT, LB, LT, Up, Right, Down, Left, Up, A",
                 keyboardInput: "W, A, S, D, W, Left Click, E, 3, Q, 1, W, D, S, A, W, Spacebar"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Green,
                 name: "Green Spyro",
                 description: "",
                 Properties.Resources.image_cheat_green,
                 ps4Input: "Up, Left, Down, Right, Up, Square, R1, R2, L1, L2, Up, Right, Down, Left, Up, Triangle",
                 xboxInput: "Up, Left, Down, Right, Up, X, RB, RT, LB, LT, Up, Right, Down, Left, Up, Y",
                 keyboardInput: "W, A, S, D, W, Left Click, E, 3, Q, 1, W, D, S, A, W, F"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Pink,
                 name: "Pink Spyro",
                 description: "",
                 Properties.Resources.image_cheat_pink,
                 ps4Input: "Up, Left, Down, Right, Up, Square, R1, R2, L1, L2, Up, Right, Down, Left, Up, Square",
                 xboxInput: "Up, Left, Down, Right, Up, X, RB, RT, LB, LT, Up, Right, Down, Left, Up, X",
                 keyboardInput: "W, A, S, D, W, Left Click, E, 3, Q, 1, W, D, S, A, W, Right Click"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Purple,
                 name: "Purple Spyro",
                 description: "",
                 Properties.Resources.image_cheat_purple,
                 ps4Input: "Up, Left, Down, Right, Up, Square, R1, R2, L1, L2, Up, Right, Down, Left, Up, Right",
                 xboxInput: "Up, Left, Down, Right, Up, X, RB, RT, LB, LT, Up, Right, Down, Left, Up, Right",
                 keyboardInput: "W, A, S, D, W, Left Click, E, 3, Q, 1, W, D, S, A, W, D"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Red,
                 name: "Red Spyro",
                 description: "",
                 Properties.Resources.image_cheat_red,
                 ps4Input: "Up, Left, Down, Right, Up, Square, R1, R2, L1, L2, Up, Right, Down, Left, Up, O",
                 xboxInput: "Up, Left, Down, Right, Up, X, RB, RT, LB, LT, Up, Right, Down, Left, Up, B",
                 keyboardInput: "W, A, S, D, W, Left Click, E, 3, Q, 1, W, D, S, A, W, Left Click"
                 ));

            m_cheats.Add(new Cheat(
                 cheatType: ECheat.Yellow,
                 name: "Yellow Spyro",
                 description: "",
                 Properties.Resources.image_cheat_yellow,
                 ps4Input: "Up, Left, Down, Right, Up, Square, R1, R2, L1, L2, Up, Right, Down, Left, Up, Up",
                 xboxInput: "Up, Left, Down, Right, Up, X, RB, RT, LB, LT, Up, Right, Down, Left, Up, Down",
                 keyboardInput: "W, A, S, D, W, Left Shift, E, 3, Q, 1, W, D, S, A, W, W"
                 ));

            list_codes.SelectedIndexChanged += OnListCodes_SelectedIndexChanged;
            ChangeInput(dataCopy.m_preferredInput);
        }

        // Change cheat selection and show description / image
        private void OnListCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_codes.SelectedIndices.Count == 0) return;
            txt_cheatCode.Text = m_cheats[list_codes.SelectedIndices[0]].Description;
            pic_cheatImage.Image = m_cheats[list_codes.SelectedIndices[0]].Image;
            if (pic_cheatImage.Image == null)
                pic_cheatImage.Image = pic_cheatImage.InitialImage;
        }

        // Change input type and update list accordingly
        private void ChangeInput(int inputType)
        {
            list_codes.Items.Clear();

            foreach (Cheat cheat in m_cheats)
                list_codes.Items.Add(new ListViewItem(new string[] 
                { 
                    cheat.Name,
                    cheat.GetCode(inputType)
                }));
        }

        // Called when combo box index is changed
        private void Combo_Platform_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PreferredInput != combo_platform.SelectedIndex)
            {
                PreferredInput = combo_platform.SelectedIndex;
                ChangeInput(PreferredInput);
            }
        }
    }
}
