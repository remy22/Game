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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using GameLibrary.Core;


namespace GameLibrary.Global
{
    public static class Graphics
    {
        public static Dictionary<String, Texture2D> dictionary = new Dictionary<string, Texture2D>();
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        private static ContentManager content;
        public static SpriteFont font;
        public static Color airColor = new Color(0, 0, 0, 0);
        
        public static void LoadGraphics(Game game)
        {
            dictionary.Add(plainTex, Graphics.CreateTexture2D(1, 1, Color.White, Color.White));
            dictionary.Add("circleTex", Graphics.CreateCircleTexture(300, Color.White, Color.White));
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            try
            {
                Graphics.font = game.Content.Load<SpriteFont>("font");
            }
            catch { }
        }

        public static String plainTex
        {
            get
            {
                return "plainTex";
            }
        }


        public static void LoadTexture(string pathfile, string fileName)
        {
            dictionary.Add(fileName, LoadTextureFile(pathfile + fileName));
        }

        public static void LoadTexture(string pathfile, string fileName, string type)
        {
            dictionary.Add(fileName, LoadTextureFile(pathfile + fileName + type));
        }

        public static Texture2D LoadTextureFile(string pathFile)
        {
            Stream stream = new FileStream(pathFile, FileMode.Open, FileAccess.Read, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            stream.Flush();
            return Texture2D.FromStream(graphics.GraphicsDevice, stream);
        }

        public static void DrawString(String text, Vector2 position, Color colour)
        {
            spriteBatch.DrawString(font, text, position, colour);
        }



        public static Texture2D plainTexture
        {
            get
            {
                return dictionary[plainTex];
            }
        }

        public static Texture2D circleTexture
        {
            get
            {
                return dictionary["circleTex"];
            }
        }

        private static int getTextureIndex(Texture2D texture, int x, int y)
        {
            return x + y * texture.Width;
        }

        public static Texture2D damageTexture(Texture2D texture, int x, int y, float radius)
        {
            int width = texture.Width;
            int height = texture.Height;
            Color[] foregroundColors = new Color[width * height];
            texture.GetData<Color>(foregroundColors);
            foregroundColors[getTextureIndex(texture, x, y)] = airColor;

            Texture2D foregroundTexture = new Texture2D(graphics.GraphicsDevice, width, height, false, SurfaceFormat.Color);
            foregroundTexture.SetData(foregroundColors);
            return foregroundTexture;
        }

        public static Texture2D CreateTexture2D(int width, int height, Color fillColour, Color outlineColour)
        {
            Color[] foregroundColors = new Color[width * height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    foregroundColors[x + y * width] = fillColour;

                    if (x == 0 || y == 0)
                    {
                        foregroundColors[x + y * width] = outlineColour;
                    }

                    if (x == width - 1 || y == height - 1)
                    {
                        foregroundColors[x + y * width] = outlineColour;
                    }
                }
            }
            Texture2D foregroundTexture = new Texture2D(graphics.GraphicsDevice, width, height, false, SurfaceFormat.Color);
            foregroundTexture.SetData(foregroundColors);
            return foregroundTexture;
        }


        /// <summary>
        /// Draws a line in screen coordinates
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="thickness"></param>
        public static void DrawLine(Vector2 pointA, Vector2 pointB, int thickness, Color color)
        {
            float rotation = Trig.GetRadionsBetween(pointA, pointB);
             Rectangle rectangle = new Rectangle((int)pointA.X, (int)pointA.Y, (int)Vector2.Distance(pointA, pointB), thickness);
             spriteBatch.Draw(plainTexture, rectangle, null, color, rotation, new Vector2(), SpriteEffects.None, 0);
        }

        public static Texture2D CreateGradientTexture(int width, int height, Color topColour, Color bottomColour)
        {
            Color[] foregroundColors = new Color[width * height];
            float redDiff = bottomColour.R - topColour.R;
            float greenDiff = bottomColour.G - topColour.G;
            float blueDiff = bottomColour.B - topColour.B;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    float percent = (float)y / (float)height;
                    float r = topColour.R + (redDiff * percent);
                    float g = topColour.G + (greenDiff * percent);
                    float b = topColour.B + (blueDiff * percent);

                    foregroundColors[x + y * width] = new Color((byte)r, (byte)g, (byte)b);
                }
            }
            Texture2D texture = new Texture2D(graphics.GraphicsDevice, width, height, false, SurfaceFormat.Color);
            texture.SetData(foregroundColors);
            return texture;
        }



        public static Texture2D CreateCircleTexture(int radius, Color outline, Color fill)
        {
            int size = radius * 2;
            Color[] foregroundColors = new Color[size * size];
            Color clear = new Color(0, 0, 0, 0);

            for (int y = -radius; y < radius; y++)
            {
                int x1, x2;

                x1 = -(int)Math.Sqrt((radius * radius) - (y * y));
                x2 = -x1;

                for (int i = -radius; i < radius; i++)
                {
                    int index = (y + radius) * size + (i + radius);

                    if (i < x1 || i > x2)
                    {
                        foregroundColors[index] = clear;
                    }
                    else
                    {
                        if (i == x1 || i == x2)
                        {
                            foregroundColors[index] = outline;
                        }
                        else
                        {
                            foregroundColors[index] = fill;
                        }
                    }
                }
            }
            Texture2D foregroundTexture = new Texture2D(graphics.GraphicsDevice, size, size, false, SurfaceFormat.Color);
            foregroundTexture.SetData(foregroundColors);
            return foregroundTexture;
        }



        public static void WriteText(String text, Vector2 pos, Color col)
        {
            spriteBatch.DrawString(font, text, pos, col);
        }




        public static Texture2D LoadTexture(string textureName)
        {
            return content.Load<Texture2D>(textureName);
        }
    }
}
