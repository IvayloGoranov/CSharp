using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class MeltedSnow : EnvironmentObject
    {
        private const int SnowWidth = 1;
        private const int SnowHeight = 1;
        private const char SnowImageCharacter = '.';
        public MeltedSnow(int x, int y)
            : base(x, y, SnowWidth, SnowHeight)
        {
            this.ImageProfile = new char[,] { { SnowImageCharacter } };
        }
        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }
        public override void Update()
        {
        }
        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
