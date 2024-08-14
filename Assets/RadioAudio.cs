using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace CustomRadioMod
{   
    public class RadioAudio : Radio_Playlist
    {
        private const string MODPATH = "../Mods/Radio7DTD/Audio";
        public List<AudioClip> playlist = new List<AudioClip>();
        private int currentTrackIndex = 0;
        private bool isRadioOn = false;


        // Start is called before the first frame update
        [System.Obsolete]
        void Start()
        {
            LoadAudioFiles(MODPATH);
        }

        /*
        * 
        *
        */
        public string GetCurrentTrackName()
        {
            if (playlist.Count > 0)
            {
                return playlist[currentTrackIndex].name;
            }
            return "No Track";
        }

        /*
        * 
        *
        */
        public void NextTrack()
        {
            if (playlist.Count == 0) return;
            currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
            audioSource.clip = playlist[currentTrackIndex];
            if (isRadioOn) audioSource.Play();
        }

        /*
         * 
         *
         */
        public void PreviousTrack()
        {
            if (playlist.Count == 0) return;
            currentTrackIndex = (currentTrackIndex - 1 + playlist.Count) % playlist.Count;
            audioSource.clip = playlist[currentTrackIndex];
            if (isRadioOn) audioSource.Play();
        }

        /*
         * 
         *
         */
        [System.Obsolete]
        void LoadAudioFiles(string folderPath)
        {
            string fullPath = Path.Combine(Application.dataPath, folderPath);
            if (Directory.Exists(fullPath))
            {
                string[] audioFiles = Directory.GetFiles(fullPath, "*.ogg");
                foreach (string file in audioFiles)
                {
                    StartCoroutine(LoadAudioClip(file));
                }

                audioFiles = Directory.GetFiles(fullPath, "*.mp3");
                foreach (string file in audioFiles)
                {
                    StartCoroutine(LoadAudioClip(file));
                }
            }
            else
            {
                Debug.LogError("Audio folder not found: " + fullPath);
            }
        }



        /*
        * 
        *
        */
        [System.Obsolete]
        IEnumerator LoadAudioClip(string filePath)
        {
            string url = "file:///" + filePath;
            using (WWW www = new WWW(url))
            {
                yield return www;
                if (www.error == null)
                {
                    AudioClip clip = www.GetAudioClip(false, true);
                    clip.name = Path.GetFileName(filePath);
                    playlist.Add(clip);
                }
                else
                {
                    Debug.LogError("Error loading audio file: " + www.error);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
