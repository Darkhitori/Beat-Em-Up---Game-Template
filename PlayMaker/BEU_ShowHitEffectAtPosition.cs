//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/EnemyActions ")]
	[Tooltip("show hit effect ")]
	public class BEU_ShowHitEffectAtPosition : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EnemyActions))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 pos;
		
		public FsmBool everyFrame;

		EnemyActions theScript;
  

		public override void Reset()
		{
			gameObject = null;
			pos = new Vector3(0,0,0);
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

			theScript.ShowHitEffectAtPosition(pos.Value); 
			
		}

	}
}