using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary;
using Microsoft.Xna.Framework;
using GameLibrary.Global;
using GameLibrary.Core;

namespace bombardiens.Engine.Character
{
    public class AI
    {
        public GenericCharacter character;
        public Vector2 destination;
        public GenericCharacter target;
        public float visionRange = 500;

        public AI(GenericCharacter character)
        {
            this.character = character;
            destination = character._position;
        }

        public void goToDestination()
        {
            character.rotation = Trig.GetRadionsBetween(character._position, destination);
            character.moveForward();
        }

        public void attackTarget()
        {
            destination = target._position;
            goToDestination();
        }

        public void searchForTarget() 
        {
            // TODO Perform this search over a few frames 
            for (int i = 0; i < character.team.enemyTeams.Count; i++)
            {
                for (int j = 0; j < character.team.enemyTeams[i].characters.Count; j++)
                {
                    AnimatedGameObject enemyChar = character.team.enemyTeams[i].characters[j] as AnimatedGameObject;
                    float distanceToEnemy = Vector2.Distance(character._position, enemyChar._position);
                    
                    if (distanceToEnemy < visionRange)
                    {
                        spotTarget(enemyChar as GenericCharacter);
                    }
                }
            }
        }

        public void spotTarget(GenericCharacter basicChar)
        {
            target = basicChar;
        }


        public void think()
        {
            character.stopMoving();

            if (target == null)
            {
                searchForTarget();

            }
            else
            {
                attackTarget();
            }
        }

    }
}
