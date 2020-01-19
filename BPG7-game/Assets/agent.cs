using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected float currentHealth { get; set; }
    [Header("shooting related")]
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float recoil;
    protected Rigidbody2D rb;
    protected Camera mainCam;
    [Header("audio related prop.")]
    [SerializeField] protected AudioClip shootSound;
    [SerializeField] protected float basePitch;
    [SerializeField] protected float PitchDiviation;
    [SerializeField] protected AudioClip DeathSound;
    protected AudioSource sound;
    void Awake()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        sound = gameObject.AddComponent<AudioSource>();
        sound.clip = shootSound;
        sound.playOnAwake = false;
        currentHealth = maxHealth;
    }
    protected void look(Vector2 position)
    {
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, position - (Vector2)transform.position));
    }
    public virtual void Shoot(Transform gunpoint)
    {
        Instantiate(bulletPrefab, gunpoint.position, transform.rotation);
        rb.AddForce(-transform.up * recoil * 10, ForceMode2D.Force);

        sound.pitch = basePitch + Random.Range(-PitchDiviation, PitchDiviation);
        sound.Play();
    }
    public virtual void Shoot(List<Transform> gunpoints) => Shoot(gunpoints.ToArray());
    public virtual void Shoot(Transform[] gunpoints)
    {
        foreach (var gunpoint in gunpoints)
        {
            Instantiate(bulletPrefab, gunpoint.position, transform.rotation);
        }

        rb.AddForce(-transform.up * recoil * 10, ForceMode2D.Force);
        sound.pitch = basePitch + Random.Range(-PitchDiviation, PitchDiviation);
        sound.Play();
    }
    public virtual void TakeDamage() => TakeDamage(1);
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }
    public virtual void Die()
    {
        Debug.Log("[agent.cs] im dead , from the base class");
        sound.clip = DeathSound;
        sound.pitch = 1f;
        sound.Play();
    }
}
