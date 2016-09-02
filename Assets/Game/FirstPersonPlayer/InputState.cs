﻿using System;

namespace Neighbourhood.Game.FirstPersonPlayer
{
	public enum MovementDirection
	{
		Still,
		Forward,
		Backward
	}

	public enum RotationDirection
	{
		None,
		Left,
		Right
	}

	public class InputState
	{
		public MovementDirection Direction { get; set; }
		public RotationDirection Rotation { get; set; }
	}
}
