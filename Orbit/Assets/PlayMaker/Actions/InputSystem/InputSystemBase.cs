using UnityEngine.InputSystem;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

namespace Digitom.PlayMakerInputSystemActions.RunTime
{
	public abstract class InputSystemBase : FsmStateAction
	{
		public enum InputType { PlayerInput, InputAsset }

		[DisplayOrder(0)]
		[Tooltip("The source of input")]
		public InputType inputSource;

		[DisplayOrder(1)]
		[HideIf(nameof(InputSourceIsInputAsset))]
		[Tooltip("The Player Input Component.")]
		public FsmOwnerDefault playerInput;

		[DisplayOrder(1)]
		[HideIf(nameof(InputSourceIsPlayerInput))]
		[Tooltip("The Player Input Component.")]
		public InputActionAsset inputAsset;

		protected InputActionAsset actionAsset;

		public bool InputSourceIsPlayerInput() => inputSource == InputType.PlayerInput;
		public bool InputSourceIsInputAsset() => inputSource == InputType.InputAsset;

		public override void Reset()
		{
			inputSource = default;
			playerInput = null;
			actionAsset = null;
			inputAsset = null;
		}

		public override void OnEnter()
		{
			// get the animator component
			var go = Fsm.GetOwnerDefaultTarget(playerInput);

			if (go == null)
			{
				Finish();
				return;
			}

			if (inputSource == InputType.PlayerInput && !go.GetComponent<PlayerInput>())
            {
				Debug.LogError($"{go} must have a {typeof(PlayerInput)} component!");
            }

			actionAsset = inputSource == InputType.PlayerInput ? go.GetComponent<PlayerInput>().actions : inputAsset;
		}

	}
}
