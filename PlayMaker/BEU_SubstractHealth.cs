//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/HealthSystem ")]
	[Tooltip("substract health ")]
	public class BEU_SubstractHealth : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(HealthSystem))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt damage;
		
		public FsmBool everyFrame;

		HealthSystem theScript;
  

		public override void Reset()
		{
			gameObject = null;
			damage = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<HealthSystem>();


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

			theScript.SubstractHealth(damage.Value); 
			
		}

	}
}