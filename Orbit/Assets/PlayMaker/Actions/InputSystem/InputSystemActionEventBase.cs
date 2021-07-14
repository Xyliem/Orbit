using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
    public abstract class InputSystemActionEventBase : InputSystemActionBase
    {
        public enum InputTriggerType { OnDown, OnHold, OnUp }
        protected abstract InputTriggerType TriggerType { get; }

        [Tooltip("The event to send on input triggered")]
        public FsmEvent sendEvent;

        protected bool actionRunning;

        public override void Reset()
        {
            base.Reset();
            sendEvent = null;
            actionRunning = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (TriggerType == InputTriggerType.OnDown && action.triggered ||
                TriggerType == InputTriggerType.OnHold && action.phase == InputActionPhase.Started ||
                TriggerType == InputTriggerType.OnUp && action.phase != InputActionPhase.Started && actionRunning)
                OnInputTriggered();

            actionRunning = action.phase == InputActionPhase.Started;
        }

        protected virtual void OnInputTriggered()
        {
            Fsm.Event(sendEvent);
            Finish();
        }
    }
}
