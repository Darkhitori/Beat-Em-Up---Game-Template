//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerAnimator ")]
	[Tooltip("adds a small forward force ")]
	public class BEU_PA_AddForce : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerAnimator))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat force;
		
		public FsmBool everyFrame;

		PlayerAnimator theScript;
  

		public override void Reset()
		{
			gameObject = null;
			force = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<PlayerAnimator>();


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

			theScript.AddForce(force.Value); 
			
		}

	}
}