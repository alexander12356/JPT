using UnityEngine;

namespace JPT.Prototype.Gameplay
{
	public class Actor : MonoBehaviour, IActor
	{
		public void Move(int i)
		{
			var transform1 = transform;
			var pos = transform1.localPosition;
			pos.x += i * Time.deltaTime;
			transform1.localPosition = pos;
		}
	}
}