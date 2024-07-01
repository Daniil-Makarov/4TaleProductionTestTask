namespace Core.Services.StateMachine {
	public interface IState {
		public void Enter();
		public void Exit();
	}
}