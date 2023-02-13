using Apos.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Profession
{
    public static class config
    {
        // game cfg
        public static string w_title = "Application";
        public static int w_width = 1336;
        public static int w_height = 960;
    }

    public class KeyBinds
    {
        public static List<Keybindstruct> KeyBindsList = new List<Keybindstruct>()
        {
            new Keybindstruct
            {
                key = Keys.W,
                KeyEnum = KeyEnum.forward
            },

            new Keybindstruct
            {
                key = Keys.S,
                KeyEnum = KeyEnum.backwards
            },

            new Keybindstruct
            {
                key = Keys.A,
                KeyEnum = KeyEnum.left
            },

            new Keybindstruct
            {
                key = Keys.D,
                KeyEnum = KeyEnum.right
            },


            // menu stuff
            new Keybindstruct
            {
                key = Keys.Escape,
                KeyEnum = KeyEnum.Exit
            },

            new Keybindstruct
            {
                key = Keys.Y,
                KeyEnum = KeyEnum.PauseMenu
            },

            new Keybindstruct
            {
                key = Keys.U,
                KeyEnum = KeyEnum.MainMenu
            },

            new Keybindstruct
            {
                key = Keys.I,
                KeyEnum = KeyEnum.InGame
            }
        };

        public enum KeyEnum
        {
            forward,backwards,left,right, 
            
            MainMenu, PauseMenu, Exit, InGame,
            
            None
        }

        public struct Keybindstruct
        {
            public Keys key;
            public KeyEnum KeyEnum;
        }

        public static void addKeys(Keys Key, KeyEnum WhatToDo) => KeyBindsList.Add(new Keybindstruct { key = Key, KeyEnum = WhatToDo });


    }
}
