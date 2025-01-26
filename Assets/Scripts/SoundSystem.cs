using UnityEngine;
using Hellmade.Sound;


namespace GGJ2025
{
	public class SoundSystem : MonoBehaviour
	{

		public AudioClip music;

		private void Start() {
			EazySoundManager.PlayMusic(music, 1, true, true);
		}
	}
}