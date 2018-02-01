using EnvironmentSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentSystem.Interfaces;
using EnvironmentSystem.Models.Objects;

namespace EnvironmentSystem
{
    public class AdvancedEngine : Engine
    {
        private IController controller;
        private bool isPaused;
        public AdvancedEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, 
            ICollisionHandler collisionHandler, IRenderer renderer, IController controller)
            : base (worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
            this.AttachControllerEvents();
        }
        private void AttachControllerEvents()
        {
            this.controller.Pause += controller_Pause;
        }
        private void controller_Pause(object sender, EventArgs e)
        {
            this.isPaused = !isPaused;
        }
        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();
            if (this.isPaused == false)
            {
                base.ExecuteEnvironmentLoop();    
            }
        }
        protected override void Insert(Models.Objects.EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Advanced engine Insert object.", "Object cannot be null.");
            }
            base.Insert(obj);
        }
    }
}
