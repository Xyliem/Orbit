using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
    public abstract class InputSystemActionReadValueBase<T> : InputSystemActionBase
        where T : NamedVariable
    {
        [Tooltip("The stored value.")]
        public T storeValue;

        [Tooltip("Perform this action every frame.")]
        public bool everyFrame;

        public override void Reset()
        {
            base.Reset();
            storeValue = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (!everyFrame)
            {
                ReadValue();
                Finish();
            }
        }

        public override void OnUpdate()
        {
            if (everyFrame)
                ReadValue();
        }

        protected abstract void ReadValue();
    }
}
