using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework {
    class Component {
        GameObject gameObject = null;
        public string Name = null;
        public bool Active = false;
        public virtual void Initialize(string name, GameObject game) {
            Name = name;
            gameObject = game;
        }
        public virtual void OnActivate() {

        }
        public virtual void OnDeactivate() {

        }
        public virtual void Update(float dTime) {

        }
        public virtual void Render() {

        }
        public virtual void Shutdown() {
            Name = null;
            gameObject = null;
            Active = false;
        }
    }
}
