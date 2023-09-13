using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 100;
    [SerializeField] private bool _broken;
    [SerializeField] private ParticleSystem _explosionParticleSystem;
    [SerializeField] private AudioSource _audioSource; // AudioSource 컴포넌트 추가

    public AudioClip collisionSound; // 충돌 사운드 클립

    void OnCollisionEnter(Collision collision)
    {
        if (_broken) return;
        if (collision.relativeVelocity.magnitude >= _breakForce)
        {
            _broken = true;

            if (_explosionParticleSystem != null)
            {
                _explosionParticleSystem.Play();
            }

            // 충돌 사운드 재생
            if (_audioSource != null && collisionSound != null)
            {
                _audioSource.clip = collisionSound;
                _audioSource.Play();
            }

            var replacement = Instantiate(_replacement, transform.position, transform.rotation);

            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collisionMultiplier, collision.contacts[0].point, 2);
            }

            Destroy(gameObject);
        }
    }
}
