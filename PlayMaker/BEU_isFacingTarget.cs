//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerCombat ")]
	[Tooltip("returns true is the player is facing the enemy ")]
	public class BEU_isFacingTarget : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerCombat))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject g;
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool isFacingTarget;
		
		public FsmBool everyFrame;

		PlayerCombat theScript;
  

		public override void Reset()
		{
			gameObject = null;
			g = null;
			isFacingTarget = false;
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

			isFacingTarget.Value = theScript.isFacingTarget(g.Value); 
			
		}

	}
}