using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
 
[RequireComponent(typeof(AudioSource))]

public class PitchTracker : MonoBehaviour
{
 
    public float squareRootValue;
    public float decibelValue;
    public float pitch;
    public int Samples = 8192;
    public int bin = 8192;
 
 
    private List<Peak> peaks = new List<Peak>();
    float[] samples;
    float[] spectrum;
    int samplerate;
 
    public Text display; // to show values on screen this needs a text field from the canvas
    public bool mute = true;
    public AudioMixer masterMixer; // audio mixer goes here
 
 
    void Start()
    {
        samples = new float[Samples];
        spectrum = new float[bin];
        samplerate = AudioSettings.outputSampleRate;
 
        // microphone start, and attachment if to to audio source
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, samplerate);
        GetComponent<AudioSource>().loop = true; // make audioclip loop
        while (!(Microphone.GetPosition(null) > 0)) { } // wait for recording to start
        GetComponent<AudioSource>().Play();
 
        // mutes the mixer so this wont play sounds
        masterMixer.SetFloat("masterVolume", -80f);
    }
 
    void Update()
    {
        AnalyzeSound();
        if (display != null)
        {
            display.text = "RMS: " + squareRootValue.ToString("F2") +
                " (" + decibelValue.ToString("F1") + " dB)\n" +
                "Pitch: " + pitch.ToString("F0") + " Hz";
        }
    }
 
    void AnalyzeSound()
    {
        float[] samples = new float[Samples];
        GetComponent<AudioSource>().GetOutputData(samples, 0); // fill the array with samples from the mic
        int i = 0;
        float sum = 0f;
        for (i = 0; i < Samples; i++)
        {
            sum += samples[i] * samples[i]; // sum the samples
        }
        squareRootValue = Mathf.Sqrt(sum / Samples);
        decibelValue = 20 * Mathf.Log10(squareRootValue / 0.1f); // decibel calculation
        if (decibelValue < -160) decibelValue = -160; // if the decibel value is less then -160 make it -160
 
        // get the sound spectrum
        GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0f;
        for (i = 0; i < bin; i++)
        { // find the maximum value
            if (spectrum[i] > maxV && spectrum[i] > 0.01f)
            {
                peaks.Add(new Peak(spectrum[i], i));
                if (peaks.Count > 5)
                { // get the 5 highest peaks from the samples
                    peaks.Sort(new AmpComparer()); // sort the 5 peaks from high to low
                }
            }
        }
        float freqN = 0f;
        if (peaks.Count > 0)
        {
            maxV = peaks[0].amplitude;
            int maxN = peaks[0].index;
            freqN = maxN; // pass the index to a float variable
            if (maxN > 0 && maxN < bin - 1)
            { // interpolate index using neighbours
                var dL = spectrum[maxN - 1] / spectrum[maxN];
                var dR = spectrum[maxN + 1] / spectrum[maxN];
                freqN += 0.5f * (dR * dR - dL * dL);
            }
        }
        pitch = freqN * (samplerate / 2f) / bin; // convert index to frequency
        peaks.Clear();
    }
}

// Class for peak
class Peak
{
    public float amplitude;
    public int index;
 
    public Peak()
    {
        amplitude = 0f;
        index = -1;
    }
 
    public Peak(float _frequency, int _index)
    {
        amplitude = _frequency;
        index = _index;
    }
}

// Class for AmpComparer
class AmpComparer : IComparer<Peak>
{
    public int Compare(Peak a, Peak b)
    {
        return 0 - a.amplitude.CompareTo(b.amplitude);
    }
}

// Class for IndexComparer 
class IndexComparer : IComparer<Peak>
{
    public int Compare(Peak a, Peak b)
    {
        return a.index.CompareTo(b.index);
    }
}