using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class Star : EnvironmentObject
    {
        private const int StarWidth = 1;
        private const int StarHeight = 1;
        private const char StarImageCharacter = 'o';
        private const int StarImageUpdateFrequency = 10;
        private int updateCount = 0;
        private static readonly Random randomizer = new Random();
        private static char[] starImageProfiles = new char[] { '0', 'o', '@' };
        public Star(int x, int y)
            : base(x, y, StarWidth, StarHeight)
        {
            this.ImageProfile = new char[,] { { StarImageCharacter } };
        }
        public override void Update()
        {
            if (this.updateCount == StarImageUpdateFrequency)
            {
                int index = randomizer.Next(0, starImageProfiles.Length);
                this.ImageProfile = new char[,] { { starImageProfiles[index] } };
                this.updateCount = 0;
            }
            this.updateCount++;
        }
        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }
        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
