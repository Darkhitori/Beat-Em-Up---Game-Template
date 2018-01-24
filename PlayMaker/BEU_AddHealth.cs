//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/HealthSystem ")]
	[Tooltip("add health ")]
	public class BEU_AddHealth : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(HealthSystem))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt amount;
		
		public FsmBool everyFrame;

		HealthSystem theScript;
  

		public override void Reset()
		{
			gameObject = null;
			amount = null;
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

			theScript.AddHealth(amount.Value); 
			
		}

	}
}