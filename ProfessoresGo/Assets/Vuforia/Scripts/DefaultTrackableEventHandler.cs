/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using System;
using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }


        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {            
            try
            {
                AudioSource audioTeste = GetComponent<AudioSource>();
                audioTeste.Play();
            }
            catch (Exception ex)
            {
                Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
                Debug.Log(ex.Message);
            }

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            try
            {
                if (mTrackableBehaviour.TrackableName == "Imagem1" &&
                    !GameObject.Find("txt2").GetComponent<MeshRenderer>().enabled &&
                    !GameObject.Find("ImageTarget2").GetComponent<DefaultTrackableEventHandler>().enabled
                    )
                {
                    GameObject.Find("txt2").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("ImageTarget2").GetComponent<DefaultTrackableEventHandler>().enabled = true;
                }
                if (mTrackableBehaviour.TrackableName == "imagen2" &&
                    !GameObject.Find("txt3").GetComponent<MeshRenderer>().enabled &&
                    !GameObject.Find("ImageTarget3").GetComponent<DefaultTrackableEventHandler>().enabled
                    )
                {
                    GameObject.Find("txt3").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("ImageTarget3").GetComponent<DefaultTrackableEventHandler>().enabled = true;
                }
                if (mTrackableBehaviour.TrackableName == "imagen4" &&
                    !GameObject.Find("txt4").GetComponent<MeshRenderer>().enabled &&
                    !GameObject.Find("ImageTarget4").GetComponent<DefaultTrackableEventHandler>().enabled
                    )
                {
                    GameObject.Find("txt4").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("ImageTarget4").GetComponent<DefaultTrackableEventHandler>().enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.Log("erro it2");
                Debug.Log(ex);
            }

        }


        private void OnTrackingLost()
        {
          
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

        }

        #endregion // PRIVATE_METHODS
    }
}
