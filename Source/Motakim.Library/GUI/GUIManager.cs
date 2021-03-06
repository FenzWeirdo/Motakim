using System.Collections.Generic;

namespace Motakim
{
    public sealed class GUIManager
    {
        public List<GUILayer> Layers = new List<GUILayer>();
        public GUILayer Current => (Layers.Count > 0)? Layers[Layers.Count - 1]: null;
        public float Scale = 2f;

        internal void Update()
        {
            if (Current == null) return;
            Current.Update();
        }

        internal void Render()
        {
            foreach (var layer in Layers)
            {
                layer.Render();
            }
        }

        public void Display(GUILayer gui)
        {
            Layers.Add(gui);
            gui.Initialize();
        }

        public void Hide(GUILayer gui)
        {
            gui.Dispose();
            Layers.Remove(gui);
        }
        public void Hide(int index)
        {
            if (Layers.Count <= 0) return;
            Layers[index].Dispose();
            Layers.RemoveAt(index);
        }
        public void HideCurrent()
        {
            if (Layers.Count <= 0) return;
            Layers[Layers.Count - 1].Dispose();
            Layers.RemoveAt(Layers.Count - 1);
        }

        public void Clear()
        {
            foreach (var layer in Layers)
            {
                layer.Dispose();
            }
            Layers.Clear();
        }
    }
}