//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/PlayerCombat ")]
	[Tooltip("player knockDown coroutine ")]
	public class BEU_PC_KnockDown : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerCombat))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject inflictor;
		
		public FsmBool everyFrame;

		PlayerCombat theScript;
  

		public override void Reset()
		{
			gameObject = null;
			inflictor = null;
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

			theScript.KnockDown(inflictor.Value); 
			
		}

	}
}