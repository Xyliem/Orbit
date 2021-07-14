using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Begins a rebinding process for a specific action. Event gets triggered once a new valid key is pressed.")]
	public class InputSystemRebindAction : InputSystemActionBase
	{
        [Tooltip("Disable action before rebind process? Actions need to be disabled before rebinding")]
        public FsmBool disableAction;

        [UIHint(UIHint.Variable)]
        [Tooltip("Event to send after rebinding is finished")]
        public FsmString storeRebindName;

        [RequiredField]
		[Tooltip("Event to send after rebinding is finished")]
		public FsmEvent onRebindCompleted;

        private InputActionRebindingExtensions.RebindingOperation rebindOperation;
        private bool rebindCompleted;

        public override void Reset()
		{
			base.Reset();
            disableAction = false;
            storeRebindName = null;
            onRebindCompleted = null;
            rebindOperation = null;
            rebindCompleted = false;
		}

        public override void OnEnter()
        {
            base.OnEnter();
            StartRebindProcess();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            CheckRebindCompleted();
        }

        private void StartRebindProcess()
        {
            if (disableAction.Value)
                action.Disable();

            rebindOperation = action.PerformInteractiveRebinding()
                .WithControlsExcluding("<Mouse>/position")
                .WithControlsExcluding("<Mouse>/delta")
                .WithControlsExcluding("<Gamepad>/Start")
                .WithControlsExcluding("<Keyboard>/p")
                .WithControlsExcluding("<Keyboard>/escape")
                .OnMatchWaitForAnother(0.1f)
                .OnApplyBinding((operation, name) => RebindCompleted(name));

            rebindOperation.Start();
        }

        private void RebindCompleted(string bindingName)
        {
            rebindCompleted = true;
            storeRebindName.Value = InputControlPath.ToHumanReadableString(bindingName);
        }

        private void CheckRebindCompleted()
        {
            if (!rebindCompleted) return;

            rebindOperation.Dispose();
            rebindOperation = null;

            if (onRebindCompleted != null)
                Fsm.Event(onRebindCompleted);
        }
    }
}