using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Reads input from Input System and sends an event when performed. Ex. On Input Down")]
    public class InputSystemPerformedEvent : InputSystemActionEventBase
    {
        protected override InputTriggerType TriggerType => InputTriggerType.OnDown;
    }
}