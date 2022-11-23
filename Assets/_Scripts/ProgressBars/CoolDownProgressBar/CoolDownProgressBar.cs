using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image imgFiller;

    private void SetValue(float valueNormalized)
    {
        this.imgFiller.fillAmount = valueNormalized;
    }
}
