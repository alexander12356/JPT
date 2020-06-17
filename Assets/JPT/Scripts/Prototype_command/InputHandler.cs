using System;
using System.Collections.Generic;

using UnityEngine;

namespace JPT.Prototype.Gameplay
{
	public class InputHandler : MonoBehaviour
	{
		private ICommand _moveRightCommand = null;
		private ICommand _moveLeftCommand = null;

		public Actor _actor = null;
		public List<CommandMemory> _commandMemoryList = null;
		
		private void Awake()
		{
			_moveRightCommand = new MoveRightCommand();
			_moveLeftCommand = new MoveLeftCommand();
			_commandMemoryList = new List<CommandMemory>();
		}

		private void Update()
		{
			ICommand command = null;
			if (Input.GetKey(KeyCode.D))
			{
				command = _moveRightCommand;
			}
			else if (Input.GetKey(KeyCode.A))
			{
				command = _moveLeftCommand;
			}
			else if (Input.GetKey(KeyCode.Z))
			{
				Undo();
			}

			if (command != null)
			{
				var commandMemory = new CommandMemory();
				commandMemory.Type = command.CommandType;
				_commandMemoryList.Add(commandMemory);
				command.Execute(_actor);
			}
		}

		private void Undo()
		{
			if (_commandMemoryList.Count == 0)
			{
				return;
			}

			var command = _commandMemoryList[_commandMemoryList.Count - 1];

			switch (command.Type)
			{
				case CommandType.None:
					break;
				case CommandType.MoveRight:
					_moveRightCommand.Undo(_actor);
					break;
				case CommandType.MoveLeft:
					_moveLeftCommand.Undo(_actor);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			_commandMemoryList.RemoveAt(_commandMemoryList.Count - 1);
		}
	}
}