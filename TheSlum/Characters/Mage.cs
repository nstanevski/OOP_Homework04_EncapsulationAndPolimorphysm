using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;


namespace TheSlum.Characters
{
    class Mage:Character, IAttack
    {
       
        private const int DefaultHealthPoints = 150;
        private const int DefaultDefencePoints = 50;
        private const int DefaultAttackPoints = 300;
        private const int DefaultRange = 5;

        public Mage(string id, int x, int y, Team team)
            :base(id, x, y, DefaultHealthPoints, DefaultDefencePoints, team, DefaultRange)
        {
            this.AttackPoints = DefaultAttackPoints;
        }

        public int AttackPoints { get; set; }

        public  override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        public override void RemoveFromInventory(Item item)
        {
            throw new NotImplementedException();
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList
                .Where(x => x.IsAlive)
                .Last(x => x.Team != this.Team);
            return target;
        }


    }
}
