//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerCombat ")]
	[Tooltip("interact with an item in range ")]
	public class BEU_InteractWithItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerCombat))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool everyFrame;

		PlayerCombat theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<PlayerCombat>();


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

			theScript.InteractWithItem(); 
			
		}

	}
}