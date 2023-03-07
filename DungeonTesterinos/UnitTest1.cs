using DungeonLibrary;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading;

namespace DungeonTesterinos
{
    public class UnitTest1
    {
        [Fact]
        public void HPBarValue()
        {
            //Arrange
            Monster m = new Monster("Test", 20, 0, 70, 10, 1, "A practice dummy", false);

            Weapon sword = new Weapon(30, 30, "Gladius", 10, false, WeaponType.Short_Sword);
            Player player = new("Swing", 99, 5, 40, Race.Human, sword);
            Combat.DoAttack(player, m);

            double expectedBar = 0;
            double actualBar = 0;

            //Act
            expectedBar = 70 - 30;
            actualBar = m.Life;
            //Assert
            Assert.Equal(expectedBar, actualBar);
        }
        [Fact]
        public void TestingBlock()
        {
            //Arrange
            Monster m = new Monster("Test", 20, 10, 70, 10, 1, "A practice dummy", false);
            //Act
            int expectedBlock = 0;
            int actualBlock = 0;


            expectedBlock = 10;
            actualBlock = m.CalcBlock();
            //Assert
            Assert.Equal(expectedBlock, actualBlock);
        }
        [Fact]
        public void IsItAMonster()
        {
            //Arrange
            Monster m = Monster.GetMonster();
            //Act

            //Assert
            Assert.IsAssignableFrom<Monster>(m);

        }
        [Fact]
        public void PrintingRooms()
        {
            //Arrange
            string room = Combat.GetRoom();
            //Act

            //Assert
            Assert.Contains("door blocks your path, pushing past it you enter the next room!", room);
        }
        [Fact]
        public void TEST()
        {
            //Arrange
            Monster m = new Monster("Test", 20, 30, 70, 10, 1, "A practice dummy", false);
            //Act
            int expectedHitChance = 0;
            int actualHitChance = 0;

            expectedHitChance = 20;
            actualHitChance = m.CalcHitChance();
            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);
        }
    }
}