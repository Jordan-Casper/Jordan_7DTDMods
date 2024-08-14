/* 
*
* Author: Jordan Casper 
* https://github.com/Jordan-Casper
*
*/
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace CustomRadioMod
{

    public class Radio_Playlist : MonoBehaviour
    {
        protected AudioSource audioSource;


        public void Awake()
        {
            GameObject customRadio = new GameObject("CustomRadio");
            audioSource = customRadio.AddComponent<AudioSource>();
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.maxDistance = 0.02f;
            audioSource.volume = 0.7f;
            audioSource.dopplerLevel = 0f;

        }





    }

}


