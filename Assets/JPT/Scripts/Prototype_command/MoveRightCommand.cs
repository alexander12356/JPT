using System;

namespace JPT.Prototype.Gameplay
{
	public class MoveRightCommand : Command
	{
		public override void Execute(IActor actor)
		{
			actor.Move(5);
		}

		public override void Undo(IActor actor)
		{
			actor.Move(-5);
		}

		protected override void SetCommandType()
		{
			CommandType = CommandType.MoveRight;
		}
	}
}