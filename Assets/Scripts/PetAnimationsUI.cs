using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimationsUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _panelCanvasGroup;
    [SerializeField] private float _panelCanvasGroupAlphaStart = 0.5f;
    [SerializeField] private float _panelCanvasGroupAlphaNormal = 1.0f;
    private PetAnimations petAnimations = null;

    private void Start()
    {
        StartValuesCanvasGroup();
    }

    public void NormalValuesCanvasGroup()
    {
        _panelCanvasGroup.interactable = true;
        _panelCanvasGroup.alpha = _panelCanvasGroupAlphaNormal;
    }
    private void StartValuesCanvasGroup()
    {
        _panelCanvasGroup.interactable = false;
        _panelCanvasGroup.alpha = _panelCanvasGroupAlphaStart;
    }
    private void GetPetAnimationsComponent()
    {
        if (petAnimations != null)
            return;
        petAnimations = FindObjectOfType<PetAnimations>();
    }

    public void SetAnimation(string nameAnim)
    {
        GetPetAnimationsComponent();
        petAnimations.SetTriggerParam(nameAnim);
    }
}
