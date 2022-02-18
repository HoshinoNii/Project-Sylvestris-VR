using UnityEngine;

namespace TemplateScripts {
    public class AnimatorBoolControl : MonoBehaviour {
        public string key;

        private Animator Animator => GetComponent<Animator>();
        private int Key => Animator.StringToHash(key);

        public void SetBool(bool value) {
            Animator.SetBool(Key, value);
        }
    }
}