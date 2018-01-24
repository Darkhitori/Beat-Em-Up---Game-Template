//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/CameraFollow ")]
	[Tooltip("sets the clamped camera view to the next wave position ")]
	public class BEU_SetNewClampPosition : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(CameraFollow))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector2 pos;
		public FsmFloat lerpTime;

		public FsmBool everyFrame;

		CameraFollow theScript;
  

		public override void Reset()
		{
			gameObject = null;
			pos = new Vector2(0,0);
			lerpTime = null;
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<CameraFollow>();


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

			theScript.SetNewClampPosition(pos.Value, lerpTime.Value); 
			
		}

	}
}