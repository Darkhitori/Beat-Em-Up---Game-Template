//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/EnemyAI ")]
	[Tooltip("set an enemy tactic ")]
	public class BEU_SetEnemyTactic : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EnemyAI))] 
		public FsmOwnerDefault gameObject;
		
		public ENEMYTACTIC tactic;
		
		public FsmBool everyFrame;

		EnemyAI theScript;
		

		public override void Reset()
		{
			gameObject = null;
			tactic =  ENEMYTACTIC.ENGAGE;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<EnemyAI>();


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
			
			theScript.SetEnemyTactic(tactic); 
			
		}

	}
}