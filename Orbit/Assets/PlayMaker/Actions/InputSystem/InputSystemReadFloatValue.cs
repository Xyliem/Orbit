using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Reads input from Input System and stores it as a variable.")]
	public class InputSystemReadFloatValue : InputSystemActionReadValueBase<FsmFloat>
	{
        protected override void ReadValue()
        {
            storeValue.Value = action.ReadValue<float>();
        }
    }
}