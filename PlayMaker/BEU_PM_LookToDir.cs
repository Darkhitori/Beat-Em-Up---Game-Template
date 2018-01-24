//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerMovement ")]
	[Tooltip("look towards the movement direction (up and down are ignored because we don't want to update the left/right direction when going up/down) ")]
	public class BEU_PM_LookToDir : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerMovement))] 
		public FsmOwnerDefault gameObject;
		
		public DIRECTION dir;
		
		public FsmBool everyFrame;

		PlayerMovement theScript;
  

		public override void Reset()
		{
			gameObject = null;
			dir = DIRECTION.Right;
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

			theScript.LookToDir(dir); 
			
		}

	}
}