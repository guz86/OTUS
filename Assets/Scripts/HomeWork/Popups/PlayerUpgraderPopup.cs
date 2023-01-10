using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWork
{
    public class PlayerUpgraderPopup : Popup
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        
        [SerializeField] private TextMeshProUGUI _descriptionText;

        [SerializeField] private Image _iconImage;
        
        [SerializeField] private TextMeshProUGUI _level;
        
        [SerializeField] private TextMeshProUGUI _hitPoints;
        [SerializeField] private TextMeshProUGUI _maxHitPoints;
        
        [SerializeField] private TextMeshProUGUI _manaPoints;
        
        [SerializeField] private TextMeshProUGUI _damage;
        
        [SerializeField] private UpgradeButton _buyButton;
        
        private IPlayerUpgraderPresentationModel _presenter;
    
    protected override void OnShow(object args)
    {
        if (args is not IPlayerUpgraderPresentationModel presenter)
        {
            throw new Exception("Expected Player Upgrader Presentation model!");
        }
            
        _presenter = presenter;
            
        _presenter.OnUpgradeButtonStateChanged += OnUpgradeChanged;
            
        _presenter.Start();
            
        _nameText.text = presenter.GetName();
        _descriptionText.text = presenter.GetDescription();
        _iconImage.sprite = presenter.GetIcon();
        _level.text = presenter.GetLevel();
        _hitPoints.text = presenter.GetHitPoints();
        _maxHitPoints.text = presenter.GetMaxPoints();
        _manaPoints.text = presenter.GetManaPoints();
        _damage.text = presenter.GetDamage();

        _buyButton.AddListener(OnUpgradeButtonClicked);
    }
    
    private void OnUpgradeChanged(bool isAvailabe)
    {
        _buyButton.SetAvailable(isAvailabe);
    }
    
    protected override void OnHide()
    {
        _buyButton.RemoveListener(OnUpgradeButtonClicked);
        _presenter.OnUpgradeButtonStateChanged -= OnUpgradeChanged;
        _presenter.Stop();
    }
    
    
    private void OnUpgradeButtonClicked()
    {
        _presenter.OnUpgradeClicked();
    }
    
    public interface IPlayerUpgraderPresentationModel
    {
        string GetName();
        void Start();
        void Stop();
        string GetDescription();
        Sprite GetIcon();
        string GetLevel();
        string GetHitPoints();
        string GetMaxPoints();
        string GetManaPoints();
        string GetDamage();
        void OnUpgradeClicked();
        event Action<bool> OnUpgradeButtonStateChanged;
    }
    
    }
}