using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameLibrary.Global;
using GameLibrary.Core;

namespace bombardiens
{
    public class Res
    {
        public static String spacecraft = "spacecraft";
        public static String arrow = "arrow";
        public static String bullet = "bullet";
        public static String tree = "tree";
        public static Animation arrowAnim;
        public static Animation treeAnim;
        public static String block = "block";
        public static String effect1 = "effect1";
        public static String crate = "crate";
        public static String run = "run";
        public static String stand = "stand";
        public static String strafe = "strafe";
        public static String machinegun = "machinegun";
        public static String pistol = "pistol";
        public static String explosion1 = "explosion1";
        public static String explosion2 = "explosion2";
        private static List<String> explosions = new List<string>();

        public static int explosionCount = 0;

        public void Load() 
        {
           Add(spacecraft, GameLibrary.Global.Graphics.CreateTexture2D(10, 100, Color.White, Color.Black));
           Add(bullet, Graphics.CreateCircleTexture(3, Color.Black, Color.Red));
           Add(tree, load("tree.png"));
           Add(block, Graphics.CreateTexture2D(50, 50, Color.White, Color.Black));

           Texture2D arrowTex = load("arrow.png");
           Add(arrow, arrowTex);
           arrowAnim = new Animation(arrow);
           treeAnim = new Animation(tree);
           Add(effect1, load("effect1.png"));
           LoadAndAdd("crate.png", crate);
           LoadAndAdd("run.png", run);
           LoadAndAdd("stand.png", stand);
           LoadAndAdd("strafe.png", strafe);
           LoadAndAdd("machinegun.png", machinegun);
           LoadAndAdd("pistol.png", pistol);
           LoadAndAdd("explosion1.png", explosion1);
           LoadAndAdd("explosion2.png", explosion2);

           explosions.Add(explosion1);
           explosions.Add(explosion2);
        }

        private void LoadAndAdd(String fileName, String refName)
        {
            Add(refName, load(fileName));
        }

        private Texture2D load(String filename)
        {
            return GameLibrary.Global.Graphics.LoadTextureFile(filename);
        }

        private void Add(String name, Texture2D texture)
        {
            GameLibrary.Global.Graphics.dictionary.Add(name, texture);
        }

        public static Animation randomExplosion
        {
            get
            {
               explosionCount = (explosionCount+1) % explosions.Count;                
               return new Animation(explosions[explosionCount]);
            }
        }


    }
}
