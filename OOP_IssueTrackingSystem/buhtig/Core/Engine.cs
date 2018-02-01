using Buhtig.Interfaces;
using System;

namespace Buhtig.Core
{
    public class Engine : IEngine
    {
        //DI: Decoupling the engine from the concrete Dispatcher class by introducing a dependancy injection.
        //The Engine can now work with any dispatcher type that extends the IDispatcher interface.
        private IDispatcher dispatcher;
        
        //DI: Decoupling the engine from the console by introducing a dependancy injection.
        //Added two fields, renderer and inputHandler, that process user output and input respectively.
        //Both of them are of abstract type, i.e. they can be assigned any type of Renderer/InputHandler through
        //the Engine class constructor.
        private IRenderer renderer;
        private IInputHandler inputHandler;
        
        public Engine(IDispatcher dispatcher, IRenderer renderer, IInputHandler inputHandler)
        {
            this.dispatcher = dispatcher;
            this.renderer = renderer;
            this.inputHandler = inputHandler;
        }

        public Engine(IRenderer renderer, IInputHandler inputHandler)
            : this(new Dispatcher(), renderer, inputHandler)
        {
        }
        
        public void Run()
        {
            while (true)
            {
                string url = this.inputHandler.ReadLine();
                if (url == null)
                {
                    break;
                }
                
                url = url.Trim();

                if (url != string.Empty)
                {
                    try
                    {
                        var endPoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endPoint);
                        this.renderer.WriteLine(viewResult);
                    }
                    catch (InvalidOperationException ex)
                    {
                        this.renderer.WriteLine(ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        this.renderer.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
