//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerMovement ")]
	[Tooltip("player is grounded ")]
	public class BEU_PM_playerIsGrounded : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerMovement))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		public FsmBool isGrounded;
		
		public FsmBool everyFrame;

		PlayerMovement theScript;
  

		public override void Reset()
		{
			gameObject = null;
			isGrounded = false;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<PlayerMovement>();


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

			isGrounded.Value = theScript.playerIsGrounded(); 
			
		}

	}
}