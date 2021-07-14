using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Reads input from Input System and stores triggered as bool.")]
	public class InputSystemTriggeredValue : InputSystemActionBase
	{
        [RequiredField]
        [UIHint(UIHint.Variable)]
		[Tooltip("store the input value")]
		public FsmBool storeValue;

		public override void Reset()
		{
			base.Reset();
			storeValue = null;
		}

		public override void OnUpdate()
		{
			if (action != null)
			{
				storeValue.Value = action.triggered;
			}
		}

	}
}