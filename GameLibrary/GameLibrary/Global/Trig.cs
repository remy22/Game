using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameLibrary.Global
{
    public static class Trig
    {
        public const float PI = (float)Math.PI;
        public const float PI_Two = PI * 2;
        public const float PI_Half = PI * 0.5f;
        public const float PI_ThreeQuarter = PI_Two * 0.75f;
        public const float PI_Quarter = PI_Half / 2;
        
        public static Vector2 RotateVectorAroundPoint(Vector2 vector, Vector2 point, float degrees)
        {
            // Translate it to the origin
            vector -= point;

            // Rotate it around the origin
            Vector2 rotatedPosition = new Vector2();

            float cosDegrees = (float)(Math.Cos(degrees));
            float sinDegrees = (float)(Math.Sin(degrees));

            rotatedPosition.X = (vector.X * cosDegrees) - (vector.Y * sinDegrees);
            rotatedPosition.Y = (vector.X * sinDegrees) + (vector.Y * cosDegrees);

            // Translate it back
           // rotatedPosition += point;
            return rotatedPosition;
        }

        public static Vector2 getVelocity(float rotation, float speed)
        {
            float opp = (float)(speed * Math.Sin(rotation));
            float adj = (float)(speed * Math.Cos(rotation));
            return new Vector2(adj, opp);
        }

        public static bool isBetween(float value, float bottom, float top)
        {
            return value > bottom && value < top;
        }

        /*
        public static float GetYAtXOfLine(Vector2 a, Vector2 b, float X)
        {
            if (a.X < b.X)
            {
                return (((X - a.X) * (b.Y - a.Y)) / (b.X - a.X)) + a.Y;
            }
            else
            {
                return (((X - b.X) * (a.Y - b.Y)) / (a.X - b.X)) + b.Y;
            }
        }


        public static float GetXAtYOfLine(Vector2 a, Vector2 b, float Y)
        {
            if (a.Y < b.Y)
            {
                return (((Y - a.Y) * (b.X - a.X)) / (b.Y - a.Y)) + a.X;
            }
            else
            {
                return (((Y - b.Y) * (a.X - b.X)) / (a.Y - b.Y)) + b.X;
            }
        }


        public static Vector2? LinesIntercect(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
        {
            // Make sure that a1 is on the left and a2 is on the right
            if (a1.X > a2.X)
            {
                Vector2 save = a1;
                a1 = a2;
                a2 = save;
            }
            if (b1.X > b2.X)
            {
                Vector2 save = b1;
                b1 = b2;
                b2 = save;
            }
            List<Vector2> list = new List<Vector2>();
            List<Vector2> unsorted = new List<Vector2>();
            list.Add(a1);
            list.Add(a2);
            list.Add(b1);
            list.Add(b2);
            list = SortListByX(list, unsorted);

            // First prove that they are intercecting
            float left = list[1].X;
            float right = list[2].X;
            // A is higher on the left
            if (GetYAtXOfLine(a1, a2, left) > GetYAtXOfLine(b1, b2, left))
            {
                // If A is higher on the right as well, there is no intercection
                if (GetYAtXOfLine(a1, a2, right) > GetYAtXOfLine(b1, b2, right))
                {
                    return null;
                }
                // Else if B is higher on the left
            }
            else
            {
                // If B is higher on the right as well, there is no intercection
                if (GetYAtXOfLine(a1, a2, right) < GetYAtXOfLine(b1, b2, right))
                {
                    return null;
                }
            }

            if (list[0] == a1 && list[1] == a2 || list[1] == a1 && list[0] == a2)
            {
                return null;
            }

            if (list[0] == b1 && list[1] == b2 || list[1] == b1 && list[0] == b2)
            {
                return null;
            }

            // if A is a straight line
            if (a1.X == a2.X)
            {
                // Make a1 the higher node
                if (a1.Y > a2.Y)
                {
                    Vector2 save = a1;
                    a1 = a2;
                    a2 = save;
                }
                float y = GetYAtXOfLine(b1, b2, a1.X);

                if (y < a1.Y || y > a2.Y)
                {
                    return null;
                }
                else
                {
                    return new Vector2(a1.X, y);
                }
            }

            // if A is a straight line
            if (b1.X == b2.X)
            {
                // Make a1 the higher node
                if (b1.Y > b2.Y)
                {
                    Vector2 save = b1;
                    b1 = b2;
                    b2 = save;
                }
                float y = GetYAtXOfLine(a1, a2, b1.X);

                if (y < b1.Y || y > b2.Y)
                {
                    return null;
                }
                else
                {
                    return new Vector2(b1.X, y);
                }
            }
            float Ma = (a2.Y - a1.Y) / (a2.X - a1.X);
            float Mb = (b2.Y - b1.Y) / (b2.X - b1.X);
            float Ca = a1.Y - (Ma * a1.X);
            float Cb = b1.Y - (Mb * b1.X);
            float X = (Cb - Ca) / (Ma - Mb);
            float Y = Ma * X + Ca;
            return new Vector2(X, Y);
        }
         * */




        /// <summary>
        /// Returns a rectangle at the point of the vector
        /// </summary>
        /// <param name="vector2"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Rectangle VectorToRectangle(Vector2 vector2, int width, int height)
        {
            return new Rectangle((int)vector2.X, (int)vector2.Y, width, height);
        }

        /// <summary>
        /// This gives back the new position of a vector after its been moved in a certain direction by a speed
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static Vector2 MoveToCurrentDirection(Vector2 position, float rotation, float speed)
        {
            float opp = (float)(speed * Math.Sin(rotation));
            float adj = (float)(speed * Math.Cos(rotation));
            position.X += adj;
            position.Y += opp;
            return position;
        }



        /// <summary>
        /// Returns the angle between two points in radions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float GetRadionsBetween(Vector2 a, Vector2 b)
        {
            if (a == b)
            {
                return 0.0f;
            }
            float adjacent = a.X - b.X;
            float opposite = a.Y - b.Y;
            if (a.X > b.X)
            {
                return (float)(Math.Atan(opposite / adjacent)) + PI;
            }
            
            return (float)(Math.Atan(opposite / adjacent));
        }



        public static float VectorHypotonuce(Vector2 vector)
        {
            return Vector2.Distance(Vector2.Zero, vector);
        }
    


    }
}
