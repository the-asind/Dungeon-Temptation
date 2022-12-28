using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthProgressBar : MonoBehaviour
{
    [SerializeField] private Image imgFiller;

    public void SetValue(float valueNormalized)
    {
        this.imgFiller.fillAmount = valueNormalized;
    }
}
