//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerState ")]
	[Tooltip("decides the order of imporance of playerstates ")]
	public class BEU_SetState : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerState))] 
		public FsmOwnerDefault gameObject;
		
		public PLAYERSTATE state;
		
		public FsmBool everyFrame;

		PlayerState theScript;
		

		public override void Reset()
		{
			gameObject = null;
			state =  PLAYERSTATE.IDLE;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<PlayerState>();


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
			
			theScript.SetState(state); 
			
		}

	}
}