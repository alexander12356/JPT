namespace JPT.Prototype.Gameplay
{
	public abstract class Command : ICommand
	{
		public CommandType CommandType { get; protected set; }

		protected Command()
		{
			SetCommandType();
		}

		public abstract void Execute(IActor actor);

		public abstract void Undo(IActor actor);

		protected abstract void SetCommandType();
	}
}