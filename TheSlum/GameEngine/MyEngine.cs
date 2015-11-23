using System;

using TheSlum.Characters;

namespace TheSlum.GameEngine
{
    class MyEngine:Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            //create characterClass id x y team
            string characterClass = inputParams[1];
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = inputParams[5] == "Red" ? Team.Red : Team.Blue;
            Character character;
            switch (characterClass)
            {
                case "warrior":
                    character = new Warrior(id, x, y, team);
                    break;

            }
        }
    }
}
