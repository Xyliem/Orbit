using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Enables / Disables specific input action.")]
	public class InputSystemEnableAction : InputSystemActionBase
	{
		[RequiredField]
		[Tooltip("Enable or Disable the action?")]
		public FsmBool enable;

		public override void Reset()
		{
			base.Reset();
			enable = false;
		}

        public override void OnEnter()
        {
            base.OnEnter();
			if (enable.Value)
				action.Enable();
			else
				action.Disable();

			Finish();
        }

	}
}