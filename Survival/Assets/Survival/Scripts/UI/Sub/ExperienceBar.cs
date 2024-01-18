using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : Singleton<ExperienceBar>
{
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent menuEvent;
    [SerializeField] private Image experienceBar;
    [SerializeField] private FloatEvent playerExperienceChangeEvent;
    
    public float PlayerExperience { get; set; }
    public float PlayerMaxExperience { get; set; }
    private void Awake()
    {
        playerExperienceChangeEvent.Register(UpdateExperienceBar);
        startGameEvent.Register(ShowExperienceBar);
        menuEvent.Register(HideExperienceBar);
        
        gameObject.SetActive(false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        playerExperienceChangeEvent.Unregister(UpdateExperienceBar);
        startGameEvent.Register(ShowExperienceBar);
        menuEvent.Register(HideExperienceBar);
    }

    private void ShowExperienceBar() => gameObject.SetActive(true);
    private void HideExperienceBar() => gameObject.SetActive(false);

    private void UpdateExperienceBar(float value)
    {
        if(PlayerMaxExperience <= 0) return;
        PlayerExperience += value;
        experienceBar.fillAmount = PlayerExperience / PlayerMaxExperience;
    }
}
