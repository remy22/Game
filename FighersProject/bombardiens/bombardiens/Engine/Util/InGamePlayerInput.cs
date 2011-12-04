using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Global;
using GameLibrary.Core;
using Microsoft.Xna.Framework.Input;
using bombardiens.Engine.Character;

namespace bombardiens.Engine.GameRender
{
    public class InGamePlayerInput
    {
        private float rotationSpeed = 0.01f;
        private float movementSpeed = 3f;

        public float sensitivity = 1000f;

        Keys forwardKey = Keys.W;
        Keys backwardKey = Keys.S;
        Keys leftKey = Keys.A;
        Keys rightKey = Keys.D;

        Keys rotateClockwise = Keys.E;
        Keys rotateAntiClockwise = Keys.Q;


        public void rotateObject(AnimatedGameObject gameObject)
        {
            if (KEYBOARD.KeyDown(rotateAntiClockwise))
            {
                gameObject.rotation -= rotationSpeed;
            }

            if (KEYBOARD.KeyDown(rotateClockwise))
            {
                gameObject.rotation += rotationSpeed;
            }
        }

        public void controlObject(AnimatedGameObject gameObject)
        {
            if (KEYBOARD.KeyDown(forwardKey))
            {
                gameObject._position = Trig.MoveToCurrentDirection(gameObject._position, gameObject.rotation, movementSpeed);            
            }

            if (KEYBOARD.KeyDown(backwardKey))
            {
                gameObject._position = Trig.MoveToCurrentDirection(gameObject._position, gameObject.rotation, -movementSpeed);
            }

            if (KEYBOARD.KeyDown(leftKey))
            {
                gameObject._position = Trig.MoveToCurrentDirection(gameObject._position, gameObject.rotation -Trig.PI_Half, movementSpeed);
          
            }

            if (KEYBOARD.KeyDown(rightKey))
            {
                gameObject._position = Trig.MoveToCurrentDirection(gameObject._position, gameObject.rotation +Trig.PI_Half, movementSpeed);
          
            }
        }

        public void controlCharacter(Engine.Character.GenericCharacter character)
        {
            if (KEYBOARD.KeyDown(forwardKey))
            {
                character.moveForward();
            }

            if (KEYBOARD.KeyDown(backwardKey))
            {
                character.moveBackward();
            }

            if (KEYBOARD.KeyDown(leftKey))
            {
                character.moveLeft();
            }

            if (KEYBOARD.KeyDown(rightKey))
            {
                character.moveRight();
            }
        }

        public void readMouseToAim(AnimatedGameObject gameObject)
        {
            float rel = MOUSE.SC.X - Screen.width / 2;
            float percentage = rel / Screen.width * 100;
            percentage = percentage * percentage * (percentage * 0.001f);
            gameObject.rotation += percentage / sensitivity;
        }

        public void shoot(GenericCharacter shooter, ParticleGun particleGun, ObjectList bullets)
        {
            if (MOUSE.LeftDown && particleGun.readyToFire)
            {
                bullets.Add(particleGun.Fire());
            }
        }

        public void switchModes()
        {
            if (KEYBOARD.KeyPressed(Keys.Z))
            {
                Section.debugMode = !Section.debugMode;
            }
        }
    }
}
