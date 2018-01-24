//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("BeatEmUp/AudioPlayer ")]
	[Tooltip(" ")]
	public class BEU_playMusic : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(AudioPlayer))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString name;

		public FsmBool everyFrame;

		AudioPlayer theScript;
  

		public override void Reset()
		{
			gameObject = null;
			name = "";
			everyFrame = false;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<AudioPlayer>();


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

			theScript.playMusic(name.Value); 
			
		}

	}
}