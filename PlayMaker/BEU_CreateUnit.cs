//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/Enemy ")]
	[Tooltip("create event")]
	public class BEU_CreateUnit : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Enemy))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject g;
		
		public FsmBool everyFrame;

		Enemy theScript;
  

		public override void Reset()
		{
			gameObject = null;
			g = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<Enemy>();


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

			theScript.CreateUnit(g.Value); 
			
		}

	}
}