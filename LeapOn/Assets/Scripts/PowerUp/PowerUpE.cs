using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpE : MonoBehaviour
{
    [SerializeField] GameObject powerUpParticles;


    private void OnEnable()
    {
        PowerUp.rotatePowerUpAction += PoUPEffects;
        PowerUp.jumpPowerUpAction += PoUPEffects;
        PowerUp.destroyBlackAction += PoUPEffects;
        PowerUp.increaseMultiplierAction += PoUPEffects;
        PowerUp.destroyInstantAction += PoUPEffects;
    }


    private void OnDisable()
    {
        PowerUp.rotatePowerUpAction -= PoUPEffects;
        PowerUp.jumpPowerUpAction -= PoUPEffects;
        PowerUp.destroyBlackAction -= PoUPEffects;
        PowerUp.increaseMultiplierAction -= PoUPEffects;
        PowerUp.destroyInstantAction -= PoUPEffects;
    }

    public void PoUPEffects()
    {
        ImpactEffect();
        Vibrate();
    }

    private void ImpactEffect()
    {
        GameObject explosion = Instantiate(powerUpParticles, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, .15f);
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate(long milliseconds = 100)
    {
        if (isAndroid())
            vibrator.Call("vibrate", milliseconds);
        else
            Handheld.Vibrate();
    }

    public static void Cancel()
    {
        if (isAndroid())
            vibrator.Call("cancel");
    }

    private static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
	return true;
#else
        return false;
#endif
    }

}
