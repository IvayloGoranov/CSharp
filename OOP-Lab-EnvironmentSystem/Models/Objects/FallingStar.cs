using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class FallingStar : MovingObject
    {
        private const int FallingStarWidth = 1;
        private const int FallingStarHeight = 1;
        private const char StarImageCharacter = 'o';
        public FallingStar(int x, int y, Point direction)
            : base(x, y, FallingStarWidth, FallingStarHeight, direction)
        {
            this.ImageProfile = new char[,] { { StarImageCharacter } };
            this.CollisionGroup = CollisionGroup.FallingStar;
        }
        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup ;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.MeltedSnow)
            {
                this.Exists = false;
            }
        }
        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            List<EnvironmentObject> producedObjects = new List<EnvironmentObject>();
            producedObjects.Add
                    (new FallingStarTail(this.Bounds.TopLeft.X - this.Direction.X, this.Bounds.TopLeft.Y - this.Direction.Y));
            producedObjects.Add
                    (new FallingStarTail(this.Bounds.TopLeft.X - 2 * this.Direction.X, this.Bounds.TopLeft.Y - 2 * this.Direction.Y));
            producedObjects.Add
                    (new FallingStarTail(this.Bounds.TopLeft.X - 3 * this.Direction.X, this.Bounds.TopLeft.Y - 3 * this.Direction.Y));
            return producedObjects;
        }
    }
}
