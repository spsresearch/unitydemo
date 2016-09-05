﻿using System;
using Zenject;

namespace Neighbourhood.Game.Outdoors.Houses
{
	public class HouseInstaller : Installer<HouseInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<HouseController>().ToSelf().AsTransient();
			Container.Bind<HouseRegistry>().ToSelf().AsSingle();
		}
	}
}
