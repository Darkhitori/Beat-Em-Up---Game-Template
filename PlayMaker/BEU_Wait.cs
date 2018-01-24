//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/EnemyActions ")]
	[Tooltip("wait for an x number of seconds ")]
	public class BEU_Wait : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EnemyActions))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat delay;
		
		public FsmBool everyFrame;

		EnemyActions theScript;
  

		public override void Reset()
		{
			gameObject = null;
			delay = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<EnemyActions>();


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

			theScript.Wait(delay.Value); 
			
		}

	}
}