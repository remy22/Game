using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GameLibrary;
using GameLibrary.Global;
using GameLibrary.Core;
using bombardiens.Engine.GameRender;
using System.Diagnostics;
using GameLibrary.Managers;
using GameLibrary.Testing;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using bombardiens.Engine.Character;
using bombardiens.Engine.CustomObjects;
using bombardiens.Engine;
using bombardiens.Engine.Effects;

namespace bombardiens.GameStuff
{
    public class GameSection:Section
    {
        public void addExplosion(Vector2 position, float power) 
        {
            explosions.Add(new Explosion(position, power, fireballs));
        }
    }
}
