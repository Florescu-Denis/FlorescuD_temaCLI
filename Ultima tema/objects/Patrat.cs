using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace OpenTK3_StandardTemplate_WinForms.objects
{
    internal class Patrat
    {
        private int textureId;


        public Patrat(string texturePath)
        {
            LoadTexture(texturePath);
            ConfigureLighting();
        }

        private void LoadTexture(string texturePath)
        {
            Bitmap bitmap = new Bitmap(texturePath);

            GL.GenTextures(1, out textureId);
            GL.BindTexture(TextureTarget.Texture2D, textureId);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
        

        private void ConfigureLighting()
        {
        
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

          
            float[] lightColor = { 1.0f, 0.3f, 0.3f, 1.0f }; 
            float[] ambientLight = { 0.6f, 0.2f, 0.2f, 1.0f }; 
            float[] lightPosition = { 0.0f, 0.0f, 10.0f, 1.0f }; 

        
            GL.Light(LightName.Light0, LightParameter.Diffuse, lightColor);
            GL.Light(LightName.Light0, LightParameter.Ambient, ambientLight);
            GL.Light(LightName.Light0, LightParameter.Position, lightPosition);

     
            GL.Enable(EnableCap.Normalize);
        }

        public void Draw()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.PushMatrix();

          
            GL.Translate(0.0f, 0.0f, 8);
         

            float[] materialDiffuse = { 1.0f, 1.0f, 1.0f, 1.0f }; 
            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, materialDiffuse);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.One);
            GL.Enable(EnableCap.Blend);
            GL.Begin(BeginMode.Quads);

           
            GL.Normal3(0.0f, 0.0f, 1.0f); 
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-20, -20);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(20, -20);  
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(20, 20);  
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-20, 20); 

            GL.End();
            GL.Disable(EnableCap.Blend);
            GL.PopMatrix();
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Disable(EnableCap.Texture2D);
        }
    }
}
