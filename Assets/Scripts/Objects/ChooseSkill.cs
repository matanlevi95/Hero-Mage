using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSkill : MonoBehaviour
{
    [SerializeField] List<GameObject> skills;

    private void OnEnable()
    {
        Debug.Log("enable");
        List<GameObject> skillsToShow = GetThreeRandomSkills();
        foreach (var skill in skillsToShow)
        {
            Instantiate(skill, transform);
        }
    }

    private void OnDisable()
    {
        Debug.Log("disable");
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    

    List<GameObject> GetThreeRandomSkills()
    {
        List<GameObject> emptyList = new List<GameObject>();
        if (skills.Count == 0) return emptyList;
        List<GameObject> skillsToShow = emptyList;
        int numberOfSkillsToShow = skills.Count > 3 ? 3 : skills.Count;
        for (int i = 0; i < numberOfSkillsToShow; i++)
        {
            int val = Random.Range(0, skills.Count);
            while (skillsToShow.Contains(skills[val]))
            {
                val = Random.Range(0, skills.Count);
            }
            skillsToShow.Add(skills[val]);
        }
        return skillsToShow;
    }
}
