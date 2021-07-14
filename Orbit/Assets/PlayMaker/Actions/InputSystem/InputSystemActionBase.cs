using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
    public abstract class InputSystemActionBase : InputSystemBase
    {
        [DisplayOrder(0)]
        [RequiredField]
        [Tooltip("The Input Asset Reference")]
        public InputActionReference actionReference;

        protected InputAction action;

        public override void Reset()
        {
            base.Reset();
            actionReference = null;
            action = null;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            action = actionAsset.FindAction(actionReference.action.id);

            if (action == null)
            {
                FsmDebugUtility.Log("Could not find action " + actionReference.name);
                Finish();
                return;
            }

        }
    }
}
