using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Reads input from Input System and stores it as a variable.")]
	public class InputSystemReadVector2Value : InputSystemActionReadValueBase<FsmVector2>
	{
        protected override void ReadValue()
        {
            storeValue.Value = action.ReadValue<Vector2>();
        }
    }
}