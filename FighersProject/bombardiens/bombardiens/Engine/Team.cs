using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bombardiens.Engine
{
    public class Team
    {
        public ObjectList characters = new ObjectList(30, 128);
        public ObjectList bullets = new ObjectList(3, 128);

        public List<Team> enemyTeams = new List<Team>();
        public List<Team> allyTeams = new List<Team>();
        public List<Team> neutralTeams = new List<Team>();


        public void removeDead()
        {
            characters.removeDead();
            bullets.removeDead();
        }

        public void updatePhysics()
        {
            characters.updateObjectPhysics();
            bullets.updateObjectPhysics();
        }

        public void checkBulletCollisions()
        {
            if (bullets.Count > 0)
            {
                for (int i = 0; i < enemyTeams.Count; i++)
                {
                    bullets.checkExternalCollisionsY(enemyTeams[i].characters);
                }
            }
        }

        public void updateToCamera(Engine.GameRender.InGameCamera camera, int frame)
        {
            characters.updateToCamera(camera, frame);
            bullets.updateToCamera(camera, frame);
        }        
    }
}
