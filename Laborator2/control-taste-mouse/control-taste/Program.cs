using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace Laborator2
{
    class ImmediateMode : GameWindow
    {
        float rotationAngle = 0.0f;
        
        private float lastMouseX;
        private float lastMouseY;


        public ImmediateMode() : base(800, 600)
        {
            VSync = VSyncMode.On;
            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";

        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
           
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 1024);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(0, 0, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);


        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
            }

            if (keyboard.IsKeyDown(Key.Left))
            {
                rotationAngle += 0.01f;
            }
            else if (keyboard.IsKeyDown(Key.Right))
            {
                rotationAngle -= 0.01f;
            }
            else
            {
                rotationAngle = 0.0f;
            }
            float deltaX = mouse.X - lastMouseX;
            float deltaY = mouse.Y - lastMouseY;

            rotationAngle += deltaX * 0.01f; 

            
            lastMouseX = mouse.X;
            lastMouseY = mouse.Y;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);



            GL.Rotate(rotationAngle, 0.0f, 0.0f, 1.0f);
            
            DrawAxes();





            SwapBuffers();

        }

        private void DrawAxes()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Red);
            GL.Vertex2(-5.0f, -5.0f); 
            GL.Color3(Color.Yellow);
            GL.Vertex2(-5.0f, 5.0f);  
            GL.Color3(Color.BlueViolet);
            GL.Vertex2(5.0f, 5.0f);    
            GL.Color3(Color.Pink);
            GL.Vertex2(5.0f, -5.0f);
           
            
            GL.End();
        }



        [STAThread]
        static void Main(string[] args)
        {
            using (ImmediateMode example = new ImmediateMode())
            {
                example.Run(30.0, 0.0);
            }
        }
    }

}
