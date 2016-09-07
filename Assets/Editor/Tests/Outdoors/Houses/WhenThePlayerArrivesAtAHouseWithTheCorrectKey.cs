using NUnit.Framework;
using Neighbourhood.Editor.Tests.TestExtensions;
using Neighbourhood.Game.Outdoors.Houses;
using Neighbourhood.Game.FlashMessages;
using Neighbourhood.Game.Levels;
using Neighbourhood.Game.Inventory;

namespace Neighbourhood.Editor.Tests.Outdoors.Houses
{

	[TestFixture]
	public class WhenThePlayerArrivesAtAHouseWithTheCorrectKey
	{
		string dispatchedMessage;
		string requestedLevel;

		[SetUp]
		public void Given()
		{
			var registry = new HouseRegistry();
			var trigger = new InventoryItemAddedSignal.Trigger();
			trigger.SetupSignalListenerForTesting<InventoryItemAddedSignal, Item>(item => {});
			var inventory = new Game.Inventory.Inventory(trigger);
			inventory.Add(new Item("Green key", new Key {Code = "KEY_GREEN"}));

			var showMessageCommand = new ShowMessageCommand();
			dispatchedMessage = null;
			showMessageCommand.Construct(msg => dispatchedMessage = msg);
			var loadLevelCommand = new EnterHouseCommand();
			requestedLevel = null;
			loadLevelCommand.Construct(levelName => requestedLevel = levelName);

			var controller = new HouseController(registry, inventory, showMessageCommand, loadLevelCommand);
			controller.Initialize(new HouseData { RequiredKeyCode = "KEY_GREEN", LoadLevel = "nextLevel" });
			controller.PlayerArrived();
		}

		[Test]
		public void NoMessageToTheUserIsDispatched()
		{
			Assert.That(string.IsNullOrEmpty(dispatchedMessage), Is.True);
		}

		[Test]
		public void TheLevelManagerIsAskedToLoadANewLevel()
		{
			Assert.That(requestedLevel, Is.EqualTo("nextLevel"));
		}
	}
}