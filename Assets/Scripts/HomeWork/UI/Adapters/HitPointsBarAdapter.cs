using System.Collections;
using UnityEngine;

namespace HomeWork
{
    public class HitPointsBarAdapter : MonoBehaviour
    {
        [SerializeField]
        private IntBehaviour _hitPoints;

        [SerializeField]
        private HitPointsBar _view;
        
        // temp _maxHitPoints
        private int _maxHitPoints = 10;

        private Coroutine hideCoroutine;

        private void Awake()
        {
            this.SetupBar();
        }

        private void OnEnable()
        {
            _hitPoints.OnValueChanged += this.UpdateBar;
        }

        private void OnDisable()
        {
            _hitPoints.OnValueChanged -= this.UpdateBar;
        }

        private void SetupBar()
        {
            this.ResetCoroutines();

            var hitPoints = _hitPoints.Value;
            var maxHitPoints = _maxHitPoints;
            
            var showBar = hitPoints > 0 && hitPoints < maxHitPoints;
            _view.SetVisible(showBar);
            _view.SetHitPoints(hitPoints, maxHitPoints);
        }

        private void UpdateBar(int hitPoints)
        {
            this.ResetCoroutines();

            var maxHitPoints = _maxHitPoints;
            
            _view.SetVisible(true);
            _view.SetHitPoints(hitPoints, maxHitPoints);

            if (hitPoints <= 0 || hitPoints == maxHitPoints)
            {
                this.hideCoroutine = this.StartCoroutine(this.HideWithDelay());
            }
        }
        
        private void ResetCoroutines()
        {
            if (this.hideCoroutine != null)
            {
                this.StopCoroutine(this.hideCoroutine);
                this.hideCoroutine = null;
            }
        }

        private IEnumerator HideWithDelay()
        {
            yield return new WaitForSeconds(1.0f);
            _view.SetVisible(false);
            this.hideCoroutine = null;
        }
    }
}