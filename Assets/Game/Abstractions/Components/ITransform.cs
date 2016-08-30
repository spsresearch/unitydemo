using UnityEngine;

namespace Neighbourhood.Game.Abstractions.Components
{

	public interface ITransform
	{
		Vector3 Position { get; set; }
		Vector3 Forward { get; }

		void Rotate(float x, float y, float z);
	}
}
