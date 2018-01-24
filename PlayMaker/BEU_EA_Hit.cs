//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/EnemyAnimator ")]
	[Tooltip(" ")]
	public class BEU_EA_Hit : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EnemyAnimator))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool everyFrame;

		EnemyAnimator theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<EnemyAnimator>();


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

			theScript.Hit(); 
			
		}

	}
}