
namespace RPG.Interfaces
{
    public interface ICharacter
    {
        void Attack(ICharacter target);

        string Name { get; set; }

        int Health { get; set; }

        IWeapon Weapon { get; set; }
    }
}
