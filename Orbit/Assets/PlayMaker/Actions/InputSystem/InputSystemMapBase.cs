using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	public abstract class InputSystemMapBase : InputSystemBase
	{
		[DisplayOrder(0)]
        [RequiredField]
		[Tooltip("The Input Map Name")]
		public FsmString actionMapName;

        protected InputActionMap actionMap;

		public override void Reset()
		{
			base.Reset();
			actionMapName = null;
            actionMap = null;
		}

		public override void OnEnter()
		{
			base.OnEnter();

			actionMap = actionAsset.FindActionMap(actionMapName.Value);

			if (actionMap == null)
            {
				FsmDebugUtility.Log("Could find action map " + actionMapName.Value);
				Finish();
				return;
            }
		}

	}
}
