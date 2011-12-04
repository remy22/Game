using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameLibrary;
using GameLibrary.Core;
using Microsoft.Xna.Framework;
using bombardiens.Engine;
using bombardiens.Engine.Character;
using GameLibrary.Global;
using bombardiens.Engine.GameRender;
using bombardiens.Engine.CustomObjects;
using bombardiens.Engine.Util;
using bombardiens.Engine.Effects;
using bombardiens.GameStuff;

namespace bombardiens.Demo
{
    public class DemoLevel:GameSection
    {
        public GenericCharacter player;
        private InGamePlayerInput playerInput = new InGamePlayerInput();
        private InGameMouse mouseInput = new InGameMouse();
        Animation animation = new Animation(Res.arrow);
        GenericGun gun;
        protected Team redTeam = new Team();
        protected Team blueTeam = new Team();

        public DemoLevel():base()
        {
            initialiseTeams();
            gun = new GenericGun(Vector2.Zero, new Animation(Res.pistol));
            player = createGeneric(Vector2.Zero, blueTeam, Color.Blue);
            player.weapon = gun;
            blueTeam.characters.Add(player);
            genericObjects.Add(gun);
            spawnCharacters(10);
            spawnDestructableEnvironment(10, 100, 100);
           // spawnSolidEnvironment(10, 200, 200);
            spawnBackground(10);
            gun.muzzleVelocity = 10;

            DestructableTerrain test = new DestructableTerrain(new Vector2(10, 0), Graphics.dictionary[Res.crate]);
            List<Vector2> list = test.getVectorCollisions(new Vector2(10, 5), 1);

        }


        public GenericCharacter createGeneric(Vector2 position, Team team, Color color)
        {
            Animation stand = new Animation(Res.stand);
            Animation run = new Animation(Res.run, 8);
            Animation strafe = new Animation(Res.strafe, 8);
            GenericCharacter character = new GenericCharacter(position, team, run, run, strafe, strafe, stand);
            character.color = color;
            return character;
        }

        private void initialiseTeams()
        {
            redTeam.enemyTeams.Add(blueTeam);
            blueTeam.enemyTeams.Add(redTeam);
            teams.Add(redTeam);
            teams.Add(blueTeam);
        }

        public void spawnCharacters(int count)
        {
            for (int i = 0; i < count; i++)
            {
                float x = RANDOM.random.Next(0, 5000);
                float y = RANDOM.random.Next(0, 5000);
                Vector2 position = new Vector2(x,y);
                GenericCharacter character = createGeneric(position, redTeam, Color.Red);
                character.health = 10;
                redTeam.characters.Add(character);
                AI ai = new AI(character);
                aiList.Add(ai);
            }
        }

        public void spawnDestructableEnvironment(int count, int width, int height)
        {
            for (int i = 0; i < count; i++)
            {
                float x = RANDOM.random.Next(0, count * 100);
                float y = RANDOM.random.Next(0, count * 100);
                Vector2 position = new Vector2(x, y);                
              //  environment.Add(new DestructableTerrain(new Vector2(x,y), Graphics.CreateTexture2D(width, height, Color.Black, Color.Black)));
                environment.Add(new DestructableTerrain(new Vector2(x, y), Graphics.dictionary[Res.crate]));
            }
        }

        public void spawnSolidEnvironment(int count, int width, int height)
        {
            Animation anim = new Animation(Res.block);

            for (int i = 0; i < count; i++)
            {
                float x = RANDOM.random.Next(0, count * 10);
                float y = RANDOM.random.Next(0, count * 10);
                Vector2 position = new Vector2(x, y);
                environment.Add(new SolidTerrain(position, anim));

            }
        }

        public void spawnBackground(int count)
        {
            for (int i = 0; i < count; i++)
            {
                float x = RANDOM.random.Next(0, 5000);
                float y = RANDOM.random.Next(0, 5000);
                Vector2 position = new Vector2(x, y);
                AnimatedGameObject gameObject = new AnimatedGameObject(position, Res.treeAnim);
                background.Add(gameObject);
            }
        }




        public void readInput()
        {
            mouseInput.rotate(player);
            player.stopMoving();
            playerInput.controlCharacter(player);
            playerInput.switchModes();
            playerInput.shoot(player, gun, blueTeam.bullets);
            mouseInput.update();
            customUser();
        }

        public void customUser()
        {
            if (MOUSE.RightClicked)
            {
                explosions.Add(new Explosion(camera.mouseWC, 10, fireballs));
            }

            if (KEYBOARD.KeyDown(Keys.I))
            {
                DestructableTerrain d = new DestructableTerrain(camera.mouseWC, Graphics.CreateTexture2D(50, 50, Color.Black, Color.Black));
                environment.Add(d);
                environment.partitionObject(d);
            }
        }

        public override void Update()
        {
            DEBUG.reset();
            gun.CoolDown();
            readInput();
            base.Update();
        }

        public override void Draw()
        {
            camera.chaseCam(player);
            base.Draw();
        }
    }
}
