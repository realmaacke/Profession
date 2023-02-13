using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profession.EventHandlers
{
    public class KeyHandler : KeyBinds
    {
        static KeyboardState state;

        public static Keys GetKeys()
        {
            state = Keyboard.GetState();

            if (!state.GetPressedKeys().Any())
                return Keys.None;

           foreach(var PressedKeys in state.GetPressedKeys())
           {
               foreach(var AvailableKeys in KeyBindsList)
               {
                   if(PressedKeys == AvailableKeys.key)
                   {
                        return PressedKeys;
                   }
               }
           }

            return Keys.None;
        }

        public static KeyEnum GetKeyAction(Keys key)
        {
            foreach(var keybinds in KeyBindsList)
            {
                if(key == keybinds.key)
                {
                    return keybinds.KeyEnum;
                }
            }
            return KeyEnum.None;
        }

        public static void KeyEvent()
        {
            Keys key = GetKeys();

            switch (GetKeyAction(key))
            {
                case KeyEnum.MainMenu:
                    StateManager.OnMainMenu();
                    break;
                case KeyEnum.PauseMenu:
                    StateManager.OnPauseMenu();
                    break;
                case KeyEnum.InGame:
                    StateManager.OnInGame();
                    break;
            }
        }


        public static bool OnExit()
        {
            Keys key = GetKeys();

            if (GetKeyAction(key) == KeyEnum.Exit)
                return true;
            else
                return false;
        }

        // TODO ADD MOUSE INPUT
    }
}
