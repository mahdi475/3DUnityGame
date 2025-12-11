using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[ExecuteAlways]
[RequireComponent(typeof(VisualEffect))]
public class PlayFireWorkAudio : VFXOutputEventAbstractHandler
{
    public override bool canExecuteInEditor => true;
    public AudioSource audioSourceExplosion;
    public AudioSource audioBeforeExplosion;

    public override void OnVFXOutputEvent(VFXEventAttribute eventAttribute)
    {
        if (audioSourceExplosion != null)
        {
            audioSourceExplosion.Play();
        }

        if (audioBeforeExplosion != null)
        {
            audioBeforeExplosion.Play();
        }
    } 
}
