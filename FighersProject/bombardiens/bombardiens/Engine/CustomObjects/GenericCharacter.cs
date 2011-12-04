using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary;
using Microsoft.Xna.Framework;
using GameLibrary.Global;
using GameLibrary.Core;
using bombardiens.Engine.Types;
using bombardiens.Engine.CustomObjects;
using GameLibrary.Interfaces;

namespace bombardiens.Engine.Character
{
    public class GenericCharacter :TerrainCollideObject, IControllable, IBulletCollideable, ISolidTerrainCollidable
    {
        protected int _health = 1;
        public float movementSpeed = 3f;
        protected Animation moveForwardAnimation;
        protected Animation moveBackwardAnimation;
        protected Animation moveLeftAnimation;
        protected Animation moveRightAnimation;
        protected Animation standAnimation;
        protected Team _team;
        public GenericGun weapon;

        public GenericCharacter(Vector2 position, Team team, Animation forward, Animation backward, Animation left, Animation right, Animation stand)
            : base(position, stand, stand.Width(1)/3)
        {
            this.team = team;
            standAnimation = stand;
            moveRightAnimation = right;
            moveLeftAnimation = left;
            moveForwardAnimation = forward;
            moveBackwardAnimation = backward;
            stopMoving();
            layerDepth = 10;            
        }


        public void solidTerrainCollision(SolidTerrain solidTerrain)
        {
        }

        public Team team
        {
            get
            {
                return _team;
            }
            set
            {
                if (_team != null)
                {
                    _team.characters.Remove(this);
                }
                _team = value;
                _team.characters.Add(this);
            }
        }

        public virtual void struckByBullet(GenericBullet bullet)
        {
            health -= bullet.damage;
        }

        public int health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    Die();
                }
            }
        }

        public void moveForward()
        {
            acceleration += Trig.MoveToCurrentDirection(Vector2.Zero, rotation, movementSpeed);
            animation = moveForwardAnimation;
        }

        public void moveBackward()
        {
            acceleration += Trig.MoveToCurrentDirection(Vector2.Zero, rotation, -movementSpeed);
            animation = moveBackwardAnimation;
        }

        public void moveLeft()
        {
            acceleration += Trig.MoveToCurrentDirection(Vector2.Zero, rotation - Trig.PI_Half, movementSpeed);
            animation = moveLeftAnimation;
        }

        public void moveRight()
        {
            acceleration += Trig.MoveToCurrentDirection(Vector2.Zero, rotation + Trig.PI_Half, movementSpeed);
            animation = moveRightAnimation;
        }

        public void stopMoving()
        {
            animation = standAnimation;
            velocity = Vector2.Zero;
        }

        public void Die()
        {
            alive = false;
        }

        public override void updatePhysics()
        {
            base.updatePhysics();
            if (weapon != null)
            {
                weapon.position = Trig.MoveToCurrentDirection(position, rotation + Trig.PI_Quarter, width/3);
           //     weapon.position = Trig.MoveToCurrentDirection(position, rotation, height / 2);
                weapon.rotation = rotation;
            }
        }

        public override void draw(Vector2 position, float rotation)
        {
            base.draw(position, rotation);
        }


    }
}
