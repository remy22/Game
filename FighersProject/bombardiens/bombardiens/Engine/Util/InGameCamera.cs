using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using GameLibrary.Core;
using GameLibrary.Managers;
using GameLibrary.Interfaces;
using GameLibrary.Global;

namespace bombardiens.Engine.GameRender
{
    public class InGameCamera : AnimatedGameObject
    {
        public Vector2 screenPosition = Vector2.Zero;
        public float directionToFace = -Trig.PI_Half;
        public float distanceBehind = 100;
        public float drawDistance = 1500f;
        public List<IGameObject> drawList = new List<IGameObject>();
        float sensitivity = 10;

        public static List<Vector2> debugPositions = new List<Vector2>();


        public InGameCamera(Vector2 position, Animation animation)
            : base(position, animation)
        {
            screenPosition.X = GameLibrary.Global.Screen.width / 2;
            screenPosition.Y = GameLibrary.Global.Screen.height * 0.95f;
            color = Color.Yellow;
            //drawList.Add(this);
        }

        public void chaseCam(AnimatedGameObject gameObject)
        {
            position = gameObject.position;
            float difference = gameObject.rotation - this.rotation;

            if (Math.Abs(difference) > Trig.PI)
            {
                if (rotation < Trig.PI)
                {
                    difference = -(Trig.PI_Two - Math.Abs(difference));
                }
                else
                {
                    difference = (Trig.PI_Two - Math.Abs(difference));
                }
            }

            rotation += ((difference) / sensitivity);
            position = Trig.MoveToCurrentDirection(position, rotation, -distanceBehind);
        }


        public void drawObject(IDisplayed displayObject)
        {
            Vector2 pos = relativePosition(displayObject.position);
            float rotation = relativeRotation(displayObject.rotation);
            displayObject.draw(pos, rotation);
        }

        public void clear()
        {
            for (int i = 0; i < drawList.Count; i++)
            {
                if (!drawList[i].alive || Vector2.Distance(drawList[i].position, position) > drawDistance)
                {
                    drawList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void faceMouse(AnimatedGameObject gameObject)
        {
            gameObject.rotation = Trig.GetRadionsBetween(gameObject._position, mouseWC);
        }

        public Vector2 mouseSC
        {
            get
            {
                return MOUSE.SC - screenPosition;
            }
        }

        public Vector2 mouseWC
        {
            get
            {
                return -Trig.RotateVectorAroundPoint(mouseSC, Vector2.Zero, rotation + directionToFace) + position;
            }
        }

        /// <summary>
        /// Given a world position, translates it to a the position relative to the camera's position and rotation
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Vector2 relativePosition(Vector2 position)
        {
            return Trig.RotateVectorAroundPoint(position, this._position, -rotation + directionToFace) + screenPosition;
       
        }

        /// <summary>
        /// Returns the rotation relative to the camera's angle
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public float relativeRotation(float rotation)
        {
            return rotation - this.rotation + directionToFace;
        }

        public void Draw()
        {
            clear();
            for (int i = 0; i < drawList.Count; i++)
            {
                drawObject(drawList[i]);
            }
            drawDebugPositions();
        }

        public void checkToDraw(IGameObject iDisplayed)
        {
            DEBUG.cameraChecks++;
            if (Vector2.Distance(position, iDisplayed.position) < drawDistance)
            {
                if (!drawList.Contains(iDisplayed))
                {
                    drawList.Add(iDisplayed);
                }
            }
        }

        public void drawDebugPositions()
        {
            for (int i = 0; i < debugPositions.Count;)
            {
                drawPoint(debugPositions[i]);
                debugPositions.RemoveAt(i);                
            }
        }

        public void drawPoint(Vector2 position)
        {
            Graphics.spriteBatch.Draw(Graphics.circleTexture, relativePosition(position), Color.Pink);
        }


        /// <summary>
        /// Sorts the drawList based on the gameobject's depth, this controls the order in which objects are draw
        /// to make sure that what is on top is drawn on top
        /// </summary>
        public List<AnimatedGameObject> quicksort(ref List<AnimatedGameObject> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            List<AnimatedGameObject> less = new List<AnimatedGameObject>();
            List<AnimatedGameObject> high = new List<AnimatedGameObject>();

            while (list.Count > 1)
            {
                if (list[1].depth < list[0].depth)
                {
                    less.Add(list[1]);
                }
                else
                {
                    high.Add(list[1]);
                }
                list.RemoveAt(1);
            }
            less = quicksort(ref less);
            less.Add(list[0]);
            high = quicksort(ref high);
            less.AddRange(high);
            return less;
        }
    }
}
