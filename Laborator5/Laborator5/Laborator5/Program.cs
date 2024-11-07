using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

public class Window3D : GameWindow
{
    private Cube cube;

    public Window3D() : base(800, 600)
    {
        VSync = VSyncMode.On;
        cube = new Cube();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.ClearColor(Color.CornflowerBlue);
        GL.Enable(EnableCap.DepthTest);
        GL.DepthFunc(DepthFunction.Less);

    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Width, Height);

        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 1024);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projection);

        Matrix4 camera = Matrix4.LookAt(new Vector3(3, 3, 3), Vector3.Zero, Vector3.UnitY);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref camera);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        
        KeyboardState input = Keyboard.GetState();
        if (input.IsKeyDown(Key.C)) 
        {
            cube.SetRandomColors();
        }
        if (input.IsKeyDown(Key.Escape))
        {
            Exit();
        }
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        cube.Draw();

        SwapBuffers();
    }
  
}
