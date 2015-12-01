using System;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    class MyEngine:Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            base.ExecuteCommand(inputParams);
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    throw new ArgumentException("Invalid command");
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            //create characterClass id x y team
            string charClassStr = inputParams[1];
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = inputParams[5] == "Red" ? Team.Red : Team.Blue;
            Character newCharacter;
            switch (charClassStr.ToLower())
            {
                case "warrior":
                    newCharacter = new Warrior(id, x, y, team);
                    break;
                case "mage":
                    newCharacter = new Mage(id, x, y, team);
                    break;
                case "healer":
                    newCharacter = new Healer(id, x, y, team);
                    break;
                default:
                    throw new ArgumentException("Invalid character type");
            }
            this.characterList.Add(newCharacter);
        }

        protected new void AddItem(string[] inputParams)
        {
            //add character itemClass itemId
            Character itemOwner = this.GetCharacterById(inputParams[1]);
            string itemClassStr = inputParams[2];
            string itemId = inputParams[3];
            Item newItem;
            switch (itemClassStr.ToLower())
            {
                case "axe":
                    newItem = new Axe(itemId);
                    break;
                case "shield":
                    newItem = new Shield(itemId);
                    break;
                case "injection":
                    newItem = new Injection(itemId);
                    break;
                case "pill":
                    newItem = new Pill(itemId);
                    break;
                default:
                    throw new ArgumentException("Invalid item type");
            }
            itemOwner.AddToInventory(newItem);

        }
    }
}
