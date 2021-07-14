using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Reads input from Input System and sends event when triggered.")]
	public class InputSystemTriggeredEvent : InputSystemActionBase
	{
		[Tooltip("The event to send on input triggered")]
		public FsmEvent sendEvent;

		[UIHint(UIHint.Variable)]
		[Tooltip("store the input value")]
		public FsmBool storeValue;

		public override void Reset()
		{
			base.Reset();
			sendEvent = null;
			storeValue = null;
		}

		public override void OnUpdate()
		{
			if (action != null)
			{
				storeValue.Value = action.triggered;
				if (action.triggered)
				{
					Fsm.Event(sendEvent);
					Finish();
				}	
			}
			
		}

	}
}