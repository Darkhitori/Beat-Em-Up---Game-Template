//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/ItemInteractable ")]
	[Tooltip("activates this item ")]
	public class BEU_ActivateItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(ItemInteractable))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject target;
		
		public FsmBool everyFrame;

		ItemInteractable theScript;
  

		public override void Reset()
		{
			gameObject = null;
			target = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<ItemInteractable>();


			if (!everyFrame.Value)
			{
				DoTheMethod();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMethod();
			}
		}

		void DoTheMethod()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.ActivateItem(target.Value); 
			
		}

	}
}