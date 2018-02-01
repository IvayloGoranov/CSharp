using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class FallingStarTail : EnvironmentObject
    {
        private const int FallingStarTailWidth = 1;
        private const int FallingStarTailHeight = 1;
        private const char FallingStarTailImageCharacter = '*';
        private int lifetime;
        public FallingStarTail(int x, int y, int lifetime = 1)
            : base(x, y, FallingStarTailWidth, FallingStarTailWidth)
        {
            this.ImageProfile = new char[,] { { FallingStarTailImageCharacter } };
            this.lifetime = lifetime;
        }
        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }
        public override void Update()
        {
            this.lifetime--;
            if (lifetime == 0)
            {
                this.Exists = false;
            }
        }
        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
