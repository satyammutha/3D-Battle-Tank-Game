using IDamagableNS;
using System.Collections;
using UnityEngine;
namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }

        public LayerMask m_TankMask;
        public ParticleSystem m_ExplosionParticles;
        public AudioSource m_ExplosionAudio;
        public float m_MaxDamage = 100f;
        public float m_ExplosionForce = 1000f;
        public float m_MaxLifeTime = 2f;
        public float m_ExplosionRadius = 5f;
        public Coroutine destroy;
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
        private void Start()
        {
            Destroy(this.gameObject, 2f);
            if (destroy == null)
                destroy = StartCoroutine(DestroyAfterSomeTime());
        }
        private void FixedUpdate()
        {
            bulletController.Movement();
        }
        public void DestroyView()
        {
            bulletController = null;
            if (destroy != null)
            {
                StopCoroutine(destroy);
                destroy = null;
            }

            Destroy(this.gameObject);
        }
        private IEnumerator DestroyAfterSomeTime()
        {
            yield return new WaitForSeconds(5f);
            BulletService.GetInstance().DestroyBullet(bulletController);
        }
        private void OnTriggerEnter(Collider other)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidBody = colliders[i].GetComponent<Rigidbody>();
                if (!targetRigidBody)
                {
                    continue;
                }
                targetRigidBody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            }
            m_ExplosionParticles.transform.parent = null;
            m_ExplosionParticles.Play();
            m_ExplosionAudio.Play();
            Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
            IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(bulletController.bulletModel.damage);
                Debug.Log("Bullet and Enemy Collides");
            }
            BulletService.GetInstance().DestroyBullet(bulletController);
            Destroy(gameObject);
        }
    }
}