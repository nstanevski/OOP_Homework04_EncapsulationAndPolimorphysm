using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    class Healer:Character, IHeal
    {
        //Has default Health points of 75, Defense points of 50, 
        // Healing points of 60 and Range of 6.
        private const int DefaultHealthPoints = 75;
        private const int DefaultDefencePoints = 50;
        private const int DefaultHealingPoints = 60;
        private const int DefaultRange = 6;

        public Healer(string id, int x, int y, Team team) :
            base(id, x, y, DefaultHealthPoints, DefaultDefencePoints, team, DefaultRange)
        {
            this.HealingPoints = DefaultHealingPoints;
        }

        public int HealingPoints
        {
            get;
            set;
        }

       
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(c => c.Id != this.Id && c.Team == this.Team && c.IsAlive)
                .OrderBy(c => c.HealthPoints)
                .FirstOrDefault();
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return string.Format("{0}, Healing: {1}", base.ToString(), this.HealingPoints);
        }
       
    }
}
