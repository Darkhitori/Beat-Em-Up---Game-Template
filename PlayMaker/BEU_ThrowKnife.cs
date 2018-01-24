//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/ThrowingKnife ")]
	[Tooltip(" ")]
	public class BEU_ThrowKnife : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(ThrowingKnife))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt direction;
		
		public FsmBool everyFrame;

		ThrowingKnife theScript;
  

		public override void Reset()
		{
			gameObject = null;
			direction = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<ThrowingKnife>();


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

			theScript.ThrowKnife(direction.Value); 
			
		}

	}
}