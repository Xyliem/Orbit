using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Enables / Disables specific input map.")]
	public class InputSystemEnableMap : InputSystemMapBase
	{
		[RequiredField]
		[Tooltip("Enable or Disable the map?")]
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
				actionMap.Enable();
			else
				actionMap.Disable();

			Finish();
        }

	}
}