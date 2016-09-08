﻿using System;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	[Serializable]
	public class PlayerSettings
	{
		public MovePlayerBehaviour Player;
		public Movement MovementSettings;
		public TouchInputDimensions TouchInputSettings;

		public PlayerSettings ()
		{
			// set up sensible defaults here; they can be tweaked in the editor
			MovementSettings = new Movement { ForwardSpeed = 1.5f, RotationSpeed = 15f };
			TouchInputSettings = new TouchInputDimensions { ButtonSize = 50, Spacing = 10 };
		}

		[Serializable]
		public class Movement
		{
			public float ForwardSpeed;
			public float RotationSpeed;
		}

		[Serializable]
		public class TouchInputDimensions
		{
			public int ButtonSize;
			public int Spacing;
		}
	}
}

