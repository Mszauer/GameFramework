
#define CHILDDEBUG
#define COMPONENTDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameFramework {
    class GameObject {
        public string Name = null;
        public Point LocalPosition = new Point(0, 0);
        private bool _enabled = false;
        public bool Enabled {
            get {
                return _enabled;
            }
            set {
                if (value != _enabled) {
                    if (value) {
                        OnEnable();
                    }
                    else {
                        OnDisable();
                    }
                }
                _enabled = value;
            }
        }
        public List<GameObject> Children = null;
        public GameObject Parent = null;
        public List<Component> Components = null;
        public GameObject(string name, Point pos, bool enabled, GameObject parent) {
            Name = name;
            LocalPosition = pos;
            Enabled = enabled;
            Parent = parent;
        }

        public void Update(float dTime) {
            if (Enabled) {
                //do self update stuff here
                if (Children != null) {
                    for (int i = Children.Count - 1; i >= 0; i--) {
                        Children[i].Update(dTime);
                    }
                }
            }
            
        }
        public void Render() {
            if (Enabled) {
                //do self render stuff here
                if (Children != null) {
                    for (int i = Children.Count - 1; i >= 0; i--) {
                        Children[i].Render();
                    }
                }
            }
        }

        public void OnEnable() {

        }
        public void OnDisable() {

        }
        public void AddChild(GameObject child) {
            if (Children == null) {
                Children = new List<GameObject>();
            }
            Children.Add(child);
#if CHILDDEBUG
            Console.WriteLine("Added child:" + child.ToString());
            Console.WriteLine("Children Length: " + Children.Count);
#endif
        }
        public void RemoveChild(GameObject child) {
            for (int i = Children.Count - 1; i >= 0; i--) {
                if (Children[i] == child) {
                    Children.RemoveAt(i);
#if CHILDDEBUG
                    Console.WriteLine("Removed child:" + child.ToString() + " at: " + i);
                    Console.WriteLine("Children Length: " + Children.Count);
#endif
                }
            }
        }

        public GameObject FindChild(string child) {
            if (Children == null) {
#if CHILDDEBUG
                Console.WriteLine("Child not found");
#endif
                return null;
            }
            for (int i = Children.Count-1; i >= 0; i--) {
                if (Children[i].Name == child) {
#if CHILDDEBUG
                    Console.WriteLine("Child found at: " + i);
#endif
                    return Children[i];
                }
                else {
                    Children[i].FindChild(child);
                }
            }
#if CHILDDEBUG
            Console.WriteLine("Child not found");
#endif
            return null;
        }
        public void AddComponent(Component component) {
            if (Components == null) {
                Components = new List<Component>();
            }
            Components.Add(component);
#if COMPONENTDEBUG
            Console.WriteLine("Component added: " + component);
            Console.WriteLine("Component Length: " + Components.Count);
#endif
        }
        public void RemoveComponent(Component component) {
            for (int i = Components.Count - 1; i >= 0; i--) {
                if (Components[i] == component) {
                    Components.RemoveAt(i);
#if COMPONENTDEBUG
                    Console.WriteLine("Component removed: " + component);
                    Console.WriteLine("Component Length: " + Components.Count);
#endif
                }
            }
        }
        public Component FindComponent(String component) {
            for (int i = Components.Count - 1; i >= 0; i--) {
                if (Components[i].Name == component) {
#if COMPONENTDEBUG
                    Console.WriteLine("Component Found: " + component + " at: " + i);
#endif
                    return Components[i];
                }
            }
#if COMPONENTDEBUG
            Console.WriteLine("Component not found");
#endif
            return null;
        }
    }
}
