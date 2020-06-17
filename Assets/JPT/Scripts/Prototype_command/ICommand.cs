namespace JPT.Prototype.Gameplay
{
	public enum CommandType
	{
		None,
		MoveRight,
		MoveLeft
	}
	
	public interface ICommand
	{
		CommandType CommandType { get; }
		void Execute(IActor actor);
		void Undo(IActor actor);
	}
}
