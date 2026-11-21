# PCES AR - Augmented Reality Picture Exchange Communication System for Autism Therapy

![Unity Version](https://img.shields.io/badge/Unity-2022.3.38f1-blue.svg?style=for-the-badge&logo=unity)
![AR Framework](https://img.shields.io/badge/AR_SDK-PTC_Vuforia_Engine-orange.svg?style=for-the-badge)
![Gesture SDK](https://img.shields.io/badge/Touch-LeanTouch-yellow.svg?style=for-the-badge)
![Target Group](https://img.shields.io/badge/Target-Autism_Spectrum_%26_Speech_Delay-red.svg?style=for-the-badge)
![Platform](https://img.shields.io/badge/Platform-Android_APK-green.svg?style=for-the-badge&logo=android)
![Clinical Scope](https://img.shields.io/badge/Protocol-PECS_Phases_1_through_6-purple.svg?style=for-the-badge)

---

## 📖 1. Clinical Background & Therapeutic Value

### 1.1 The Challenge of Non-Verbal Autism Communication
Children diagnosed with **Autism Spectrum Disorder (ASD)**, severe expressive language impairments, or developmental speech delays often experience intense frustration due to their inability to vocalize needs, thoughts, and emotions. This communicative barrier frequently manifests as behavioral meltdowns, social withdrawal, and high dependency on caregivers.

To facilitate functional communication, speech therapists and special education professionals utilize the **Picture Exchange Communication System (PECS)**. In traditional PECS, a child physically hands laminated picture cards to a communication partner to request items. While highly effective, traditional paper PECS cards have distinct limitations:
1. **Passive & Non-Acoustic:** Paper cards produce no auditory feedback; the child does not hear the spoken word immediately upon exchange.
2. **Abstract Visuals:** Flat 2D drawings or photographs often fail to capture the sensory interest of children on the autism spectrum.
3. **Card Wear & Loss:** Physical cards tear, get lost, and require cumbersome binder management during therapeutic sessions.

### 1.2 The PCES AR Solution
**PCES AR** digitizes and elevates the clinical PECS methodology by infusing Augmented Reality and synthesized audio reinforcement. When an autistic child presents physical cards to a tablet or smartphone camera, the system recognizes the marker and immediately renders a vibrant, tactile 3D model of the item (e.g., an animated squishy toy, a plate of food, a pencil) while pronouncing the word with clear, positive vocal diction.

Most importantly, PCES AR implements **simultaneous multi-marker tracking**, enabling children to construct multi-card sentence strips in real time. Placing an *"I Want"* (*Saya Ingin*) card alongside an *"Item"* card triggers immediate composite sentence articulation, bridging the crucial gap between non-verbal symbolic exchange and verbal sentence formation.

---

## ⚙️ 2. Dual-Marker Sentence Strip Construction (`ARVoiceManager.cs`)

The heart of PCES AR's therapeutic logic is its multi-target tracking manager, which continuously evaluates active marker combinations:

```csharp
using System.Collections.Generic;
using UnityEngine;

public class ARVoiceManager : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Sentence Starter Clips")]
    public AudioClip clipSayaIngin;    // "Saya Mau..." (I Want)
    public AudioClip clipSayaMelihat;  // "Saya Melihat..." (I See)

    [Header("Item Audio Clips")]
    public AudioClip clipKerupukKulit;
    public AudioClip clipSquishy;
    public AudioClip clipBuku;
    public AudioClip clipGelas;

    public List<MarkerTrigger> activeMarkers = new List<MarkerTrigger>();

    public void MarkerFound(string markerName)
    {
        if (!activeMarkers.Exists(m => m.markerName == markerName))
        {
            activeMarkers.Add(new MarkerTrigger { markerName = markerName });
            EvaluateAndPlayCompositeSentence();
        }
    }

    public void MarkerLost(string markerName)
    {
        activeMarkers.RemoveAll(m => m.markerName == markerName);
    }

    void EvaluateAndPlayCompositeSentence()
    {
        bool hasWant = activeMarkers.Exists(m => m.markerName == "I_Want");
        bool hasSee  = activeMarkers.Exists(m => m.markerName == "I_See");

        // Phase 4: Sentence Strip Evaluation
        if (hasWant && activeMarkers.Exists(m => m.markerName == "Kerupuk_Kulit"))
        {
            audioSource.PlayOneShot(clipSayaIngin);
            // Sequenced audio playback for complete functional speech
        }
    }
}
```

---

## 📚 3. Clinical PECS Protocol: Phases 1 Through 6

PCES AR features 30+ dedicated scenes structured across all six canonical phases of PECS:

1. **Phase 1: How to Communicate (`Fase1.unity` to `Fase1_4.unity`)**
   - Children learn to initiate communication by picking up a single picture card and presenting it to receive the tangible item.
2. **Phase 2: Distance and Persistence (`Fase2.unity` to `Fase2_3.unity`)**
   - Training children to overcome physical distance to seek out their communication partner and AR tablet.
3. **Phase 3: Picture Discrimination (`Fase3.unity` to `Fase3_3.unity`)**
   - Children learn to discriminate between two or more cards: choosing a highly motivating item (e.g., toy/snack) versus a distractor or non-preferred object.
4. **Phase 4: Sentence Structure (`Fase4.unity` to `Fase4_3.unity`)**
   - Constructing multi-word sentences on a virtual sentence strip using *"I Want"* cards followed by the target item card.
5. **Phase 5: Answering Questions (`Fase5.unity` to `Fase5_3.unity`)**
   - Responding to verbal partner inquiries such as *"What do you want?"* using AR card prompts.
6. **Phase 6: Commenting (`Fase6.unity` to `Fase6_3.unity`)**
   - Expanding communication beyond requesting into social sharing using *"I See"* (*Saya Melihat*) and *"I Hear"* (*Saya Mendengar*) cards.

---

## 📂 4. 3D Model Catalog & Card Categories

- **Food & Nutrition:** Kerupuk kulit (`Kerupuk_Kulit.fbx`), Corn (*Jagung*), Drinking Glass, Plate.
- **Sensory & Calming Toys:** Squishy stress relief model (`squishy.glb`, `squisy.fbx`), Puzzle pieces, Lego blocks.
- **School & Daily Living:** Book (`Buku.blend`), Pencil, Eraser, Smartphone.
- **Sentence Synthesizers:** Physical cards for *"I WANT"* and *"I SEE"*.

---

## 🎥 5. Clinical Testing Proof & APK Deliverables
- **Live Clinical Video:** [PCES-Dokumentasi.mp4](file:///e:/Project/AR/PCES/PCES/Testing/PCES-Dokumentasi.mp4) (Demonstrating live therapeutic sessions with autistic children).
- **Compiled Android Builds:** Located in root `PCES/`:
  - **`PCES-Tes7.apk`** *(Final Production Testing Build)*
  - `PCES-Tes0.apk` through `PCES-Tes6.apk`
