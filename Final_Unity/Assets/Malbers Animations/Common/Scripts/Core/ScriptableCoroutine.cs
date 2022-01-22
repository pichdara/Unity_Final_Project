using System.Collections;
using UnityEngine;


namespace MalbersAnimations
{
    public abstract class ScriptableCoroutine : ScriptableObject
    {
        internal IEnumerator ICoroutine;
        internal MonoBehaviour coroutine;

        protected virtual void OnDisable()
        {
            coroutine = null; //Clean the values
            ICoroutine = null;
        }

        internal virtual void SetCoroutine(GameObject gameObject)
        {
            if (coroutine == null)
            {
                coroutine = gameObject.GetComponent<UnityUtils>(); //Try to find an UnityUtils

                if (coroutine == null)
                {
                    coroutine = gameObject.AddComponent<UnityUtils>(); //Add the UnityUtils Mono to the Renderer so it can have accesss to a Coroutine
                    coroutine.hideFlags = HideFlags.HideInHierarchy;
                }
            }
        }

        /// <summary> Faster way of assigning the coroutine</summary>
        internal virtual void SetCoroutine(MonoBehaviour coroutine) => this.coroutine = coroutine;


        /// <summary> Stop the coroutine in case it exist</summary>
        public virtual void Stop()
        {
            if (ICoroutine != null && coroutine != null)
            {
                coroutine.StopCoroutine(ICoroutine);
            }
        }

        internal void CleanCoroutine()
        {
            ICoroutine = null;
            coroutine = null;
        }


        public virtual void ExitValue() { }

    }
}