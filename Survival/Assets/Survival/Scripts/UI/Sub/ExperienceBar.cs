using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : Singleton<ExperienceBar>
{
    [SerializeField] private Image experienceBar;
    [SerializeField] private FloatEvent playerExperienceChangeEvent;
    
    public float PlayerExperience { get; set; }
    public float PlayerMaxExperience { get; set; }
    private void Awake()
    {
        playerExperienceChangeEvent.Register(UpdateExperienceBar);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        playerExperienceChangeEvent.Unregister(UpdateExperienceBar);
    }

    private void UpdateExperienceBar(float value)
    {
        if(PlayerMaxExperience <= 0) return;
        PlayerExperience += value;
        experienceBar.fillAmount = PlayerExperience / PlayerMaxExperience;
    }
}
