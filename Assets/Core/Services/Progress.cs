namespace Core.Services {
	public class Progress {
		public int CurrentRoom { get; private set; } = 1;
		public int CurrentRoomIndex => CurrentRoom - 1;
		
		public void MoveToNextRoom() => CurrentRoom++;
		public void Reset() => CurrentRoom = 1;
	}
}