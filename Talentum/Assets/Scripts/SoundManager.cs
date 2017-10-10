using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Xml;

public class SoundManager : MonoBehaviour {



    public AudioSource fxAudio;

    public AudioSource musicAudio;
    public static SoundManager instance = null;
    private bool bossBattle = false;
    private bool bossBattleCall = false;
    private bool gameplay = false;
    ArrayList fxSoundList;
    ArrayList themeSounds;
    private bool loopInicial = false;
    private bool playing = false;
    private bool intro = false;


    // Use this for initialization
    void Awake () {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        fxSoundList = new ArrayList();
        themeSounds = new ArrayList();
        FillAudioClips();
        DontDestroyOnLoad(gameObject);

	}
	
    public void playfx(string nameOfFx)
    {
        foreach (AudioClip audio in fxSoundList)
        {
            if (audio.name.Equals(nameOfFx))
            {
                fxAudio.clip = audio;
                fxAudio.Play();
                break;
            }

        }

    }

    void playmusic(string name)
    {
        if (themeSounds.Contains(name))
        {
            foreach (AudioClip audio in themeSounds)
            {
                if (audio.name.Equals(name))
                {
                    musicAudio.clip = audio;
                    break;
                }
            }
            musicAudio.Play();
        }
        else Debug.Log("Audio inexistente");
        
    }
    void playAudio(AudioClip c)
    {
        fxAudio.clip = c;
        fxAudio.Play();

    }


    void FillAudioClips()
    {
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.Load(Application.dataPath + "/Scripts/music.xml");

        }
        catch (XmlException e)
        {
            throw new XmlException("Fallo en la lectura del fichero: ", e);
        }

        XmlNodeList nodos = doc.GetElementsByTagName("Nodos");

        XmlNodeList list = ((XmlElement)nodos[0]).GetElementsByTagName("fx");

        ArrayList auxiliar = new ArrayList();

        foreach (XmlElement nodo in list)
        {
            //El nombre del audio fx
            string nombre =
                nodo.GetAttribute("nombre");
            //Hit, attack, etc
            string tipo =
                nodo.GetAttribute("tipo");
            //De quien es
            string quien = nodo.GetAttribute("who");

            AudioClip newTrack = Resources.Load("Music/fx/"+nombre, typeof(AudioClip)) as AudioClip;
            // Dupla data = new Dupla(tipo,newTrack);

            if (newTrack == null)
                Debug.Log(nombre + " no cargado");
            else
            {
                fxSoundList.Add(newTrack);
                Debug.Log(newTrack);
            }   
            


        }

        XmlNodeList musicList = ((XmlElement)nodos[0]).GetElementsByTagName("music");
       // Debug.Log(musicList.Count+ " elementos");
        foreach (XmlElement nodo in musicList)
        {
            //El nombre del theme audio 
            string nombre =
                nodo.GetAttribute("nombre");
             AudioClip newTrack = Resources.Load("Music/"+nombre, typeof(AudioClip)) as AudioClip;
            if(newTrack != null)
            {
                themeSounds.Add(newTrack);
            }
           

        }
    }


    // Update is called once per frame
    void Update () {

        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("MainMenu")))
        {
            musicAudio.loop = false;
            if (!musicAudio.isPlaying)
            {
                musicAudio.Stop();
                foreach (AudioClip audio in themeSounds)
                {
                    if (audio.name.Equals("Intro Loop Inicial") && !intro)
                    {
                        intro = true;
                        playing = true;
                        musicAudio.clip = audio;
                        musicAudio.Play();
                        break;
                    }
                    if (audio.name.Equals("Intro Loop Main"))
                    {
                        intro = true;
                        playing = true;
                        musicAudio.clip = audio;
                        musicAudio.Play();
                        break;
                    }

                }
            }
            
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("pruebaProcedural")))
        {
            foreach (AudioClip audio in themeSounds)
            {
                if (audio.name.Equals("Intro Loop Inicial"))
                {
                    themeSounds.Remove(audio);
                    break;
                }
                if (audio.name.Equals("Intro Loop Main"))
                {
                    themeSounds.Remove(audio);
                    break;
                }

            }

            musicAudio.loop = false;

            if (!musicAudio.isPlaying || musicAudio.name.Equals("Intro Loop Inicial") || musicAudio.name.Equals("Intro Loop Main"))
            {
                musicAudio.Stop();
                foreach (AudioClip audio in themeSounds)
                {
                    int centinela = UnityEngine.Random.RandomRange(0, 4);
                    if (audio.name.Equals("Loop Inicial"))
                    {
                        loopInicial = true;
                        playing = true;
                        musicAudio.clip = audio;
                        musicAudio.Play();

                        themeSounds.Remove(audio);
                        break;
                    }
                    else if(!audio.name.Equals(musicAudio.clip.name) && centinela == 0)
                    {

                        musicAudio.clip = audio;
                        musicAudio.Play();
                        break;
                    }

                }
            }

           

        }
        

    }
}
