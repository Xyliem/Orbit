using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Reads input from Input System and stores it as a variable.")]
    public class InputSystemReadBoolValue : InputSystemActionReadValueBase<FsmBool>
    {
        private bool down;
        private bool up;
        private bool running;

        public override void Reset()
        {
            base.Reset();
            down = false;
            up = false;
            running = false;
        }

        protected override void ReadValue()
        {
            down = action.triggered;
            up = action.phase != InputActionPhase.Started && running;
            running = action.phase == InputActionPhase.Started;

            if (down)
                storeValue.Value = true;              
            else if (up)
                storeValue.Value = false;
        }
    }
}