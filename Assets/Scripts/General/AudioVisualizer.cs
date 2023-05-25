using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioVisualizer : MonoBehaviour {
		
    public Transform[] audioSpectrumObjects;
    [Range(1, 100)] public float heightMultiplier;
    [Range(64, 8192)] public int numberOfSamples = 8820; //step by 2
    public FFTWindow fftWindow;
    public float lerpTime = 0.1f;
    public Slider sensitivitySlider;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    
    public int current;

    public GameObject PitchtrackerObject;
    private PitchTracker pitchTracker;
    
    /*
     * The intensity of the frequencies found between 0 and 44100 will be
     * grouped into 8820 elements. So each element will contain a range of about 5 Hz.
     * The average human voice spans from about 60 hz to 9k Hz.
    */
    
    void Awake()
    {
        pitchTracker = PitchtrackerObject.GetComponent<PitchTracker>();
    }
    
    void Start(){

        heightMultiplier = PlayerPrefsManager.GetSensitivity ();
    }

    void Update() {

        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            
            //Debug.Log(pitchTracker.pitch);

            if ( pitchTracker.pitch >= 16.35 && pitchTracker.pitch < 18.35 || pitchTracker.pitch >= 32.70 && pitchTracker.pitch < 36.71 || pitchTracker.pitch >= 65.41 && pitchTracker.pitch < 73.42 || pitchTracker.pitch >= 130.81 && pitchTracker.pitch < 146.83 || pitchTracker.pitch >= 261.63 && pitchTracker.pitch < 293.66 || pitchTracker.pitch >= 523.25 && pitchTracker.pitch < 587.33 || pitchTracker.pitch >= 1046.50 && pitchTracker.pitch < 1174.66 || pitchTracker.pitch >= 2093.00 && pitchTracker.pitch < 2349.32 || pitchTracker.pitch >= 4186.01 && pitchTracker.pitch < 4698.63)
            {
                // C note
                this.current = 1;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("C");
            }
            else  if ( pitchTracker.pitch >= 18.35  && pitchTracker.pitch < 19.45 || pitchTracker.pitch >= 36.71 && pitchTracker.pitch < 41.20 || pitchTracker.pitch >= 73.42 && pitchTracker.pitch < 82.41 || pitchTracker.pitch >= 146.83 && pitchTracker.pitch < 164.81 || pitchTracker.pitch >= 293.66 && pitchTracker.pitch < 329.63 || pitchTracker.pitch >= 587.33 && pitchTracker.pitch < 659.25 || pitchTracker.pitch >= 1174.66 && pitchTracker.pitch < 1318.51 || pitchTracker.pitch >= 2349.32 && pitchTracker.pitch < 2637.02 || pitchTracker.pitch >= 4698.63 && pitchTracker.pitch < 5274.04)
            { 
                // D note
                this.current = 2;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("D");
            }else  if (pitchTracker.pitch >= 19.45 && pitchTracker.pitch < 21.83 || pitchTracker.pitch >= 41.20 && pitchTracker.pitch < 43.65 || pitchTracker.pitch >= 82.41 && pitchTracker.pitch < 87.31 || pitchTracker.pitch >= 164.81 && pitchTracker.pitch < 174.61 || pitchTracker.pitch >= 329.63 && pitchTracker.pitch < 349.23 || pitchTracker.pitch >= 659.25 && pitchTracker.pitch < 698.46 || pitchTracker.pitch >= 1318.51 && pitchTracker.pitch < 1396.91 || pitchTracker.pitch >= 2637.02 && pitchTracker.pitch < 2793.83 || pitchTracker.pitch >= 5274.04 && pitchTracker.pitch < 5587.65)
            { 
                // E note
                this.current = 3;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("E");
            }
            else  if (pitchTracker.pitch >= 21.83 && pitchTracker.pitch < 24.50 || pitchTracker.pitch >= 43.65 && pitchTracker.pitch < 49.00 || pitchTracker.pitch >= 87.31 && pitchTracker.pitch < 98.00 || pitchTracker.pitch >= 174.61 && pitchTracker.pitch < 196.00 || pitchTracker.pitch >= 349.23 && pitchTracker.pitch < 392.00 || pitchTracker.pitch >= 698.46 && pitchTracker.pitch < 783.99 || pitchTracker.pitch >= 1396.91 && pitchTracker.pitch < 1567.98 || pitchTracker.pitch >= 2793.83 && pitchTracker.pitch < 3135.96 || pitchTracker.pitch >= 5587.65 && pitchTracker.pitch < 6271.93)
            {
                // F note
                this.current = 4;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("F");
            }
            else  if (pitchTracker.pitch >= 24.50 && pitchTracker.pitch < 27.50 || pitchTracker.pitch >= 49.00 && pitchTracker.pitch < 55.00 || pitchTracker.pitch >= 98.00 && pitchTracker.pitch < 110.00 || pitchTracker.pitch >= 196.00 && pitchTracker.pitch < 220.00 || pitchTracker.pitch >= 392.00 && pitchTracker.pitch < 440.00 || pitchTracker.pitch >= 783.99 && pitchTracker.pitch < 880.00 || pitchTracker.pitch >= 1567.98 && pitchTracker.pitch < 1760.00 || pitchTracker.pitch >= 3135.96 && pitchTracker.pitch < 3520.00 || pitchTracker.pitch >= 6271.93 && pitchTracker.pitch < 7040.00)
            {
                // G note
                this.current = 5;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("G");
            }
            else if (pitchTracker.pitch >= 27.50 && pitchTracker.pitch < 29.14 || pitchTracker.pitch >= 55.00 && pitchTracker.pitch < 61.74 || pitchTracker.pitch >= 110.00 && pitchTracker.pitch < 	123.47 || pitchTracker.pitch >= 220.00 && pitchTracker.pitch < 246.94 || pitchTracker.pitch >= 440.00 && pitchTracker.pitch < 493.88 || pitchTracker.pitch >= 880.00 && pitchTracker.pitch < 987.77 || pitchTracker.pitch >= 1760.00 && pitchTracker.pitch < 1975.53 || pitchTracker.pitch >= 3520.00 && pitchTracker.pitch < 3951.07 || pitchTracker.pitch >= 7040.00 && pitchTracker.pitch < 7902.13 )
            {
                // A note
                this.current = 6;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("A");
            }
            else  if (pitchTracker.pitch >= 29.14 && pitchTracker.pitch < 32.70 || pitchTracker.pitch >= 61.74 && pitchTracker.pitch < 65.41 || pitchTracker.pitch >= 123.47 && pitchTracker.pitch < 130.81 || pitchTracker.pitch >= 246.94 && pitchTracker.pitch < 261.63 || pitchTracker.pitch >= 493.88 && pitchTracker.pitch < 523.25 || pitchTracker.pitch >= 987.77 && pitchTracker.pitch < 1046.50 || pitchTracker.pitch >= 1975.53 && pitchTracker.pitch < 2093.00 || pitchTracker.pitch >= 3951.07 && pitchTracker.pitch < 4186.01 || pitchTracker.pitch >= 7902.13 && pitchTracker.pitch < 8800)
            {
                // B note
                this.current = 7;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("B");
            }
            else if (pitchTracker.pitch < 16.35 || pitchTracker.pitch >8800)
            {
                // these frequency are either too high or too low
                this.current = 1000;
                //Debug.Log("AudioVis" + current);
                //Debug.Log("None");
            }
        }
    }

    public void SensitivityValueChangedHandler(Slider sensitivitySlider){
    }
    

}


