using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AwardsCountShow : MonoBehaviour
{
    [SerializeField] private TMP_Text _thingsText;
    [SerializeField] private TMP_Text _diamondsText;
    [SerializeField] private ThindsCollector _thingsCollector;
    [SerializeField] private DiamondsCollector _diamondsCollector;

    private void OnEnable()
    {
        _thingsCollector.ThingTaken += OnThingTaken;
        _diamondsCollector.DiamondTaken += OnDimondTaken;
    }

    private void Start()
    {
        _thingsText.text = _thingsCollector.Count.ToString();
        _diamondsText.text = _diamondsCollector.Count.ToString();
    }

    private void OnDisable()
    {
        _thingsCollector.ThingTaken -= OnThingTaken;
        _diamondsCollector.DiamondTaken -= OnDimondTaken;
    }

    private void OnThingTaken()
    {
        _thingsText.text = _thingsCollector.Count.ToString();
    }

    private void OnDimondTaken()
    {
        _diamondsText.text = _diamondsCollector.Count.ToString();
    }

}
