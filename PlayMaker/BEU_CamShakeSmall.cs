//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/CameraShake ")]
	[Tooltip("cam shake presets")]
	public class BEU_CamShakeSmall : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(CameraShake))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool everyFrame;

		CameraShake theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<CameraShake>();


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

			theScript.CamShakeSmall(); 
			
		}

	}
}