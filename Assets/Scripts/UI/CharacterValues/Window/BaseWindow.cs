using DSA.Character.Value.Calculation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWindow : MonoBehaviour
{
    private List<ModifierInfo> calculationSteps;

    private void Awake()
    {
        calculationSteps = new List<ModifierInfo>();

        Hide();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void AddCalculationStep(ModifierInfo calculationInfo)
    {
        calculationSteps.Add(calculationInfo);
    }

    public void UpdateWindow()
    {

    }

    public void Clear()
    {

    }
}
