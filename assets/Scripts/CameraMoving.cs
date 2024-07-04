using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private static CameraMoving instance;
    public Transform target;
    public float offsetX;
    public float smoothTime;

    private Vector3 currentVelocity;

    public static bool alsoFollowY = true; // active ça si tu veux que la caméra suive le joueur en Y

    public static CameraMoving get {
        get => instance;
    }

    private void Start() {
        instance = this;
        Application.targetFrameRate = 60;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculer la position cible en ajoutant l'offset � la position du joueur
            Vector3 targetPosition = target.position + offsetX * Vector3.right;

            // Appliquer un effet d'amortissement pour un mouvement fluide
            Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

            // Mettre � jour la position de la cam�ra en conservant l'offset en Y
            transform.position = new Vector3(newPosition.x, alsoFollowY ? newPosition.y : transform.position.y, transform.position.z);
        }
    }
}
