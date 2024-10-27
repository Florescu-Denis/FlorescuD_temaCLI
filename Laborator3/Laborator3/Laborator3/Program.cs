using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Laborator3
{
    class Vertex                     //clasa Vertex 
    {
        public Vector3 Position { get; set; }
        public float[] Color { get; set; }

        public Vertex(Vector3 position, float[] color)
        {
            Position = position;
            Color = color;
        }
    }

    class ImmediateMode : GameWindow
    {
        private List<Vertex> triangleVertices = new List<Vertex>(); //lista unde va fi pus fiecare vertex
        
        private bool isMousePressed = false;
        private float lastMouseX;
        private float lastMouseY;
        private float cameraAngleX = 0.0f;
        private float cameraAngleY = 0.0f;
        

        public ImmediateMode() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
           


            LoadTriangleCoords("coords.txt");    //incarc coordonatele din fisier
        }

        private void LoadTriangleCoords(string filename)
        {
            foreach (var line in File.ReadLines(filename))  //citeste fiecare linie
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)         //verific daca linia are 3 coordonate
                {
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    float z = float.Parse(parts[2]);

                    float[] initialColor = { 0.0f, 0.0f, 0.0f };   // culoare initiala
                    triangleVertices.Add(new Vertex(new Vector3(x, y, z), initialColor)); //adaugare in lista
                }
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            isMousePressed = true;
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            if (mouse[MouseButton.Left])
            {

                if (isMousePressed == true)
                {
                    float deltaX = mouse.X - lastMouseX;
                    float deltaY = mouse.Y - lastMouseY;


                    cameraAngleX += deltaX * 0.001f;
                    cameraAngleY += deltaY * 0.001f;


                    lastMouseX = mouse.X;
                    lastMouseY = mouse.Y;
                }
            }
            else
            {
                isMousePressed = false;
                cameraAngleX = 0;
                cameraAngleY = 0;
            }



            foreach (var vertex in triangleVertices)

            {
                
                if (keyboard[Key.R] && !keyboard[Key.ShiftLeft] && triangleVertices.Count > 0)
                    triangleVertices[0].Color[0] = Math.Min(triangleVertices[0].Color[0] + 0.01f, 1.0f); //creste rosu
                
                if (keyboard[Key.G] && !keyboard[Key.ShiftLeft] && triangleVertices.Count > 1)
                    triangleVertices[1].Color[1] = Math.Min(triangleVertices[1].Color[1] + 0.01f, 1.0f); //verde
                
                if (keyboard[Key.B] && !keyboard[Key.ShiftLeft] && triangleVertices.Count > 2)
                    triangleVertices[2].Color[2] = Math.Min(triangleVertices[2].Color[2] + 0.01f, 1.0f); //creste albastru
                

                if (keyboard[Key.ShiftLeft])
                {
                    if (keyboard[Key.R])
                        triangleVertices[0].Color[0] = Math.Max(triangleVertices[0].Color[0] - 0.01f, 0.0f); // scade roșul
                    
                    if (keyboard[Key.G])
                        triangleVertices[1].Color[1] = Math.Max(triangleVertices[1].Color[1] - 0.01f, 0.0f); // scade verdele
                   
                    if (keyboard[Key.B])
                        triangleVertices[2].Color[2] = Math.Max(triangleVertices[2].Color[2] - 0.01f, 0.0f); // scade albastrul
                   
                }
               
            }

        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);



            GL.LineWidth(3);
            GL.Begin(PrimitiveType.Triangles);

            foreach (var vertex in triangleVertices)
            {
                GL.Color3(vertex.Color[0], vertex.Color[1], vertex.Color[2]); // aplic culoarea fiecărui vertex
                GL.Vertex3(vertex.Position); // se deseneaza vertexul in pozitie
            }

            GL.End();
            GL.Rotate(cameraAngleY, 1.0f, 0.0f, 0.0f);
            GL.Rotate(cameraAngleX, 0.0f, 1.0f, 0.0f);
            SwapBuffers();
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
