using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Reads input from Input System and sends an event when canceled. Ex. On Input Up")]
    public class InputSystemCanceledEvent : InputSystemActionEventBase
    {
        protected override InputTriggerType TriggerType => InputTriggerType.OnUp;
    }
}