using Photon.Pun;
using StupidTemplate.Mods;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Classes
{
	internal class Button : MonoBehaviour
	{
		public string relatedText;

		public static float buttonCooldown = 0f;
		
		public void OnTriggerEnter(Collider collider)
		{
			if (Time.time > buttonCooldown && collider == buttonCollider && menu != null)
			{
                buttonCooldown = Time.time + 0.2f;
                GorillaTagger.Instance.StartVibration(rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);

                if (PhotonNetwork.InRoom)
                {
                    GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]{
                        hitSoundValues[hitSoundValue],
                        rightHanded,
                        0.4f
                    });
                    SafetyShit.RpcFlush();
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(hitSoundValues[hitSoundValue], rightHanded, 0.4f);
                }

                Toggle(relatedText);
            }
		}
	}
}
