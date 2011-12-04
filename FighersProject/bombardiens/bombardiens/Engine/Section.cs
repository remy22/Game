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


namespace bombardiens.Engine
{
    /// <summary>
    /// The level class stores and manages all the objects inside the level
    /// </summary>
    public class Section 
    {
        protected InGameCamera camera;
        DebugHelper debugHelper = new DebugHelper();
        protected ObjectList environment = new ObjectList(30, 128);
        protected ObjectList background = new ObjectList(30, 128);
        protected ObjectList fireballs = new ObjectList(3, 128);
        protected ObjectList explosions = new ObjectList(3, 128);
        protected ObjectList genericObjects = new ObjectList(30, 100);

        public List<Team> teams = new List<Team>();
        public List<AI> aiList = new List<AI>();
        private int _frame = 0;
        public static bool debugMode = true;


        public Section()
        {
            camera = new InGameCamera(Vector2.Zero, Res.arrowAnim);
        }

        public int frame
        {
            get
            {
                return _frame;
            }
        }


        public virtual void Update()
        {
            _frame++;
            removeDead();
            updateCollisions();
            updatePhysics();
            updateAI();
        }

        private void updateAI()
        {
            for (int i = 0; i < aiList.Count; i++)
            {
                aiList[i].think();
            }
        }

        private void removeDead()
        {
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].removeDead();
            }
            explosions.removeDead();
            fireballs.removeDead();
        }

        private void updateCollisions()
        {
            clearAllDictionaries();
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].checkBulletCollisions();
                environment.checkExternalCollisionsY(teams[i].bullets);
                environment.checkExternalCollisionsY(teams[i].characters);                
            }
            environment.checkExternalCollisionsY(fireballs);
        }

        private void clearAllDictionaries()
        {
            explosions.clearDictionary();
            fireballs.clearDictionary();
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].bullets.clearDictionary();
                teams[i].characters.clearDictionary();
            }

        }

        private void clearCache()
        {

        }

        private void updatePhysics()
        {
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].updatePhysics();
            }
            fireballs.updateObjectPhysics();
            explosions.updateObjectPhysics();
        }

        public virtual void Draw()
        {
            fireballs.updateToCamera(camera, frame);
            explosions.updateToCamera(camera, frame);
            environment.updateToCamera(camera, frame);
            background.updateToCamera(camera, frame);
            genericObjects.updateToCamera(camera, frame);
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].updateToCamera(camera, frame);
            }
            camera.Draw();

            if (debugMode)
            {
                int characterCount = 0;
                int bulletCount = 0;
                int environmentCount = environment.Count;

                for (int i = 0; i < teams.Count; i++)
                {
                    characterCount += teams[i].characters.Count;
                    bulletCount = teams[i].bullets.Count;
                }
                float x = 10;
                float y = 10;
                float space = 25;
                Color colour = Color.Black;
                int start = 0;
                Graphics.DrawString("CharacterCount: " + characterCount, new Vector2(x, y + (space * start++)), colour);
                Graphics.DrawString("BulletCount: " + bulletCount, new Vector2(x, y + (space * start++)), colour);
                Graphics.DrawString("EnvironmentCount: " + environmentCount, new Vector2(x, y + (space * start++)), colour);
                Graphics.DrawString("ObjectsDrawn: " +camera.drawList.Count, new Vector2(x, y + (space * start++)), colour);
                Graphics.DrawString("Comparisons: " + DEBUG.comparisons, new Vector2(x, y + (space * start++)), colour);
                Graphics.DrawString("DrawChecks: " + DEBUG.cameraChecks, new Vector2(x, y + (space * start++)), colour);
                Graphics.DrawString("CamPos: " + camera.position.ToString(), new Vector2(x, y + (space * start++)), colour);
                Graphics.DrawString("Explosion: " + explosions.Count.ToString(), new Vector2(x, y + (space * start++)), colour);
            }
        }
    }
}
