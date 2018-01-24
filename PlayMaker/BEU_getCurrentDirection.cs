//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/EnemyActions ")]
	[Tooltip("returns the current direction ")]
	public class BEU_getCurrentDirection : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EnemyActions))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		public DIRECTION direction;
		
		public FsmBool everyFrame;

		EnemyActions theScript;
  

		public override void Reset()
		{
			gameObject = null;
			direction = DIRECTION.Left;
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

			direction = theScript.getCurrentDirection(); 
			
		}

	}
}